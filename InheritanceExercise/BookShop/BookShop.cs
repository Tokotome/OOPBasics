//You are working in a library.And you are pissed of writing descriptions for books by hand, so you wanted to use the 
//computer to make them faster.So the task is simple.Your program should have two classes – one for the ordinary books – 
//Book, and another for the special ones – GoldenEditionBook.So let’s get started! We need two classes:
//•	Book - represents a book that holds title, author and price.A book should offer information about itself in the format
//shown in the output below.
//•	GoldenEditionBook - represents a special book holds the same properties as any Book, but its price is always 30% higher.


namespace BookShop
{
    using System;
    using System.Text;
    public class BookShopMain
    {
        public static void Main()
        {
            try
            {
                string author = Console.ReadLine();
                string title = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());

                Book book = new Book(author, title, price);
                GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);

                Console.WriteLine(book);
                Console.WriteLine(goldenEditionBook);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }

   

    public class Book
    {
        private string title;
        private string author;
        private double price;

        public Book(string author, string title, double price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }


        public string Author
        {
            get
            {
                return this.author;
            }

            protected set
            {
                if (!ValidAuthorName(value))
                {
                    throw new ArgumentException("Author not valid!");
                }

                this.author = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            protected set
            {
                if (!ValidTitle(value))
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }

        public virtual double Price
        {
            get
            {
                return this.price;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        //create method to validate the title of the book
        private bool ValidTitle(string bookTitle)
        {
            if (bookTitle.Length >= 3)
            {
                return true;
            }

            return false;
        }
        //create method to validate the name of the author
        private bool ValidAuthorName(string authorName)
        {
            var fullName = authorName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (fullName.Length < 2)
            {
                return false;
            }

            string secondName = fullName[1];

            int digit;
            if (int.TryParse(secondName[0].ToString(), out digit))
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            string priceOut = string.Format("{0:F1}", this.Price);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Type: ").Append(this.GetType().Name)
                    .Append(Environment.NewLine)
                    .Append("Title: ").Append(this.Title)
                    .Append(Environment.NewLine)
                    .Append("Author: ").Append(this.Author)
                    .Append(Environment.NewLine)
                    .Append("Price: ").Append(priceOut)
                    .Append(Environment.NewLine);

            return stringBuilder.ToString();
        }
    }

    public class GoldenEditionBook : Book
    {
        private const double GoldenEditionPriceModifier = 1.3;

        public GoldenEditionBook(string author, string title, double price)
            : base(author, title, price)
        {
        }

        public override double Price
        {
            get
            {
                return base.Price * GoldenEditionPriceModifier;
            }
        }
    }
}
