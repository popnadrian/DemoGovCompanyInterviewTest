using DataAccessInterfaces;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace DomainLogic.UnitTests
{
    public class CompanyWriteServiceTests
    {
        private readonly CompanyWriteService sut;
        private readonly Mock<ICompanyRepository> _repository = new();
        private readonly Mock<ICompanyValidator> _validator = new();

        public CompanyWriteServiceTests()
        {
            sut = new CompanyWriteService(_repository.Object, _validator.Object);
        }

        [Fact]
        public async Task AddAsync_invokes_validator()
        {
            var item = new Company();
            await sut.AddAsync(item);
            _validator.Verify(x => x.ValidateAndThrow(item), Times.Once());
        }

        [Fact]
        public async Task AddAsync_invokes_repository_create()
        {
            var item = new Company();
            await sut.AddAsync(item);
            _repository.Verify(x => x.Create(item), Times.Once());
        }

        [Fact]
        public async Task AddAsync_invokes_repository_save()
        {
            var item = new Company();
            await sut.AddAsync(item);
            _repository.Verify(x => x.SaveChangesAsync(), Times.Once());
        }

        [Fact]
        public async Task UpdateAsync_invokes_validator()
        {
            var item = new Company();
            await sut.UpdateAsync(item);
            _validator.Verify(x => x.ValidateAndThrow(item), Times.Once());
        }

        [Fact]
        public async Task UpdateAsync_invokes_repository_create()
        {
            var item = new Company();
            await sut.UpdateAsync(item);
            _repository.Verify(x => x.Update(item), Times.Once());
        }

        [Fact]
        public async Task UpdateAsync_invokes_repository_save()
        {
            var item = new Company();
            await sut.UpdateAsync(item);
            _repository.Verify(x => x.SaveChangesAsync(), Times.Once());
        }
    }
}