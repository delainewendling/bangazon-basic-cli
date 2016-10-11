using System;
using Bangazon.Customers;
using Bangazon.Orders;
using Bangazon.Payments;

namespace Bangazon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a customer and grab first/last name from first argument
            Customer firstCustomer = new Customer();
            firstCustomer.firstName = args[0].Split(new Char[] { ' ' })[0];
            firstCustomer.lastName = args[0].Split(new Char[] { ' ' })[1];
            //The customer is greeted on the command line. greet is a method on the Customer class so we use it here by first referencing the new instance titled firstCustomer. 
            firstCustomer.greet();

            // Create an order and add product from argument list. All of the arguments after the first and before the last are items in the order. 
            Order firstOrder = new Order();
            for(int i = 1; i < args.Length - 1; i++)
            {
                //We are pinging the addProduct method in the Order.cs file each time through
                firstOrder.addProduct(args[i]);
            }
            //We're printing each of the products on a new line in the console
            Console.WriteLine(firstOrder.listProducts());

            // Create a payment
            //We need this to be of type Payment because we can only declare a variable once and, since all payments inherit from Payment, they can all be set equal to this variable.
            Payment payment = null;
            string mainEmailAddress = "steve@stevebrownlee.com";

            // Depending on the value of the last argument, assign
            // the payment variable to the correct derived class
            switch (args[args.Length - 1])
            {
                case "credit":
                //CreditCard and Paypal are both Payment types. You cannot declare a variable with the same name more than once in the same scope. This is why we needed to declare the variable above because we want to use the variable in both situations. 
                    payment = new CreditCard(firstOrder)
                    //Object initializers
                    {
                        bankName = "Amex",
                        accountNumber = "948587245092"
                    };
                    break;
                case "paypal":
                    payment = new Paypal(firstOrder)
                    {
                        email = mainEmailAddress,
                        password = "1234512345"
                    };
                    break;
                default:
                    break;
            }

            // Simplistic operation to calculate total order cost
            //Count is a property on a List similar to length 
            payment.amount = firstOrder.products.Count * 9.99;

            // Process the payment
            Console.WriteLine(payment.process());

            // Send confirmation email
            payment.confirm(mainEmailAddress);
        }
    }
}
