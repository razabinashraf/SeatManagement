// IEmployeesService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;

public interface IEmployeesService
{
    IEnumerable<Employee> GetEmployees();
    Employee GetEmployee(int id);
    void PutEmployee(Employee employee);
    Employee PostEmployee(EmployeeDTO employeeDTO);
    void DeleteEmployee(int id);
    void BulkAddEmployees(EmployeeDTO[] employeeDTOs);
}
