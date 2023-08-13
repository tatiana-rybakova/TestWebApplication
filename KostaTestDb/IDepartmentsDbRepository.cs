namespace KostaTestDb
{
    public interface IDepartmentsDbRepository
    {
        Task<List<Department>> GetAllAsync();
        Task<Department> TryGetAsync(Guid id);
        Task AddAsync(Department department);
        Task RemoveAsync(Department department);
        Task<Department> GetMainAsync();
        Task EditAsync();
    }
}
