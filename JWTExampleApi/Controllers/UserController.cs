using JWTExampleApi.DataBaseCOntext;
using JWTExampleApi.DTOs;
using JWTExampleApi.Entitties;
using JWTExampleApi.Mappers;
using JWTExampleApi.Repository;
using JWTExampleApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace JWTExampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //public UserDbContext UserDbContext { get; set; }

        //public RoleService RoleService { get; set; }
        //public UserController(UserDbContext _userDbContext, RoleService _roleService)
        //{
        //    UserDbContext = _userDbContext;

        //    RoleService = _roleService;
        //}

        [HttpGet]
        public IActionResult Get([FromServices] UserService userService, [FromServices] RoleService _roleService)
        {
            var result = userService.GetAllUsers(); // Example usage of the UserDbContext
            return Ok(result);
        }


        [HttpPost]
        public IActionResult Post([FromServices] UserDbContext _userDbContext, [FromBody]   UserDTO userData)
        {

          var user=  _userDbContext.Users.FirstOrDefault(x=>x.Id==userData.Id);

            if (user == null)
            {
                // throw new Exception($"User with ID {userData.Id} not found.");
                return NotFound($"User with ID {userData.Id} not found.");
            }

           UserDataDTOMapper.MapToEntityWithExistingUser(userData, user, user.Role);

            if("userRole"=="Admin")
            {
              var user2=  UserDataDTOMapper.MapToEntityWithRole(userData, user.Role);

            }

            _userDbContext.SaveChanges();



            //            _userDbContext.Entry(userData).State = EntityState.Modified;
            //             _userDbContext.Entry(userData.Role).State = EntityState.Unchanged;
            //            //_userDbContext.ChangeTracker.TrackGraph(userData, (e) =>
            //            //{
            //            //    e.Entry.State = EntityState.Unchanged;
            //            //});


            //            foreach (var entry in _userDbContext.ChangeTracker.Entries())
            //            {
            //                var DATA = $"Entity: {entry.Entity.GetType().Name}, State: {entry.State.ToString()}";
            //                Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: { entry.State.ToString()}");
            //}

            //            _userDbContext.SaveChanges();

            //role service
            var result = _userDbContext.Users.Include(x=>x.Role).Where(x=>x.Id==userData.Id).AsNoTracking().ToList(); // Example usage of the UserDbContext
            return Ok(result);
        }
    }
}
