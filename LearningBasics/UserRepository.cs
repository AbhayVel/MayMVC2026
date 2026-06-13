using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningBasics
{
    public class UserRepository : IUserRepository
    {

        public User GetUserById(int id)
        {

            Console.WriteLine("I am in UserRepository");
            // Simulate fetching user from a database
            return new User { Id = id, Name = "John Doe" };
        }
    }
}
