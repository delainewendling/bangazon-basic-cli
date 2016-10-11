using Xunit;
using Bangazon.Orders;
using System;

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
  }
}