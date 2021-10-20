using DataAccessInterfaces;

namespace DomainLogic
{
    public class CompanyReadService
    {
        private readonly ICompanyRepository _repository;

        public CompanyReadService(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Company>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Company> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<Company> GetByIsinAsync(string isin) => _repository.GetByIsinAsync(isin);
    }
}