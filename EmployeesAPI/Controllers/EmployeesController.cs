using EmployeesAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Employees>> GetAllEmployyes()
        {

            return await _context.Employees.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(i => i.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id,[FromBody] Employees employees)
        {
            if(id != employees.Id)
            {
                return BadRequest();
            }
            _context.Entry(employees).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee([FromBody] Employees employees)
        {
            _context.Employees.Add(employees);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllEmployyes), new { id = employees.Id }, employees);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee (int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(i => i.Id == id);
            if(employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
