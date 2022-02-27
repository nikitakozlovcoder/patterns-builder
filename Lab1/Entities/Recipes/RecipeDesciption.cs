using Lab1.Constants.Ingredients;
using Lab1.Data;

namespace Lab1.Entities.Recipes;

public class Recipe : BaseRecipe
{
    public BreadTypes Bread { get; set; } = BreadTypes.None;
    public SauceTypes Sauce { get; set; } = SauceTypes.None;
    public VegetablesTypes Vegetables { get; set; } = VegetablesTypes.None;
    public СutletTypes Cutlet { get; set; } = СutletTypes.None;
    
    public override string ToString()
    {
       return  $"Bread: {Bread}\nSauce: {Sauce}\nVegetables: {Vegetables}\nCutlet {Cutlet}";
    }
}