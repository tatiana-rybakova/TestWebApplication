using KostaTestDb;
using KostaTestRybakovaWebApplication.Models;

namespace KostaTestRybakovaWebApplication.Helpers
{
    public static class Mapping
    {
        public static List<DepartmentViewModel> ToDepartmentViewModels(this List<Department> departments)
        {
            var departmentViewModels = new List<DepartmentViewModel>();
            foreach (var department in departments)
            {
                departmentViewModels.Add(ToDepartmentViewModel(department));
            }
            return departmentViewModels;
        }

        public static DepartmentViewModel ToDepartmentViewModel(this Department department)
        {
            var existingDepartment = new DepartmentViewModel
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                ParentDepartmentID = department.ParentDepartmentID,
                Departments = department.Departments.ToDepartmentViewModels(),
                Employees = department.Employees.ToEmployeeViewModels()
            };
            return existingDepartment;
        }

        public static Department ToDepartment(this DepartmentViewModel department)
        {
            return new Department
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                ParentDepartmentID = department.ParentDepartmentID,
                Employees = ToEmployees(department.Employees)
            };
        }

        public static Department ToDepartment(this AddDepartmentViewModel department)
        {
            return new Department
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                ParentDepartmentID = department.ParentDepartmentID                
            };
        }

        public static EditDepartmentViewModel ToEditDepartmentViewModel(this Department department)
        {
            return new EditDepartmentViewModel
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                ParentDepartmentID = department.ParentDepartmentID
            };
        }

        public static List<EmployeeViewModel> ToEmployeeViewModels(this List<Employee> employees)
        {
            var employeesViewModels = new List<EmployeeViewModel>();
            foreach (var employee in employees)
            {
                employeesViewModels.Add(ToEmployeeViewModel(employee));
            }
            return employeesViewModels;
        }

        public static EmployeeViewModel ToEmployeeViewModel(this Employee employee)
        {
            return new EmployeeViewModel
            {
                Id = employee.ID,
                FirstName = employee.FirstName,
                SurName = employee.SurName,
                Patronymic = employee.Patronymic,
                DateOfBirth = employee.DateOfBirth,
                DepartmentID = employee.DepartmentID,
                DocSeries = employee.DocSeries,
                DocNumber = employee.DocNumber,
                Position = employee.Position
            };
        }

        public static List<Employee> ToEmployees(this List<EmployeeViewModel> employees)
        {
            var employeesViewModels = new List<Employee>();
            foreach (var employee in employees)
            {
                employeesViewModels.Add(ToEmployee(employee));
            }
            return employeesViewModels;
        }
        public static Employee ToEmployee(this EmployeeViewModel employee)
        {
            return new Employee
            {
                ID = employee.Id,
                FirstName = employee.FirstName,
                SurName = employee.SurName,
                Patronymic = employee.Patronymic,
                DateOfBirth = employee.DateOfBirth,
                DepartmentID = employee.DepartmentID,
                DocSeries = employee.DocSeries,
                DocNumber = employee.DocNumber,
                Position = employee.Position
            };
        }

        public static Employee ToEmployee(this AddEmployeeViewModel employee)
        {
            return new Employee
            {                
                FirstName = employee.FirstName,
                SurName = employee.SurName,
                Patronymic = employee.Patronymic,
                DateOfBirth = employee.DateOfBirth,
                DepartmentID = employee.DepartmentId,
                DocSeries = employee.DocSeries,
                DocNumber = employee.DocNumber,
                Position = employee.Position
            };
        }

        public static EditEmployeeViewModel ToEditEmployeeViewModel(this Employee employee)
        {
            return new EditEmployeeViewModel
            {
                Id = employee.ID,
                FirstName = employee.FirstName,
                SurName = employee.SurName,
                Patronymic = employee.Patronymic,
                DateOfBirth = employee.DateOfBirth,
                DepartmentId = employee.DepartmentID,
                DocSeries = employee.DocSeries,
                DocNumber = employee.DocNumber,
                Position = employee.Position
            };
        }
    }
}
