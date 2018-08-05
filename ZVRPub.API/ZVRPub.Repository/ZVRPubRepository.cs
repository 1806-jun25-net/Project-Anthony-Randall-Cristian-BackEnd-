using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZVRPub.Library.Model;
using ZVRPub.Scaffold;

namespace ZVRPub.Repository
{
    public class ZVRPubRepository : IZVRPubRepository
    {

        private readonly ZVRContext _db;
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        public ZVRPubRepository(ZVRContext db)
        {
            log.Info("Creating instance of ZVR repository");
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

      
        public IEnumerable<Users> GetUsers()
        {
            log.Info("Obtaining all users from database");
            List<Users> UserList = _db.Users.AsNoTracking().ToList();
            log.Info("Users obtained");
            return UserList;
        }

        public async Task AddUserAsync(Users user)
        {
            try
            {
                log.Info("Attempting to add user to database");
                await _db.AddAsync(user);
                await _db.SaveChangesAsync();
                log.Info("User added to database");
            }
            catch (Exception ex)
            {
                log.Info("Exception thrown");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
            }
        }
        public async void Save()
        {
            await _db.SaveChangesAsync();
        }

        public Users GetUserByUsername(string username)
        {
            log.Info("Retreiving user from database with given username");
            return _db.Users.AsNoTracking().FirstOrDefault(u => u.Username.ToLower().Equals(username.ToLower()));
        }

        public bool CheckIfUsernameInDatabase(string CheckName)
        {
            bool UsernameTaken = false;

            var token = _db.Users.AsNoTracking().FirstOrDefault(u => u.Username.ToLower().Equals(CheckName.ToLower()));

            if (token != null)
            {
                UsernameTaken = true;
            }

            return UsernameTaken;
        }

       

        public IEnumerable<Locations> GetLocations()
        {
            log.Info("Obtaining all locations from database");
            List<Locations> LocationList = _db.Locations.AsNoTracking().ToList();
            log.Info("All locations obtained");
            return LocationList;
        }

        public async void AddLocationAsync(Locations loc)
        {
            try
            {
                log.Info("Attempting to add location to database");
                await _db.AddAsync(loc);
                await _db.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                log.Info("Exception thrown");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
            }
        }

        public Locations GetLocationById(int id)
        {
            log.Info("Obtaining single location from location id");
            return _db.Locations.AsNoTracking().First(l => l.Id == id);
        }

        public Locations GetLocationByCity(string city)
        {
            log.Info("Obtaining single location from location id");

            return _db.Locations.AsNoTracking().First(l => l.City == city);
        }

        

        public IEnumerable<Orders> GetOrders()
        {
            log.Info("Obtaining all saved orders from database");
            List<Orders> OrderList = _db.Orders.AsNoTracking().ToList();
            log.Info("Orders retreived");
            return OrderList;
        }

        public IEnumerable<Orders> GetOrdersByLocation(int id)
        {
            log.Info("Obtaining orders from provided location");
            List<Orders> OrderList = _db.Orders.AsNoTracking().Where(o => o.LocationId == id).ToList();
            log.Info("Orders obtained");
            return OrderList;
        }

        public IEnumerable<Orders> GetOrdersByUsername(string user)
        {
            log.Info("Obtaining orders ordered by given user");
            var CurrentUser = _db.Users.AsNoTracking().First(u => u.Username.ToLower().Equals(user.ToLower()));
            var userId = CurrentUser.UserId;
            List<Orders> OrderList = _db.Orders.AsNoTracking().Where(o => o.UserId == userId).ToList();
            log.Info("Orders obtained");
            return OrderList;
        }

        public async Task AddOrderAsync(Orders NewOrder)
        {
            try
            {
                log.Info("Attempting to add new order");
                await _db.AddAsync(NewOrder);
                await _db.SaveChangesAsync();
                log.Info("Order added");
            }

            catch (Exception ex)
            {
                log.Info("Exception thrown");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
            }
        }

       

        public IEnumerable<InventoryHasLocation> GetLocationInventoryByLocationId(int id)
        {
            log.Info("Attempting to get inventory by location id");
            List<InventoryHasLocation> InventoryList = _db.InventoryHasLocation.AsNoTracking().Where(i => i.LocationId == id).ToList();
            log.Info("Inventory retreived");
            return InventoryList;
        }

        public async Task EditInventoryAsync(InventoryHasLocation inventory)
        {
            try
            {
                log.Info("Attempting to edit inventory");
                _db.Update(inventory);
                await _db.SaveChangesAsync();
                log.Info("Inventory updated");
            }

            catch (Exception ex)
            {
                log.Info("Exception thrown");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
            }
        }


        

        //Inventory Table.
        public IEnumerable<Inventory> GetInventories()
        {
            log.Info("Obtaining inventories from db");
            List<Inventory> InventoryList = _db.Inventory.AsNoTracking().ToList();
            log.Info("Inventories obtained");
            return InventoryList;
        }
        public async Task<Inventory> GetInventoriesByNameAsync(string ingredient)
        {
            log.Info("Obtaining ingredient with given name");
            return await  _db.Inventory.AsNoTracking().FirstOrDefaultAsync(u => u.IngredientName.ToLower().Equals(ingredient.ToLower()));
        }
        public Inventory GetInventoriesByName(string ingredient)
        {
            log.Info("Obtaining ingredient with given name");
            return  _db.Inventory.AsNoTracking().FirstOrDefault(u => u.IngredientName.ToLower().Equals(ingredient.ToLower()));
        }
        //Inventory SaveChanges.
        public async void AddInventoryItem(Inventory NewItem)
        {
            try
            {
                log.Info("Attempting to add item to inventory");
                await _db.AddAsync(NewItem);
                await _db.SaveChangesAsync();
                log.Info("Item added");
            }

            catch (Exception ex)
            {
                log.Info("Exception thrown");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
            }
        }

        public string GetIngredientNameById(int id)
        {
            Inventory inv = _db.Inventory.AsNoTracking().FirstOrDefault(x => x.Id == id);
            string ingredient = inv.IngredientName;
            return ingredient;
        }
        public async Task addPreMenuOrder(MenuPrebuiltHasOrders menu)
        {
            await _db.MenuPrebuiltHasOrders.AddAsync(menu);
            await _db.SaveChangesAsync();
        }


        public IEnumerable<InventoryHasLocation> getLocationInv()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LocationOrderProcess> GetOrderProcesses()
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(Users u)
        {
            throw new NotImplementedException();
        }

        public void UpdatePreBuiltMenu(string v1, int v2)
        {
            throw new NotImplementedException();
        }

        
        public async Task addPremadeItemInOrder(int OrderId, int PreID)
        {
            var Pre = new MenuPrebuiltHasOrders()
            {
                OrdersId = OrderId,
                MenuPreBuildId = PreID
            };
            await _db.MenuPrebuiltHasOrders.AddAsync(Pre);
            await _db.SaveChangesAsync();
        }

        public IEnumerable<MenuPrebuiltHasOrders> GetMenuPreBuiltHasOrders()
        {
            log.Info("Obtaining all locations from database");
            List<MenuPrebuiltHasOrders> MenuPrebuiltHasOrders = _db.MenuPrebuiltHasOrders.AsNoTracking().ToList();
            log.Info("All locations obtained");
            return MenuPrebuiltHasOrders;
        }


        public async Task<MenuPreBuilt> GetPreMenuByNameOfProduct(string np){

            return await _db.MenuPreBuilt.FirstOrDefaultAsync(o => o.NameOfMenu.ToLower().Equals( np.ToLower()));
            }

        public async Task<Orders> FindLastOrderOfUserAsync(int userId) { return await _db.Orders.AsNoTracking().LastOrDefaultAsync(u => u.UserId == userId); }

        public async Task addCustomOrder(MenuCustom MC)
        {
            await _db.MenuCustom.AddAsync(MC);
            await _db.SaveChangesAsync();
        }

        public async Task AddCustomeOrderHasInventroy(MenuCustomHasIventory MCHasInv)
        {
            await _db.MenuCustomHasIventory.AddAsync(MCHasInv);
            await _db.SaveChangesAsync();
        }
        public async Task AddPrebuiltOrderHasInventroy(MenuPreBuiltHasInventory MPHasInv)
        {
            await _db.MenuPreBuiltHasInventory.AddAsync(MPHasInv);
            await _db.SaveChangesAsync();
        }

        public Inventory GetInventoryByNameOfProduct(string np)
        {
            return _db.Inventory.FirstOrDefault(o => o.IngredientName.ToLower().Equals(np.ToLower()));
        }

        public async Task<MenuCustom> getLastCustom(string CBurger)
        {
            return await _db.MenuCustom.LastOrDefaultAsync(o => o.NameOfCustomMenu.ToLower().Equals(CBurger.ToLower()));
        }

        public Users GetUserByUserById(int id)
        {
            log.Info("Retreiving user from database with given username");
            return _db.Users.AsNoTracking().FirstOrDefault(u => u.UserId.Equals(id));
        }
        
        public IEnumerable<InventoryHasLocation> GetLocationInventoryByLocationCityID(int id)
        {
            log.Info("Attempting to get inventory by location id");
            List<InventoryHasLocation> InventoryList = _db.InventoryHasLocation.AsNoTracking().Where(i => i.LocationId == id).ToList();
            log.Info("Inventory retreived");

            return InventoryList;
        }


        public InventoryHasLocation invHasLoc(int id, int qty)
        {
            throw new NotImplementedException();
        }

        public async Task InventoryHasLocationUpdateQTYAsync(int idLocation, int idInventory)
        {
            var allInventoryLoc = _db.InventoryHasLocation.AsNoTracking().FirstOrDefault(u => u.LocationId.Equals(idLocation) && u.InventoryId.Equals(idInventory));
            allInventoryLoc.Quantity -= 1;
            try
            {
                log.Info("Attempting to edit inventory");
                _db.Update(allInventoryLoc);
                await _db.SaveChangesAsync();
                log.Info("Inventory updated");
            }

            catch (Exception ex)
            {
                log.Info("Exception thrown");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
            }
        }





        public IEnumerable<InventoryHasLocation> GetAllLocationInventoryByLocation()
        {
            log.Info("Obtaining all inventory has location from database");
            List<InventoryHasLocation> InventoryHasLocation1 = _db.InventoryHasLocation.AsNoTracking().ToList();
            log.Info("Inventory obtained");
            return InventoryHasLocation1;
        }

        public MenuPreBuilt GetMenuPreBuilt(int NewItem)
        {
            log.Info("Obtaining single location from location id");
            return _db.MenuPreBuilt.AsNoTracking().First(l => l.Id == NewItem);
        }

        public IEnumerable<MenuPreBuilt> GetPreMenuByID()
        {
            log.Info("Attempting to get inventory by MenuPreBuilt id");
            List<MenuPreBuilt> MenuPre = _db.MenuPreBuilt.AsNoTracking().ToList();
            log.Info("Inventory retreived");
            return MenuPre;
        }

        public IEnumerable<MenuPreBuilt> GetAllMenuPreBuilt()
        {
            log.Info("Attempting to get MenuPreBuilt");
            List<MenuPreBuilt> MenuPre = _db.MenuPreBuilt.AsNoTracking().ToList();
            log.Info("Inventory retreived");
            return MenuPre;
        }

        public async Task<InventoryHasLocation> getInventroyByTwoID(int locId, int invid)
        {
            return await _db.InventoryHasLocation.FirstOrDefaultAsync(o => o.InventoryId == invid && o.LocationId == locId);

        }
    }
}
