using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.UnitTests.Domain
{
    public class OrderTests
    {
        [Fact]
        public void Should_Create_Order_With_Status_Created_And_Calculate_Total()
        {
            var customerId = Guid.NewGuid();
            var productId = Guid.NewGuid();

            var order = new Order(customerId);
            order.AddItem(productId, "Notebook", 2500m, 2);

            Assert.Equal(OrderStatus.Created, order.Status);
            Assert.Single(order.Items);
            Assert.Equal(5000m, order.Total);
        }
    }
}
