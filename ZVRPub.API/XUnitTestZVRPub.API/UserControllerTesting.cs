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
        //[Fact]
        //public void UserControllerGetAllMethodShouldReturnAllUsers()
        //{
        //    var mockRepo = new Mock<ZVRPubRepository>();
        //    mockRepo.Setup(repo => repo.GetUsers().ToList()).Returns(GetTestUsers());
        //    var controller = new UserController(mockRepo.Object);

        //    var result = controller.GetAll();

        //    var viewResult = Assert.IsType<List<Users>>(result);
        //}
        
        //private List<Users> GetTestUsers()
        //{
        //    var users = new List<Users>();
        //    users.Add(new Users()
        //    {
        //        UserId = 1,
        //        Username = "test1",
        //        FirstName = "Tester",
        //        LastName = "Tester",
        //        PhoneNumber = "1234567890",
        //        Email = "123@abc.net",
        //        LevelPermission = true,
        //        UserAddress = "123 Pickatown Ave., Herndon, VA",
        //        UserPic = "admin.png",
        //        DateOfBirth = DateTime.Now
        //    });
        //    users.Add(new Users()
        //    {
        //        UserId = 2,
        //        Username = "test3",
        //        FirstName = "Success?",
        //        LastName = "Testingness",
        //        PhoneNumber = "0987654321",
        //        Email = "abc@123.com",
        //        LevelPermission = false,
        //        UserAddress = "321 Anystreet Rd., Reston, VA",
        //        UserPic = null,
        //        DateOfBirth = DateTime.Now
        //    });
        //    return users;
        //}
    }
}
