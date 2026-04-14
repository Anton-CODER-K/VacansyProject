using CheckNumberPhoneAPI.Repositories;
using CheckNumberPhoneAPI.Services.Result;
using PhoneNumbers;
using System.Numerics;
using System.Text.RegularExpressions;

namespace CheckNumberPhoneAPI.Services
{
    public class NumberService
    {
        private readonly NumberRepository _numberRepo;

        public NumberService(NumberRepository numberRepository)
        {
            _numberRepo = numberRepository;
        }
        public async Task<(NumberResult result, string? number)> AddNumberAsync(string input)
        {
            var number = CheckNumber(input);
            if (number == null)
            {
                return (NumberResult.Invalid, null);
            }

            var rows = await _numberRepo.InsertNumberAsync(number);

            if (rows == 0)
            {
                return (NumberResult.AlreadyExists, null);
            }

            return (NumberResult.Success, number);

        }

        private string? CheckNumber(string numberInput)
        {
            var phoneUtil = PhoneNumberUtil.GetInstance();

            if (string.IsNullOrWhiteSpace(numberInput))
                return null;

            try
            {
                numberInput = numberInput.Trim();

                var cleaned = Regex.Replace(numberInput, @"[^\d\+]", "");

                if (cleaned.StartsWith("+") && !cleaned.StartsWith("+1"))
                {
                    var digitsOnly = cleaned.Substring(1);

                    if (digitsOnly.Length == 10)
                    {
                        cleaned = "+1" + digitsOnly;
                    }
                }

                if (!cleaned.StartsWith("+") && cleaned.Length == 10)
                {
                    cleaned = "+1" + cleaned;
                }

                var parsed = phoneUtil.Parse(cleaned, null);

                if (!phoneUtil.IsValidNumber(parsed))
                    return null;

                if (parsed.CountryCode != 1)
                    return null;

                var region = phoneUtil.GetRegionCodeForNumber(parsed);
                if (region != "US")
                    return null;

                return phoneUtil.Format(parsed, PhoneNumberFormat.E164);
            }
            catch
            {
                return null;
            }
        }
    }
}
