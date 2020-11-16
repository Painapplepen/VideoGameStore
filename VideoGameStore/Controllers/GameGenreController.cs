using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VideoGameStore.Domain.Core.DTO;
using VideoGameStore.Domain.Core.Models;
using VideoGameStore.Domain.Core.Models.GameGenre;
using VideoGameStore.Services.Interfaces;

namespace VideoGameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class GameGenreController : ControllerBase
    {
        private readonly IService<GameGenreDTO> _service;
        private readonly ILogger<GameGenreDTO> _logger;
        private IMapper _mapper;
        public GameGenreController(IService<GameGenreDTO> service, ILogger<GameGenreDTO> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
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
        public IActionResult Post([FromBody] GameGenreCUModel model)
        {
            _logger.LogInformation($"Create new videoGame : {HttpContext.Request.Query} ");
            if (_service.Create(_mapper.Map<GameGenreDTO>(model)))
                return Ok();
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _logger.LogInformation($"Delete {id} object");
            if (_service.Delete(id))
                return Ok();
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Update([FromBody] GameGenreCUModel model)
        {
            _logger.LogInformation($"Update new videoGame : {HttpContext.Request.Query} ");
            if (_service.Update(_mapper.Map<GameGenreDTO>(model)))
                return Ok();
            return BadRequest();
        }
    }
}
