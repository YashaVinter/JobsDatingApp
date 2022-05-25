using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using JobsDatingApp.ViewModels;
using JobsDatingApp.Data.Models;
using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Data.mocks;
using JobsDatingApp.Data;
using JobsDatingApp.Data.Repository;
using JobsDatingApp.Data.SeedData;
using JobsDatingApp.Data.SeedData.Implementation.HH_WEB_API;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//DB
builder.Services.AddSingleton<MockDataBase>();
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connection));
//Services
builder.Services.AddTransient<ICompaniesRepository, CompaniesRepository>(); // MockCompanies
builder.Services.AddTransient<IVacanciesRepository, VacanciesRepository>(); // MockVacancies
builder.Services.AddTransient<IUsersRepository, UsersRepository>(); // MockUsers

builder.Services.AddScoped<VacancyViewModel>();
builder.Services.AddDistributedMemoryCache();// добавляем IDistributedMemoryCache
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(); // .AddCookie(options => options.LoginPath="/login");
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
using (var scope = app.Services.CreateScope())
{
    AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
    string hhRequestUri = "https://api.hh.ru/vacancies?text=developer&area=113";
    var seedData = new DBSeed(new HHDBSeed(hhRequestUri));
    seedData.Initial(context);
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