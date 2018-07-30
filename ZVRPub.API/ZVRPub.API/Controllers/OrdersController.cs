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
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        private readonly IZVRPubRepository Repo;

        public OrdersController(IZVRPubRepository repo)
        {
            log.Info("Creating instance of orders controller");
            Repo = repo;
        }

        // GET: api/Orders
        [HttpGet]
        public ActionResult<List<Orders>> GetAll()
        {
            log.Info("Retreiving all orders from database");
            return Repo.GetOrders().ToList();
        }

        // GET: api/Orders/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Orders
        [HttpPost]
        public ActionResult<Orders> Post(Orders NewItem)
        {

            Orders order = new Orders
            {
                LocationId = NewItem.LocationId,
                OrderTime = DateTime.Today,
                UserId = NewItem.UserId
            };

            Repo.AddOrderAsync(order);

            return NoContent();


        }


        // PUT: api/Orders/5
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
