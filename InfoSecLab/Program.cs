using InfoSecLab.Components;
using System.Security.Cryptography.X509Certificates;
using InfoSecLab.Models;
using Microsoft.EntityFrameworkCore;
namespace InfoSecLab
{
    public class Program
    {
        public static String Pepper { get; private set; }
        public static void Main(String[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddDbContext<InfoSecDemoContext>(options =>
            {
                options.UseMySQL(builder.Configuration
                    .GetConnectionString("DefaultConnection")!);
#if DEBUG
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
#endif
            });
            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            Pepper = app.Configuration["Pepper"]!;
            app.Run();
        }
    }
}
