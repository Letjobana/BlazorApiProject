using EmployeeManagement.Api.Repositories.Abstracts;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web
{
    public class BaseEmployeeDetails : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        public  IEmployeeService EmployeeService { get; set; }
    }
}
