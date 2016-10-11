using System;
using System.Collections.Generic;

namespace Bangazon.Orders
{
  public class Order {
    //Private to this class. If you have a private variable you prefix it with an underscore. A List is like an array but it's a collection, which is why the weird syntax is required. _products is private because we want to limit the ability to edit this List to just this class.  
    private List<string> _products = new List<string>();

    //Can get the products elsewhere from this property
    public List<string> products
    {
      get {
        return _products;
      }
    }
    //GUID - Globally Unique Id
    private Guid _orderNumber = Guid.NewGuid();
    
    public Guid orderNumber {
      get {
        return _orderNumber;
      }
    }
    //You want people to add things to the private products List through this method. You can add conditional statements to increase your control.
    public void addProduct(string product)
    {
      //Add is like push
      _products.Add(product);
    }

    public string listProducts()
    {
      string output = "";

      //Since List is like an array the order will be preserverved here
      foreach (string product in _products)
      {
        output += $"\nYou ordered {product}";
      }

      return output;
    }

      public bool removeProduct(string product)
      {
        //Will only remove the exact string, not something that contains that string as a substring
          return _products.Remove(product);
      }

      public void removeProduct()
      {
        //Will only remove the exact string, not something that contains that string as a substring
         _products.Clear();
      }
    }
}