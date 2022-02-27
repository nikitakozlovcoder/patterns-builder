using Lab1.Entities.Recipes;

namespace Lab1.Entities.Hamburgers;

public interface IFood
{
    public Recipe GetRecipe();
    public string GetName();
}