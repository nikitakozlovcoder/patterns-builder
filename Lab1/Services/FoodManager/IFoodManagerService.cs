using Lab1.Entities.Hamburgers;
using Lab1.Services.FoodBuilder;

namespace Lab1.Services.FoodManager;

public interface IFoodManagerService<T> where T : IFood
{
    T ComposeOrder();
}