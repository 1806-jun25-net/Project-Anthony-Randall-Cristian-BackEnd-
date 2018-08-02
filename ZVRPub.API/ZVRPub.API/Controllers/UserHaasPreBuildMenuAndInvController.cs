using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLog;
using ZVRPub.API.ModelsNeeded;
using ZVRPub.Repository;

namespace ZVRPub.API.Controllers
{
    [Route("api/UserPreBuildInv")]
    [ApiController]
    public class UserHaasPreBuildMenuAndInvController : ControllerBase
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        private readonly IZVRPubRepository Repo;
        private SignInManager<IdentityUser> _signInManager { get; }

        public UserHaasPreBuildMenuAndInvController(IZVRPubRepository repo)
        {
            log.Info("Creating instance of UserHaasPreBuildMenuAndInvController ");
            Repo = repo;
        }

        // GET: api/UserHaasPreBuildMenuAndInv
        [HttpGet]
        public ActionResult<UserHasPreBuildMenuAndInvModel> GetUserPreMade(string username)
        {
            var user = Repo.GetUsers().FirstOrDefault(x => x.Username == username);
            var userId = user.UserId;
            var orderList = Repo.GetOrders().Where(x => x.UserId == userId).ToList();
            var getPreOrder = Repo.GetMenuPreBuiltHasOrders().Where(x => x.OrdersId.Equals(orderList.Equals(userId))).ToList();




        }

       
    }
}
