using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZVRPub.Repository;
using ZVRPub.Scaffold;

namespace ZVRPub.API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ZVRPubRepository Repo;

        public UserController(ZVRPubRepository repo)
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
        public async Task Post(Users user)
        {

            var u = new Users
            {
                Username = user.Username,
                FirstName = user.FirstName,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                LastName = user.LastName,
                LevelPermission = false,
                PhoneNumber = user.PhoneNumber,
                UserAddress = user.UserAddress,
                UserPic = user.UserPic,

            };
           await Repo.AddUserAsync(user);
           //Repo.Save();
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
