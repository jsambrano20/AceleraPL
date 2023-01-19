using Aula01_MVCfull.Data;
using Aula01_MVCfull.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContextcs>();
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

builder.Services.
    AddEntityFrameworkSqlServer().
    AddDbContext<AppDbContextcs>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddScoped<IContatoRepository,ContatoRepository>();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
