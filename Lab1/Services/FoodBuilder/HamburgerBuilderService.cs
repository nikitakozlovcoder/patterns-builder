using Lab1.Constants.Ingredients;
using Lab1.Entities.Hamburgers;

namespace Lab1.Services.FoodBuilder;

public class HamburgerBuilderService : FoodBuilderBase<Hamburger>
{
    public override FoodBuilderBase<Hamburger> AddBread(BreadTypes type)
    {
        Food.Recipe.Bread = type;
        return this;
    }

    public override FoodBuilderBase<Hamburger> AddSauce(SauceTypes type)
    {
        Food.Recipe.Sauce = type;
        return this;
    }

    public override FoodBuilderBase<Hamburger> AddVegetables(VegetablesTypes type)
    {
        Food.Recipe.Vegetables = type;
        return this;
    }

    public override FoodBuilderBase<Hamburger> AddCutlet(СutletTypes type)
    {
        Food.Recipe.Cutlet = type;
        return this;
    }

    public override FoodBuilderBase<Hamburger> SetName(string name)
    {
        Food.Name = name;
        return this;
    }

    public override FoodBuilderBase<Hamburger> SetCutletsCount(int count)
    {
        Food.Recipe.CutletCount = count;
        return this;
    }

    public override Hamburger Build()
    {
        if (Food.Recipe.Bread == BreadTypes.None)
        {
            throw new InvalidOperationException("Bread is required for hamburger");
        }
        var hamburger = Food;
        Reset();
        return hamburger;
    }
}