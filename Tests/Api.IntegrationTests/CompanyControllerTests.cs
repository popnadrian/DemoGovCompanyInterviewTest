using Api.Controllers;
using DataAccessInterfaces;
using DomainLogic;
using EfDal;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace Api.IntegrationTests
{
    public class CompanyControllerTests
    {
        private readonly CompanyController sut = new();
        private readonly CompanyReadService readService;
        private readonly CompanyWriteService writeService;


        public CompanyControllerTests()
        {
            var options = new DbContextOptionsBuilder<CompanyDbContext>()
                  .UseInMemoryDatabase(databaseName: "Companies")
                  .Options;

            var repo = new CompanyRepository(new CompanyDbContext(options));
            readService = new CompanyReadService(repo);
            writeService = new CompanyWriteService(repo, new CompanyValidator());
        }

        [Fact]
        public async Task Test1()
        {
            await sut.Post(new Company
            {
                Exchange = "bvb",
                ISIN = "ab1234567890",
                Id = 1,
                Name = "Google",
                Ticker = "ABC",
                Website = "google.com"
            }, writeService);

            var item = await sut.GetById(1, readService);

            item.Name = "Alphabet";

            await sut.Put(item, writeService);

            var items = await sut.Get(readService);

            Assert.Single(items);

            var itemByIsin = await sut.GetByIsin("ab1234567890", readService);
            var itemById = await sut.GetById(1, readService);

            Assert.Equal(itemById.Name, itemByIsin.Name);
        }
    }
}