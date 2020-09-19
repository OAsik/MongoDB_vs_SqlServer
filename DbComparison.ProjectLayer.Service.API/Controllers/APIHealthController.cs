using System;
using Microsoft.AspNetCore.Mvc;

namespace DbComparison.ProjectLayer.Service.API.Controllers
{
    [ApiController]
    public class APIHealthController : ControllerBase
    {
        [Route("StartUp")]
        [HttpGet]
        public IActionResult Health()
        {
            try
            {
                return Ok("Service is up and running.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}