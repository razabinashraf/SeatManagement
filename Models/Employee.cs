using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
