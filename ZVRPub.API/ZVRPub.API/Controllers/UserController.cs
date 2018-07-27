﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZVRPub.Repository;
using ZVRPub.Scaffold;

namespace ZVRPub.API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IZVRPubRepository Repo;
        private SignInManager<IdentityUser> _signInManager { get; }
        
        public UserController(IZVRPubRepository repo)
        {
            Repo = repo;

        }
        // GET: api/User
        [HttpGet]
        public ActionResult<List<Users>> GetAll()
        {
            return Repo.GetUsers().ToList();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<Users> Get(string u)
        {
          
            return Repo.GetUserByUsername(u);
      }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> Post(AllUserInfo NewUser)
        {
            var u = new User
            {
                Username = NewUser.Username,
                Password = NewUser.Password
            };

            Users user = new Users
            {
                Username = NewUser.Username,
                FirstName = NewUser.FirstName,
                LastName = NewUser.LastName,
                DateOfBirth = NewUser.DateOfBirth,
                UserAddress = NewUser.UserAddress,
                PhoneNumber = NewUser.PhoneNumber,
                Email = NewUser.Email,
                LevelPermission = false,
                UserPic = NewUser.UserPic
            };
            await Repo.AddUserAsync(user);

            return NoContent();
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task Put(Users u)
        {


            await Repo.UpdateUser(u);


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
