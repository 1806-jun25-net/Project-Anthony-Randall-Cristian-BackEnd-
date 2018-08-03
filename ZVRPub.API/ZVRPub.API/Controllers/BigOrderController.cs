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
            if (value.CustomBurgerYes)
            {
                addCustomBurger(value.CustomBurgerYes, value.Custom_Burger, LastOrderOfUser.OrderId);

                var cb = Repo.getLastCustom(value.Custom_Burger);
                var buns = Repo.GetInventoriesByName("buns");
                var patties = Repo.GetInventoriesByName("patties");
                var cheese = Repo.GetInventoriesByName("cheese");
                var Inv = Repo.GetInventoriesByName(value.ingredient);
                var Inv1 = Repo.GetInventoriesByName(value.ingredient1);
                var Inv2 = Repo.GetInventoriesByName(value.ingredient2);
                var Inv3 = Repo.GetInventoriesByName(value.ingredient3);
               await CustomUsesInventory(cb.Id, buns.Id);
               await CustomUsesInventory(cb.Id, patties.Id);
               await CustomUsesInventory(cb.Id, cheese.Id);
               await CustomUsesInventory(cb.Id, Inv.Id);
               await CustomUsesInventory(cb.Id, Inv1.Id);
               await CustomUsesInventory(cb.Id, Inv2.Id);
               await CustomUsesInventory(cb.Id, Inv3.Id);
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
                    await updatePreMadeIvn(addPreMadeItem.Id, addPreMadeItem.NameOfMenu);

                }
            }
           
        }
       
        public async Task updatePreMadeIvn(int PremadeId,  string menu)
        {
            if (menu.ToLower().Equals("wrap"))
            {
                await somesortofthing("cheese", PremadeId);
                await somesortofthing("buns", PremadeId);
                await somesortofthing("Lettuce", PremadeId);
                await somesortofthing("Tomato", PremadeId);
            }
            if (menu.ToLower().Equals("burger"))
            {
                await somesortofthing("cheese", PremadeId);
                await somesortofthing("buns", PremadeId);
                await somesortofthing("Lettuce", PremadeId);
                await somesortofthing("Tomato", PremadeId);
               
            }
            if (menu.ToLower().Equals("taco"))
            {
                await somesortofthing("cheese", PremadeId);
                await somesortofthing("buns", PremadeId);
                await somesortofthing("Lettuce", PremadeId);
                await somesortofthing("Tomato", PremadeId);
                
            }
       
        }

        public async Task somesortofthing(string item, int PremadeId)
        {
            var inc = Repo.GetInventoriesByName(item);
            var invhaspre = new MenuPreBuiltHasInventory()
            {
                InventoryId = inc.Id,
                MenuPreBuildId = PremadeId

            };
           await Repo.AddPrebuiltOrderHasInventroy(invhaspre);
        }
        public async Task CustomUsesInventory(int CustomId, int InvId)
        {

            MenuCustomHasIventory menuPre = new MenuCustomHasIventory()
            {
               IdMenuCustom = CustomId, 
               IdInventory = InvId
               
            };
           await Repo.AddCustomeOrderHasInventroy(menuPre);
        }
        public async Task PreMadeUsesInventory(int mPBId,  int InvId, int Quantity)
        {

            MenuPreBuiltHasInventory menuPre = new MenuPreBuiltHasInventory()
            {
                MenuPreBuildId = mPBId, 
                InventoryId = InvId, 
                Quantity = Quantity
            };
           await Repo.AddPrebuiltOrderHasInventroy(menuPre);
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
