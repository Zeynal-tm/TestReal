using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// using Swashbuckle.AspNetCore.Annotations;
using TestReal.Services.Interfaces;
using TestReal.Services.Interfaces.ViewModels;

namespace TestReal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IUserRegistrationService userRegistrationService;

        public UserRegistrationController(IUserRegistrationService userRegistrationService)
        {
            this.userRegistrationService = userRegistrationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(userRegistrationService.GetAll());
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            return Ok(userRegistrationService.GetDetail(userId));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateUserRegistrationViewModel viewModel)
        {
            await userRegistrationService.Create(viewModel);
            return NoContent();
        }

        [HttpPut("userId")]
        public async Task<IActionResult> Put([FromForm] UpdateUserRegistrationViewModel viewModel)
        {
            await userRegistrationService.Update(viewModel);
            return NoContent();
        }
        
    }
}