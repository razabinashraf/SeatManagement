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

    public void PutDepartment(Department department)
    {
        var item = _repository.GetById(department.Id);
        if (item == null)
        {
            return;
        }
        // Update any properties of Department as needed
        item.Name = department.Name;
        // Add any other properties you need to update
        _repository.Update(item);
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

    public void DeleteDepartment(int id)
    {
        var department = _repository.GetById(id);
        if (department == null)
        {
            return;
        }
        _repository.Delete(id);
    }
}
