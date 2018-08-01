using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        #region Users
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
            catch(Exception ex)
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

            if(token != null)
            {
                UsernameTaken = true;
            }

            return UsernameTaken;
        }

        #endregion

        #region Locations

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
            
            catch(Exception ex)
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

        #endregion

        #region Orders

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

        public async void AddOrderAsync(Orders NewOrder)
        {
            try
            {
                log.Info("Attempting to add new order");
                await _db.AddAsync(NewOrder);
                await _db.SaveChangesAsync();
                log.Info("Order added");
            }

            catch(Exception ex)
            {
                log.Info("Exception thrown");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
            }
        }

        #endregion

        #region InventoryHasLocation

        public IEnumerable<InventoryHasLocation> GetLocationInventoryByLocationId(int id)
        {
            log.Info("Attempting to get inventory by location id");
            List<InventoryHasLocation> InventoryList = _db.InventoryHasLocation.AsNoTracking().Where(i => i.LocationId == id).ToList();
            log.Info("Inventory retreived");
            return InventoryList;
        }

        public async void EditInventoryAsync(InventoryHasLocation inventory)
        {
            try
            {
                log.Info("Attempting to edit inventory");
                _db.Update(inventory);
                await _db.SaveChangesAsync();
                log.Info("Inventory updated");
            }
            
            catch(Exception ex)
            {
                log.Info("Exception thrown");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
            }
        }


        #endregion

        #region Inventory

        //Inventory Table.
        public IEnumerable<Inventory> GetInventories()
        {
            log.Info("Obtaining inventories from db");
            List<Inventory> InventoryList = _db.Inventory.AsNoTracking().ToList();
            log.Info("Inventories obtained");
            return InventoryList;
        }
        public Inventory GetInventoriesByName(string ingredient)
        {
            log.Info("Obtaining ingredient with given name");
            return _db.Inventory.AsNoTracking().FirstOrDefault(u => u.IngredientName.ToLower().Equals(ingredient.ToLower()));
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

            catch(Exception ex)
            {
                log.Info("Exception thrown");
                log.Info(ex.Message);
                log.Info(ex.StackTrace);
            }
        }

        //Task  IZVRPubRepository.AddOrderAsync(Orders NewOrder)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task addPreMenuOrder(MenuPrebuiltHasOrders menu)
        {
            await _db.MenuPrebuiltHasOrders.AddAsync(menu);
        }

        public Orders FindOrdersByDate(DateTime DO)
        {
            return GetOrders().FirstOrDefault(x => x.OrderTime == DO);
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

        #endregion

        #region LocationOrderProcess

        #endregion

        #region MenuCustom

        #endregion

        #region MenuCustomHasInventory

        #endregion

        #region MenuPreBuilt

        #endregion

        #region MenuPreBuiltHasInventory

        #endregion

        #region MenuPreBuiltHasOrders
        public async Task addPremadeItemInOrder(int OrderId, int PreID)
        {
            var Pre = new MenuPrebuiltHasOrders()
            {
                OrdersId = OrderId, 
                MenuPreBuildId = PreID
            };
            await _db.MenuPrebuiltHasOrders.AddAsync(Pre);
        }

        public IEnumerable<MenuPrebuiltHasOrders> GetMenuPreBuiltHasOrders()
        {
            log.Info("Obtaining all locations from database");
            List<MenuPrebuiltHasOrders> MenuPrebuiltHasOrders = _db.MenuPrebuiltHasOrders.AsNoTracking().ToList();
            log.Info("All locations obtained");
            return MenuPrebuiltHasOrders;
        }

       



        #endregion








    }
}
