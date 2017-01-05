//Create two classes: class Person and class Product. Each person should have a name, money and a bag of products.Each product should have name and cost.Name cannot be an empty string. Money cannot be a negative number.
//Create a program in which each command corresponds to a person buying a product. If the person can afford a product 
//add it to his bag. If a person doesn’t have enough money, print an appropriate message 
//("[Person name] can't afford [Product name]").
//On the first two lines you are given all people and all products.After all purchases print every person in the order 
//of appearance and all products that he has bought also in order of appearance.If nothing is bought, print the name 
//of the person followed by "Nothing bought".  In case of invalid input(negative money exception message: 
//"Money cannot be negative") or empty name: (empty name exception message "Name cannot be empty") break the program 
//with an appropriate message.


namespace Polymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Person
    {
        private string name;
        private decimal money;
        private List<string> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<string>();
        }

        public string Name
        {
            get { return this.name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }
        public List<string> BagOfProducts
        {
            get { return this.bagOfProducts; }
        }

        public void BuyProduct(Product product)
        {
            if (product.Cost > this.Money)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} bought {product.Name}");

                this.Money -= product.Cost;
                this.bagOfProducts.Add(product.Name);
            }
        }

        public override string ToString()
        {
            string person = $"{this.Name} - ";

            if (this.bagOfProducts.Count == 0)
            {
                person += "Nothing bought";
            }
            else
            {
                person += string.Join(", ", this.bagOfProducts);
            }

            return person;
        }
    }

    class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get { return this.name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Cost
        {
            get { return this.cost; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.cost = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> peopleCollection = new List<Person>();
            List<Product> productCollection = new List<Product>();

            try
            {
                string[] people = Console.ReadLine().Split(new[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
                string[] products = Console.ReadLine().Split(new[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < people.Length; i += 2)
                {
                    string name = people[i];
                    decimal money = decimal.Parse(people[i + 1]);

                    Person person = new Person(name, money);

                    peopleCollection.Add(person);
                }


                for (int i = 0; i < products.Length; i += 2)
                {
                    string name = products[i];
                    decimal cost = decimal.Parse(products[i + 1]);

                    Product product = new Product(name, cost);

                    productCollection.Add(product);
                }

                string purchase = Console.ReadLine();

                while (purchase != "END")
                {
                    string[] inputArguments = purchase.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    Person buyer = peopleCollection.FirstOrDefault(x => x.Name == inputArguments[0]);
                    Product product = productCollection.FirstOrDefault(y => y.Name == inputArguments[1]);

                    buyer.BuyProduct(product);

                    purchase = Console.ReadLine();
                }

                foreach (var element in peopleCollection)
                {
                    Console.WriteLine(element);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

