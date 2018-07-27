using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ZVRPub.API.Controllers;
using ZVRPub.Repository;
using ZVRPub.Scaffold;

namespace XUnitTestZVRPub.API
{
    public class UserControllerTesting
    {
        [Fact]
        public void UserControllerShouldReturnAllUsers()
        {
            Users user1 = new Users
            {
                Username = "Test",
                FirstName = "Mick",
                LastName = "Tester",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "0123456789",
                Email = "a@b.com",
                UserAddress = "123 Anystreet, Herndon",
                LevelPermission = true,
                UserPic = "admin.png",
                UserId = 1
            };
            var user2 = new Users
            {
                Username = "Test2",
                FirstName = "Nick",
                LastName = "Escalona",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "0987654321",
                Email = "nick@escalona.com",
                UserAddress = "321 Nothere, Reston",
                LevelPermission = false,
                UserPic = null,
                UserId = 2
            };

            var repoMock = new Mock<IZVRPubRepository>();
            repoMock.Setup(c => c.GetUsers()).Returns(new List<Users>
            {
               user1, user2
            });

            var controller = new UserController(repoMock.Object);
            var result = controller.GetAll();

            Assert.NotNull(result.Value);

            Assert.Same(user1, result.Value[0]);
            Assert.Same(user2, result.Value[1]);

        }
    }
}
