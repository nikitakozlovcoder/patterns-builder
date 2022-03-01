using Lab1.Constants;
using Lab1.Constants.Ingredients;
using Lab1.Entities.Hamburgers;
using Lab1.Services.FoodBuilder;
using Lab1.Services.UserInteractor;

namespace Lab1.Services.FoodManager;

public class FoodManagerService<T> : IFoodManagerService<T> where T : IFood, new()
{
    private readonly FoodBuilderBase<T> _builder;
    private readonly IUserInteractor _userInteractor;

    public FoodManagerService(IUserInteractor userInteractor, FoodBuilderBase<T> builder)
    {
        _userInteractor = userInteractor;
        _builder = builder;
    }
    
    public T ComposeOrder()
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
            if (x.Payload != СutletTypes.None)
            {
                var count = _userInteractor.GetCount(StringConstants.WriteCutletsCount);
                _builder.SetCutletsCount(count);
            }
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
        return _builder.Build();
    }
}