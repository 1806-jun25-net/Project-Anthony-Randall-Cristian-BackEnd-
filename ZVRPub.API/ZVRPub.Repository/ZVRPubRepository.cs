using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZVRPub.Scaffold;

namespace ZVRPub.Repository
{
    public class ZVRPubRepository
    {

        private readonly ZVRContext _db;

        public ZVRPubRepository(ZVRContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<Users> GetUsers()
        {
            List<Users> UserList = _db.Users.AsNoTracking().ToList();
            return UserList;
        }

        public async void AddUserAsync(Users user)
        {
            await _db.AddAsync(user);
            await _db.SaveChangesAsync();
        }

        public Users GetUserByUsername(string username)
        {
            return _db.Users.AsNoTracking().First(u => u.Username.ToLower().Equals(username.ToLower()));
        }

        public IEnumerable<Locations> GetLocations()
        {
            List<Locations> LocationList = _db.Locations.AsNoTracking().ToList();
            return LocationList;
        }

        public async void AddLocationAsync(Locations loc)
        {
            await _db.AddAsync(loc);
            await _db.SaveChangesAsync();
        }

        public Locations GetLocationById(int id)
        {
            return _db.Locations.AsNoTracking().First(l => l.Id == id);
        }

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
    }
}
