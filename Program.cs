using FavTVShow2.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Configure Database

var connectString = builder.Configuration.GetConnectionString("FavoriteTvShowsDbConnection");
builder.Services.AddDbContext<FavoriteTvShowsDbContext>(options => options.UseSqlServer(connectString));

#endregion

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TvShow}/{action=Index}/{id?}");

app.Run();
