using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ZVRPub.API.Controllers;
using ZVRPub.Repository;
using ZVRPub.Scaffold;

namespace XUnitTestZVRPub.API
{
    public class OrderControllerTesting
    {

        [Fact]
        public void OrderControllerShouldReturnAllUsers()
        {
            Orders order1 = new Orders
            {

                OrderId = 1,
                OrderTime = DateTime.Parse("2018-08-03 14:49:01"),
                LocationId = 1,
                UserId = 5,
                Cost = 19


            };
            Orders order2 = new Orders
            {

                OrderId = 2,
                OrderTime = DateTime.Parse("2018-08-03 14:49:01"),
                LocationId = 1,
                UserId = 5,
                Cost = 19


            };


            var repoMock = new Mock<IZVRPubRepository>();
            repoMock.Setup(c => c.GetOrders()).Returns(new List<Orders>
            {
               order1
            });

            var controller = new OrdersController(repoMock.Object);
            var result = controller.GetAll();

            Assert.NotNull(result.Value);

            Assert.Same(order1, result.Value[0]);
        }


    }
}
