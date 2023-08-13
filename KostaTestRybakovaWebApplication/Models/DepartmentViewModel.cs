using KostaTestDb;
using System.ComponentModel.DataAnnotations;

namespace KostaTestRybakovaWebApplication.Models
{
    public class DepartmentViewModel
    {
        public Guid Id { get; set; }
        public Guid? ParentDepartmentID { get; set; }       
        public string? Code { get; set; }       
        public string Name { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }
        public List<DepartmentViewModel> Departments { get; set; }
    }
}
