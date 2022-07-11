using BurgerWebApp.DataAccess.Abstraction;
using BurgerWebApp.DataAccess.Repositories;
using BurgerWebApp.Domain;
using BurgerWebApp.Services.Abstraction;
using BurgerWebApp.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddTransient<IBurgerService, BurgerService>();
builder.Services.AddTransient<IExtraService, ExtraService>();
builder.Services.AddTransient<IOrderService, OrderService>();

builder.Services.AddTransient<IRepository<Burger>, BurgerRepository>();
builder.Services.AddTransient<IRepository<Extra>, ExtraRepository>();
builder.Services.AddTransient<IRepository<Order>, OrderRepository>();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
