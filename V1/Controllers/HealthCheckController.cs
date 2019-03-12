using demo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/healthcheck")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly IHealthCheckService _healthCheckService;

        public HealthCheckController(IHealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]int detailed)
        {
            var response = _healthCheckService.GetStatus(detailed);

            return Ok(response); 
        }
    }
}
