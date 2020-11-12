using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VideoGameStore.Domain.Core.Models;
using VideoGameStore.Services.Interfaces;

namespace VideoGameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameGenreController : ControllerBase
    {
        private readonly IService<GameGenre> _service;
        private readonly ILogger<GameGenre> _logger;
        public GameGenreController(IService<GameGenre> service, ILogger<GameGenre> logger)
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
        public IActionResult Post([FromBody] GameGenre gameGenre)
        {
            _logger.LogInformation($"Create new gameGenre: {HttpContext.Request.Query} ");
            if (_service.Create(gameGenre))
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
        public IActionResult Update([FromBody] GameGenre gameGenre)
        {
            _logger.LogInformation($"Update new gameGenre: {HttpContext.Request.Query} ");
            if (_service.Update(gameGenre))
                return Ok();
            return BadRequest();
        }
    }
}
