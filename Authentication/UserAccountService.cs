using BlazorServerApp.Data;
using Microsoft.Data.SqlClient;
using BlazorServerApp.Authentication;
using BlazorServerApp.Services;
using Microsoft.Extensions.Configuration;
using BlazorServerApp.Authentication;

using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace BlazorServerApp.Authentication
{
    public class UserAccountService
    {
        private readonly string _connectionString;

        public UserAccountService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

       

        public UserAccount? GetByUserName(string userName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT UserName, Password, Role FROM UserAccounts WHERE UserName = @UserName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", userName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string password = reader.GetString(1);
                            string role = reader.GetString(2);

                            return new UserAccount
                            {
                                UserName = userName,
                                Password = password,
                                Role = role
                            };
                        }
                    }
                }
            }

            return null;
        }

        public async Task<List<UserAccount>> GetAllUsers()
        {
            List<UserAccount> useraccounts = new List<UserAccount>();

           
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM UserAccounts WHERE Role='User'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            UserAccount useraccount = new UserAccount
                            {
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                Password= reader.GetString(reader.GetOrdinal("Password")),
                                Role = reader.GetString(reader.GetOrdinal("Role")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                LeaveLeft = reader.GetInt32(reader.GetOrdinal("LeaveLeft")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),



                            };

                            useraccounts.Add(useraccount);
                        }
                    }
                }
            }

            return useraccounts;
        }
    }
}
