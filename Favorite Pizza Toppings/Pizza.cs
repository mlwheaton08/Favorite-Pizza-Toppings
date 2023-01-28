namespace Favorite_Pizza_Toppings;

public class Pizza
{
    public List<string> Toppings { get; set; } //this has to have the same name and structure as the json object (toppings, which is an array (list))
    //if each json object had a price property for example, you'd need the following:
    //public double Price { get; set; }
}