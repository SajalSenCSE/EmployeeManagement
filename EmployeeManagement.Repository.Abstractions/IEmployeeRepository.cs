using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.Abstractions
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetAllEmployee();
        public Task<bool> AddEmployee(Employee employee);
        public Task<Employee> GetById(int id);
        public Task<bool> DeleteEmployee(Employee employee);
        public Task<bool> EditEmployee(Employee employee);
    }
}
