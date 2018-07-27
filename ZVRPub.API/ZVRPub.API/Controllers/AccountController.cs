using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZVRPub.API;
using ZVRPub.Repository;
using ZVRPub.Scaffold;

namespace ZVRPub.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private SignInManager<IdentityUser> _signInManager { get; }

        private readonly ZVRPubRepository Repo;


        public AccountController(SignInManager<IdentityUser> signInManager, ZVRPubRepository repo)
        {
            _signInManager = signInManager;
            Repo = repo;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(403)]
        public async Task<ActionResult> Login(User input)
        {
            var result = await _signInManager.PasswordSignInAsync(input.Username, input.Password,
                isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return StatusCode(403); // Forbidden
            }

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(204)]
        public async Task<NoContentResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Register(AllUserInfo input,
            [FromServices] UserManager<IdentityUser> userManager,
            [FromServices] RoleManager<IdentityRole> roleManager, bool admin = false)
        {
            // with an [ApiController], model state is always automatically checked
            // and return 400 if any errors.

            var user = new IdentityUser(input.Username);

            var result = await userManager.CreateAsync(user, input.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            if (admin)
            {
                if (!(await roleManager.RoleExistsAsync("admin")))
                {
                    var adminRole = new IdentityRole("admin");
                    result = await roleManager.CreateAsync(adminRole);
                    if (!result.Succeeded)
                    {
                        return StatusCode(500, result);
                    }
                }
                result = await userManager.AddToRoleAsync(user, "admin");
                if (!result.Succeeded)
                {
                    return StatusCode(500, result);
                }
            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            Users u = new Users
            {
                Username = input.Username,
                FirstName = input.FirstName,
                LastName = input.LastName,
                DateOfBirth = input.DateOfBirth,
                UserAddress = input.UserAddress,
                PhoneNumber = input.PhoneNumber,
                Email = input.Email,
                LevelPermission = false,
                UserPic = input.UserPic
            };
            await Repo.AddUserAsync(u);

            return NoContent();
        }
    }
}