namespace Lab1.Constants.Ingredients;

public static class Menu
{
    public static BreadTypes[] BreadTypes => Enum.GetValues<BreadTypes>();
    public static SauceTypes[] SauceTypes => Enum.GetValues<SauceTypes>();
    public static VegetablesTypes[] VegetablesTypes => Enum.GetValues<VegetablesTypes>();
    public static СutletTypes[] СutletTypes => Enum.GetValues<СutletTypes>();
}