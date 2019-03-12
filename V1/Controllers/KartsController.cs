using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.V1.Models;
using demo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace demo.V1.Controllers
{
    /// <summary>
    /// Resource for managing Karts
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/karts")]
    [ApiController]
public class KartsController : ControllerBase
{
    IKartService _kartService;

    //the constructor is injected with an IKartService 
    //it is recreated every call
    public KartsController(IKartService kartService)
    {
        _kartService = kartService;
    }

        /// <summary>
        /// Gets the list of Karts
        /// </summary>
        /// <param name="kartSpecification">The parameters to limit the Kart results by </param>
        /// <returns></returns>
        /// <response code="200">The list of Karts was retrieved succesfully.</response>
        [ProducesResponseType( typeof( KartResponse ), 200 )]
        [HttpGet]
        [Produces("application/json")]
        public IActionResult Get([FromQuery] KartResourceParameters kartSpecification)
        {
            return Ok(_kartService.Get(kartSpecification));
        }

        /// <summary>
        /// Gets a specific Kart by its vehicle identification number (vin)
        /// </summary>
        /// <param name="vin">The vin of the Kart to retrieve</param>
        /// <response code="200">The kart was retrieved.</response>
        /// <response code="404">A kart with this VIN was not found.</response>
        [HttpGet("{vin}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(KartItem), 200)]
        [Produces("application/json")]
        public IActionResult Get(string vin)
        {
            var result = _kartService.Get(vin);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Creates a new Kart and saves it to the Kart collection
        /// </summary>
        /// <param name="kart">the new kart to create</param>
        /// <returns>Status response information</returns>
        [HttpPost]
        public IActionResult Post([FromBody] KartItem kart)
        {
                _kartService.Add(kart);
                return base.Ok(new NoContentResponse("Ok", "created kart"));       
        }
 
        /// <summary>
        /// Updates the Kart matching on the vin number supplied in the updated Kart 
        /// </summary>
        /// <param name="kart">the kart to update</param>
        /// <returns>Status response information</returns>
        [HttpPut]
        public IActionResult Put([FromBody] KartItem kart)
        {
            _kartService.Update(kart);
            return base.Ok(new NoContentResponse("Ok", "updated kart"));
        }

        /// <summary>
        /// Removes a Kart from the list of Karts
        /// </summary>
        /// <param name="vin">The vehicle identification number (vin) of the Kart to remove</param>
        /// <returns>Status response information</returns>
        [HttpDelete("{vin}")]
        public IActionResult Delete(string vin)
        {
            _kartService.Delete(vin);
            return base.Ok(new NoContentResponse("Ok", "deleted kart"));
        }


    }


}
