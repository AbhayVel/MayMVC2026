using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var jwtkey = "mysecretkey1234567890mysecretkey1234567890";
// Add services to the container.

//builder.Services.AddDbContext<JWTExampleApi.DataBaseCOntext.UserDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddDbContext<JWTExampleApi.DataBaseCOntext.UserDbContext>(options =>
    options.UseInMemoryDatabase("UserDataBase"));

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = false,
            ValidIssuer = "myIssuer",
            ValidAudience = "myAudience",
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtkey)),
            // ClockSkew = TimeSpan.Zero
        };
    });
// builder.Services.AddAuthorization();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((option) =>
{
    option.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    option.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });


});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<JWTExampleApi.DataBaseCOntext.UserDbContext>();
    dbContext.Database.EnsureCreated();

    if (!dbContext.Roles.Any())
    {
        dbContext.Roles.Add(new JWTExampleApi.Entitties.Role
        {
            RoleName = "Admin"
        });
        dbContext.Roles.Add(new JWTExampleApi.Entitties.Role
        {
            RoleName = "User"
        });
        dbContext.SaveChanges();
    }


    if (!dbContext.Users.Any())
    {
        dbContext.Users.Add(new JWTExampleApi.Entitties.UserData
        {
            UserName = "admin",
            Password = "password",
            RoleID = 1
        });
        dbContext.Users.Add(new JWTExampleApi.Entitties.UserData
        {
            UserName = "user",
            Password = "password",
            RoleID = 2
        });
        dbContext.SaveChanges();
    }

      
}

// Configure the HTTP request pipeline.

app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
