using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using ZVRPub.Library.Model;
using ZVRPub.Repository;
using ZVRPub.Scaffold;

namespace ZVRPub.API.Controllers
{
    [Route("api/MenuPreBuiltHasOrders")]
    [ApiController]
    public class MenuPreBuiltHaasOrdersController : ControllerBase
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        private readonly IZVRPubRepository Repo;

        public MenuPreBuiltHaasOrdersController(IZVRPubRepository repo)
        {
            log.Info("Creating instance of menuprebuilt has orders controller");
            Repo = repo;
        }
        // GET: api/MenuPreBuiltHaasOrders
        [HttpGet]
        public ActionResult<List<MenuPrebuiltHasOrders>> GetAll()
        {
            log.Info("Retreiving all orders from database");
            return Repo.GetMenuPreBuiltHasOrders().ToList();
        }

        // GET: api/MenuPreBuiltHaasOrders/5
        [HttpGet("{id}", Name = "GetPreBuiltMenu")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MenuPreBuiltHaasOrders
        [HttpPost]
        public async Task PostAsync(MHO mHO)
        {
            var m = Repo.GetPreMenuByNameOfProduct(mHO.NameOfProduct);
            var Menu = new MenuPrebuiltHasOrders
            {
               MenuPreBuildId = m.Id
            };
           await Repo.addPreMenuOrder(Menu);
           
        }
    }
}
