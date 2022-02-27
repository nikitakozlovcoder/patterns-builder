using Lab1.Entities.Recipes;

namespace Lab1.Entities.Hamburgers;

public interface IFood
{
    public BaseRecipe GetRecipe();
    public string GetName();
}