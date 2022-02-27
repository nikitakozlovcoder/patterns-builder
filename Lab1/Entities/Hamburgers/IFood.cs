using Lab1.Entities.Recipes;

namespace Lab1.Entities.Hamburgers;

public interface IFood<T> where T : BaseRecipe
{
    public T GetRecipe();
    public string GetName();
}