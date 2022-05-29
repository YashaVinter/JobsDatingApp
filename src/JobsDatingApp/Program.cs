using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Data;
using JobsDatingApp.Data.Repository;
using JobsDatingApp.Data.SeedData;
using JobsDatingApp.Data.SeedData.Implementation.HH_WEB_API;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add database services
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connection));
// Adding services for working with database
builder.Services.AddTransient<ICompaniesRepository, CompaniesRepository>(); // MockCompanies
builder.Services.AddTransient<IVacanciesRepository, VacanciesRepository>(); // MockVacancies
builder.Services.AddTransient<IUsersRepository, UsersRepository>();         // MockUsers

builder.Services.AddDistributedMemoryCache();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(); // .AddCookie(options => options.LoginPath="/login");
builder.Services.AddAuthorization();
// Building App
var app = builder.Build();
// Add seed data to Database
using (var scope = app.Services.CreateScope())
{
    AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
    string hhRequestUri = "https://api.hh.ru/vacancies?text=developer&area=113";
    var seedData = new DBSeed(new HHDBSeed(hhRequestUri));
    seedData.Initial(context);
}
// Adding middlewares to app
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();