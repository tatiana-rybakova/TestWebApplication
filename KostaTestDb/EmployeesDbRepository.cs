using Microsoft.EntityFrameworkCore;

namespace KostaTestDb
{
    public class EmployeesDbRepository : IEmployeesDbRepository
    {
        private readonly DatabaseContext databaseContext;

        public EmployeesDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task AddAsync(Employee employee)
        {
            await databaseContext.Employee.AddAsync(employee);
            await databaseContext.SaveChangesAsync();
        }

        public async Task EditAsync()
        {
            await databaseContext.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await databaseContext.Employee.ToListAsync();
        }

        public async Task RemoveAsync(Employee employee)
        {
            databaseContext.Employee.Remove(employee);
            await databaseContext.SaveChangesAsync();
        }        

        public async Task<Employee> TryGetAsync(decimal id)
        {
            return await databaseContext.Employee.FirstOrDefaultAsync(e => e.ID == id);
        }
    }
}
