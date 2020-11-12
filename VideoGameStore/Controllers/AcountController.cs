using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VideoGameStore.Domain.Core.DTO;
using VideoGameStore.Domain.Core.Models;
using VideoGameStore.Services.Interfaces;

namespace VideoGameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private IUserService _service;
        private ILogger<User> _logger;
        public AcountController(IUserService service, ILogger<User> logger)
        {
            _logger = logger;
            _service = service;
        }
        [Route("/register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserDTO model)
        {
            if (await _service.Register(model))
            {
                _logger.LogInformation($"Register {HttpContext.Request.Query}");
                return Ok();
            }
            return BadRequest();
        }
        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserDTO model)
        {
            if (await _service.Login(model)) {
                _logger.LogInformation($"Login {HttpContext.Request.Query}");
                return Ok();
            }
            return BadRequest();
        }
        [Route("/logout")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            _logger.LogInformation($"Logout {HttpContext.Request.Query}");
            await _service.Logout();
            return Ok();
        }
    }
}
