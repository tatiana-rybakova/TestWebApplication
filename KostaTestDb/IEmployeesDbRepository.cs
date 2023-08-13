namespace KostaTestDb
{
    public interface IEmployeesDbRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee> TryGetAsync(decimal id);
        Task AddAsync(Employee employee);
        Task RemoveAsync(Employee employee);
        Task EditAsync();        
    }
}
