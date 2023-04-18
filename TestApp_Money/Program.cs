using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestApp_Money.DataAccess.MsSql;
using TestApp_Money.Entites.Models;
using TestApp_Money.Infrastructure.Interfaces.DataAccessInterfaces;
using TestApp_Money.UseCases;
using TestApp_Money.UseCases.Common;
using TestApp_Money.Web.Command.MapperProfiles;

namespace TestApp_Money.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddUseCases();

            string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;

            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(connection);
            });

            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddTransient<IDbContext, ApplicationDbContext>();

            builder.Services.AddAutoMapper(
                typeof(CategoryMapperProfile),
                typeof(MapperProfile));

            var app = builder.Build();



            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}