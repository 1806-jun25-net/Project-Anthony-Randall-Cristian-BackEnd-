using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZVRPub.Scaffold;

namespace ZVRPub.Repository
{
    public interface IZVRPubRepository
    {

        IEnumerable<Users> GetUsers();

        Task AddUserAsync(Users user);

        Users GetUserByUsername(string username);

        bool CheckIfUsernameInDatabase(string CheckName);

        IEnumerable<Locations> GetLocations();


        void AddLocationAsync(Locations loc);


        Locations GetLocationById(int id);


        Locations GetLocationByCity(string city);

        IEnumerable<Orders> GetOrders();


        IEnumerable<Orders> GetOrdersByLocation(int id);

        IEnumerable<Orders> GetOrdersByUsername(string user);


        Task AddOrderAsync(Orders NewOrder);


        IEnumerable<InventoryHasLocation> GetLocationInventoryByLocationId(int id);


        void EditInventoryAsync(InventoryHasLocation inventory);





        IEnumerable<Inventory> GetInventories();

        Inventory GetInventoriesByName(string ingredient);

        //Inventory SaveChanges.
        void AddInventoryItem(Inventory NewItem);

        Task addPreMenuOrder(MenuPrebuiltHasOrders menu);


        Orders FindOrdersByDate(DateTime DO);




        Task addPremadeItemInOrder(int OrderId, int PreID);


        IEnumerable<MenuPrebuiltHasOrders> GetMenuPreBuiltHasOrders();


        MenuPreBuilt GetPreMenuByNameOfProduct(string np);


        Orders FindLastOrderOfUserAsync(int userId);

        Task addCustomOrder(MenuCustom MC);


        Task AddCustomeOrderHasInventroy(MenuCustomHasIventory MCHasInv);

        Task AddPrebuiltOrderHasInventroy(MenuPreBuiltHasInventory MPHasInv);
      











    }
}

