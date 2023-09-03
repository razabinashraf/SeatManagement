using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Models;

namespace SeatManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IRepository<Department> _repository;

        public DepartmentsController(IRepository<Department> repository)
        {
            _repository = repository;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartment()
        {
            return _repository.GetAll();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = _repository.GetById(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(Department department)
        {
            var item = _repository.GetById(department.Id);
            if (item == null)
            {
                return NotFound();
            }
            item.Name = department.Name;
            // Add any other properties you need to update
            _repository.Update(item);
            return Ok();
        }

        // POST: api/Departments
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(DepartmentDTO departmentDTO)
        {
            var department = new Department
            {
                Name = departmentDTO.Name,
                // Add any other properties you need to set
            };
            _repository.Add(department);

            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = _repository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }

            _repository.Delete(id);

            return NoContent();
        }
    }
}
