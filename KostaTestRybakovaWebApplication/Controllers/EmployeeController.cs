using KostaTestDb;
using KostaTestRybakovaWebApplication.Helpers;
using KostaTestRybakovaWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace KostaTestRybakovaWebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IDepartmentsDbRepository departmentsRepository;
        private readonly IEmployeesDbRepository employeesRepository;

        public EmployeeController(IDepartmentsDbRepository departmentsRepository, IEmployeesDbRepository employeesRepository)
        {
            this.departmentsRepository = departmentsRepository;
            this.employeesRepository = employeesRepository;
        }

        public async Task<IActionResult> Index(Guid departmentId)
        {
            var department = await departmentsRepository.TryGetAsync(departmentId);
            return View(department.ToDepartmentViewModel());
        }

        public async Task<IActionResult> EmployeeInfo(decimal employeeId)
        {
            var employee = await employeesRepository.TryGetAsync(employeeId);
            return View(employee.ToEmployeeViewModel());
        }

        public IActionResult Add(Guid departmentId)
        {
            var newEmployee = new AddEmployeeViewModel();
            newEmployee.DepartmentId = departmentId;
            return View(newEmployee);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddEmployeeViewModel newEmployee)
        {
            if (!ModelState.IsValid)
            {
                return View(newEmployee);
            }

            var employee = newEmployee.ToEmployee();
            await employeesRepository.AddAsync(employee);

            var department = await departmentsRepository.TryGetAsync(employee.DepartmentID);
            department.Employees.Add(employee);

            return RedirectToAction("Index", "Employee", new { employee.DepartmentID });
        }

        public async Task<IActionResult> EditAsync(decimal employeeId)
        {
            var employee = await employeesRepository.TryGetAsync(employeeId);
            return View(employee.ToEditEmployeeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(EditEmployeeViewModel changedEmployee)
        {
            if (!ModelState.IsValid)
            {
                return View(changedEmployee);
            }

            var changingEmployee = await employeesRepository.TryGetAsync(changedEmployee.Id);

            changingEmployee.FirstName = changedEmployee.FirstName;
            changingEmployee.SurName = changedEmployee.SurName;
            changingEmployee.DateOfBirth = changedEmployee.DateOfBirth;
            changingEmployee.DepartmentID = changedEmployee.DepartmentId;
            changingEmployee.ID = changedEmployee.Id;
            changingEmployee.Patronymic = changedEmployee.Patronymic;
            changingEmployee.DocSeries = changedEmployee.DocSeries;
            changingEmployee.DocNumber = changedEmployee.DocNumber;
            changingEmployee.Position = changedEmployee.Position;

            await employeesRepository.EditAsync();

            return RedirectToAction("Index", new { changingEmployee.DepartmentID });
        }

        public async Task<IActionResult> RemoveAsync(decimal employeeId)
        {
            var removingEmployee = await employeesRepository.TryGetAsync(employeeId);
            var departmentId = removingEmployee.DepartmentID;
            await employeesRepository.RemoveAsync(removingEmployee);
            return RedirectToAction("Index", new { departmentId });
        }
    }
}

