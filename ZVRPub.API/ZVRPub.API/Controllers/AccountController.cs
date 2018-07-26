﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZVRPub.API;

namespace TodoApi2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private SignInManager<IdentityUser> _signInManager { get; }

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
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
        public async Task<ActionResult> Register(User input,
            [FromServices] UserManager<IdentityUser> userManager)
        {
            // with an [ApiController], model state is always automatically checked
            // and return 400 if any errors.

            var user = new IdentityUser(input.Username);
            var result = await userManager.CreateAsync(user, input.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            return NoContent();
        }
    }
}