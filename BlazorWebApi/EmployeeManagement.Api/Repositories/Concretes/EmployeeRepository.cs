using EmployeeManagement.Api.Data;
using EmployeeManagement.Api.Repositories.Abstracts;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Repositories.Concretes
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return result.Entity;

        }

        public async void DeleteEmployee(int employeeId)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            if (result != null)
            {
                _context.Employees.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);
            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.DepartmentId = employee.DepartmentId;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
