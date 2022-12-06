using Microsoft.EntityFrameworkCore;
using PjA2Tp3.Helper;
using PjA2Tp3.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TpContext>(options =>
{
    options.UseSqlServer("Data Source=DESKTOP-9O4PDO6\\SQLEXPRESS;Initial Catalog=TpIII;Integrated Security=True;Encrypt=false");
});

builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<ISessao, Sessao>();

builder.Services.AddSession( o =>
{
    o.Cookie.HttpOnly= true;
    o.Cookie.IsEssential= true;
});  

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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
