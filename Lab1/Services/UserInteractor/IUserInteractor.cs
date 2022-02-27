using Lab1.Constants;
using Lab1.Constants.Ingredients;
using Lab1.Dto;
using Lab1.Entities.Hamburgers;
using Lab1.Entities.Recipes;

namespace Lab1.Services.UserInteractor;

public interface IUserInteractor
{
    public Task Start(Func<ActionTypes, Task<bool>> handler);
    void GetIngredientType<T>(Func<CreateFoodDto<T>, bool> handler, string option) where T : struct, Enum;
    string GetName();
    void ShowFood<T>(IFood<T> food) where T : BaseRecipe;
    bool ShouldSave();
}