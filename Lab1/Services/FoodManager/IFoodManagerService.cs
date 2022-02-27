using Lab1.Entities.Hamburgers;
using Lab1.Entities.Recipes;
using Lab1.Services.FoodBuilder;

namespace Lab1.Services.FoodManager;

public interface IFoodManagerService<in T, TRecipe> where T : IFood<TRecipe> where TRecipe : BaseRecipe
{
    public void SetBuilder(IFoodBuilderService<T, TRecipe> foodBuilderService);
    void ComposeOrder();
}