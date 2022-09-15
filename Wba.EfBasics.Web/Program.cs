using Microsoft.EntityFrameworkCore;
using Wba.EfBasics.Web.Data;
using Wba.EfBasics.Web.Services;
using Wba.EfBasics.Web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register our own DbContext. It can now be injected and used by EF tooling.
//register session
builder.Services.AddSession();
//add HttpContextAccessor
//in order to access HTttpContext
//from service classes or ViewComponents
builder.Services.AddHttpContextAccessor();
//register DbContext for Dependency Injection
builder.Services.AddDbContext<SchoolDbContext>(
    options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("SchoolDb"))
    );
//register own services
builder.Services.AddTransient<ISessionServices, SessionService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();