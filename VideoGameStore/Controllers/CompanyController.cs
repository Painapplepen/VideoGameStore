using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VideoGameStore.Domain.Core.Models;
using VideoGameStore.Services.Interfaces;

namespace VideoGameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IService<Company> _service;
        private readonly ILogger<Company> _logger;
        public CompanyController(IService<Company> service, ILogger<Company> logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Get all objects");
            return Ok(_service.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation($"Get {id} object");
            return Ok(_service.Get(id));
        }
        [HttpPost]
        public IActionResult Post([FromBody] Company company)
        {
            _logger.LogInformation($"Create new company: {HttpContext.Request.Query} ");
            if (_service.Create(company))
                return Ok();
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"Delete {id} object");
            if (_service.Delete(id))
                return Ok();
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Update([FromBody] Company company)
        {
            _logger.LogInformation($"Update new company: {HttpContext.Request.Query} ");
            if (_service.Update(company))
                return Ok();
            return BadRequest();
        }
    }
}
