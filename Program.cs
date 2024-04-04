using VoLeAnhTien_2180604444_Tuan6.DataAccess;
using Microsoft.EntityFrameworkCore;
using VoLeAnhTien_2180604444_Tuan6.Respository;
using Microsoft.AspNetCore.Identity;
using VoLeAnhTien_2180604444_Tuan6.Models;

var builder = WebApplication.CreateBuilder(args);
// Đặt trước AddControllersWithViews();
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddDefaultTokenProviders().AddDefaultUI()
.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.LogoutPath = $"/Identity/Account/AccessDenied";
});

builder.Services.AddSingleton<CartService>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;
app.UseSession();
app.UseAuthorization();
app.MapRazorPages();
app.UseEndpoints(endpoints =>
{ 
    endpoints.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=ProductManager}/{action=Index}/{id?}"
        );
});
app.MapControllerRoute( 
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
