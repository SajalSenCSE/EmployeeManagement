using EmployeeManagement.Database;
using EmployeeManagement.Models;
using EmployeeManagement.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmpManagementDbContext _empManagementDbContext;

        public EmployeeRepository(EmpManagementDbContext empManagementDbContext)
        {
            _empManagementDbContext = empManagementDbContext;
        }

        private async Task<bool> Save()
        {
            return await _empManagementDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            _empManagementDbContext.Employees.Add(employee);
            return await Save();

        }

        public async Task<bool> DeleteEmployee(Employee employee)
        {
            _empManagementDbContext.Employees.Remove(employee);
            return await Save();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await _empManagementDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _empManagementDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> EditEmployee(Employee employee)
        {
            _empManagementDbContext.Employees.Update(employee);

            return await Save();
        }
    }
}
