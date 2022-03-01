using Lab1.Data;
using Lab1.Dto;
using Lab1.Entities.Recipes;

namespace Lab1.Entities.Hamburgers;

public class Hamburger : BaseEntity, IFood
{
    public HamburgerRecipe HamburgerRecipe { get; set; } = new();
    public string Name { get; set; } = "";

    public BaseRecipe GetRecipe()
    {
        return HamburgerRecipe;
    }

    public string GetName()
    {
        return Name;
    }
}