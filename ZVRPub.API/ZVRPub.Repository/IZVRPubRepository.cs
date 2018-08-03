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
        void AddOrderAsync(Orders NewOrder);
        Task addPremadeItemInOrder(int OrderId, int PreID);
        Task addPreMenuOrder(MenuPrebuiltHasOrders menu);
        Task AddUserAsync(Users user);
        bool CheckIfUsernameInDatabase(string CheckName);
        void EditInventoryAsync(InventoryHasLocation inventory);
        Orders FindOrdersByDate(DateTime DO);
        IEnumerable<Inventory> GetInventories();
        Inventory GetInventoriesByName(string ingredient);
        Locations GetLocationByCity(string city);
        Locations GetLocationById(int id);
        IEnumerable<InventoryHasLocation> getLocationInv();
        IEnumerable<InventoryHasLocation> GetLocationInventoryByLocationId(int id);
        IEnumerable<Locations> GetLocations();
        IEnumerable<MenuPrebuiltHasOrders> GetMenuPreBuiltHasOrders();
        IEnumerable<LocationOrderProcess> GetOrderProcesses();
     
        IEnumerable<Orders> GetOrders();
        IEnumerable<Orders> GetOrdersByLocation(int id);
        IEnumerable<Orders> GetOrdersByUsername(string user);
        Users GetUserByUsername(string username);
        IEnumerable<Users> GetUsers();
        void Save();

        void UpdatePreBuiltMenu(string v1, int v2);
        Task UpdateUser(Users u);
        Users GetUserByUserById(int id);
        InventoryHasLocation invHasLoc(int id, int qty);
        IEnumerable<InventoryHasLocation> GetAllLocationInventoryByLocation();
        IEnumerable<InventoryHasLocation> GetLocationInventoryByLocationCityID(int id);
        Task InventoryHasLocationUpdateQTYAsync(int idLocation, int idInventory);
        MenuPreBuilt GetMenuPreBuilt(int NewItem);
        IEnumerable<MenuPreBuilt> GetPreMenuByID();



    }
}