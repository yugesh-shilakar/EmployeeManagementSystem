using EmployeeManagementSystem.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
var connectionString = configuration.GetConnectionString("conn");
builder.Services.AddSingleton<IEmployeeRepository>(new EmployeeRepository(connectionString));
builder.Services.AddSingleton<IUserRepository>(new UserRepository());
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
