using Lab1.Constants.Ingredients;

namespace Lab1.Constants;

public static class StringConstants
{
    public static readonly string Options = @$"
{(int)ActionTypes.ListFood} - Show saved hamburgers
{(int)ActionTypes.CreateFood} - Create new hamburger
{(int)ActionTypes.Exit} - Exit";

    public const string UnknownCommand = "Unknown command";
    public static readonly string BreadOptions = @$"
Choose bread:
{(int)BreadTypes.White} - White
{(int)BreadTypes.Rye} - Rye";
    
    public static readonly string SauceOptions = @$"
Choose sauce:
{(int)SauceTypes.None} - None
{(int)SauceTypes.Cheese} - Cheese
{(int)SauceTypes.SweetAndSour} - Sweet and Sour
{(int)SauceTypes.Salsa} - Salsa";
    
    public static readonly string VegetablesOptions = @$"
Choose vegetables:
{(int)VegetablesTypes.None} - None
{(int)VegetablesTypes.Cucumbers} - Cucumbers
{(int)VegetablesTypes.Tomatoes} - Tomatoes";
    
    public static readonly string CutletOptions = @$"
Choose cutlet:
{(int)СutletTypes.None} - None
{(int)СutletTypes.Chicken} - Chicken
{(int)СutletTypes.Pork} - Pork
{(int)СutletTypes.Beef} - Beef";

    public const string WriteName = "Enter title";
}