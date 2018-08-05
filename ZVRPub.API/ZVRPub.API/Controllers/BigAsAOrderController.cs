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
        public ActionResult<List<UserHasPreBuildMenuAndInvModel>> Get()
        {
            var user = Repo.GetUsers();
            var inv = Repo.GetInventories().ToList();
            var loc = Repo.GetLocations().ToList();

            var orderList = Repo.GetOrders();
            
          

            var preBuiltList = Repo.GetMenuPreBuiltHasOrders();
            var getPreOrder = new List<MenuPrebuiltHasOrders>();
            foreach (var item in orderList)
            {
                foreach (var item2 in preBuiltList)
                {
                    if (item.OrderId == item2.OrdersId)
                    {
                        getPreOrder.Add(item2);
                    }

                }
            }





            var getPreOrderMenu = Repo.GetAllMenuPreBuilt().ToList();


            IEnumerable<LocationModel> location2 = loc.Select(x => new LocationModel
            { Id = x.Id, City = x.City });
            IEnumerable<InventoryModel> inventory2 = inv.Select(x => new InventoryModel
            { Id = x.Id, IngredientName = x.IngredientName, Price = x.Price });
            IEnumerable<OrderModel> order2 = orderList.Select(x => new OrderModel
            { OrderId = x.OrderId, UserId = x.UserId, LocationId = x.LocationId, OrderTime = x.OrderTime });
            IEnumerable<MenuPrebuiltHasOrdersModel> PreOr = getPreOrder.Select(x => new MenuPrebuiltHasOrdersModel
            { Id = x.Id, MenuPreBuildId = x.MenuPreBuildId, OrdersId = x.OrdersId });
            IEnumerable<MenuPreBuiltModel> PreBuilt = getPreOrderMenu.Select(x => new MenuPreBuiltModel
            { Id = x.Id, NameOfMenu = x.NameOfMenu, Price = x.Price, TwentyOneOver = x.TwentyOneOver });

            List<UserHasPreBuildMenuAndInvModel> model = new List<UserHasPreBuildMenuAndInvModel>();
            foreach(var item in user)
            {
                model.Add(new UserHasPreBuildMenuAndInvModel
                {

                    User = item.Username,
                    Location = location2,
                    Inventories = inventory2,
                    Order = order2,
                    PreBuilt = PreBuilt,
                    PreBuiltHasOrder = PreOr


                }
              );    
            }
           

            return model;
        }


    }
}
   

