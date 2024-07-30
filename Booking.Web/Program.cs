using Booking.DataAccess.Models;
using Booking.Services;

namespace Booking.Web
{
    public class Program
    {
        public Program(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddHttpClient(); // Menambahkan HttpClientFactory
        }

        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<BookingCodeProvider>();
            builder.Services.AddScoped<ResourceProvider>();
            builder.Services.AddScoped<RoomProvider>();
            builder.Services.AddScoped<UserProvider>();
            builder.Services.AddScoped<RoleProvider>();
            builder.Services.AddScoped<GlobalSetupProvider>();
            builder.Services.AddScoped<ResourceCodeProvider>();
            builder.Services.AddScoped<BookingContext>();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}