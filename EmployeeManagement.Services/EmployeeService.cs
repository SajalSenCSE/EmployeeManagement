using EmployeeManagement.Models;
using EmployeeManagement.Repository.Abstractions;
using EmployeeManagement.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<bool> AddEmployee(Employee employee)
        {
           return _employeeRepository.AddEmployee(employee);
        }

        public Task<bool> DeleteEmployee(Employee employee)
        {
            return _employeeRepository.DeleteEmployee(employee);
        }

        public Task<IEnumerable<Employee>> GelAllEmployees()
        {
            return _employeeRepository.GetAllEmployee();
        }

        public Task<Employee> GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public Task<bool> UpdateEmployee(Employee employee)
        {
            return _employeeRepository.EditEmployee(employee);
        }
            
    }
}
