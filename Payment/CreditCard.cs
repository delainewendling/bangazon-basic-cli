using System;
using Bangazon.Orders;

namespace Bangazon.Payments
{
  class CreditCard: Payment 
  {

    public string bankName { get; set; }
    public string accountNumber { get; set; }

    //When we write base we are invoking the base (whatever it's inheriting from) and invoking it. This allows us access to the order in the base since the getter function in the class above it is called order.

    //The argument passed in is of the type Order since firstOrder is a new instance of the Order class. 

    //A method in a class with the same name as a constructor function. Without overloading you can only have one constructor function.
    public CreditCard(Order order): base(order)
    {
      //If you mutate the order here it's only local, it won't go up to the base. 
      //order right now is Bangazon.Orders.Order
    }
    public override string process()
    {
      return $"You are using a {this.bankName} card, with the account number {this.accountNumber}\n{base.process()}";
    }
  }
}