using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLog;
using ZVRPub.Repository;
using ZVRPub.Scaffold;

namespace ZVRPub.API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        private readonly IZVRPubRepository Repo;
        private SignInManager<IdentityUser> _signInManager { get; }

        public UserController(IZVRPubRepository repo)
        {
            log.Info("Creating instance of user controller");
            Repo = repo;
        }
        // GET: api/User
        [HttpGet]
        public ActionResult<List<Users>> GetAll()
        {
            log.Info("Retreiving all users");
            return Repo.GetUsers().ToList();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<Users> Get(string u)
        {
            log.Info("Retreiving user with given username");
           return Repo.GetUserByUsername(u);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //unused due to lack of need for this functionality
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //unused due to lack of need for this functionality
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(AllUserInfo NewUser)
        {
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

    }
}
