using DigiCash.Models;
using Microsoft.Extensions.Options;
using Npgsql;

namespace DigiCash.Services
{
    public class PostgreSqlServices
    {
        private NpgsqlConnection connection;

        public PostgreSqlServices(IOptions<PostgreDbSettings> postgreDbSettings)
        {
            string connectionString = postgreDbSettings.Value.ConnectionString;
            connection = new NpgsqlConnection(connectionString);
        }

        public void AddUser(User user)
        {
            string query = "INSERT INTO users (username, email) VALUES (@username, @email)";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TcKimlikNo", user.TcKimlikNo);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddWallet(string userId, Wallet wallet)
        {
            //kullanıcıya yeni bir cüzdan oluşturur
            using (connection)
            {
                string query = "INSERT INTO wallets (userId, balance) VALUES (@userId, @balance)";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@balance", wallet.Balance);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteWallet(string walletId)
        {
            //kullanıcının istediği wallet ı silmesini sağlar
            string query = "DELETE FROM \"Wallets\" WHERE walletId = @walletId";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@walletId", walletId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close(); 
            }
            
        }
        public async Task<Wallet> GetWallet(string id)
        {
            Wallet wallet = new Wallet();           //entity list kullanılmalı datatable çok kullanılmaz
            Console.WriteLine("ben çalıştım1");
            await connection.OpenAsync();
            Console.WriteLine("ben çalıştım2");
            using (var cmd = new NpgsqlCommand("SELECT * FROM \"Wallets\" WHERE \"walletid\" = @walletid", connection))
            {
                Console.WriteLine("ben çalıştım3");
                cmd.Parameters.AddWithValue("walletid", id);
                Console.WriteLine("ben çalıştım4");
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    Console.WriteLine("ben çalıştım5");
                        
                    while (await reader.ReadAsync())
                    {
                        string tc = reader.GetString(reader.GetOrdinal("tc"));
                        string walletid = reader.GetString(reader.GetOrdinal("walletid"));
                        double balance = reader.GetDouble(reader.GetOrdinal("balance"));
                        string currency = reader.GetString(reader.GetOrdinal("currency"));
                        wallet.Balance = balance;
                        wallet.Currency = currency;
                        wallet.TC = tc;
                        wallet.Id = walletid;
                    }
                }
            }
            await connection.CloseAsync();

            return wallet;
        }

        public async void SetBalance(double balance,string walletid)
        {
            await connection.OpenAsync();
            using var cmd = new NpgsqlCommand("UPDATE \"Wallets\" SET \"balance\" = @newBalance WHERE \"walletid\" = @walletid", connection);
            cmd.Parameters.AddWithValue("newBalance", balance); // new balance
            cmd.Parameters.AddWithValue("walletid", walletid); // wallet to make change on

            cmd.ExecuteNonQuery();
            await connection.CloseAsync();
        }
    }
}

