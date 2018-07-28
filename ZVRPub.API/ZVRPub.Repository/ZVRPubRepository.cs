using Microsoft.EntityFrameworkCore;
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

        public ZVRPubRepository(ZVRContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        #region Users
        public IEnumerable<Users> GetUsers()
        {
            List<Users> UserList = _db.Users.AsNoTracking().ToList();
            return UserList;
        }

        public async Task AddUserAsync(Users user)
        {
            try
            {
                await _db.AddAsync(user);
                await _db.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public async void Save()
        {
            await _db.SaveChangesAsync();
        }

        public Users GetUserByUsername(string username)
        {
            return _db.Users.AsNoTracking().FirstOrDefault(u => u.Username.ToLower().Equals(username.ToLower()));
        }

        #endregion

        #region Locations

        public IEnumerable<Locations> GetLocations()
        {
            List<Locations> LocationList = _db.Locations.AsNoTracking().ToList();
            return LocationList;
        }

        public Locations GetLocationById(int id)
        {
            return _db.Locations.AsNoTracking().First(l => l.Id == id);
        }

        public async Task AddLocationAsync(Locations loc)
        {
            await _db.AddAsync(loc);
            await _db.SaveChangesAsync();
        }

        public Locations GetLocationByName(string name)
        {
            return _db.Locations.AsNoTracking().First(l => l.City == name);
        }

        public void UpdateLocation(Locations location)
        {
            // calling Update would mark every property as Modified.
            // this way will only mark the changed properties as Modified.

            _db.Entry(_db.Locations.Find(location.Id)).CurrentValues.SetValues(location);
        }




        #endregion

        #region Orders

        public IEnumerable<Orders> GetOrders()
        {
            List<Orders> OrderList = _db.Orders.AsNoTracking().ToList();
            return OrderList;
        }

        public IEnumerable<Orders> GetOrdersByLocation(int id)
        {
            List<Orders> OrderList = _db.Orders.AsNoTracking().Where(o => o.LocationId == id).ToList();
            return OrderList;
        }

        public IEnumerable<Orders> GetOrdersByUsername(string user)
        {
            var CurrentUser = _db.Users.AsNoTracking().First(u => u.Username.ToLower().Equals(user.ToLower()));
            var userId = CurrentUser.UserId;
            List<Orders> OrderList = _db.Orders.AsNoTracking().Where(o => o.UserId == userId).ToList();
            return OrderList;
        }

        public async void AddOrderAsync(Orders NewOrder)
        {
            await _db.AddAsync(NewOrder);
            await _db.SaveChangesAsync();
        }

        #endregion

        #region InventoryHasLocation

        public IEnumerable<InventoryHasLocation> GetLocationInventoryByLocationId(int id)
        {
            List<InventoryHasLocation> InventoryList = _db.InventoryHasLocation.AsNoTracking().Where(i => i.LocationId == id).ToList();
            return InventoryList;
        }

        public async void EditInventoryAsync(InventoryHasLocation inventory)
        {
            _db.Update(inventory);
            await _db.SaveChangesAsync();
        }


        #endregion

        #region Inventory

        //Inventory Table.
        public IEnumerable<Inventory> GetInventories()
        {
            List<Inventory> InventoryList = _db.Inventory.AsNoTracking().ToList();
            return InventoryList;
        }
        public Inventory GetInventoriesByName(string ingredient)
        {
            return _db.Inventory.AsNoTracking().FirstOrDefault(u => u.IngredientName.ToLower().Equals(ingredient.ToLower()));
        }
        //Inventory SaveChanges.
        public async void AddInventoryItem(Inventory NewItem)
        {
            await _db.AddAsync(NewItem);
            await _db.SaveChangesAsync();
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

        #endregion








    }
}
