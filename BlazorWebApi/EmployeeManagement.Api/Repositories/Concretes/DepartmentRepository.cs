using EmployeeManagement.Api.Data;
using EmployeeManagement.Api.Repositories.Abstracts;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Repositories.Concretes
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Department> GetDepartment(int departmentId)
        {
            return await _context.Departments.FirstOrDefaultAsync(x => x.DepartmentId == departmentId);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }
    }
}
