using Lab1.Data;
using Lab1.Dto;
using Lab1.Entities.Recipes;

namespace Lab1.Entities.Hamburgers;

public class Hamburger : BaseEntity, IFood<Recipe>
{
    public Recipe Recipe { get; set; } = new();
    public string Name { get; set; } = "";

    public Recipe GetRecipe()
    {
        return Recipe;
    }

    public string GetName()
    {
        return Name;
    }
}