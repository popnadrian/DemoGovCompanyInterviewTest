using DataAccessInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EfDal
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyDbContext _context;

        public CompanyRepository(CompanyDbContext context)
        {
            _context = context;
        }

        public void Create(Company company)
        {
            _context.Add(company);
        }

        public async Task<IEnumerable<Company>> GetAllAsync() => (await _context.Company.ToListAsync()).AsEnumerable();

        public Task<Company> GetByIdAsync(int id) => _context.Company.SingleAsync(x => x.Id == id);

        public Task<Company> GetByIsinAsync(string isin) => _context.Company.SingleAsync(x => x.ISIN == isin);

        public Task SaveChangesAsync() => _context.SaveChangesAsync();

        public void Update(Company company)
        {
            _context.Update(company);
        }
    }
}