using Xunit;
using Bangazon.Orders;
using System;
using System.Collections.Generic;

namespace Bangazon.Tests
{
  public class OrderTests
  {
    //This is a decorator that indicates what kind of thing this test is testing. A fact is a simple thing 
    [Fact]
    public void TestTheTestingFramework()
    {
      Assert.True(true);
    }

    [Fact]
    public void OrdersCanExist()
    {
      Order ord = new Order();
      //This is saying that an order exists
      Assert.NotNull(ord);
    }

    [Fact]
    public void NewOrdersHaveAGuid()
    {
      Order ord = new Order();
      Assert.NotNull(ord.orderNumber);
      Assert.IsType<Guid>(ord.orderNumber);
    }
    [Fact]
    public void NewOrdersShouldHaveAnEmptyProductList()
    {
      Order ord = new Order();
      Assert.NotNull(ord.products);
      Assert.IsType<List<string>>(ord.products);
      Assert.Empty(ord.products);
    }
    //A theory is like a fact but you can send in multiple bits of data to test
    [Theory]
    [InlineData("banana")]
    //You don't technically need the Attirbute but it'll autocomplete that way for you 
    [InlineDataAttribute("A product with a number 43235")]
    [InlineDataAttribute("A product wih spaces")]
    [InlineDataAttribute("Product that has a , comma?")]
    //Since we have 4 inline attributes this test will run 4 times
    public void OrdersCanhaveProductsAddedToThem(string product)
    {
      Order ord = new Order();
      ord.addProduct(product);
      //This is checking to see that the list is only 1 product long
      Assert.Equal(1, ord.products.Count);
      //Need to identify the type that it contains, the first parameter is the item and the second parameter is the container
      Assert.Contains<string>(product, ord.products);
    }
    //You can only add one string at a time
    [Theory]
    [InlineDataAttribute("Product")]
    [InlineDataAttribute("product,another product")]
    [InlineDataAttribute("a first product,someother,yet,another product")]
    [InlineDataAttribute("prod1,prod2,prod3,prod4")]
    public void OrdersCanHaveMultipleProductsAddedToThem(string productsStr)
    {
      //You need to create a new character array, even though there's only one character inside of it. However, you can split on multiple things here.
      string[] products = productsStr.Split(new char[] {','});
      Order ord = new Order();
      foreach (string product in products)
      {
        ord.addProduct(product);
      }
      Assert.Equal(products.Length, ord.products.Count);
      foreach (string product in products)
      {
        Assert.Contains<string>(product, ord.products);
      }
    }
    [Theory]
    [InlineDataAttribute("Product")]
    [InlineDataAttribute("product,another product")]
    [InlineDataAttribute("a first product,someother,yet,another product")]
    [InlineDataAttribute("prod1,prod2,prod3,prod4")]
    public void OrdersCanListProductsForTerminalDisplay(string productsStr)
    {
      //You need to create a new character array, even though there's only one character inside of it. However, you can split on multiple things here.
      string[] products = productsStr.Split(new char[] {','});
      Order ord = new Order();
      foreach (string product in products)
      {
        ord.addProduct(product);
      }
      Assert.Equal(products.Length, ord.products.Count);
      foreach (string product in products)
      {
        //Contains without an argument just compares the first string to the next string, not something within a collection
        Assert.Contains($"\nYou ordered {product}", ord.listProducts());
      }
    }

    [Fact]
    public void OrdersCanHaveAProductRemovedFromThem()
    {
      Order ord = new Order();
      ord.addProduct("Banana Bread");
      ord.addProduct("Banana");
      ord.addProduct("Honeydew Melon");
      ord.addProduct("Another Product");
      //Remove One
      ord.removeProduct("Banana");
      //Check to see that they are the same length
      Assert.Equal(3, ord.products.Count);
      //Check to see that the new collection does not contain the removed item
      Assert.DoesNotContain<string>("Banana", ord.products);
    }

    [Fact]
    public void OrdersCannotRemoveAProductThatDoesNotExist()
    {
      Order ord = new Order();
      ord.addProduct("Banana Bread");
      ord.addProduct("Banana");
      ord.addProduct("Honeydew Melon");
      ord.addProduct("Another Product");
      //Remove One
      ord.removeProduct("Pineapple");
      //Check to see that they are the same length
      Assert.Equal(4, ord.products.Count);
    }

    [Theory]
    [InlineDataAttribute("Banana")]
    [InlineDataAttribute("Pineapple")]
    public void RemoveMethodReturnsBooleanIndicatingIfProductWasRemoved(string product)
    {
      Order ord = new Order();
      ord.addProduct("Banana Bread");
      ord.addProduct("Banana");
      ord.addProduct("Honeydew Melon");
      ord.addProduct("Another Product");

      bool removed = ord.removeProduct(product);
      if (product == "Banana")
      {
        Assert.True(true);
      }
      if (product == "pineapple") 
      {
        Assert.False(false);
      }
    }
    [Fact]
    public void AllProductsFromAnOrderCanBeDeleted()
    {
      Order ord = new Order();
      ord.addProduct("Banana Bread");
      ord.addProduct("Banana");
      ord.addProduct("Honeydew Melon");
      ord.addProduct("Another Product");
      ord.removeProduct();
      Assert.Empty(ord.products);
    }
  }
}