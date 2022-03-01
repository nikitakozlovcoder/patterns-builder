using Lab1.Constants;
using Lab1.Data;
using Lab1.Entities.Hamburgers;
using Lab1.Services.FoodBuilder;
using Lab1.Services.FoodManager;
using Lab1.Services.UserInteractor;
using Microsoft.EntityFrameworkCore;

namespace Lab1;

public class App
{
    private readonly IUserInteractor _userInteractor;
    private readonly IFoodManagerService<Hamburger> _foodManagerService;
    private readonly IRepository<Hamburger> _hamburgerRepository;

    public App(
        IUserInteractor userInteractor, 
        IFoodManagerService<Hamburger> foodManagerService, 
        IRepository<Hamburger> hamburgerRepository)
    {
        _userInteractor = userInteractor;
        _foodManagerService = foodManagerService;
        _hamburgerRepository = hamburgerRepository;
    }

    public async Task Run()
    {
       await  _userInteractor.Start(async x =>
        {
            switch (x)
            {
                case ActionTypes.ListFood:
                    await ListFood();
                    break;
                case ActionTypes.CreateFood:
                    await CreateFood();
                    break;
                case ActionTypes.Exit:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(x), x, null);
            }
            return x != ActionTypes.Exit;
        });
        
    }

    private async Task ListFood()
    {
        var hamburgers = await _hamburgerRepository.QueryableSelect()
            .Include(x => x.HamburgerRecipe).ToArrayAsync();
        foreach (var hamburger in hamburgers)
        {
            _userInteractor.ShowFood(hamburger);
        }
    }

    private async Task CreateFood()
    {
        var hamburger = _foodManagerService.ComposeOrder();
        _userInteractor.ShowFood(hamburger);
        var save = _userInteractor.ShouldSave();
        if (save)
        {
           await _hamburgerRepository.Create(hamburger, CancellationToken.None);
        }

    }
}