using Microsoft.EntityFrameworkCore;

namespace KostaTestDb
{
    public class DepartmentsDbRepository : IDepartmentsDbRepository
    {
        private readonly DatabaseContext databaseContext;

        public DepartmentsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await databaseContext.Department.ToListAsync();
        }
        public async Task AddAsync(Department department)
        {
            await databaseContext.Department.AddAsync(department);
            await databaseContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Department department)
        {
            databaseContext.Department.Remove(department);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<Department> TryGetAsync(Guid id)
        {
            var department = await databaseContext.Department.Include(d => d.Employees).Include(d => d.Departments).FirstOrDefaultAsync(d => d.Id == id);
            return department;
        }

        public async Task<Department> GetMainAsync()
        {
            var mainDepartment = await databaseContext.Department.Include(d => d.Employees).Include(d => d.Departments).FirstOrDefaultAsync(d => d.ParentDepartmentID == null);
            
            if(mainDepartment == null)
            {
                mainDepartment = new Department
                {
                    Name = "Новая компания",
                    Code = "N1",
                };
                await databaseContext.Department.AddAsync(mainDepartment);
                await databaseContext.SaveChangesAsync();
            }

            return mainDepartment;
        }

        public async Task EditAsync()
        {
            await databaseContext.SaveChangesAsync();
        }
    }
}
