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

            // most voted here, no protocol: https://stackoverflow.com/questions/3809401/what-is-a-good-regular-expression-to-match-a-url
            RuleFor(x => x.Website).NotEmpty().Matches(@"[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)");
        }

        public new void Validate(Company company)
        {
            var r = base.Validate(company);

            if (r == null || r.IsValid) return;

            throw new ValidationException(r.Errors);
        }
    }
}