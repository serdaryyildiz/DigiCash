using DigiCash.Models;
using Npgsql;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DigiCash.Services
{
    public class BalanceServices
    {
        private readonly string _connectionString;

        public BalanceServices(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<double> GetBalanceAsync(string walletId)
        {
            double balance = 0;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand("SELECT balance FROM wallets WHERE walletId = @walletId", connection))
                {
                    command.Parameters.AddWithValue("walletId", walletId);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            balance = Convert.ToDouble(reader["balance"]);
                        }
                    }
                }
            }
            return balance;
        }
    }
}
