using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLog;
using ZVRPub.API;
using ZVRPub.Repository;
using ZVRPub.Scaffold;

namespace ZVRPub.API.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        private SignInManager<IdentityUser> _signInManager { get; }

        private readonly ZVRPubRepository Repo;


        public AccountController(SignInManager<IdentityUser> signInManager, ZVRPubRepository repo)
        {
            log.Info("Creating instance of account controller");
            _signInManager = signInManager;
            Repo = repo;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(403)]
        public async Task<ActionResult> Login(User input)
        {
            log.Info("Beginning login");
            var result = await _signInManager.PasswordSignInAsync(input.Username, input.Password,
                isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                log.Info("HTTP Status code 403 - user unable to perform desired action");
                return StatusCode(403); // Forbidden
            }

            log.Info("HTTP status code 204 - logging user in");
            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(204)]
        public async Task<NoContentResult> Logout()
        {
            log.Info("Logging current user out");
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

            log.Info("Beginning new user registration");
            var user = new IdentityUser(input.Username);

            var result = await userManager.CreateAsync(user, input.Password);

            if (!result.Succeeded)
            {
                log.Info("HTTP status code 400 - displaying error view");
                return BadRequest(result);
            }

            log.Info("HTTP status code 200 - continuing with login");
            if (admin)
            {
                log.Info("User is adminiatrator");
                if (!(await roleManager.RoleExistsAsync("admin")))
                {
                    log.Info("Creating admin role");
                    var adminRole = new IdentityRole("admin");
                    result = await roleManager.CreateAsync(adminRole);
                    if (!result.Succeeded)
                    {
                        log.Info("Error: internal server error. Displaying result");
                        return StatusCode(500, result);
                    }
                }
                log.Info("Administration role exists");
                log.Info("Adding admin role to user");
                result = await userManager.AddToRoleAsync(user, "admin");
                if (!result.Succeeded)
                {
                    log.Info("Error: internal server error. Displaying result");
                    return StatusCode(500, result);
                }
            }

            log.Info("Logging in user");
            await _signInManager.SignInAsync(user, isPersistent: false);

            log.Info("Creating user for non-identity database");
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

            log.Info("User registration successful");
            return NoContent();
        }
    }
}