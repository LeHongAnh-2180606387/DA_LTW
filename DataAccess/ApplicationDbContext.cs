namespace VoLeAnhTien_2180604444_Tuan6.DataAccess;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VoLeAnhTien_2180604444_Tuan6.Models;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }

    public DbSet<ApplicationUser> applicationUsers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
}

