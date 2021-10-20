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

        public async Task<Company> GetByIdAsync(int id) 
            => (await _context.Company.SingleOrDefaultAsync(x => x.Id == id)) ?? throw new EntityNotFoundException<int>(id);

        public async Task<Company> GetByIsinAsync(string isin) 
            => (await _context.Company.SingleOrDefaultAsync(x => x.ISIN == isin)) ?? throw new EntityNotFoundException<string>(isin);

        public Task SaveChangesAsync() => _context.SaveChangesAsync();

        public void Update(Company company)
        {
            _context.Update(company);
        }
    }
}