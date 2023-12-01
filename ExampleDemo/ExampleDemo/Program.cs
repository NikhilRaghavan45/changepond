using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static Program;

internal class Program
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class ShoppingCart
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
    }

    public static List<Product> Products = new List<Product>()
    {
        new Product{ Name="biscuit" , Price=20.00},
        new Product{ Name="Maggi" , Price=20.00},
        new Product{ Name="shampoo" , Price=20.00},


    };

    public static List<ShoppingCart> Cart = new List<ShoppingCart>();

    public static bool flag = true;
    private static void Main(string[] args)
    {


        while (flag)
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1.List the products");
            Console.WriteLine("2.Add the products");
            Console.WriteLine("3.Update the products");
            Console.WriteLine("4.Remove the products");
            Console.WriteLine("5.Exit and generate Bill");
            Console.WriteLine("6.Clear the cart");

            Console.WriteLine("enter the number: ");
            int user = Convert.ToInt32(Console.ReadLine());


            switch (user)
            {
                case 1:
                    ListProducts();
                    break;
                case 2:
                    AddProducts();
                    break;
                case 3:
                    UpdateProducts();
                    break;
                case 5:
                    Bill();
                    break;



            }






        }


    }

    static void ListProducts()
    {
        foreach (var product in Products)
        {
            Console.WriteLine($"{product.Name}-{product.Price}");

        }
    }

    static void AddProducts()
    {
        Console.WriteLine("enter the product name:");
        string user1 = Console.ReadLine();
        bool productexist = false;

    
            foreach (var product in Products)
            {
                if (string.Equals(user1, product.Name, StringComparison.OrdinalIgnoreCase))
                {

                    Console.WriteLine("enter the product Quantity:");
                    int user2 = Convert.ToInt32(Console.ReadLine());

                    ShoppingCart cart = new ShoppingCart
                    {
                        Name = product.Name,
                        Price = product.Price,
                        Quantity = user2

                    };

                    Cart.Add(cart);
                }


            }

        }
       
       
    


    static void Bill()
    {
        double Tprice = 0;
        foreach (var items in Cart)
        {

            Tprice = items.Price * items.Quantity;
            Console.WriteLine($"{items.Name}-{items.Quantity}-{Tprice}");
            flag = false;

        }









    }
    static void UpdateProducts()
    {
        Console.WriteLine("enter the product name:");
        string user6 = Console.ReadLine();
        foreach(var product in Products)
        {
            if (string.Equals(user6, product.Name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("enter the Quantity");
                double user9= Convert.ToDouble(Console.ReadLine());
                ShoppingCart cart = new ShoppingCart()
                {
                    Quantity=user9
                };

            }
        }
    }
}