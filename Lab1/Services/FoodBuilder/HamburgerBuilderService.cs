using Lab1.Constants.Ingredients;
using Lab1.Entities.Hamburgers;
using Lab1.Entities.Recipes;

namespace Lab1.Services.FoodBuilder;

public class HamburgerBuilderService : IFoodBuilderService<Hamburger, Recipe>
{

    private Hamburger _hamburger = new();

    public IFoodBuilderService<Hamburger, Recipe> AddBread(BreadTypes type)
    {
        _hamburger.Recipe.Bread = type;
        return this;
    }

    public IFoodBuilderService<Hamburger, Recipe> AddSauce(SauceTypes type)
    {
        _hamburger.Recipe.Sauce = type;
        return this;
    }

    public IFoodBuilderService<Hamburger, Recipe> AddVegetables(VegetablesTypes type)
    {
        _hamburger.Recipe.Vegetables = type;
        return this;
    }

    public IFoodBuilderService<Hamburger, Recipe> AddCutlet(СutletTypes type)
    {
        _hamburger.Recipe.Cutlet = type;
        return this;
    }

    public IFoodBuilderService<Hamburger, Recipe> SetName(string name)
    {
        _hamburger.Name = name;
        return this;
    }

    public Hamburger Build()
    {
        if ( _hamburger.Recipe.Bread == BreadTypes.None)
        {
            throw new InvalidOperationException("Bread is required for hamburger");
        }

        var hamburger = _hamburger;
        Reset();
        return hamburger;
    }

    private void Reset()
    {
        _hamburger = new Hamburger();
    }
}