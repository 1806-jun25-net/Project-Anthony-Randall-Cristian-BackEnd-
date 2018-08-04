using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ZVRPub.API.Controllers;
using ZVRPub.Repository;
using ZVRPub.Scaffold;
using ZVRPub.API;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace XUnitTestZVRPub.API
{
    public class LocationControllerTesting
    {

        [Fact]
        public void LocationControllerShouldReturnAll()
        {
            Locations location1 = new Locations
            {
             Id = 1,
             City = "Somehwere",
             PostalCode = "something",
             States = "Somewhere",
             StreetAddress = "somewhere"
            };
            var location2 = new Locations
            {
                Id = 2,
                City = "Somehwere1",
                PostalCode = "something1",
                States = "Somewhere1",
                StreetAddress = "somewhere1"

               
            };

            var repoMock = new Mock<IZVRPubRepository>();
            repoMock.Setup(c => c.GetLocations()).Returns(new List<Locations>
            {
               location1,location2
            });

            var controller = new LocationsController(repoMock.Object);
            var result = controller.GetAll();

            Assert.NotNull(result.Value);

            Assert.Same(location1, result.Value[0]);
        }
        

    }
}
