// IEmployeesService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;

public interface IEmployeesService
{
    IEnumerable<Employee> GetEmployees();
    Employee GetEmployee(int id);
    void PutEmployee(Employee employee);
    void PostEmployees(EmployeeDTO[] employeeDTO);
    void DeleteEmployee(int id);
}
