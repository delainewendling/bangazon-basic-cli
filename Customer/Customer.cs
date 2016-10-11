using System;

namespace Bangazon.Customers
{
  public class Customer
  {
    //A new customer is created upon running the program
    public string firstName { get; set; }
    public string lastName { get; set; }

    public void greet() 
    {
      Console.WriteLine($"Welcome {this.firstName} {this.lastName}!");
    }
  }
}