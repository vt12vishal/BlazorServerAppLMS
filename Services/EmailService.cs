using BlazorServerApp.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BlazorServerApp.Services
{
    public class EmailService
    {

        private readonly string connectionString;

        public EmailService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task SendMailApproveAsync(string toEmail, string status,int id)
        {
            string fromMail = "vt12vishal@gmail.com";
            string fromPassword = "mszmijfrxcsaztkl";

            
            

            DateTime startDate=DateTime.Now;
            DateTime endDate=DateTime.Now;
            string leaveType="";
            string firstName="";
            string lastName = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT StartDate, EndDate, LeaveType, FirstName, LastName FROM Employees WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {

                            startDate = reader.GetDateTime(0);
                            endDate = reader.GetDateTime(1);
                            leaveType = reader.GetString(2);
                            firstName = reader.GetString(3);
                            lastName = reader.GetString(4);
                        }
                    }
                }
            }

            string body = $@"
            <html>
            <head>
                <style>
                    body {{
                        font-family: Arial, sans-serif;
                    }}
                    .container {{
                        padding: 20px;
                        border: 1px solid #ccc;
                        border-radius: 5px;
                    }}
                    h1 {{
                        color: #555;
                    }}
                    table {{
                        border-collapse: collapse;
                        width: 100%;
                    }}
                    th, td {{
                        padding: 8px;
                        text-align: left;
                        border-bottom: 1px solid #ddd;
                    }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <h1>Your Application Status</h1>
                    <table>
                        <tr>
                            <th>Leave Id:</th>
                            <td>{id}</td>
                        </tr>
                        <tr>
                            <th>Status:</th>
                            <td>{status}</td>
                        </tr>
                        <tr>
                            <th>First Name:</th>
                            <td>{firstName}</td>
                        </tr>
                        <tr>
                            <th>Last Name:</th>
                            <td>{lastName}</td>
                        </tr>
                        <tr>
                            <th>Start Date:</th>
                            <td>{startDate}</td>
                        </tr>
                        <tr>
                            <th>End Date:</th>
                            <td>{endDate}</td>
                        </tr>
                        <tr>
                            <th>Leave Type:</th>
                            <td>{leaveType}</td>
                        </tr>
                        
                    </table>
                </div>
            </body>
            </html>";

            // Create and send the email message
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Test Subject";
            message.To.Add(new MailAddress(toEmail));
            message.Body = body;
            message.IsBodyHtml = true;
            using (var smtpClient = new SmtpClient("smtp.gmail.com"))
            {
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(fromMail, fromPassword);
                smtpClient.EnableSsl = true;

                try
                {
                    await smtpClient.SendMailAsync(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error sending email: " + ex.Message);
                    // Handle the exception as per your requirements
                }
            }

        }
        public async Task SendMailRejectAsync(string toEmail, string status, int id,string reason)
        {
            string fromMail = "vt12vishal@gmail.com";
            string fromPassword = "mszmijfrxcsaztkl";

            


            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            string leaveType = "";
            string firstName = "";
            string lastName = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT StartDate, EndDate, LeaveType, FirstName, LastName FROM Employees WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {

                            startDate = reader.GetDateTime(0);
                            endDate = reader.GetDateTime(1);
                            leaveType = reader.GetString(2);
                            firstName = reader.GetString(3);
                            lastName = reader.GetString(4);
                        }
                    }
                }
            }

            string body = $@"
            <html>
            <head>
                <style>
                    body {{
                        font-family: Arial, sans-serif;
                    }}
                    .container {{
                        padding: 20px;
                        border: 1px solid #ccc;
                        border-radius: 5px;
                    }}
                    h1 {{
                        color: #555;
                    }}
                    table {{
                        border-collapse: collapse;
                        width: 100%;
                    }}
                    th, td {{
                        padding: 8px;
                        text-align: left;
                        border-bottom: 1px solid #ddd;
                    }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <h1>Your Application Status</h1>
                    <table>
                         <tr>
                            <th>Leave Id:</th>
                            <td>{id}</td>
                        </tr>
                        <tr>
                            <th>Status:</th>
                            <td>{status}</td>
                        </tr>
                         <tr>
                            <th>First Name:</th>
                            <td>{firstName}</td>
                        </tr>
                        <tr>
                            <th>Last Name:</th>
                            <td>{lastName}</td>
                        </tr>
                        <tr>
                            <th>Start Date:</th>
                            <td>{startDate}</td>
                        </tr>
                        <tr>
                            <th>End Date:</th>
                            <td>{endDate}</td>
                        </tr>
                        <tr>
                            <th>Leave Type:</th>
                            <td>{leaveType}</td>
                        </tr>
                       
                        <tr>
                            <th>Reason:</th>
                            <td>{reason}</td>
                        </tr>


                    </table>
                </div>
            </body>
            </html>";

            // Create and send the email message
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Test Subject";
            message.To.Add(new MailAddress(toEmail));
            message.Body = body;
            message.IsBodyHtml = true;
            using (var smtpClient = new SmtpClient("smtp.gmail.com"))
            {
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(fromMail, fromPassword);
                smtpClient.EnableSsl = true;

                try
                {
                    await smtpClient.SendMailAsync(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error sending email: " + ex.Message);
                    // Handle the exception as per your requirements
                }
            }

        }
    }
}
