using JWTExampleApi.DataBaseCOntext;
using JWTExampleApi.Entitties;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JWTExampleApi.Repository
{
    public class BaseRepository
    {
        public readonly UserDbContext UserDbContext;
        public BaseRepository(UserDbContext _userDbContext)
        {
            UserDbContext = _userDbContext;
        }

       

        public List<T> GetAll<T>(Expression<Func<T,bool>>? query=null,
            
            params Expression<Func<T, object>>[] includes

            ) where T : class
        {
             IQueryable<T> queryable = UserDbContext.Set<T>();
            if(query != null)
            {
                queryable = queryable.Where(query);
            }
                
            foreach (var include in includes)
            {
                queryable = queryable.Include(include);
            }

            var result = queryable.ToList(); // Example usage of the UserDbContext

            return result;
        }

    }
}
