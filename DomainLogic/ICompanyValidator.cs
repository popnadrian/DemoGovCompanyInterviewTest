using DataAccessInterfaces;

namespace DomainLogic
{
    public interface ICompanyValidator
    {
        void ValidateAndThrow(Company company);
    }
}