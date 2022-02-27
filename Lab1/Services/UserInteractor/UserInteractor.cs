using Lab1.Constants;
using Lab1.Constants.Ingredients;
using Lab1.Dto;
using Lab1.Entities.Hamburgers;
using Lab1.Entities.Recipes;

namespace Lab1.Services.UserInteractor;

public class UserInteractor : IUserInteractor
{
    public async Task Start(Func<ActionTypes, Task<bool>> handler)
    {
        while (true)
        {
            ShowStepOne();
            var input = Console.ReadLine();
            ActionTypes action;
            try
            {
                action = ParseEnumType<ActionTypes>(input);
            }
            catch (Exception)
            {
                Console.WriteLine(StringConstants.UnknownCommand);
                continue;
            }

            if (!await handler(action))
            {
                break;
            };
        }
    }

    public void GetIngredientType<T>(Func<CreateFoodDto<T>, bool> handler, string option) where T : struct, Enum
    {
        while (true)
        {
            Console.WriteLine(option);
            var inp = Console.ReadLine();
            try
            {
                var result = handler(new CreateFoodDto<T>()
                {
                    Payload = ParseEnumType<T>(inp)
                });
                if (!result)
                {
                    throw new InvalidOperationException(); 
                }
                break;
            }
            catch (Exception)
            {
                Console.WriteLine(StringConstants.UnknownCommand);
            }
        }
    }

    public string GetName()
    {
        Console.WriteLine(StringConstants.WriteName);
        return Console.ReadLine() ?? string.Empty;
    }

    public void ShowFood<T>(IFood<T> food) where T: BaseRecipe
    {
        Console.WriteLine("Name: " + food.GetName());
        Console.WriteLine("Recipe\n" + food.GetRecipe()+"\n");
    }

    public bool ShouldSave()
    {
        Console.WriteLine("Save food? Yes/no");
        return Console.ReadLine()?.ToLower() == "yes";
    }

    private static void ShowStepOne()
    {
        Console.WriteLine(StringConstants.Options);
    }
    
    private static T ParseEnumType<T>(string? input) where T : struct, Enum
    {
        var action = (T)(object)int.Parse(input!);
        if (!Enum.IsDefined(action))
        {
            throw new ArgumentOutOfRangeException(nameof(ActionTypes));
        }

        return action;
    }
}