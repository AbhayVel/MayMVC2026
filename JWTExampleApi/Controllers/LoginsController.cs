using JWTExampleApi.DataBaseCOntext;
using JWTExampleApi.Entitties;
using LearningBasics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTExampleApi.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginsController : ControllerBase
    {

        public UserDbContext UserDbContext { get; set; }
        public LoginsController(UserDbContext _userDbContext)
        {
            UserDbContext=_userDbContext;
        }

        // GET: api/<LoginsController>
        [HttpGet]
        public UserAuthenticateionResponse Get()
        {
             var auth = new UserAuthentication();
            

         
            return auth.Authenticate("admin", "password");
        }


         void DisplayStates(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name},State: { entry.State.ToString()}");
            }
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
