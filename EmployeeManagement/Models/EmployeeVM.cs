using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }
        public string EmpAddress { get; set; }
        public string EmpPhone { get; set; }
    }
}
