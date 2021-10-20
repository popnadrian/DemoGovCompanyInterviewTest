using DataAccessInterfaces;
using FluentValidation;

namespace DomainLogic
{
    public class CompanyValidator : AbstractValidator<Company>, ICompanyValidator
    {
        public CompanyValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Exchange).NotEmpty();
            RuleFor(x => x.Ticker).NotEmpty();


            RuleFor(x => x.ISIN).NotEmpty().Length(12).Matches(@"[A-Za-z]{2}\w{10}");

            // https://stackoverflow.com/questions/42618872/regex-for-website-or-url-validation/42619368
            RuleFor(x => x.Website).NotEmpty().Matches(@"^((https?):\/\/)?(www.)?[a-z0-9]+\.[a-z]+(\/[a-zA-Z0-9#]+\/?)*$");
        }

        public void ValidateAndThrow(Company company)
        {
            // keeping this as a prove of concept
            // TODO: investigate how to use FluentValidator with API

            var r = Validate(company);

            if (r == null || r.IsValid) return;

            throw new ValidationException(r.Errors);
        }
    }
}