using Lab1.Data;
using Lab1.Entities.Hamburgers;
using Lab1.Services.FoodBuilder;
using Lab1.Services.FoodManager;
using Lab1.Services.UserInteractor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lab1;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<ApplicationContext>()
            .AddSingleton<DbContext, ApplicationContext>()
            .AddSingleton<App, App>()
            .AddSingleton(typeof(IRepository<>), typeof(Repository<>))
            .AddTransient<FoodBuilderBase<Hamburger>, HamburgerBuilderService>()
            .AddTransient<HamburgerBuilderService, HamburgerBuilderService>()
            .AddTransient<IUserInteractor, UserInteractor>()
            .AddTransient(typeof(IFoodManagerService<>),typeof(FoodManagerService<>))
            .BuildServiceProvider();
    
        var app = serviceProvider.GetRequiredService<App>();
        await app.Run();
    }
}