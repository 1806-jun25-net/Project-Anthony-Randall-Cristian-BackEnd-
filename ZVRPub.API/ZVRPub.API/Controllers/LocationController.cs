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
    [Route("api/Location")]
    [ApiController]
    public class LocationController : ControllerBase
    {

        private readonly IZVRPubRepository Repo;

        public LocationController(IZVRPubRepository repo)
        {
            Repo = repo;

        }

        // GET: api/Location
        [HttpGet]
        public ActionResult<List<Locations>> GetAll()
        {
            return Repo.GetLocations().ToList();
        }

        // GET: api/Location/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Location
        // POST: api/Location
        [HttpPost]
        public async Task<ActionResult<Locations>> Post(Locations value)
        {
            Locations locations = new Locations
            {
                StreetAddress = value.StreetAddress,
                PostalCode = value.PostalCode,
                City = value.City,
                States = value.States

            };

            await Repo.AddLocationAsync(locations);

            return NoContent();

        }



        // PUT: api/Location/5
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
