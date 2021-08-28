using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestReal.Services.Interfaces;

namespace TestReal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly ICalculationService calculationService;

        public CalculationController(ICalculationService calculationService)
        {
            this.calculationService = calculationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int rollingRetentionDay)
        {
            return Ok(await calculationService.Calculate(rollingRetentionDay));
        }

    }
}