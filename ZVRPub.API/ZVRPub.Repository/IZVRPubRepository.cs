using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZVRPub.Scaffold;

namespace ZVRPub.Repository
{
    public interface IZVRPubRepository
    {
        void AddInventoryItem(Inventory NewItem);
        void AddLocationAsync(Locations loc);
        Task AddOrderAsync(Orders NewOrder);
        Task addPreMenuOrder(int OrderId, int MenuPreId);
        Task AddUserAsync(Users user);
        void EditInventoryAsync(InventoryHasLocation inventory);
        Orders FindOrdersByDate(DateTime DO);
        IEnumerable<Inventory> GetInventories();
        Inventory GetInventoriesByName(string ingredient);
        Locations GetLocationById(int id);
        IEnumerable<InventoryHasLocation> getLocationInv();
        IEnumerable<InventoryHasLocation> GetLocationInventoryByLocationId(int id);
        IEnumerable<Locations> GetLocations();
        IEnumerable<LocationOrderProcess> GetOrderProcesses();
        IEnumerable<Orders> GetOrders();
        IEnumerable<Orders> GetOrdersByLocation(int id);
        IEnumerable<Orders> GetOrdersByUsername(string user);
        Users GetUserByUsername(string username);
        IEnumerable<Users> GetUsers();
        void Save();
        Task UpdateUser(Users u);
    }
}