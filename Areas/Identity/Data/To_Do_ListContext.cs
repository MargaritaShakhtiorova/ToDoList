using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using To_Do_List.Areas.Identity.Data;
using To_Do_List.Models;

namespace To_Do_List.Data;

public class To_Do_ListContext : IdentityDbContext<To_Do_ListUser>
{
    public To_Do_ListContext(DbContextOptions<To_Do_ListContext> options)
        : base(options)
    {
    }

    public DbSet<To_Do_ListUser> to_Do_ListUsers { get; set; }
    public DbSet<UserTask> UserTasks { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
