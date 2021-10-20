namespace DataAccessInterfaces
{
    public interface ICompanyRepository
    {
        Task CreateAsync(Company company);

        Task UpdateAsync(Company company);

        Task<IEnumerable< Company>> GetAllAsync();

        Task<Company> GetByIdAsync(int id); 
    }
}