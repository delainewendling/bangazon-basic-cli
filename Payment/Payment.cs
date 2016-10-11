using System;
using Bangazon.Orders;

namespace Bangazon.Payments
{
  class Payment {
    //descriptor - decides what you can do with that property
    public double amount { get; set; }

    private Order _order = null;

    //Property
    public Order order
    {
      get {
        return _order;
      }
    }
    //Constructor Function. Is this the thing that 
    public Payment(Order order)
    {
      _order = order;
    }
    public virtual string process() 
    {
      return $"You paid ${this.amount} for order {this.order.orderNumber}"; 
    }
    //You don't have to write overload to overload a method. The following methods are overloaded methods of each other even though we don't need to write the word overload.
    //Overload is a concept or convention not a keyword
    public void confirm(string email)
    {
      Console.WriteLine($"Sending confirmation email to {email}");
    }

    public void confirm(string email, string cc)
    {
      Console.WriteLine($"Sending confirmation email to {email} and {cc}");
    }
  }
}