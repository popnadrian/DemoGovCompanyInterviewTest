using DataAccessInterfaces;

namespace DomainLogic
{
    public class CompanyWriteService
    {
        private readonly ICompanyRepository _repository;
        private readonly ICompanyValidator _validator;

        public CompanyWriteService(ICompanyRepository repository, ICompanyValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public Task AddAsync(Company company)
        {
            _validator.ValidateAndThrow(company);

            _repository.Create(company);

            return _repository.SaveChangesAsync();
        }

        public Task UpdateAsync(Company company)
        {
            _validator.ValidateAndThrow(company);

            _repository.Update(company);

            return _repository.SaveChangesAsync();
        }
    }
}