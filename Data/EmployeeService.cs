using BlazorServerApp.Data;
using Microsoft.Data.SqlClient;
using BlazorServerApp.Authentication;
using Microsoft.Extensions.Configuration;


namespace BlazorServerApp.Data
{
    public class EmployeeService
    {


        private readonly string _connectionString;

        public EmployeeService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Get Employee List
        public async Task<List<Employee>> GetAllEmployeesP()
        {
            List<Employee> employees = new List<Employee>();

          
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Employees WHERE Status='Pending'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Employee employee = new Employee
                            {
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                LeaveType = reader.GetString(reader.GetOrdinal("LeaveType")),
                                StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                                NoofDays = reader.GetInt32(reader.GetOrdinal("NoofDays")),
                                Status = reader.GetString(reader.GetOrdinal("Status")),
                                SDtype = reader.GetBoolean(reader.GetOrdinal("SDtype")),
                                EDtype = reader.GetBoolean(reader.GetOrdinal("EDtype")),

                            };

                            employees.Add(employee);
                        }
                    }
                }
            }

            return employees;
        }
        public async Task<List<Employee>> GetAllEmployeesA()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Employees WHERE Status='Approved' OR Status='Rejected'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Employee employee = new Employee
                            {
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                LeaveType = reader.GetString(reader.GetOrdinal("LeaveType")),
                                StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                                NoofDays = reader.GetInt32(reader.GetOrdinal("NoofDays")),
                                Status = reader.GetString(reader.GetOrdinal("Status")),
                                SDtype = reader.GetBoolean(reader.GetOrdinal("SDtype")),
                                EDtype = reader.GetBoolean(reader.GetOrdinal("EDtype")),



                            };

                            employees.Add(employee);
                        }
                    }
                }
            }

            return employees;
        }
        // Get Employee Record by Id
        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee employee = null;

            string _connectionString = "Server=MSI\\SQLEXPRESS02;Database=Blazor;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Employees WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            employee = new Employee
                            {
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                LeaveType = reader.GetString(reader.GetOrdinal("LeaveType")),
                                StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                                NoofDays = reader.GetInt32(reader.GetOrdinal("NoofDays")),
                                Status = reader.GetString(reader.GetOrdinal("Status")),
                                SDtype = reader.GetBoolean(reader.GetOrdinal("SDtype")),
                                EDtype = reader.GetBoolean(reader.GetOrdinal("EDtype")),
                            };
                        }
                    }
                }
            }

            return employee;
        }
        public async Task<List<Employee>> GetEmployeeByUserNameP(string username)
        {
            List<Employee> employees = new List<Employee>();

            string _connectionString = "Server=MSI\\SQLEXPRESS02;Database=Blazor;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Employees WHERE UserName = @UserName and Status='Pending'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Employee employee = new Employee
                            {
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                LeaveType = reader.GetString(reader.GetOrdinal("LeaveType")),
                                StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                                NoofDays = reader.GetInt32(reader.GetOrdinal("NoofDays")),
                                Status = reader.GetString(reader.GetOrdinal("Status")),
                                SDtype = reader.GetBoolean(reader.GetOrdinal("SDtype")),
                                EDtype = reader.GetBoolean(reader.GetOrdinal("EDtype")),


                            };

                            employees.Add(employee);
                        }
                    }
                }
            }

            return employees;
        }
        public async Task<List<Employee>> GetEmployeeByUserNameA(string username)
        {
            List<Employee> employees = new List<Employee>();

            string _connectionString = "Server=MSI\\SQLEXPRESS02;Database=Blazor;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Employees WHERE UserName = @UserName AND (Status='Approved' OR Status='Rejected')";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Employee employee = new Employee
                            {
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                LeaveType = reader.GetString(reader.GetOrdinal("LeaveType")),
                                StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                                NoofDays = reader.GetInt32(reader.GetOrdinal("NoofDays")),
                                Status = reader.GetString(reader.GetOrdinal("Status")),
                                SDtype = reader.GetBoolean(reader.GetOrdinal("SDtype")),
                                EDtype = reader.GetBoolean(reader.GetOrdinal("EDtype")),




                            };

                            employees.Add(employee);
                        }
                    }
                }
            }

            return employees;
        }
    }
}
