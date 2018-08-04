using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using ZVRPub.Repository;
using ZVRPub.Scaffold;

namespace ZVRPub.API.Controllers
{
    [Route("api/inventoryHasLocation")]
    [ApiController]
    public class InventoryHasLocationController : ControllerBase
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        private readonly IZVRPubRepository Repo;

        public InventoryHasLocationController(IZVRPubRepository repo)
        {
            log.Info("Creating instance of orders controller");
            Repo = repo;
        }

        // GET: api/InventoryHasLocation
        [HttpGet]
        public ActionResult<List<InventoryHasLocation>> GetAll()
        {
            log.Info("Retreiving all inventory Location from database");
            return Repo.GetAllLocationInventoryByLocation().ToList();
        }

        // GET: api/InventoryHasLocation/5
        [HttpGet("{city}", Name = "GetInventoryHasLocation")]
        public IEnumerable<InventoryHasLocation> Get([FromQuery]string city)
        {
            Locations loc = Repo.GetLocationByCity(city);
            return Repo.GetLocationInventoryByLocationId(loc.Id);
        }

        // POST: api/InventoryHasLocation
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/InventoryHasLocation/5
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
