// EmployeesController.cs
using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Models;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeesService _employeesService;

    public EmployeesController(IEmployeesService employeesService)
    {
        _employeesService = employeesService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetEmployee()
    {
        return Ok(_employeesService.GetEmployees());
    }

    [HttpGet("{id}")]
    public ActionResult<Employee> GetEmployee(int id)
    {
        var employee = _employeesService.GetEmployee(id);

        if (employee == null)
        {
            return NotFound();
        }

        return employee;
    }

    [HttpPut("{id}")]
    public IActionResult PutEmployee(Employee employee)
    {
        _employeesService.PutEmployee(employee);
        return Ok();
    }

    [HttpPost]
    public ActionResult<Employee> PostEmployee(EmployeeDTO[] employeeDTO)
    {
        _employeesService.PostEmployees(employeeDTO);

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        _employeesService.DeleteEmployee(id);
        return NoContent();
    }
}
