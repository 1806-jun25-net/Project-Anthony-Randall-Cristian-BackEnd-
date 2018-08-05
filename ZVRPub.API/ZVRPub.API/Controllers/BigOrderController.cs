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

        public async Task addCustomBurger(bool check, string nameofproduct, int orderid)
        {
            var CustomeBurger = new MenuCustom()
            {
                NameOfCustomMenu = nameofproduct, 
                IdOrders = orderid
            };
            if (check)
            {
               
               await  Repo.addCustomOrder(CustomeBurger); 

            }
        }
        public async Task JustDoMAgic(BigOrder value)
        {
            //order bit
            Users u = Repo.GetUserByUsername(value.user);
            Locations l = Repo.GetLocationByCity(value.Location);
            Orders o = new Orders();
            if (value.CustomBurgerYes)
            {
                 o = new Orders
                {
                    UserId = u.UserId,
                    LocationId = l.Id,
                    OrderTime = value.OrderTime,
                    Cost = 5 * (value.QuantityBurger + value.QuantityCocktail + value.QuantityDraft_Beer + value.QuantityOfBurger + value.QuantityTaco + value.QuantityWrap + 11)
                };
            }
            else
            {
                 o = new Orders
                {
                    UserId = u.UserId,
                    LocationId = l.Id,
                    OrderTime = value.OrderTime,
                    Cost = 5 * (value.QuantityBurger + value.QuantityCocktail + value.QuantityDraft_Beer + value.QuantityOfBurger + value.QuantityTaco + value.QuantityWrap)
                };
            }
           
        
            await Repo.AddOrderAsync(o);

            //order bit

            //items into order
            Orders LastOrderOfUser = await Repo.FindLastOrderOfUserAsync(u.UserId);

            await addPreMadeItem(value.burger, value.QuantityOfBurger, "Burger", LastOrderOfUser.OrderId, l.Id);
           
            await addPreMadeItem(value.CockTail, value.QuantityCocktail, "Cocktail", LastOrderOfUser.OrderId, l.Id);
            await addPreMadeItem(value.Draft_Beer, value.QuantityDraft_Beer, "Draft Beer", LastOrderOfUser.OrderId, l.Id);
            await addPreMadeItem(value.Taco, value.QuantityTaco, "Taco", LastOrderOfUser.OrderId, l.Id);
            await addPreMadeItem(value.wrap, value.QuantityWrap, "Wrap", LastOrderOfUser.OrderId, l.Id);
            //items into order 
            if (value.CustomBurgerYes)
            {
                await addCustomBurger(value.CustomBurgerYes, value.Custom_Burger, LastOrderOfUser.OrderId);

                var cb = await Repo.getLastCustom(value.Custom_Burger);
                var buns = await Repo.GetInventoriesByNameAsync("buns");
                var patties = await Repo.GetInventoriesByNameAsync("patties");
                var cheese = await Repo.GetInventoriesByNameAsync("cheese");
                var Inv = await Repo.GetInventoriesByNameAsync(value.ingredient);
                var Inv1 = await Repo.GetInventoriesByNameAsync(value.ingredient1);
                var Inv2 = await Repo.GetInventoriesByNameAsync(value.ingredient2);
                var Inv3 = await Repo.GetInventoriesByNameAsync(value.ingredient3);
               await CustomUsesInventory(cb.Id, buns.Id);
               await CustomUsesInventory(cb.Id, patties.Id);
               await CustomUsesInventory(cb.Id, cheese.Id);
               await CustomUsesInventory(cb.Id, Inv.Id);
               await CustomUsesInventory(cb.Id, Inv1.Id);
               await CustomUsesInventory(cb.Id, Inv2.Id);
               await CustomUsesInventory(cb.Id, Inv3.Id);
                await addinv(l.Id, buns.Id);
                await addinv(l.Id, patties.Id);
                await addinv(l.Id, cheese.Id);
                await addinv(l.Id, Inv.Id);
                await addinv(l.Id, Inv1.Id);
                await addinv(l.Id, Inv2.Id);
                await addinv(l.Id, Inv3.Id);

            }
               



        }

        public async Task addinv(int locId, int invid)
        {
            var lhi = await Repo.getInventroyByTwoID(locId, invid);
            lhi.Quantity = lhi.Quantity - 1;
            await Repo.EditInventoryAsync(lhi);
        }
        
        public async Task addPreMadeItem(bool Item, int qty, string nameOfProduct, int orderid, int locid)
        {
           var addPreMadeItem  = await Repo.GetPreMenuByNameOfProduct(nameOfProduct);
            if (Item)
            {
                for (int i = 0; i< qty; i++)
                {
                   await  Repo.addPremadeItemInOrder(orderid, addPreMadeItem.Id);
                   await updatePreMadeIvn(addPreMadeItem.Id, addPreMadeItem.NameOfMenu, locid);


                }
            }
           
        }
       
        public async Task updatePreMadeIvn(int PremadeId,  string menu, int locId)
        {
            if (menu.ToLower().Equals("wrap"))
            {
                await somesortofthing("cheese", PremadeId, locId);
                await somesortofthing("buns", PremadeId, locId);
                await somesortofthing("Lettuce", PremadeId, locId);
                await somesortofthing("Tomato", PremadeId, locId);

            }
            if (menu.ToLower().Equals("burger"))
            {
                await somesortofthing("cheese", PremadeId, locId);
                await somesortofthing("buns", PremadeId, locId);
                await somesortofthing("Lettuce", PremadeId, locId);
                await somesortofthing("Tomato", PremadeId, locId);
               
            }
            if (menu.ToLower().Equals("taco"))
            {
                await somesortofthing("cheese", PremadeId, locId);
                await somesortofthing("buns", PremadeId, locId);
                await somesortofthing("Lettuce", PremadeId, locId);
                await somesortofthing("Tomato", PremadeId, locId);
                
            }
       
        }

        public async Task somesortofthing(string item, int PremadeId, int loc)
        {
            var inc = await Repo.GetInventoriesByNameAsync(item);
            var invhaspre = new MenuPreBuiltHasInventory()
            {
                InventoryId = inc.Id,
                MenuPreBuildId = PremadeId

            };
            await addinv(loc, inc.Id);
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
