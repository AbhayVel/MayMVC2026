using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningBasics
{
    public class SingletonClassExample
    {

        private static readonly object _lock = new object();
        private static SingletonClassExample _instance;
    
            // Private constructor to prevent instantiation from outside the class
            private SingletonClassExample()
            {
            }
    
            // Public method to provide access to the single instance of the class
            public static SingletonClassExample GetInstance()
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SingletonClassExample();
                        }
                    }              
                }
                return _instance;
            }
    
            public void SomeMethod()
            {
                Console.WriteLine("This is a method in the singleton class.");
        }

    }


    //public class  Other : SingletonClassExample
    //{
        
    //}
}
