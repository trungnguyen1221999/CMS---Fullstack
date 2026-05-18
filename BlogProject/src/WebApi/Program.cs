using System.Reflection;
using BlogProject.Api;
using BlogProject.Core.Domain.Identity;
using BlogProject.Core.Repositories;
using BlogProject.Core.SeedWorks;
using BlogProject.Data;
using BlogProject.Data.Repositories;
using BlogProject.Data.SeedWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddScoped(typeof(IRepository<,>), typeof(RepositoryBase<,>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add business services and repositories

var dataAssembly = Assembly.GetAssembly(typeof(PostRepository));

//Scan and retrieve all concrete, non-abstract classes ending with "Repository"
var repositories = dataAssembly
    .GetTypes()
    .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Repository"));

foreach (var repository in repositories)
{
    // Find the corresponding interface by naming convention (e.g., PostRepository matches IPostRepository)
    var iRepository = repository
        .GetInterfaces()
        .FirstOrDefault(i => i.Name == $"I{repository.Name}");

    if (iRepository != null)
    {
        builder.Services.AddScoped(iRepository, repository);
    }
}

//Config DB Context and ASP.NET Core Identity
builder.Services.AddDbContext<BlogContext>(options => options.UseNpgsql(connectionString));

builder
    .Services.AddIdentity<AppUser, AppRole>(options =>
        options.SignIn.RequireConfirmedAccount = false
    )
    .AddEntityFrameworkStores<BlogContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

//Default config for ASP.NET Core
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Seeding Data to DB

app.MigrationDataBase();

app.Run();