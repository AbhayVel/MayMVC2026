using JWTExampleApi.DataBaseCOntext;
using JWTExampleApi.DTOs;
using JWTExampleApi.Entitties;
using JWTExampleApi.Mappers;
using JWTExampleApi.Repository;
using JWTExampleApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace JWTExampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        public BaseRepository _USerRepository { get; set; }

        public RoleService RoleService { get; set; }
        public UserController(BaseRepository uSerRepository, RoleService _roleService)
        {
            this._USerRepository = uSerRepository;

            RoleService = _roleService;
        }

        [HttpGet]
        public IActionResult Get([FromServices] UserService userService, [FromServices] RoleService _roleService)
        {
            var k = 1;
            var j = 1 / k;
            var result = userService.GetAllUsers(); // Example usage of the UserDbContext
            return Ok(result);
        }


        [HttpPost]

         
        public IActionResult Post( [FromBody]   UserDTO userData)
        {

            var k = 1;
            var j = 1 / k;
             var entity = UserDataDTOMapper.MapToEntity(userData);

            var role = _USerRepository.GetAll<Role>((x)=>x.RoleName.Equals(userData.RoleName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            
             entity.RoleID = role?.Id ?? 0;
            _USerRepository.Save(entity);
            return Ok(entity);




        }
    }
}
