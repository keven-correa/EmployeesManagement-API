using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAPI.Entities
{
    public class Department
    {
        [Required]
        public int Id { get; set; }

        public string DepartmentName { get; set; }

        public string DepartmentDescription { get; set; }

        public List<Employees> Employees { get; set; }
    }
}
