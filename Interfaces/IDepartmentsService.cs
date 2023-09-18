// IDepartmentsService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;

public interface IDepartmentsService
{
    IEnumerable<Department> GetDepartments();
    Department GetDepartment(int id);
    void PutDepartment(Department department);
    Department PostDepartment(DepartmentDTO departmentDTO);
    void DeleteDepartment(int id);
}
