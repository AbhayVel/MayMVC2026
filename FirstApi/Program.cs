using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var jwtkey = "mysecretkey1234567890mysecretkey1234567890";

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.Use((conext, next) =>
//{
//    return next(conext);
//});

app.Use(async (context, next) =>
{
    if(context.Request.Path == "/")
    {
        await context.Response.WriteAsync("Hello World!");
        await Task.CompletedTask;
    }
    else
    {
        await next(context);
    }
});


app.Map("/",async (context) =>
{
    
        //await context.Response.WriteAsync("Hello World!");
        context.Response.Redirect("/home");
        await Task.CompletedTask;
    
     
});

app.Run(async (context) =>
{
    if (context.Request.Path == "/")
    {
        await context.Response.WriteAsync("Hello World!");
        await Task.CompletedTask;
    }
    else
    {
        await Task.CompletedTask;
    }
});

//app.Run(async (context, next) =>
//{
//    if (context.Request.Path == "/")
//    {
//        await context.Response.WriteAsync("Hello World!");
//        await Task.CompletedTask;
//    }
//    else
//    {
//        await next(context);
//    }
//});



//List<int> lstNumber = new List<int>() { 1, 2, 3, 4, 5 };

//var result = lstNumber.Where((x) =>
//{
//    return true;
//});

//app.Map("/", (context) =>
//{

//});

//app.Use((context,next) =>
//{
//      return next(context);
//});

//app.Use(async (context, next) =>
//{
//    await next(context);
//});



app.UseAuthorization();

app.MapControllers();

app.Run();
