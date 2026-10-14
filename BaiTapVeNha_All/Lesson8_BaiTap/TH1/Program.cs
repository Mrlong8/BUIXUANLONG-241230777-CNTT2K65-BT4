using Microsoft.EntityFrameworkCore;
using TH1.Models.BusinessModels;

namespace TH1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("BookStoreDbv2Context") ?? throw new InvalidOperationException("Connection string 'BookStoreDbv2Context' not found.");

            builder.Services.AddDbContext<BookStoreDbv2Context>(options => options.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            //builder.Services.AddDbContext<BookStoreDbv2Context>(options => 
            //options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreDBV2")));

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
        }
    }
}
