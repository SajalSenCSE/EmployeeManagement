using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Abstractions
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> GelAllEmployees();
        public Task<bool> AddEmployee(Employee employee);
        public Task<Employee> GetById(int id);
        public Task<bool> DeleteEmployee(Employee employee);
        public Task<bool> UpdateEmployee(Employee employee);
    }
}
