using System.Globalization;
using Lab1.Constants.Ingredients;
using Lab1.Entities.Hamburgers;

namespace Lab1.Services.FoodBuilder;

public interface IFoodBuilderService<out T> where T : IFood
{

    public IFoodBuilderService<T> AddBread(BreadTypes type);
    public IFoodBuilderService<T> AddSauce(SauceTypes type);
    public IFoodBuilderService<T> AddVegetables(VegetablesTypes type);
    public IFoodBuilderService<T> AddCutlet(СutletTypes type);
    public IFoodBuilderService<T> SetName(string name);
    public IFoodBuilderService<T> SetCutletsCount(int count);
    public T Build();

}