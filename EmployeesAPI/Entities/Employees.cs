using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAPI.Entities
{
    public class Employees
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfJoin { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
