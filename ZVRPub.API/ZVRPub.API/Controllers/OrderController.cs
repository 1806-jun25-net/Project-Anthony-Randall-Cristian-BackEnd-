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
    [Route("api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ZVRPubRepository Repo;

        public OrderController(ZVRPubRepository repo)
        {
            Repo = repo;
        }
        // GET: api/Oreder
        [HttpGet]
        public ActionResult<List<Orders>> GetOrder()
        {
            return Repo.GetOrders().ToList();
        }

        // GET: api/Oreder/5
        [HttpGet("{OrderId:int}.{format?}", Name = "GetOrder")]
        [FormatFilter]
        public string GetOrder(int id)
        {
        //    if (!ModelState.IsValid)
        //    {
        //        return NotFound();
        //    }
        //    try
        //    {
        //        return Repo.get
        //    }
            return "value";
        }

        // POST: api/Oreder
        [HttpPost]
        public async Task Post(Orders orders)
        {
            var o = new Orders
            {
                UserId = orders.UserId, 
                LocationId = orders.LocationId, 
                OrderTime = DateTime.Now, 
            };
            await Repo.AddOrderAsync(o);

        }

        // PUT: api/Oreder/5
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
