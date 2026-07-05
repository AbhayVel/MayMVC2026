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



        public bool Save<T>(T entity) where T : class  , IEntity
        {

            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if(entity.Id == 0)
            {
                UserDbContext.Set<T>().Add(entity);
            }
            else
            {
                UserDbContext.Set<T>().Attach(entity).State = EntityState.Modified;
            }


            UserDbContext.SaveChanges();




            return true;
        }


        public bool Delete<T>(T entity) where T : class, IEntity
        {


            UserDbContext.Set<T>().Remove(entity);

            UserDbContext.SaveChanges();
            return true;
        }

        public bool DeleteById<T>(int id) where T : class, IEntity
        {

           var entity= UserDbContext.Set<T>().Where(e => e.Id == id).FirstOrDefault();

            if(entity == null)
            {
                return false;
            }
            UserDbContext.Set<T>().Remove(entity);
            UserDbContext.SaveChanges();
            return true;
        }


    }
}
