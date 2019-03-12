using demo.Services;
using demo.V1.Models.V1HealthCheck;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.V1.Controllers
{
    /// <summary>
    /// Returns Health check information
    /// </summary>
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

        /// <summary>
        /// Returns health status of the application
        /// </summary>
        /// <param name="detailed">Set to 1 to retrieve the individual health checks</param>
        /// <returns>A health check response</returns>
        [ProducesResponseType(typeof(HealthCheckResponse), 200)]
        [HttpGet]
        [Produces("application/json")]
        public IActionResult Get([FromQuery]int detailed)
        {
            var response = _healthCheckService.GetStatus(detailed);

            return Ok(response); 
        }
    }
}
