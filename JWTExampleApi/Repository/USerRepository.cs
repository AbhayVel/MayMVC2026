using JWTExampleApi.DataBaseCOntext;
using JWTExampleApi.DTOs;
using JWTExampleApi.Entitties;
using JWTExampleApi.Mappers;
using Microsoft.EntityFrameworkCore;

namespace JWTExampleApi.Repository
{
    public class USerRepository : BaseRepository
    {
        public USerRepository(UserDbContext _userDbContext) : base(_userDbContext)
        {
        }


        public List<UserData> GetAll()
        {

            var result = UserDbContext.Set<UserData>().ToList(); // Example usage of the UserDbContext

            return result;
        }

        public List<UserData> GetByIdAndName(int id, string name)
        {

            var result = UserDbContext.Users.Where(x => x.Id == id && x.UserName.Contains(name)).ToList(); // Example usage of the UserDbContext

            return result;
        }

    }
}
