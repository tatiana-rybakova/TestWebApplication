using KostaTestDb;
using KostaTestRybakovaWebApplication.Helpers;
using KostaTestRybakovaWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace KostaTestRybakovaWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDepartmentsDbRepository departmentsRepository;

        public HomeController(IDepartmentsDbRepository departmentsRepository)
        {
            this.departmentsRepository = departmentsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var mainDepartment = await departmentsRepository.GetMainAsync();
            return View(mainDepartment.ToDepartmentViewModel());
        }

        public IActionResult Add(Guid departmentId)
        {
            var newDepartment = new AddDepartmentViewModel();
            newDepartment.ParentDepartmentID = departmentId;
            return View(newDepartment);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddDepartmentViewModel newDepartment)
        {
            if (!ModelState.IsValid)
            {
                return View(newDepartment);
            }

            var department = newDepartment.ToDepartment();
            await departmentsRepository.AddAsync(department);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditAsync(Guid departmentId)
        {
            var department = await departmentsRepository.TryGetAsync(departmentId);
            return View(department.ToEditDepartmentViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(EditDepartmentViewModel changedDepartment)
        {
            if (!ModelState.IsValid)
            {
                return View(changedDepartment);
            }

            var changingDepartment = await departmentsRepository.TryGetAsync(changedDepartment.Id);

            changingDepartment.Id = changedDepartment.Id;
            changingDepartment.Name = changedDepartment.Name;
            changingDepartment.Code = changedDepartment.Code;
            changingDepartment.ParentDepartmentID = changedDepartment.ParentDepartmentID;                     

            await departmentsRepository.EditAsync();

            return RedirectToAction("Index", "Employee",  new { departmentId = changingDepartment.Id });
        }

        public async Task<IActionResult> RemoveAsync(Guid departmentId)
        {
            var removingDepartment = await departmentsRepository.TryGetAsync(departmentId);            
            await departmentsRepository.RemoveAsync(removingDepartment);
            return RedirectToAction("Index");
        }
    }
}