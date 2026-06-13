using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningBasics
{
    public class ValidationClass
    {

        public static bool ValidateUser(Employee user)
        {
            if (user.Age < 18)
            {
                return false;
            }
            if (user.Gender.Equals("M", StringComparison.OrdinalIgnoreCase))
            {
                if (user.Age < 21)
                {
                    return false;
                }
            }
            
            if (user.Name.Length < 3 || user.Name.Length > 50)
            {
                return false;
            }
            return true;
        }
    }
}
