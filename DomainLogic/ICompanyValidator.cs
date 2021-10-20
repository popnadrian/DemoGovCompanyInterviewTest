using DataAccessInterfaces;

namespace DomainLogic
{
    public interface ICompanyValidator
    {
        void Validate(Company company);
    }
}