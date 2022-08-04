using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using To_Do_List.Areas.Identity.Data;
using To_Do_List.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("To_Do_ListContextConnection") ?? throw new InvalidOperationException("Connection string 'To_Do_ListContextConnection' not found.");

builder.Services.AddDbContext<To_Do_ListContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<To_Do_ListUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<To_Do_ListContext>();

// Add services to the container.
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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
