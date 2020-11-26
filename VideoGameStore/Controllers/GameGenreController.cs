using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Get all objects");
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation($"Get {id} object");
            return Ok(await _service.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GameGenreCUModel model)
        {
            _logger.LogInformation($"Create new videoGame : {HttpContext.Request.Query} ");
            if (await _service.CreateAsync(_mapper.Map<GameGenreDTO>(model)))
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            _logger.LogInformation($"Delete {id} object");
            if (await _service.DeleteAsync(id))
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] GameGenreCUModel model)
        {
            _logger.LogInformation($"Update new videoGame : {HttpContext.Request.Query} ");
            if (await _service.UpdateAsync(_mapper.Map<GameGenreDTO>(model)))
                return Ok();
            return BadRequest();
        }
    }
}
