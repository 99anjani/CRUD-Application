using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using crud_app.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace crud_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _employeeContext;
        public EmployeeController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            if (_employeeContext.Employees == null)
            {
                return NotFound();
            }

            return await _employeeContext.Employees.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployees(int id)
        {
            if (_employeeContext.Employees == null)
            {
                return NotFound();
            }
            var employee = await _employeeContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }
        
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _employeeContext.Employees.Add(employee);
            await _employeeContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployees), new { id = employee.Id }, employee);
        }

       

        /*
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            try
            {
                // Validate the incoming Employee object
                if (employee == null)
                {
                    return BadRequest("Employee data is missing or invalid.");
                }

                // Add the employee to the context
                _employeeContext.Employees.Add(employee);

                // Save changes to the database
                await _employeeContext.SaveChangesAsync();

                // Return the newly created employee with a CreatedAtAction response
                return CreatedAtAction(nameof(GetEmployees), new { id = employee.Id }, employee);
            }
            catch (Exception ex)
            {
                // If an exception occurs during the operation, return a 500 Internal Server Error
                // and log the error for further investigation.
                // Make sure you have appropriate logging in place for production scenarios.
                // For demonstration purposes, here's a simple logging example:
                Console.WriteLine($"Error while creating employee: {ex}");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        */
        [HttpPut("{id}")]
        public async Task<ActionResult> PutEmployee(int id , Employee employee)
        {
            if(id != employee.Id)
            {
                return BadRequest();
            }
            _employeeContext.Entry(employee).State = EntityState.Modified;
            try
            {
                await _employeeContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok(); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            if (_employeeContext.Employees == null)
            { 
                return NotFound();
            }
            var employee = await _employeeContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _employeeContext.Employees.Remove(employee);
            await _employeeContext.SaveChangesAsync();

            return Ok();
        }



    }
}
