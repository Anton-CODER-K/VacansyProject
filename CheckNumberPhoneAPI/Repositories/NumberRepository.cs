using Npgsql;

namespace CheckNumberPhoneAPI.Repositories
{
    public class NumberRepository
    {
        private readonly string _connectionString;

        public NumberRepository(string connectionString) 
        {
            _connectionString = connectionString;
        }

        public async Task<int> InsertNumberAsync(string number)
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            const string sql = """
                Insert Into phone_numbers (phone_number) 
                Values (@number)
                On Conflict (phone_number) Do Nothing
                """;

            var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.Add("number", NpgsqlTypes.NpgsqlDbType.Varchar).Value = number;

            return await cmd.ExecuteNonQueryAsync();
        }
    }
}
