using DataAccessInterfaces;
using FluentValidation.TestHelper;
using Xunit;

namespace DomainLogic.UnitTests
{
    public class CompanyValidatorTests
    {
        private readonly CompanyValidator sut = new();

        [Theory, InlineData(null), InlineData(""), InlineData(" "), InlineData("    ")]
        public void Should_have_error_when_Name_is_empty(string value)
        {
            var model = new Company { Name = value };
            var result = sut.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.Name);
        }

        [Fact]
        public void Should_not_have_error_when_name_is_specified()
        {
            var model = new Company { Name = "Jeremy" };
            var result = sut.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.Name);
        }

        [Theory, InlineData(null), InlineData(""), InlineData(" "), InlineData("    ")]
        public void Should_have_error_when_Ticker_is_empty(string value)
        {
            var model = new Company { Ticker = value };
            var result = sut.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.Ticker);
        }

        [Fact]
        public void Should_not_have_error_when_Ticker_is_specified()
        {
            var model = new Company { Ticker = "ABC" };
            var result = sut.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.Ticker);
        }


        [Theory, InlineData(null), InlineData(""), InlineData(" "), InlineData("    ")]
        public void Should_have_error_when_Exchange_is_empty(string value)
        {
            var model = new Company { Exchange = value };
            var result = sut.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.Exchange);
        }

        [Fact]
        public void Should_not_have_error_when_Exchange_is_specified()
        {
            var model = new Company { Exchange = "ABC" };
            var result = sut.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.Exchange);
        }

        [Theory, InlineData(null), InlineData(""), InlineData(" "), InlineData("    ")]
        public void Should_have_error_when_ISIN_is_empty(string value)
        {
            var model = new Company { ISIN = value };
            var result = sut.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.ISIN);
        }


        [Fact]
        public void Should_have_error_when_ISIN_startswithnumbers()
        {
            var model = new Company { ISIN = "121234567890" };
            var result = sut.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.ISIN);
        }

        [Fact]
        public void Should_have_error_when_ISIN_is_too_long()
        {
            var model = new Company { ISIN = "AA12345678901" };
            var result = sut.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.ISIN);
        }


        [Fact]
        public void Should_have_error_when_ISIN_is_too_short()
        {
            var model = new Company { ISIN = "AA123456789" };
            var result = sut.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.ISIN);
        }

        [Fact]
        public void Should_not_have_error_when_ISIN_is_formated_Corectly()
        {
            var model = new Company { ISIN = "AA1234567890" };
            var result = sut.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.ISIN);
        }

        [Theory, InlineData(null), InlineData(""), InlineData(" "), InlineData("    ")]
        public void Should_have_error_when_Website_is_empty(string value)
        {
            var model = new Company { Website = value };
            var result = sut.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.Website);
        }


        [Theory, InlineData("google"), InlineData("google:abs"), InlineData("ftp://google.com"), InlineData("www")]
        public void Should_have_error_when_Website_has_wrong_format(string value)
        {
            var model = new Company { Website = value };
            var result = sut.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.Website);
        }

        [Theory, InlineData("google.com"), InlineData("http://google.com"), InlineData("www.google.com")
            , InlineData("https://google.com"), InlineData("http://www.google.com")
            , InlineData("https://www.google.com")]
        public void Should_not_have_error_when_Website_format_is_corect(string value)
        {
            var model = new Company { Website = value };
            var result = sut.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.Website);
        }
    }
}