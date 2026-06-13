using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningBasics
{
    public class AppContext
    {
        public string Request { get; set; }
    }

    public delegate Task RequestDelegate(AppContext context);

    public delegate Task MyDelegate(AppContext context);

    public delegate int MyD2(AppContext context);
    public delegate int ParentDelegate(MyD2 myD2);

   

    public delegate int MyD(int i, string s);
    public class   TempExample 
    {
       
      public  static int GetData(int i)
        {
            if(i<0)
            {
                return 0;
            }
            return i * 2;
        }



        public static async Task Print(ParentDelegate func, MyD2 d)
        {
            
            Console.WriteLine(func(d));
        }


        public static async Task Print(MyD2 myD, AppContext a )
        {
            Console.WriteLine(myD(a));
        }

        //public static async Task Print(MyD myD)
        //{
        //    Console.WriteLine(myD.Invoke());
        //}
    }

    public class ApplicationBuilder
    {
       



        public readonly IList<Func<RequestDelegate, RequestDelegate>> _middlewares
            = new List<Func<RequestDelegate, RequestDelegate>>();

        // Register middleware
        public ApplicationBuilder Use(Func<AppContext, Func<Task>, Task> middleware)
        {
            _middlewares.Add(next =>
            {
                return context =>
                {
                    Func<Task> simpleNext = () => next(context);
                    return middleware(context, simpleNext);
                };
            });

            return this;
        }

        // Build pipeline
        public RequestDelegate Build()
        {
            RequestDelegate app = context =>
            {
                Console.WriteLine("Pipeline Completed");
                return Task.CompletedTask;
            };

            // Reverse order like ASP.NET Core
            for (int i = _middlewares.Count - 1; i >= 0; i--)
            {
                app = _middlewares[i](app);
            }

            return app;
        }
    }

}
