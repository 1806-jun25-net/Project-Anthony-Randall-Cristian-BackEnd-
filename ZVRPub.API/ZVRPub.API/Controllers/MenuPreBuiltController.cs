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
    [Route("api/MenuPreBuilt")]
    [ApiController]
    public class MenuPreBuiltController : ControllerBase
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        private readonly IZVRPubRepository Repo;
        public MenuPreBuiltController(IZVRPubRepository repo)
        {
            log.Info("Creating instance of menuprebuilt controller");
            Repo = repo;
        }
        // GET: api/MenuPreBuilt
        [HttpGet]
        public ActionResult<List<MenuPreBuilt>> GetAll()
        {
            log.Info("Retreiving all Menu from database");
            return Repo.GetAllMenuPreBuilt().ToList();
        }

        // GET: api/MenuPreBuilt/5
        [HttpGet("{id}", Name = "GetMenuPreBuilt")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MenuPreBuilt
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/MenuPreBuilt/5
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
