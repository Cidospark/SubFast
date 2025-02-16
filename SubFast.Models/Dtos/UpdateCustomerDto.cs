using System.Reflection;

namespace SubFast.Models.Dtos
{
    public class UpdateCustomerDto
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhotoPath { get; set; } = "";
        public DateTime DateOfBrith { get; set; }
        public Gender Gender { get; set; }
    }
}
