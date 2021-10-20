using DataAccessInterfaces;

namespace EfDal
{
    public class CompanyRepository : ICompanyRepository
    {
        public Task CreateAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Company company)
        {
            throw new NotImplementedException();
        }
    }
}