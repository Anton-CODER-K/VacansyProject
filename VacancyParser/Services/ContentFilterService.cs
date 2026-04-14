using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VacancyParser.Models;

namespace VacancyParser.Services
{
    public class ContentFilterService
    {
        private readonly List<string> _blockedWords;

        public ContentFilterService()
        {
            var basePath = AppContext.BaseDirectory;

            var path = Path.Combine(basePath, "config", "config.json");

            var json = File.ReadAllText(path);
            var config = JsonSerializer.Deserialize<FilterConfig>(json);

            _blockedWords = config?.BlockedWords ?? new List<string>();
        }

        public bool ContainsBlockedWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            text = text.ToLower();

            return _blockedWords.Any(word => text.Contains(word));
        }
    }
}
