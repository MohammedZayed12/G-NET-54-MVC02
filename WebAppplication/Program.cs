using Microsoft.EntityFrameworkCore;
using GymManagement;
using GymManagment.DataAccess.SeedData;
using GymManagement.AppDpContext;
using MVC.Presentation.Repository;

namespace GymManagement;

public class Program
{
    public static async Task Main(string[] args)
    {
            var builder = global::Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Register DbContext so controllers can receive AppDpContext via DI
            var connection= builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<GymManagement.AppDpContext.AppDpContext>(options =>
         options.UseSqlServer(connection));

        builder.Services.AddScoped<MVC.Presentation.Reposatiry.IplanRepository, PlanRepository>();
        var app = builder.Build();
        using (var scope = app.Services.CreateScope())
        {
            var dbContext =
           scope.ServiceProvider.GetRequiredService<GymManagement.AppDpContext.AppDpContext>();

            await PlanSeeder.SeedPlansAsync(dbContext);
        }
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
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
