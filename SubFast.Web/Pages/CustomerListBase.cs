using Microsoft.AspNetCore.Components;
using SubFast.Models;

namespace SubFast.Web.Pages
{
    public class CustomerListBase : ComponentBase
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(LoadCustomers);
        }

        protected void LoadCustomers()
        {
            System.Threading.Thread.Sleep(5000);
            Customers = new List<Customer>
            {
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "John",
                    LastName = "Hastings",
                    Email = "David@pragimtech.com",
                    DateOfBrith = new DateTime(1980, 10, 5),
                    Gender = Gender.Male,
                    //Department = new Department { DepartmentId = 1, DepartmentName = "IT" },
                    PhotoPath = "images/john.png"
                },

                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Sam",
                    LastName = "Galloway",
                    Email = "Sam@pragimtech.com",
                    DateOfBrith = new DateTime(1981, 12, 22),
                    Gender = Gender.Male,
                    //Department = new Department { DepartmentId = 2, DepartmentName = "HR" },
                    PhotoPath = "images/sam.jpeg"
                },

                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Mary",
                    LastName = "Smith",
                    Email = "mary@pragimtech.com",
                    DateOfBrith = new DateTime(1979, 11, 11),
                    Gender = Gender.Female,
                    //Department = new Department { DepartmentId = 1, DepartmentName = "IT" },
                    PhotoPath = "images/mary.png"
                }
            };
        }
    }
}
