﻿using Moq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ZVRPub.API;
using ZVRPub.API.Controllers;
using ZVRPub.Repository;
using ZVRPub.Scaffold;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace XUnitTestZVRPub.API
{
    public class UserControllerTesting
    {
        /// <summary>
        /// <Purpose>Test UserController to make sure it can obtain all users in a list generated by the repository</Purpose>
        /// 
        /// <Result>Test passes if returned list is not null and values in list are returned in correct order</Result>
        /// </summary>
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


        /// <summary>
        /// <Purpose>Test UserController to make sure it can obtain a user from only a username</Purpose>
        /// 
        /// <Result>Test passes if only one user from the list is returned, the result is not null, and the returned value does not match
        /// other users in the overall list given</Result>
        /// </summary>
        [Fact]
        public void UserControllerShouldBeAbleToGetUserByUsername()
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

            string username = "Test2";
            var repoMock = new Mock<IZVRPubRepository>();
            repoMock.Setup(c => c.GetUserByUsername(username)).Returns(user2);

            var controller = new UserController(repoMock.Object);
            var result = controller.Get(username);

            Assert.NotNull(result.Value);

            Assert.Same(user2, result.Value);
            Assert.NotSame(user1, result.Value);
        }

        
    }
}
