using System.ComponentModel.DataAnnotations.Schema;

namespace KostaTestDb
{
    [Table("Department")]
    public class Department
    {       
        public Guid Id { get; set; }        
        public string Name { get; set; }       
        public string? Code { get; set; }
        public Guid? ParentDepartmentID { get; set; }   
        public List<Employee> Employees { get; set; }

        [ForeignKey("ParentDepartmentID")]
        public List<Department>? Departments { get; set; }

        public Department()
        {
            Employees = new List<Employee>();
            Departments = new List<Department>();
        }
    }
}
