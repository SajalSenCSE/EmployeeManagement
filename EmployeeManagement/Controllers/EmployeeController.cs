using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        IEmployeeService _employeeService;
        IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService,IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        public string Index()   //api/Employee 
        {
            return "Hi Sajal Test";
        }


        [HttpPost("Add")]  ////api/Employee/Add  ,row Data
        public async Task<IActionResult> AddEmployee(EmployeeVM vm)
        {
            var newlyAddableEmployee = _mapper.Map<Employee>(vm);

            bool result =await _employeeService.AddEmployee(newlyAddableEmployee);
            if (result)
                return Ok();

            return BadRequest("Another Problem Occurces");
        }

        [HttpGet("GetAllEMmp")]   /////api/Employee/GetAllEMmp
        public async Task<IActionResult> GetEmployees()
        {
            var employees =await  _employeeService.GelAllEmployees();
            var resultedEmployeesVM = _mapper.Map<IEnumerable<EmployeeVM>>(employees);
            return Ok(resultedEmployeesVM);
        }

        [HttpGet("AnEmployee/{id}")]   /////api/Employee/AnEmployee/1
        public async Task<IActionResult> GetbyId(int? id)
        {
            if (id == null)
                return BadRequest("Provide Valid Id");
            var anEmployee =await _employeeService.GetById((int)id);
            if (anEmployee == null)
                return BadRequest();
            var anEmployeeVM = _mapper.Map<EmployeeVM>(anEmployee);

            return Ok(anEmployeeVM);
        }

        [HttpDelete("Delete/{id}")]    /////api/Employee/Delete/1

        public async Task<IActionResult> DeleteEmployee(int? id)
        {
            if (id == null)
                return BadRequest("Provide Valid Id");
            var deletedEmployee =await _employeeService.GetById((int)id);
            if (deletedEmployee == null)
                return BadRequest("no Employee in database that have to delete");

            bool result =await _employeeService.DeleteEmployee(deletedEmployee);
            if (result)
                return Ok(deletedEmployee);

            return BadRequest("Some Unkhown error occurces");
        }

        [HttpPost("Update/{id}")]        /////api/Employee/Update/1  ,Data
        public async Task<IActionResult> Edit(int? id,EmployeeVM Vm)
        {
            if (id == null)
                return BadRequest("Provide and id");
            var anEmployee =await _employeeService.GetById((int)id);
            if (anEmployee == null)
                return BadRequest("Not Faound");

            _mapper.Map(Vm,anEmployee);
            bool result =await _employeeService.UpdateEmployee(_mapper.Map(Vm, anEmployee));
            if (result)
            {
                return Ok("Data updated sucess fully");
            }

            return NotFound();

        }
    }
}
