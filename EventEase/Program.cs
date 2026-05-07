using EventEase.Data;
using EventEase.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddSingleton<BlobService>(new BlobService
// (builder.Configuration.GetConnectionString("AzureBlobStorage")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

//Referencing
//
//Microsoft(2024) SQL Langauage Referencing. Available at:
//https://docs.oracle.com (accessed: 7 May 2026)
//
//Mrzyglod, K.(2022) Azure for Developers. Birmingham: Packt Publishing.
