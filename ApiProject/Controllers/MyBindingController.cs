using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyBindingController : ControllerBase
    {
        [HttpGet("{id}/{fname}/{lname}")] // from route
        public IActionResult Get( int id , string fname , string lname  )
        {
            return Ok();
            
        }
    }
}
