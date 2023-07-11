using System.ComponentModel.DataAnnotations;

namespace BlazorServerApp.Data
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        

        public string LeaveType { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }


        public string Status { get; set; }

        public int NoofDays { get; set; }
        public bool SDtype { get; set; } = false;

        public bool EDtype { get; set; } = false;

    }
}
