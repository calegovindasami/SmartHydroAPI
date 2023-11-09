using Microsoft.AspNetCore.Mvc;
using SmartHydroAPI.Models;
using SmartHydroAPI.Services;
using SmartHydroAPI.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartHydroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorReadingsController : ControllerBase
    {
        private SensorReadingsService service;

        public SensorReadingsController()
        {
            service = new();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await service.Get();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SensorReadingsViewModel model)
        {
            await service.Save(model);
            return Ok();
        }
    }
}
