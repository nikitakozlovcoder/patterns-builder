using Lab1.Constants.Ingredients;
using Lab1.Entities.Hamburgers;

namespace Lab1.Services.FoodBuilder;

public class HamburgerBuilderService : IFoodBuilderService<Hamburger>
{

    private Hamburger _hamburger = new();

    public IFoodBuilderService<Hamburger> AddBread(BreadTypes type)
    {
        _hamburger.Recipe.Bread = type;
        return this;
    }

    public IFoodBuilderService<Hamburger> AddSauce(SauceTypes type)
    {
        _hamburger.Recipe.Sauce = type;
        return this;
    }

    public IFoodBuilderService<Hamburger> AddVegetables(VegetablesTypes type)
    {
        _hamburger.Recipe.Vegetables = type;
        return this;
    }

    public IFoodBuilderService<Hamburger> AddCutlet(СutletTypes type)
    {
        _hamburger.Recipe.Cutlet = type;
        return this;
    }

    public IFoodBuilderService<Hamburger> SetName(string name)
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