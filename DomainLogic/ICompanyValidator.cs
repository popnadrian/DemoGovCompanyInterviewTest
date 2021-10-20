using DataAccessInterfaces;

namespace DomainLogic
{
    public interface ICompanyValidator
    {
        void Validate(Company company);
    }

    public class CompanyValidator : ICompanyValidator
    {
        public void Validate(Company company)
        {
            // intentionally left empty for now
        }
    }
}