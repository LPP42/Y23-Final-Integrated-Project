global using Lab3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<StoreDBContext>(opt => opt.UseLazyLoadingProxies().UseSqlite(
    builder.Configuration.GetConnectionString("StoreDB"))
);

// var dbmsVersion = new MariaDbServerVersion(builder.Configuration.GetValue<string>("DBMSVersion"));
// var connString = builder.Configuration.GetConnectionString("StoreDBContext");

// builder.Services.AddDbContext<StoreDBContext>(options =>
// 	 options.UseLazyLoadingProxies().UseMySql(connString, dbmsVersion));

builder.Services.AddDefaultIdentity<HikeUser>(options => options.SignIn.RequireConfirmedAccount = true)
	 .AddEntityFrameworkStores<StoreDBContext>();



builder.Services.AddControllers();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapControllers();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
