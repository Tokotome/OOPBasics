//A Pizza is made of a dough and different toppings.You should model a class Pizza which should have a name, dough and 
//toppings as fields.Every type of ingredient should have its own class. Every ingredient has different properties: 
//the dough can be white or wholegrain and in addition it can be crispy, chewy or homemade.The toppings can be of type meat, 
//veggies, cheese or sauce.Every ingredient should have a weight in grams and a method for calculating its calories according
//its type.Calories per gram are calculated through modifiers. Every ingredient has 2 calories per gram as a base and a modifier 
//that gives the exact calories. For example, a white dough has a modifier of 1.5, a chewy dough has a modifier of 1.1, which 
//means that a white chewy dough weighting 100 grams will have 100 * 1.5 * 1.1 = 330.00 total calories.
//Your job is to model the classes in such a way that they are properly encapsulated and to provide a public method 
//for every pizza that calculates its calories according to the ingredients it has.

namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace _05_PizzaCalories
    {
        public class Dough
        {
            private string flourType;
            private string bakingTechnique;
            private double weight;

            public Dough(string flourType, string bakingTechnique, double weight)
            {
                this.FlourType = flourType;
                this.BakingTechnique = bakingTechnique;
                this.Weight = weight;
            }

            public string FlourType
            {
                get { return this.flourType; }
                set
                {
                    if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                    {
                        throw new ArgumentException("Invalid type of dough.");
                    }
                    this.flourType = value;
                }
            }

            public double Weight
            {
                get { return this.weight; }
                set
                {
                    if (value < 1 || value > 200)
                    {
                        throw new ArgumentException("Dough weight should be in the range [1..200].");
                    }
                    this.weight = value;
                }
            }

            public string BakingTechnique
            {
                get { return this.bakingTechnique; }
                set
                {
                    if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                    {
                        throw new ArgumentException("Invalid type of dough.");
                    }
                    this.bakingTechnique = value;
                }
            }

            public double CalculateCalories(Dough dough)
            {
                return Calculation(dough);

            }
            private double Calculation(Dough dough)
            {
                
                string flourType = dough.flourType;
                double weight = dough.weight;
                string bakingTechnique = dough.bakingTechnique;
                double calories = 2 * weight;

                switch (flourType.ToLower())
                {
                    case "white":
                        calories *= 1.5;
                        break;
                    case "wholegrain":
                        calories *= 1.0;
                        break;
                }

                switch (bakingTechnique.ToLower())
                {
                    case "crispy":
                        calories *= 0.9;
                        break;
                    case "chewy":
                        calories *= 1.1;
                        break;
                    case "homemade":
                        calories *= 1.0;
                        break;
                }

                return calories;
            }
        }

        public class Pizza
        {
            private string pizzaName;
            private Dough dough;
            private HashSet<Topping> toppingList;
            private int numberOfToppings;
            private double totalCalories;

            public Pizza()
            {
            }
            public Pizza(string pizzaName)
            {
                this.PizzaName = pizzaName;
                this.Dough = dough;
                this.toppingList = new HashSet<Topping>();
                this.NumberOfToppings = toppingList.Count();
                this.TotalCalories = totalCalories;
            }

            public string PizzaName
            {
                get
                {
                    return this.pizzaName;
                }
                set
                {
                    if (value.Length > 15 && value.Length <= 0)
                    {
                        throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                    }
                    this.pizzaName = value;
                }
            }
            public Dough Dough
            {
                get
                {
                    return this.dough;
                }

                set
                {
                    this.dough = value;
                }
            }
            public int NumberOfToppings
            {
                get
                {
                    return this.numberOfToppings;
                }
                set
                {
                    if (value < 0 || value > 10)
                    {
                        throw new ArgumentException("Number of toppings should be in range [0..10].");
                    }
                    this.numberOfToppings = value;
                }
            }

            public double TotalCalories
            {
                get
                {
                    return this.totalCalories;
                }
                set
                {
                    this.totalCalories = value;
                }
            }
        }

        public class Topping
        {
            private string toppingName;
            private double toppingWeight;

            public Topping(string toppingName, double toppingWeight)
            {
                this.ToppingName = toppingName;
                this.ToppingWeight = toppingWeight;
            }

            public string ToppingName
            {
                get
                {
                    return this.toppingName;
                }
                set
                {
                    if (value.ToLower() != "meat" && value.ToLower() != "veggies" && 
                        value.ToLower() != "cheese" && value.ToLower() != "sauce")
                    {
                        throw new ArgumentException(string.Format("Cannot place {0} on top of your pizza.", value));
                    }
                    this.toppingName = value;
                }
            }
            public double ToppingWeight
            {
                get
                {
                    return this.toppingWeight;
                }
                set
                {
                    if (value < 1 || value > 50)
                    {
                        throw new ArgumentException(string.Format("{0} weight should be in the range [1..50].", this.toppingName));
                    }
                    this.toppingWeight = value;
                }
            }

            public double CalculateCalories(Topping topping)
            {
                return Calculation(topping);

            }
            private double Calculation(Topping topping)
            {
                string toppingName = topping.toppingName;
                double weight = topping.toppingWeight;

                double calories = 2 * weight; 

                switch (toppingName.ToLower())
                {
                    case "meat":
                        calories *= 1.2;
                        break;
                    case "veggies":
                        calories *= 0.8;
                        break;
                    case "cheese":
                        calories *= 1.1;
                        break;
                    case "sauce":
                        calories *= 0.9;
                        break;
                }

                return calories;
            }

        }
        public class Program
        {
            static void Main(string[] args)
            {
                string input = Console.ReadLine();
                var pizza = new Pizza();

                while (input != "END")
                {
                    string[] data = input.Split();

                    if (data[0] == "Pizza")
                    {
                        string pizzaName = data[1];
                        int numberOfToppings = int.Parse(data[2]);

                        try
                        {
                            pizza.PizzaName = pizzaName;
                            pizza.NumberOfToppings = numberOfToppings;
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                            Environment.Exit(0);
                        }

                    }
                    else if (data[0] == "Dough")
                    {
                        string keyWord = data[0];
                        string flourType = data[1];
                        string bakeTech = data[2];
                        double weight = double.Parse(data[3]);
                        try
                        {
                            var dough = new Dough(flourType, bakeTech, weight);

                            pizza.Dough = dough;
                            pizza.TotalCalories += (dough.CalculateCalories(dough));
                            Console.WriteLine("{0:f2}", dough.CalculateCalories(dough));
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                            Environment.Exit(0);
                        }
                    }
                    else if (data[0] == "Topping")
                    {
                        string toppingName = data[1];
                        double toppingWeight = double.Parse(data[2]);

                        try
                        {
                            var topping = new Topping(toppingName, toppingWeight);

                            pizza.TotalCalories += (topping.CalculateCalories(topping));
                            Console.WriteLine("{0:f2}", topping.CalculateCalories(topping));
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                            Environment.Exit(0);
                        }
                    }

                    input = Console.ReadLine();
                }

                if (!string.IsNullOrEmpty(pizza.PizzaName))
                {
                    Console.WriteLine("{0} – {1:f2} Calories.", pizza.PizzaName, pizza.TotalCalories);
                }
            }
        }
    }
}
