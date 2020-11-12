using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VideoGameStore.Domain.Core.Models;
using VideoGameStore.Services.Interfaces;

namespace VideoGameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IService<Order> _service;
        private readonly ILogger<Order> _logger;
        public OrderController(IService<Order> service, ILogger<Order> logger)
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
        public IActionResult Post([FromBody] Order order)
        {
            _logger.LogInformation($"Create new order: {HttpContext.Request.Query} ");
            if (_service.Create(order))
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
        public IActionResult Update([FromBody] Order order)
        {
            _logger.LogInformation($"Update new order: {HttpContext.Request.Query} ");
            if (_service.Update(order))
                return Ok();
            return BadRequest();
        }
    }
}
