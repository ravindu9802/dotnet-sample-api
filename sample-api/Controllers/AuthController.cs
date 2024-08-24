using Microsoft.AspNetCore.Mvc;
using sample_api.Models;

namespace sample_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost]
        public ActionResult PostIsValidLogin([FromBody] Auth auth)
        {
            string email = "abc@abc.com";
            string password = "12345";

            if (auth != null && auth.Email.Equals(email) && auth.Password.Equals(password)) return Ok();
            return BadRequest();
        }
    }
}
