using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using ZVRPub.Library.Model;
using ZVRPub.Repository;
using ZVRPub.Scaffold;

namespace ZVRPub.API.Controllers
{
    [Route("api/BigOrder")]
    [ApiController]
    public class BigOrderController : ControllerBase
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        private readonly IZVRPubRepository Repo;
        // GET: api/BigOrder
        public BigOrderController(IZVRPubRepository repo)
        {
            log.Info("Creating instance of locations controller");
            Repo = repo;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BigOrder/5
        [HttpGet("{id}", Name = "GetBigOrder")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BigOrder
        [HttpPost]
        public async Task<ActionResult<Orders>> PostAsync(BigOrder value)
        {
            await JustDoMAgic(value);

            return NoContent();
            
        }

        public void addCustomBurger(bool check, string nameofproduct, int orderid)
        {
            var CustomeBurger = new MenuCustom()
            {
                NameOfCustomMenu = nameofproduct, 
                IdOrders = orderid
            };
            if (check)
            {
               
                Repo.addCustomOrder(CustomeBurger); 

            }
        }
        public async Task JustDoMAgic(BigOrder value)
        {
            //order bit
            Users u = Repo.GetUserByUsername(value.user);
            Locations l = Repo.GetLocationByCity(value.Location);

            Orders o = new Orders
            {
                UserId = u.UserId,
                LocationId = l.Id,
                OrderTime = value.OrderTime,

            };

            await Repo.AddOrderAsync(o);

            //order bit

            //items into order
            Orders LastOrderOfUser = Repo.FindLastOrderOfUserAsync(u.UserId);

            await addPreMadeItem(value.burger, value.QuantityOfBurger, "Burger", LastOrderOfUser.OrderId);
            await addPreMadeItem(value.CockTail, value.QuantityCocktail, "Cocktail", LastOrderOfUser.OrderId);
            await addPreMadeItem(value.Draft_Beer, value.QuantityDraft_Beer, "Draft Beer", LastOrderOfUser.OrderId);
            await addPreMadeItem(value.Taco, value.QuantityTaco, "Taco", LastOrderOfUser.OrderId);
            await addPreMadeItem(value.wrap, value.QuantityWrap, "Wrap", LastOrderOfUser.OrderId);
            //items into order 
            for (int i = 0; i < value.QuantityOfBurger; i++)
            {
                addCustomBurger(value.CustomBurgerYes, value.Custom_Burger, LastOrderOfUser.OrderId);
            }

        }

        public async Task addPreMadeItem(bool Item, int qty, string nameOfProduct, int orderid)
        {
           var addPreMadeItem  = Repo.GetPreMenuByNameOfProduct(nameOfProduct);
            if (Item)
            {
                for (int i = 0; i< qty; i++)
                {
                   await  Repo.addPremadeItemInOrder(orderid, addPreMadeItem.Id);

                    
                }
            }
           
        }
        public void CustomUsesInventory(int CustomId, int InvId)
        {

            MenuCustomHasIventory menuPre = new MenuCustomHasIventory()
            {
               IdMenuCustom = CustomId, 
               IdInventory = InvId
               
            };
            Repo.AddCustomeOrderHasInventroy(menuPre);
        }
        public void PreMadeUsesInventory(int mPBId,  int InvId, int Quantity)
        {

            MenuPreBuiltHasInventory menuPre = new MenuPreBuiltHasInventory()
            {
                MenuPreBuildId = mPBId, 
                InventoryId = InvId, 
                Quantity = Quantity
            };
            Repo.AddPrebuiltOrderHasInventroy(menuPre);
        }
        // PUT: api/BigOrder/5
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
