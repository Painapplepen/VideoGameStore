using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using VideoGameStore.Domain.Core.DTO;
using VideoGameStore.Domain.Core.Entities;
using VideoGameStore.Domain.Core.Models.VideoGame;
using VideoGameStore.Services.Interfaces;

namespace VideoGameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly IService<VideoGameDTO> _service;
        private readonly ILogger<VideoGameDTO> _logger;
        private IMapper _mapper;

        public VideoGamesController(IService<VideoGameDTO> service, ILogger<VideoGameDTO> logger, IMapper mapper)
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
        public async Task<IActionResult> Post([FromBody] VideoGameCreateModel model)
        {
            _logger.LogInformation($"Create new videoGame : {HttpContext.Request.Query} ");
            if (await _service.CreateAsync(_mapper.Map<VideoGameDTO>(model)))
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]int id)
        {
            _logger.LogInformation($"Delete {id} object");
            if (await _service.DeleteAsync(id))
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] VideoGameUpdateModel model)
        {
            _logger.LogInformation($"Update new videoGame : {HttpContext.Request.Query} ");
            if (await _service.UpdateAsync(_mapper.Map<VideoGameDTO>(model)))
                return Ok();
            return BadRequest();
        }
    }
}
