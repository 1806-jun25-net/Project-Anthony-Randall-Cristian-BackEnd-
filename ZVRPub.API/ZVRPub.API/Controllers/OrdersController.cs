﻿
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

        // GET: api/Locations/5
        [HttpGet("{id}", Name = "GetLocation")]
        public ActionResult<List<Locations>> GetLocation(int id)
        {
            return Repo.GetLocations().ToList();
        }

        // POST: api/Orders
        [HttpPost]
        public ActionResult<Orders> Post(Order NewItem)
        {

            Locations loc = Repo.GetLocationByCity(NewItem.Location);
            Users u = Repo.GetUserByUsername(NewItem.Username);
            Orders order = new Orders
            {
                LocationId = loc.Id,
                OrderTime = DateTime.Now,
                UserId = u.UserId
            };

            Repo.AddOrderAsync(order);

            return NoContent();


        }
    }
}
