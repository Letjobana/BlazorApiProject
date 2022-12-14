using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Web
{
    public class BaseEmployeeList : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }
        protected override Task OnInitializedAsync()
        {
            LoadEmployee();
            return base.OnInitializedAsync();
        }
        private void LoadEmployee()
        {
            Employee e = new Employee
            {
                EmployeeId = 1,
                FirstName = "Suzan",
                LastName = "Masite",
                Email = "mahlodimasite@gmail.com",
                DateOfBirth = new DateTime(1990, 01, 01),
                Gender = Gender.Female,

            };
            Employee e1 = new Employee
            {
                EmployeeId = 2,
                FirstName = "John",
                LastName = "Smith",
                Email = "john@gmail.com",
                DateOfBirth = new DateTime(1990, 01, 03),
                Gender = Gender.Female,

            };
            Employees = new List<Employee>
            {
                e,e1
            };
        }
    }
}
