using System.Collections.Generic;
using System.Threading.Tasks;
using ZVRPub.Scaffold;

namespace ZVRPub.Repository
{
    public interface IZVRPubRepository
    {
        Task AddCustomeOrderHasInventroy(MenuCustomHasIventory MCHasInv);
        Task addCustomOrder(MenuCustom MC);
        void AddInventoryItem(Inventory NewItem);
        void AddLocationAsync(Locations loc);
        Task AddOrderAsync(Orders NewOrder);
        Task AddPrebuiltOrderHasInventroy(MenuPreBuiltHasInventory MPHasInv);
        Task addPremadeItemInOrder(int OrderId, int PreID);
        Task addPreMenuOrder(MenuPrebuiltHasOrders menu);
        Task AddUserAsync(Users user);
        bool CheckIfUsernameInDatabase(string CheckName);
        Task EditInventoryAsync(InventoryHasLocation inventory);
        Task<Orders> FindLastOrderOfUserAsync(int userId);
        IEnumerable<InventoryHasLocation> GetAllLocationInventoryByLocation();
        IEnumerable<MenuPreBuilt> GetAllMenuPreBuilt();
        IEnumerable<Inventory> GetInventories();
        Task<Inventory> GetInventoriesByNameAsync(string ingredient);
        Inventory GetInventoriesByName(string ingredient);
        Inventory GetInventoryByNameOfProduct(string np);
        Task<MenuCustom> getLastCustom(string CBurger);
        Locations GetLocationByCity(string city);
        Locations GetLocationById(int id);
        IEnumerable<InventoryHasLocation> getLocationInv();
        IEnumerable<InventoryHasLocation> GetLocationInventoryByLocationCityID(int id);
        IEnumerable<InventoryHasLocation> GetLocationInventoryByLocationId(int id);
        IEnumerable<Locations> GetLocations();
        MenuPreBuilt GetMenuPreBuilt(int NewItem);
        IEnumerable<MenuPrebuiltHasOrders> GetMenuPreBuiltHasOrders();
        IEnumerable<LocationOrderProcess> GetOrderProcesses();
        IEnumerable<Orders> GetOrders();
        IEnumerable<Orders> GetOrdersByLocation(int id);
        IEnumerable<Orders> GetOrdersByUsername(string user);
        IEnumerable<MenuPreBuilt> GetPreMenuByID();
        Task<MenuPreBuilt> GetPreMenuByNameOfProduct(string np);
        Users GetUserByUserById(int id);
        Users GetUserByUsername(string username);
        IEnumerable<Users> GetUsers();
        Task InventoryHasLocationUpdateQTYAsync(int idLocation, int idInventory);
        InventoryHasLocation invHasLoc(int id, int qty);
        void Save();
        void UpdatePreBuiltMenu(string v1, int v2);
        Task UpdateUser(Users u);
        Task<InventoryHasLocation> getInventroyByTwoID(int locId, int invid);
    }
}