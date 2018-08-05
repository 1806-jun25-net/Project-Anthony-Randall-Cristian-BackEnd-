using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using ZVRPub.Library.Model;
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
        public IEnumerable<IngredientInformationAndLocation> Get([FromQuery]string city)
        {
            Locations loc = Repo.GetLocationByCity(city);

            List<InventoryHasLocation> ingredientsIDs = new List<InventoryHasLocation> ();
            ingredientsIDs.AddRange(Repo.GetLocationInventoryByLocationId(loc.Id));

            List<IngredientInformationAndLocation> returnIngredients = new List<IngredientInformationAndLocation>();
            foreach (var item in ingredientsIDs)
            {
                returnIngredients.Add(new IngredientInformationAndLocation
                {
                    Id = item.Id,
                    LocationId = item.LocationId,
                    InventoryId = item.InventoryId,
                    Quantity = item.Quantity,
                    IngredientName = Repo.GetIngredientNameById(item.InventoryId)
                });
            }

            return returnIngredients;
        }

        // PUT: api/InventoryHasLocation/5
        [HttpPut("{city}")]
        public async Task<ActionResult> Put([FromQuery]string city)
        {
            Locations loc = Repo.GetLocationByCity(city);

            List<InventoryHasLocation> ingredientsIDs = new List<InventoryHasLocation>();
            ingredientsIDs.AddRange(Repo.GetLocationInventoryByLocationId(loc.Id));

            foreach (var item in ingredientsIDs)
            {
                item.Quantity = 10;
                await Repo.EditInventoryAsync(item);
            }

            return NoContent();
        }
    }
}
