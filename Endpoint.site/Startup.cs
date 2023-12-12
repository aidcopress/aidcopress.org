using aidcopress.org.Application.Interfaces.Contexts;
using aidcopress.org.Application.Services.Users.Commands;
using aidcopress.org.Application.Services.Users.Commands.RegisterUser;
using aidcopress.org.Application.Services.Users.Queries.GetPersonelHolidays;
using aidcopress.org.Application.Services.Users.Queries.GetRoles;
using aidcopress.org.Application.Services.Users.Queries.GetUser;
using aidcopress.org.Persistence.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {




        services.AddAuthentication(options =>
        {
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        }).AddCookie(options =>
        {
            options.LoginPath = new PathString("/");
            options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
        });





        services.AddScoped<IDataBaseContext, DataBaseContext>();
        services.AddScoped<IGetPersonelService, GetPersonelService>();
        services.AddScoped<IGetRolesService, GetRolesService>();
        services.AddScoped<IRegisterUserService, RegisterUserService>();
        services.AddScoped<IUserLoginService, UserLoginService>();
        services.AddScoped<IGetPersonelHolidaysService, GetPersonelHolidaysService>();

       

        string connectionString = "Data Source=.; Initial Catalog=aidcopress.org; User ID = sa; password = 6449 ;TrustServerCertificate=True;";
        services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(Option => Option.UseSqlServer(connectionString));//در اینجا دی بی کانتکس که در پرسیستنس ساختیم را اضافه میکنیم

        services.AddControllersWithViews();

        services.AddRazorPages();
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();
        app.UseAuthentication();



        app.MapControllerRoute(
         name: "default",
         pattern: "{controller=Home}/{action=Index}/{id?}");



        app.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=personel}/{action=Personel}/{id?}");


        app.Run();
    }
}