using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using ZVRPub.API.ModelsNeeded;
using ZVRPub.Library.Model;
using ZVRPub.Repository;
using ZVRPub.Scaffold;

namespace ZVRPub.API.Controllers
{
    [Route("api/SuperOrder")]
    [ApiController]
    public class BigAsAOrderController : ControllerBase
    {
        // GET: api/BigAsAOrder
       
        
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        private readonly IZVRPubRepository Repo;



        public BigAsAOrderController(IZVRPubRepository repo)
        {
            log.Info("Creating instance of UserHaasPreBuildMenuAndInvController ");
            Repo = repo;
            
        }
        [HttpGet]
        public ActionResult<List<SuperOrder>> Get()
        {
            var user = Repo.GetUsers();
            var inv = Repo.GetInventories().ToList();
            var loc = Repo.GetLocations().ToList();

            var orderList = Repo.GetOrders();

            var model = new List<SuperOrder>();


            foreach(var item in orderList)
            {
                model.Add(new SuperOrder
                {
                    orderTime = item.OrderTime,
                    cost = item.Cost,
                    user = Repo.GetUserByUserById(item.UserId).Username, 
                    location = Repo.GetLocationById(item.LocationId).City

                    
                });
            }

         
           

            return model;
        }


    }
}
   

