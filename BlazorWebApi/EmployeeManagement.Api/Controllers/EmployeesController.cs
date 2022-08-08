using EmployeeManagement.Api.Repositories.Abstracts;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                return Ok(await employeeRepository.GetEmployees());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while retrieving data from the database");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var result = await employeeRepository.GetEmployee(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest();
                var createEmployee = await employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = createEmployee.EmployeeId }, createEmployee);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest, "Error when adding data to the database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.EmployeeId)
                    return BadRequest();
                var updateEmployee = await employeeRepository.GetEmployee(id);
                if (updateEmployee == null)
                    return NotFound($"Employee with id = {id} not found");
                return Ok(await employeeRepository.UpdateEmployee(employee));

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when upating data");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var deleteEmployee = await employeeRepository.GetEmployee(id);
                if (deleteEmployee == null)
                    return NotFound($"Employee with id = {id} not found");
                return Ok(await employeeRepository.DeleteEmployee(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when deleting data from the database");
            }
        }
    }
}
