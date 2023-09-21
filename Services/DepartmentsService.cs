// DepartmentsService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;
using SeatManagement;

public class DepartmentsService : IDepartmentsService
{
    private readonly IRepository<Department> _repository;

    public DepartmentsService(IRepository<Department> repository)
    {
        _repository = repository;
    }

    public IEnumerable<Department> GetDepartments()
    {
        return _repository.GetAll();
    }

    public Department GetDepartment(int id)
    {
        var department = _repository.GetById(id);
        return department;
    }

    public Department PostDepartment(DepartmentDTO departmentDTO)
    {
        var department = new Department
        {
            Name = departmentDTO.Name,
            // Add any other properties you need to set
        };
        _repository.Add(department);
        return department;
    }

}
