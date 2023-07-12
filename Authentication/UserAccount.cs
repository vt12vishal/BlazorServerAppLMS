using System.ComponentModel.DataAnnotations;

namespace BlazorServerApp.Authentication
{
    public class UserAccount
    {

        [Key]
        public string UserName { get; set; }

        public string Password { get; set; }
        public string Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int LeaveLeft { get; set; }


        public string Email { get; set; }
    }
}
