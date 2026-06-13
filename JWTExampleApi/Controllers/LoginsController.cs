using LearningBasics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTExampleApi.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginsController : ControllerBase
    {
        // GET: api/<LoginsController>
        [HttpGet]
        public UserAuthenticateionResponse Get()
        {
             var auth = new UserAuthentication();
            return auth.Authenticate("admin", "password");
        }

        // GET api/<LoginsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LoginsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
