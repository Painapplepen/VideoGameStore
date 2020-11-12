using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VideoGameStore.Domain.Core.Models;
using VideoGameStore.Services.Interfaces;

namespace VideoGameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IService<Comment> _service;
        private readonly ILogger<Comment> _logger;
        public CommentController(IService<Comment> service, ILogger<Comment> logger)
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
        public IActionResult Post([FromBody] Comment comment)
        {
            _logger.LogInformation($"Create new company: {HttpContext.Request.Query} ");
            if (_service.Create(comment))
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
        public IActionResult Update([FromBody] Comment comment)
        {
            _logger.LogInformation($"Update new company: {HttpContext.Request.Query} ");
            if (_service.Update(comment))
                return Ok();
            return BadRequest();
        }
    }
}
