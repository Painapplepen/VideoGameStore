using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VideoGameStore.Domain.Core.Models;
using VideoGameStore.Services.Interfaces;

namespace VideoGameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly IService<VideoGame> _service;
        private readonly ILogger<VideoGame> _logger;
        public VideoGamesController(IService<VideoGame> service, ILogger<VideoGame> logger)
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
        public IActionResult Post([FromBody] VideoGame videoGame)
        {
            _logger.LogInformation($"Create new videoGame : {HttpContext.Request.Query} ");
            if (_service.Create(videoGame))
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
        public IActionResult Update([FromBody] VideoGame videoGame)
        {
            _logger.LogInformation($"Update new videoGame : {HttpContext.Request.Query} ");
            if (_service.Update(videoGame))
                return Ok();
            return BadRequest();
        }
    }
}
