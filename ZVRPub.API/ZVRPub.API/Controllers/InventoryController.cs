using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using ZVRPub.Repository;
using ZVRPub.Scaffold;

namespace ZVRPub.API.Controllers
{
    [Route("api/Inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        private readonly IZVRPubRepository Repo;

        public InventoryController(IZVRPubRepository repo)
        {
            log.Info("Creating instance of inventory controller");
            Repo = repo;
        }


        // GET: api/Inventory
        [HttpGet]
        public ActionResult<List<Inventory>> GetAll()
        {
            log.Info("Retreiving all inventories from database");
            return Repo.GetInventories().ToList();
        }

        // GET: api/Inventory/5
        [HttpGet("{id}", Name = "GetInventory")]
        public async Task<ActionResult<Inventory>> GetAsync(string name)
        {
            log.Info("Retreiving inventory from database based on ingredient name");
            return await Repo.GetInventoriesByName(name);
        }


        // POST: api/Inventory
        [HttpPost]
        public void Post([FromBody] string value)
        {
            log.Info("Creating new inventory");
        }

        // PUT: api/Inventory/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            log.Info("Updating inventory information");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            log.Info("Deleting inventory with given id");
        }
    }
}
