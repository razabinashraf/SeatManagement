// EmployeesService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;
using SeatManagement;

public class EmployeesService : IEmployeesService
{
    private readonly IRepository<Employee> _repository;

    public EmployeesService(IRepository<Employee> repository)
    {
        _repository = repository;
    }

    public IEnumerable<Employee> GetEmployees()
    {
        return _repository.GetAll();
    }

    public Employee GetEmployee(int id)
    {
        var employee = _repository.GetById(id);
        return employee;
    }

    public void PutEmployee(Employee employee)
    {
        var item = _repository.GetById(employee.Id);
        if (item == null)
        {
            return;
        }
        // Update any properties of Employee as needed
        item.Name = employee.Name;
        item.Department = employee.Department;
        // Add any other properties you need to update
        _repository.Update(item);
    }

    public void DeleteEmployee(int id)
    {
        var employee = _repository.GetById(id);
        if (employee == null)
        {
            return;
        }
        _repository.Delete(id);
    }

    public void PostEmployees(EmployeeDTO[] employeeDTOs)
    {
        foreach (var em in employeeDTOs)
        {
            var employee = new Employee
            {
                Name = em.Name,
                DepartmentId = em.DepartmentId,
                // Add any other properties you need to set
            };
            _repository.Add(employee);
        }
    }
}
