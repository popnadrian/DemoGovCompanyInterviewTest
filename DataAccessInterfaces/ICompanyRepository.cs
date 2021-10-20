namespace DataAccessInterfaces
{
    public interface ICompanyRepository
    {
        void Create(Company company);

        void Update(Company company);

        Task SaveChangesAsync();

        Task<IEnumerable<Company>> GetAllAsync();

        Task<Company> GetByIdAsync(int id);

        Task<Company> GetByIsinAsync(string isin);
    }
}