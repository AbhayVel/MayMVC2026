using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningBasics
{
    public class UserDataBaseRepository : IUserRepository
    {

        public User GetUserById(int id)
        {
            // Simulate fetching user from a database
            return new User { Id = id, Name = "John Doe Database" };
        }
    }
}
