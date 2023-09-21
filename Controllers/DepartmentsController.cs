// DepartmentsController.cs
using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Models;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentsService _departmentsService;

    public DepartmentsController(IDepartmentsService departmentsService)
    {
        _departmentsService = departmentsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Department>> GetDepartment()
    {
        return Ok(_departmentsService.GetDepartments());
    }

    [HttpGet("{id}")]
    public ActionResult<Department> GetDepartment(int id)
    {
        var department = _departmentsService.GetDepartment(id);

        if (department == null)
        {
            return NotFound();
        }

        return department;
    }


    [HttpPost]
    public ActionResult<Department> PostDepartment(DepartmentDTO departmentDTO)
    {
        var department = _departmentsService.PostDepartment(departmentDTO);

        return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
    }

}
