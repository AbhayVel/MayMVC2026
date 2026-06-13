using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningBasics
{
    public class Organization
    {

        public User Employee { get; set; }

        //constructor injection - Association - Dependency Inversion Principle
        public Organization(User employee)  //Association - Dependency Inversion Principle
        {
            Employee = employee;
        }

      public  Organization()
        {

        }


        //setter/Method injection - Association - Dependency Inversion Principle
        public void SetEmployee(User employee) //Association - Dependency Inversion Principle
        {
            Employee = employee;
        }


    }
}
