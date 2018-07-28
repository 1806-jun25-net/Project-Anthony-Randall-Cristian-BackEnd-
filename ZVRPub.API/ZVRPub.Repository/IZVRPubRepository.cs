using System.Collections.Generic;
using System.Threading.Tasks;
using ZVRPub.Scaffold;

namespace ZVRPub.Repository
{
    public interface IZVRPubRepository
    {
        void AddInventoryItem(Inventory NewItem);
        Task AddLocationAsync(Locations loc);
        void UpdateLocation(Locations value);
        void AddOrderAsync(Orders NewOrder);
        Task AddUserAsync(Users user);
        void EditInventoryAsync(InventoryHasLocation inventory);
        IEnumerable<Inventory> GetInventories();
        Inventory GetInventoriesByName(string ingredient);
        Locations GetLocationById(int id);
        IEnumerable<InventoryHasLocation> GetLocationInventoryByLocationId(int id);
        IEnumerable<Locations> GetLocations();
        IEnumerable<Orders> GetOrders();
        IEnumerable<Orders> GetOrdersByLocation(int id);
        IEnumerable<Orders> GetOrdersByUsername(string user);
        Users GetUserByUsername(string username);
        IEnumerable<Users> GetUsers();
        void Save();
    }
}