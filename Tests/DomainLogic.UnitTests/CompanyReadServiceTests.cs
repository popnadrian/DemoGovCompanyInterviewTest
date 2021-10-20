using DataAccessInterfaces;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DomainLogic.UnitTests
{
    public class CompanyReadServiceTests
    {
        private readonly CompanyReadService sut;
        private readonly Mock<ICompanyRepository> _repository = new();

        public CompanyReadServiceTests()
        {
            sut = new CompanyReadService(_repository.Object);
        }

        [Fact]
        public async Task GetAllAsync_returns_repository_result()
        {
            var expected = new[] { new Company(), new Company(), new Company(), new Company(), }.AsEnumerable();
            _repository.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(expected));
            var result = await sut.GetAllAsync();
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetByIdAsync_returns_repository_result()
        {
            var expected = new Company();
            _repository.Setup(x => x.GetByIdAsync(21)).Returns(Task.FromResult(expected));
            var result = await sut.GetByIdAsync(21);
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetByIsinAsync_returns_repository_result()
        {
            var expected = new Company();
            _repository.Setup(x => x.GetByIsinAsync("a")).Returns(Task.FromResult(expected));
            var result = await sut.GetByIsinAsync("a");
            Assert.Equal(expected, result);
        }
    }
}