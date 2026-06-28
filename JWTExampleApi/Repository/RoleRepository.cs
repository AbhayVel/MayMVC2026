using JWTExampleApi.DataBaseCOntext;
using JWTExampleApi.DTOs;
using JWTExampleApi.Entitties;
using JWTExampleApi.Mappers;
using Microsoft.EntityFrameworkCore;

namespace JWTExampleApi.Repository
{
    public class RoleRepository : BaseRepository
    {
        public RoleRepository(UserDbContext _userDbContext) : base(_userDbContext)
        {



        }

    }
}
