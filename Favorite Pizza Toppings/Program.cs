using Favorite_Pizza_Toppings;
using Newtonsoft.Json;

var allPizzas = JsonConvert.DeserializeObject<List<Pizza>>(File.ReadAllText("C:\\Users\\Mason\\workspace\\Favorite Pizza Toppings\\Favorite Pizza Toppings\\Assets\\pizzas.json"));
Console.WriteLine($"{allPizzas.Count} pizzas in total");

Dictionary<string, int> pizzaCounter = new Dictionary<string, int>();

foreach (Pizza pizza in allPizzas)
{
    var toppingsAsString = String.Join(",", pizza.Toppings);
    //pizzaCounter[toppingsAsString] = 1; this never throws an error in a dictionary. will add to dictionary, or replace value if it always exists
    //pizzaCounter.Add(toppingsAsString, 1); this WILL throw an error if the key already exists in the dictionary
    if (pizzaCounter.ContainsKey(toppingsAsString))
    {
        pizzaCounter[toppingsAsString] += 1;
    }
    else
    {
        pizzaCounter[toppingsAsString] = 1;
    }

}

var mostCommonPizzas = pizzaCounter.OrderByDescending(p => p.Value).Take(20);
Console.WriteLine("Here are the most commonly ordered pizzas.");
foreach (var pizza in mostCommonPizzas)
{
    Console.WriteLine($"{pizza.Key}: {pizza.Value}");
}


//// deserialize JSON directly from a file (just another way to do it)
//using (StreamReader file = File.OpenText("C: \\Users\\Mason\\workspace\\Favorite Pizza Toppings\\Favorite Pizza Toppings\\Assets\\pizzas.json"))
//{
//    JsonSerializer serializer = new JsonSerializer();
//    Pizza pizza2 = (Pizza)serializer.Deserialize(file, typeof(Pizza));
//}