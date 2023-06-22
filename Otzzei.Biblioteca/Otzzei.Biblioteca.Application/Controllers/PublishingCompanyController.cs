using Microsoft.AspNetCore.Mvc;
using Otzzei.Biblioteca.Domain.Interfaces.IServices;
using Otzzei.Biblioteca.Domain.Requests;

namespace Otzzei.Biblioteca.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublishingCompanyController : ControllerBase
    {
        private readonly IPublishingCompanyService _publishingCompanyService;
        public PublishingCompanyController(IPublishingCompanyService publishingCompanyService)
        {
            _publishingCompanyService = publishingCompanyService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublishingCompanyAsync(PublishingCompanyRequest request)
        {
            var result = await _publishingCompanyService.CreatePublishingCompanyAsync(request);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublishingCompanyAsync(Guid id, PublishingCompanyRequest request)
        {
            var result = await _publishingCompanyService.UpdatePublishingCompanyAsync(id, request);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdPublishingCompanyAsync(Guid id)
        {
            var result = await _publishingCompanyService.GetByIdPublishingCompanyAsync(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetPublishersAsync()
        {
            var result = await _publishingCompanyService.GetPublishersAsync();
            return Ok(result);
        }
    }
}
