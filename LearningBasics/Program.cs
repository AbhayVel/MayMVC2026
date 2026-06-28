////////////////// See https://aka.ms/new-console-template for more information
////////////////using LearningBasics;

////////////////Console.WriteLine("Hello, World!");

//////////////using LearningBasics;

//////////////int[] array = { 1, 2, 3, 4, 5, 6 };


//////////////double[] salary = { 1000, 2000.50, 3000, 7000 };


//////////////string[] names = { "Sayu", "Dviya", "sneha", "Abhay" };


////////////using LearningBasics;

////////////List<Employee> employees = new List<Employee>
////////////{
////////////    new Employee{Id=1, Name="Sayu", Age=25, DepartmentId=4},
////////////    new Employee{Id=2, Name="Dviya", Age=30, DepartmentId=1},
////////////    new Employee{Id=3, Name="Sneha", Age=28, DepartmentId = null},
////////////    new Employee{Id=4, Name="Abhay", Age=35, DepartmentId = 2} ,
////////////    new Employee{Id=5, Name="Ajay", Age=35, DepartmentId = 2}
////////////};

////////////List<Department> departments = new List<Department>
////////////{
////////////    new Department{Id=1, Name="HR"},
////////////    new Department{Id=2, Name="IT"},
////////////    new Department{Id=3, Name="Finance"},
////////////    new Department{Id=4, Name="Marketing"}
////////////};

//////////////Select * from Employees e
//////////////inner join Departments d
//////////////on e.DepartmentId=d.Id

////////////employees.Join(departments, x => x.DepartmentId, y => y.Id,
////////////    (x, y) =>
////////////{
////////////    return new
////////////    {
////////////        EmployeeId = x.Id,
////////////        EmployeeName = x.Name,
////////////        DepartmentName = y.Name
////////////    };
////////////})
////////////    .Select(x => $"EmployeeId: {x.EmployeeId}, EmployeeName: {x.EmployeeName}, DepartmentName: {x.DepartmentName}")
////////////    .Print();

////////////Console.WriteLine("Show Left join Example");

//////////////Select * from EMployees e
////////////// left join Department d
//////////////on e.DepartmentId=d.Id

////////////employees.GroupJoin(departments,x=>x.DepartmentId, y=>y.Id, (x, y) =>new {employee=x, departments=y})
////////////    .SelectMany(x=>x.departments.DefaultIfEmpty(),

////////////    (x, y) => new
////////////    {
////////////        EmployeesId=x.employee.Id  ,
////////////        EmployeeName=x.employee.Name,
////////////        DepartmentName=y==null? "Not assigned": y.Name

////////////    }

////////////    )
////////////    .Select(x => $"EmployeeId: {x.EmployeesId}, EmployeeName: {x.EmployeeName}, DepartmentName: {x.DepartmentName}")
////////////  .Print();


////////////Console.WriteLine("Show Right join Example  -  Select Many");

//////////////Select * from EMployees e
////////////// Right join Department d
//////////////on e.DepartmentId=d.Id

////////////departments.GroupJoin(employees, x => x.Id, y => y.DepartmentId, (x, y) => new { employee = y, departments = x })
////////////    .SelectMany(x => x.employee.DefaultIfEmpty(),

////////////    (x, y) => new
////////////    {

////////////        DepartmentName = x.departments.Name,
////////////        EmployeesId = y==null?"":y.Id.ToString(),
////////////        EmployeeName = y == null ? "" : y.Name.ToString(),

////////////    }

////////////    )
////////////    .Select(x => $"EmployeeId: {x.EmployeesId}, EmployeeName: {x.EmployeeName}, DepartmentName: {x.DepartmentName}")
////////////  .Print();


////////////Console.WriteLine("Example of Select with 2 tables but like group by with Select");

////////////employees.GroupJoin(departments, x => x.DepartmentId, y => y.Id, (x, y) => new { employee = x, departments = y })
////////////    .Select(

////////////    (x, y) => new
////////////    {
////////////        EmployeesId = x.employee.Id,
////////////        EmployeeName = x.employee.Name,
////////////        DepartmentCount = x.departments.Count()

////////////    }

////////////    )
////////////    .Select(x => $"EmployeeId: {x.EmployeesId}, EmployeeName: {x.EmployeeName}, DepartmentCount: {x.DepartmentCount}")
////////////  .Print();




////////////departments.GroupJoin(employees, x => x.Id, y => y.DepartmentId, (x, y) => new { employees = y, department = x })
////////////    .Select(

////////////    (x, y) => new
////////////    {

////////////        DepartmentName = x.department.Name,
////////////        EmployeeCount=x.employees.Count()

////////////    }

////////////    )
////////////    .Select(x => $"DepartmentName: {x.DepartmentName}   , EMployeeCount {x.EmployeeCount}")
////////////  .Print();



//////////////Select DeparmentId, count(EMployeeID) from Employee    Group by DeparmentId

////////////Console.WriteLine("result of Select DeparmentId, count(EMployeeID) from Employee    Group by DeparmentId\r\n");
////////////employees.GroupBy(x=>x.DepartmentId)
////////////    .Select(x =>
////////////    new {
////////////        DepartmentId=x.Key,
////////////        EmployeeCount=x.Count()
////////////    })
////////////    .Select(x => $"DepartmentId: {x.DepartmentId}   , EMployeeCount {x.EmployeeCount}")
////////////    .Print();


////////////Console.WriteLine("result of Select DeparmentId, count(EMployeeID) from Employee    Group by DeparmentId order by DeparmentId desc \r\n");
////////////employees.GroupBy(x => x.DepartmentId)
////////////    .Select(x =>
////////////    new {
////////////        DepartmentId = x.Key,
////////////        EmployeeCount = x.Count()
////////////    })
////////////    .OrderByDescending(x=>x.DepartmentId)
////////////    .Select(x => $"DepartmentId: {x.DepartmentId}   , EMployeeCount {x.EmployeeCount}")
////////////    .Print();


////////////Console.WriteLine("result of Select DeparmentId, count(EMployeeID) from Employee    Group by DeparmentId order by DeparmentId asc \r\n");
////////////employees.GroupBy(x => x.DepartmentId)
////////////    .Select(x =>
////////////    new {
////////////        DepartmentId = x.Key,
////////////        EmployeeCount = x.Count()
////////////    })
////////////    .OrderBy(x => x.DepartmentId)
////////////    .Select(x => $"DepartmentId: {x.DepartmentId}   , EMployeeCount {x.EmployeeCount}")
////////////    .Print();


////////////Console.WriteLine("Identify Multiple records for DepartmentID");
////////////employees.GroupBy(x => x.DepartmentId)
////////////    .Select(x =>
////////////    new {
////////////        DepartmentId = x.Key,
////////////        EmployeeCount = x.Count()
////////////    })
////////////    .Where(x=>x.EmployeeCount>1)
////////////    .OrderBy(x => x.DepartmentId)
////////////    .Select(x => $"DepartmentId: {x.DepartmentId}   , EMployeeCount {x.EmployeeCount}")
////////////    .Print();


////////////List<int> numbers = new List<int> { 1, 2, 3, 4, 3, 1, 2, 4, 5, 6 };

////////////Console.WriteLine("Bring Unoque records");
////////////numbers.GroupBy(x => x)
////////////    .Select(x => x.Key)
////////////    .Print();


////////////List<Employee> employees2 = new List<Employee>
////////////{
////////////    new Employee{Id=1, Name="Sayu", Age=25, DepartmentId=4},
////////////    new Employee{Id=2, Name="Sayu", Age=30, DepartmentId=1},
////////////    new Employee{Id=3, Name="Sneha", Age=28, DepartmentId = null},
////////////    new Employee{Id=4, Name="Sneha", Age=35, DepartmentId = 2} ,
////////////    new Employee{Id=5, Name="Ajay", Age=35, DepartmentId = 2}   ,
////////////     new Employee{Id=6, Name="Nikhi", Age=35, DepartmentId = 2}
////////////};

////////////Console.WriteLine("Bring Unique REcords Based on Name:");
////////////employees2.GroupBy(x => x.Name)
////////////    .Select(x => x.First())
////////////    .Print();






//////////////Employee user = new Employee { Id = 4, Name = "Abhay", Age = 35 };
//////////////user.Show();

////////////////list is dynamic array which can grow and shrink in size
////////////////Array is fixed size data structure
////////////////C# base does not support dynamic array but we can use List<T> which is implemented using array internally and provides dynamic resizing functionality

//////////////// List also use internally array to store data
//////////////// but it provides dynamic resizing functionality,
//////////////// which means that it can grow and shrink in size as needed.
//////////////// When you add an element to a List<T>, it checks if there is enough space in the underlying array. If there is, it simply adds the element. If there isn't, it creates a new array with a larger size, copies the existing elements to the new array, and then adds the new element.
////////////////Collection
////////////////type of collections
////////////////1. List<T>
////////////////2. Dictionary<TKey, TValue>
////////////////3. HashSet<T>
////////////////4. Queue<T>
////////////////5. Stack<T>
////////////////6. LinkedList<T>

//////////////List<int> numbers = new List<int>(100000);




////////////////Console.WriteLine($"numbers capasity:{numbers.Capacity} , size:{numbers.Count} ");
////////////////numbers.Add(1);
////////////////Console.WriteLine($"numbers capasity:{numbers.Capacity} , size:{numbers.Count} "); 
////////////////numbers.Add(2);
////////////////numbers.Add(3);
////////////////numbers.Add(4);

////////////////Console.WriteLine($"numbers capasity:{numbers.Capacity} , size:{numbers.Count} ");
//////////////////if(capacity > size)
//////////////////{
//////////////////    var internalArray=    new int[numbers.Capacity*2];
//////////////////    for(int i=0;i<numbers.Count;i++)
//////////////////    {
//////////////////        internalArray[i]=numbers[i];
//////////////////    }
//////////////////     numbers = new List<int>(internalArray);
//////////////////}
////////////////numbers.Add(5);

////////////////Console.WriteLine($"numbers capasity:{numbers.Capacity} , size:{numbers.Count} ");
////////////////numbers.Add(6);
////////////////numbers.Add(7);
////////////////numbers.Add(8);

////////////////Console.WriteLine($"numbers capasity:{numbers.Capacity} , size:{numbers.Count} ");
////////////////numbers.Add(9);

////////////////Console.WriteLine($"numbers capasity:{numbers.Capacity} , size:{numbers.Count} ");


////////////////var resultS=StringLogic.GetDataByConditionString(names, (string name) => name.Contains("h", StringComparison.OrdinalIgnoreCase));

////////////////StringLogic.Print(resultS);

//////////////////NumberLogic.PrintNumberIfexists(array, 3);
//////////////////NumberLogic.PrintNumberIfexists(array, 4);

//////////////////var result=NumberLogic.GetDataByConditionGreateNumber(array, 3);

////////////////var result = NumberLogic.GetDataByConditionNumber(array, (x) => x > 3);

////////////////NumberLogic.Print(result);

//////////////////result = NumberLogic.GetDataByConditionLessNumber(array, 5);

////////////////result = NumberLogic.GetDataByConditionNumber(array, (int x)=>x<5);


////////////////Console.WriteLine("Print less 5");
////////////////NumberLogic.Print(result);


////////////////result = NumberLogic.GetDataByConditionNumber(array, (int x) => x % 2==0);


////////////////Console.WriteLine("Print Event number");
////////////////NumberLogic.Print(result);

////////////////result = NumberLogic.GetDataByConditionNumber(array, (int x) => x % 2 == 1);


////////////////Console.WriteLine("Print Odd number");
////////////////NumberLogic.Print(result);


////////////////Console.WriteLine("Print Odd number");
////////////////var result = CommonLogic.GetDataByCondition(array, (int x) => x % 2 == 1);
////////////////CommonLogic.Print(result);

////////////////Console.WriteLine("Print Odd number");
////////////////array
////////////////    .GetDataByCondition((int x) => x % 2 == 1)
////////////////    .Print();  //fluent syntax
////////////////names
////////////////    .GetDataByCondition((string x) => x.StartsWith("A"))
////////////////    .Print();

////////////////salary.GetDataByCondition((double x) => x > 2000).Print();

////////////////Employee employee = new Employee { Id = 5, Name = "Rohit", Age = 32 };

////////////////Console.WriteLine(employee);
//////////////employees
//////////////    .Where((emp) => emp.Age > 28)
//////////////    .Print();

//////////////numbers
//////////////    .GetDataByWhereCondition((x) => x > 28)
//////////////    .Print();

////////////////Func vs Action vs Predicate
////////////////Func: A Func delegate represents a method that returns a value and can take parameters. It can have up to 16 parameters, and the last type parameter specifies the return type. For example, Func<int, int, int> represents a method that takes two integers as input and returns an integer as output.

////////////////Every Array and COllection are inherited from IEnumrable 
//////////////// IEnumbrable has Method which return IEnumerator which has MoveNext, Reset Method and Current property

////////////////string
////////////////Split , Join
////////////////Contains, StartsWith, EndsWith, Substring, ToUpper, ToLower, Trim, Replace, IndexOf, LastIndexOf, Length, IsNullOrEmpty, IsNullOrWhiteSpace
////////////////collection
//////////////// Add , Remove, Clear, Contains, Count, Capacity, IndexOf, LastIndexOf, Insert, RemoveAt, Sort, Reverse, ToArray, ToList
////////////////Example 

//////////using LearningBasics;
//////////using System.ComponentModel.DataAnnotations;

/////////////
//////////var emp=new Employee { Id = 1, Name = "Su", Age = 19, Gender= "K", CanMarry=true, DepartmentId = 4 };

////////////var isValid = ValidationClass.ValidateUser(emp);
////////////if(isValid)
////////////{
////////////    Console.WriteLine("User is valid");
////////////}
////////////else
////////////{
////////////    Console.WriteLine("User is not valid");
////////////}

//////////var context = new ValidationContext(emp);
////////using LearningBasics;
////////using System.ComponentModel.DataAnnotations;

////////ICollection<ValidationResult> results = new List<ValidationResult>();
////////var isValid = Validator.TryValidateObject(emp, context, results, true);

//////////results.AddRange(emp.Validate(context));
////////Organization organization = new Organization();
////////var emp1 = new Employee { Id = 1, Name = "Su", Age = 19 };
//////////organization.Employee =emp1;    //Property Injection


////////if (isValid)
////////{
////////    Console.WriteLine("User is valid");
////////}
////////else
////////{
////////    Console.WriteLine("User is not valid");
////////    foreach (var validationResult in results)
////////    {
////////        Console.WriteLine(validationResult.ErrorMessage);
////////    }
////////}

////////////Service Loator  ->   Runtime Dependency Resolution
////////////Dependency Injection ->  Compile time Dependency Resolution
////////////, Inversion of Control, Aspect Oriented Programming, SOLID Principles, Design Patterns, Gang of Four Design Patterns, Creational Design Patterns, Structural Design Patterns, Behavioral Design Patterns, Singleton Pattern, Factory Pattern, Abstract Factory Pattern, Builder Pattern, Prototype Pattern, Adapter Pattern, Bridge Pattern, Composite Pattern, Decorator Pattern, Facade Pattern, Flyweight Pattern, Proxy Pattern, Chain of Responsibility Pattern, Command Pattern, Interpreter Pattern, Iterator Pattern, Mediator Pattern, Memento Pattern, Observer Pattern, State Pattern, Strategy Pattern, Template Method Pattern, Visitor Pattern


////////using LearningBasics;

////////var emp = new User { Id = 1, Name = "Su" };
//////////Dependency resolved by third party or by framework like ASP.NET Core, Blazor, WPF, Xamarin, MAUI etc
//////////third party .net framework - unity 
//////////Innversion of Control - Dependency Injection - Aspect Oriented Programming - SOLID Principles - Design Patterns


////////Constructor Injection

//////using LearningBasics;
//////using Microsoft.Extensions.DependencyInjection;
//////using Microsoft.Extensions.Hosting;

////////Host may consider as a container which can manage the lifetime of objects
////////and their dependencies

//////var host = Host.CreateDefaultBuilder(args);

//////var app=host.ConfigureServices(services =>
//////{
//////    services.AddSingleton<DepartmentRepository>();  //Department repository will get creted only once and will be shared across the application
//////    services.AddScoped<User>();
//////    services.AddTransient<Organization>();
//////    services.AddTransient<IDepartmentRepository,DepartmentRepository>();   //Department repository will get creted only once and will be shared across the application
//////    services.AddKeyedSingleton<IUserRepository,UserRepository>("InMemory");
//////    services.AddKeyedSingleton<IUserRepository, UserDataBaseRepository>("InDB");

//////}).Build();

////////factory method pattern - design pattern which provides an interface for creating objects in a super class but allows subclasses to alter the type of objects that will be created
//////var org = app.Services.GetRequiredService<Organization>();

//////org.Employee.Name = "Sayu";

//////for(int i=0;i<5;i++)
//////{
//////    var dept2 = app.Services.GetRequiredService<IDepartmentRepository>();
//////    Console.WriteLine(dept2.GetDepartmentById(1));
//////}


//////var name = "InMemory";
////////Services 
////////Service Locator -  Runtime Dependency Resolution
//////var userRepo = app.Services.GetRequiredKeyedService<IUserRepository>(name);

//////userRepo.GetUserById(1);
////////Dependency Injection - Compile time Dependency Resolution
//////var dept = app.Services.GetRequiredService<IDepartmentRepository>();
//////Console.WriteLine(org.Employee.Name);
////////MVC => Model View Controller

//////// MOdel + Services + REpositories + Controllers + Views

////////Composition Root - Application entry point where we compose all the dependencies together and build the object graph
////////Association - Dependency Inversion Principle - SOLID Principles - Design Patterns - Gang of Four Design Patterns - Creational Design Patterns - Structural Design Patterns - Behavioral Design Patterns - Singleton Pattern - Factory Pattern - Abstract Factory Pattern - Builder Pattern - Prototype Pattern - Adapter Pattern - Bridge Pattern - Composite Pattern - Decorator Pattern - Facade Pattern - Flyweight Pattern - Proxy Pattern - Chain of Responsibility Pattern - Command Pattern - Interpreter Pattern - Iterator Pattern - Mediator Pattern - Memento Pattern - Observer Pattern - State Pattern - Strategy Pattern - Template Method Pattern - Visitor Pattern
////////Inversion of Control - Dependency Injection - Aspect Oriented Programming - SOLID Principles - Design Patterns - Gang of Four Design Patterns - Creational Design Patterns - Structural Design Patterns - Behavioral Design Patterns - Singleton Pattern - Factory Pattern - Abstract Factory Pattern - Builder Pattern - Prototype Pattern - Adapter Pattern - Bridge Pattern - Composite Pattern - Decorator Pattern - Facade Pattern - Flyweight Pattern - Proxy Pattern - Chain of Responsibility Pattern - Command Pattern - Interpreter Pattern - Iterator Pattern - Mediator Pattern - Memento Pattern - Observer Pattern - State Pattern - Strategy Pattern - Template Method Pattern - Visitor Pattern
////////Dependency Inversion Principle - SOLID Principles - Design Patterns - Gang of Four Design Patterns - Creational Design Patterns - Structural Design Patterns - Behavioral Design Patterns - Singleton Pattern - Factory Pattern - Abstract Factory Pattern - Builder Pattern - Prototype Pattern - Adapter Pattern - Bridge Pattern - Composite Pattern - Decorator Pattern - Facade Pattern - Flyweight Pattern - Proxy Pattern - Chain of Responsibility Pattern - Command Pattern - Interpreter Pattern - Iterator Pattern - Mediator Pattern - Memento Pattern - Observer Pattern - State Pattern - Strategy Pattern - Template Method Pattern - Visitor Pattern
////////Dependency Injection - SOLID Principles - Design Patterns - Gang of Four Design Patterns - Creational Design Patterns - Structural Design Patterns - Behavioral Design Patterns - Singleton Pattern - Factory Pattern - Abstract Factory Pattern - Builder Pattern - Prototype Pattern - Adapter Pattern - Bridge Pattern - Composite Pattern - Decorator Pattern - Facade Pattern - Flyweight Pattern - Proxy Pattern - Chain of Responsibility Pattern - Command Pattern - Interpreter Pattern - Iterator Pattern - Mediator Pattern - Memento Pattern - Observer Pattern - State Pattern - Strategy Pattern - Template Method Pattern - Visitor Pattern
////////Service Locator - Runtime Dependency Resolution - SOLID Principles - Design Patterns - Gang of Four Design Patterns - Creational Design Patterns - Structural Design Patterns - Behavioral Design Patterns - Singleton Pattern - Factory Pattern - Abstract Factory Pattern - Builder Pattern - Prototype Pattern - Adapter Pattern - Bridge Pattern - Composite Pattern - Decorator Pattern - Facade Pattern - Flyweight Pattern - Proxy Pattern - Chain of Responsibility Pattern - Command Pattern - Interpreter Pattern - Iterator Pattern - Mediator Pattern - Memento Pattern - Observer Pattern - State Pattern - Strategy Pattern - Template Method Pattern - Visitor Pattern
//////////COnstroctor Injection - Association - Dependency Inversion Principle - SOLID Principles - Design Patterns - Gang of Four Design Patterns - Creational Design Patterns - Structural Design Patterns - Behavioral Design Patterns - Singleton Pattern - Factory Pattern - Abstract Factory Pattern - Builder Pattern - Prototype Pattern - Adapter Pattern - Bridge Pattern - Composite Pattern - Decorator Pattern - Facade Pattern - Flyweight Pattern - Proxy Pattern - Chain of Responsibility Pattern - Command Pattern - Interpreter Pattern - Iterator Pattern - Mediator Pattern - Memento Pattern - Observer Pattern - State Pattern - Strategy Pattern - Template Method Pattern - Visitor Pattern
/////////Settor/Method Injection - Association - Dependency Inversion Principle - SOLID Principles - Design Patterns - Gang of Four Design Patterns - Creational Design Patterns - Structural Design Patterns - Behavioral Design Patterns - Singleton Pattern - Factory Pattern - Abstract Factory Pattern - Builder Pattern - Prototype Pattern - Adapter Pattern - Bridge Pattern - Composite Pattern - Decorator Pattern - Facade Pattern - Flyweight Pattern - Proxy Pattern - Chain of Responsibility Pattern - Command Pattern - Interpreter Pattern - Iterator Pattern - Mediator Pattern - Memento Pattern - Observer Pattern - State Pattern - Strategy Pattern - Template Method Pattern - Visitor Pattern
/////////Property Injection - Association - Dependency Inversion Principle - SOLID Principles - Design Patterns - Gang of Four Design Patterns - Creational Design Patterns - Structural Design Patterns - Behavioral Design Patterns - Singleton Pattern - Factory Pattern - Abstract Factory Pattern - Builder Pattern - Prototype Pattern - Adapter Pattern - Bridge Pattern - Composite Pattern - Decorator Pattern - Facade Pattern - Flyweight Pattern - Proxy Pattern - Chain of Responsibility Pattern - Command Pattern - Interpreter Pattern - Iterator Pattern - Mediator Pattern - Memento Pattern - Observer Pattern - State Pattern - Strategy Pattern - Template Method Pattern - Visitor Pattern

////////compile time - Dependency Injection - Constructor Injection, Setter/Method Injection, Property Injection
////////run time - Service Locator




//////var org1 = new Organization(new User { }); //  composition root - application entry point where we compose all the dependencies together and build the object graph


////// Pipelines or Middle ware - ASP.NET Core, Blazor, WPF, Xamarin, MAUI etc


////using LearningBasics;

////var builder = new ApplicationBuilder();


////builder.Use(async (context, next) =>
////{
////    Console.WriteLine("Middleware 1 - Before" + context.Request);

////    context.Request = "Middleware 1 - Before" + context.Request;
////    await next();
////    Console.WriteLine("Middleware 1 - After");
////});


////builder.Use(async (context, next) =>
////{
////    Console.WriteLine("Middleware 2 - Before" + context.Request);
////    context.Request= "Middleware 2 - Before" + context.Request;
////    await next();
////    Console.WriteLine("Middleware 2 - After");
////});


////builder.Use(async (context, next) =>
////{
////    Console.WriteLine("Middleware 3 - Before" + context.Request);
////    context.Request = "Middleware 3 - Before" + context.Request;
////    await next();
////    Console.WriteLine("Middleware 3 - After");
////});

////var app = builder.Build();

////await app(new LearningBasics.AppContext
////{
////    Request = "Hello Pipeline"
////});



//using LearningBasics;

//TempExample.Print((num, value) =>
//{
//    return num * 2;
//});


//var a= new LearningBasics.AppContext
//{
//    Request = "Hello Pipeline"
//};

//var myD2fun=new MyD2((a) =>
//{
//    return 3;
//});

//TempExample.Print((myD2fun),a);


using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

//""

//Console.WriteLine(result);


var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlNheXUiLCJYWFgiOiJBZG1pbiIsIkFkZHJlc3MiOiJBZG1pbiIsInJvbGUiOiJBZG1pbiIsIm5iZiI6MTc3OTYwMzQxNywiZXhwIjoxNzc5NjA3MDE3LCJpYXQiOjE3Nzk2MDM0MTcsImlzcyI6Im15SXNzdWVyIiwiYXVkIjoibXlBdWRpZW5jZSJ9.EmDkNSu_Yx3jbfHbh3ClLBGkh7oXdNqsghpKZdrgda8";


//validate output of JIT with cache value of UUID and if it matches then allow access otherwise deny access and ask user to login again to generate new token with new role and update the cache with new UUID
//when user role change then remove key of user from cache and when user login again then generate new token with new role and update the cache with new UUID

//Console.WriteLine(claimPrinsiple.Identity.Name);

//foreach (var item in claimPrinsiple.Claims)
//{
//    Console.WriteLine($"{item.Value}");
//}

//var data=claimPrinsiple.IsInRole("Admin");






