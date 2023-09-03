using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement.DTOs
{
    public class EmployeeDTO
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
