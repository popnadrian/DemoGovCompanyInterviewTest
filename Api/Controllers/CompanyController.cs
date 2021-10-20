using DataAccessInterfaces;
using DomainLogic;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController, Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Company>> Get([FromServices] CompanyReadService service) => await service.GetAllAsync();

        [HttpGet(nameof(GetById))]
        public async Task<Company> GetById(int id, [FromServices] CompanyReadService service) => await service.GetByIdAsync(id);

        [HttpGet(nameof(GetByIsin))]
        public async Task<Company> GetByIsin(string isin, [FromServices] CompanyReadService service) => await service.GetByIsinAsync(isin);

        [HttpPost]
        public async Task Post([FromBody] Company company, [FromServices] CompanyWriteService service)
                => await service.AddAsync(company);

        [HttpPut]
        public async Task Put([FromBody] Company company, [FromServices] CompanyWriteService service)
                => await service.UpdateAsync(company);
    }
}