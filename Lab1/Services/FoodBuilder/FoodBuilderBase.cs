using System.Globalization;
using Lab1.Constants.Ingredients;
using Lab1.Entities.Hamburgers;

namespace Lab1.Services.FoodBuilder;

public abstract class FoodBuilderBase<T> where T : IFood, new()
{
    protected T Food { get; set; } = new();
    public abstract FoodBuilderBase<T> AddBread(BreadTypes type);
    public abstract FoodBuilderBase<T> AddSauce(SauceTypes type);
    public abstract FoodBuilderBase<T> AddVegetables(VegetablesTypes type);
    public abstract FoodBuilderBase<T> AddCutlet(СutletTypes type);
    public abstract FoodBuilderBase<T> SetName(string name);
    public abstract FoodBuilderBase<T> SetCutletsCount(int count);
    
    public virtual T Build()
    {
        var food = Food;
        Reset();
        return food;
    }

    protected virtual void Reset()
    {
        Food = new T();
    }
}