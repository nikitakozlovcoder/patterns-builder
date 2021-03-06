using Lab1.Constants;
using Lab1.Constants.Ingredients;
using Lab1.Entities.Hamburgers;
using Lab1.Services.FoodBuilder;
using Lab1.Services.UserInteractor;

namespace Lab1.Services.FoodManager;

public class FoodManagerService<T> : IFoodManagerService<T> where T : IFood
{
    private IFoodBuilderService<T> _builder = null!;
    private readonly IUserInteractor _userInteractor;

    public FoodManagerService(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public void SetBuilder(IFoodBuilderService<T> foodBuilderService)
    {
        _builder = foodBuilderService;
    }
    public void ComposeOrder()
    {
        if (_builder == null)
        {
            throw new InvalidOperationException("You have to set builder first");
        }

        _userInteractor.GetIngredientType<BreadTypes>(x =>
        {
            if (x.Payload == BreadTypes.None)
            {
                return false;
            }
            _builder.AddBread(x.Payload);
            return true;
        }, StringConstants.BreadOptions);
        
        _userInteractor.GetIngredientType<СutletTypes>(x =>
        {
            _builder.AddCutlet(x.Payload);
            return true;
        }, StringConstants.CutletOptions);
        
        _userInteractor.GetIngredientType<VegetablesTypes>(x =>
        {
            _builder.AddVegetables(x.Payload);
            return true;
        }, StringConstants.VegetablesOptions);
        
        _userInteractor.GetIngredientType<SauceTypes>(x =>
        {
            _builder.AddSauce(x.Payload);
            return true;
        }, StringConstants.SauceOptions);
        var name = _userInteractor.GetName();
        _builder.SetName(name);
    }
}