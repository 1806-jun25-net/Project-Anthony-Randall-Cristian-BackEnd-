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
    [Route("api/Inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IZVRPubRepository Repo;

        public InventoryController(IZVRPubRepository repo)
        {
            Repo = repo;

        }


        // GET: api/Inventory
        [HttpGet]
        public ActionResult<List<Inventory>> GetAll()
        {
            return Repo.GetInventories().ToList();
        }

        // GET: api/Inventory/5
        [HttpGet("{id}", Name = "GetInventory")]
        public ActionResult<Inventory> Get(string name)
        {
            return Repo.GetInventoriesByName(name);
        }


        // POST: api/Inventory
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Inventory/5
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
