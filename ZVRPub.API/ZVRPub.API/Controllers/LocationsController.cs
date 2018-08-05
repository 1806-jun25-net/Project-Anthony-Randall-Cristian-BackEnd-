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
    [Route("api/locations")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        private readonly IZVRPubRepository Repo;

        public LocationsController(IZVRPubRepository repo)
        {
            log.Info("Creating instance of locations controller");
            Repo = repo;
        }

        // GET: api/Locations
        [HttpGet]
        public ActionResult<List<Locations>> GetAll()
        {
            log.Info("Retreiving all orders from database");
            return Repo.GetLocations().ToList();
        }

        // GET: api/Locations/5
        [HttpGet("{id}", Name = "GetLocations")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
