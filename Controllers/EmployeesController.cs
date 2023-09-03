using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Models;

namespace SeatManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepository<Employee> _repository;

        public EmployeesController(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return _repository.GetAll();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = _repository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(Employee employee)
        {
            var item = _repository.GetById(employee.Id);
            if (item == null)
            {
                return NotFound();
            }
            item.Name = employee.Name;
            item.Department = employee.Department;
            // Add any other properties you need to update
            _repository.Update(item);
            return Ok();
        }

        [Route("bulkadd")]
        [HttpPost]
        public async Task<ActionResult<Seat>> PostSeats(EmployeeDTO[] employeeDTOs)
        {

            foreach (var em in employeeDTOs)
            {
                Employee employee = new Employee();
                employee.Name = em.Name;
                employee.DepartmentId = em.DepartmentId;
                _repository.Add(employee);
            }
            return NoContent();

        }


        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeeDTO employeeDTO)
        {
            var employee = new Employee
            {
                Name = employeeDTO.Name,
                DepartmentId = employeeDTO.DepartmentId,
                // Add any other properties you need to set
            };
            _repository.Add(employee);

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = _repository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            _repository.Delete(id);

            return NoContent();
        }
    }
}
