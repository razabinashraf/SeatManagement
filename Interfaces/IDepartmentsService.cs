// IDepartmentsService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;

public interface IDepartmentsService
{
    IEnumerable<Department> GetDepartments();
    Department GetDepartment(int id);
    Department PostDepartment(DepartmentDTO departmentDTO);
}
