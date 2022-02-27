using System.Globalization;
using Lab1.Constants.Ingredients;
using Lab1.Entities.Hamburgers;
using Lab1.Entities.Recipes;

namespace Lab1.Services.FoodBuilder;

public interface IFoodBuilderService<out T, TRecipe> where T : IFood<TRecipe> where TRecipe : BaseRecipe
{
    public IFoodBuilderService<T, TRecipe> AddBread(BreadTypes type);
    public IFoodBuilderService<T, TRecipe> AddSauce(SauceTypes type);
    public IFoodBuilderService<T,TRecipe> AddVegetables(VegetablesTypes type);
    public IFoodBuilderService<T, TRecipe> AddCutlet(СutletTypes type);
    public IFoodBuilderService<T, TRecipe> SetName(string name);
    public T Build();

}