using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ZVRPub.API.Controllers;
using ZVRPub.Repository;
using ZVRPub.Scaffold;

namespace XUnitTestZVRPub.API
{
    public class InventoryControllerTesting
    {
        /// <summary>
        /// <Purpose>Test should be able to obtain all inventories stored in database</Purpose>
        /// 
        /// <Result>Test passes if all inventories are returned without repeats</Result>
        /// </summary>
        [Fact]
        public void InventoryControllerShouldBeAbleToReturnAllLocationInventories()
        {
            Inventory inventory1 = new Inventory
            {
                Id = 1,
                IngredientName = "Tomato",
                IngredientType = "Fruit",
                Price = 0.50M
            };
            Inventory inventory2 = new Inventory
            {
                Id = 2,
                IngredientName = "Chicken wing - 8 pieces",
                IngredientType = "Meat",
                Price = 0.25M
            };
            Inventory inventory3 = new Inventory
            {
                Id = 3,
                IngredientName = "Cheese",
                IngredientType = "Dairy",
                Price = 1.00M
            };
            Inventory inventory4 = new Inventory
            {
                Id = 4,
                IngredientName = "Coke",
                IngredientType = "Soda",
                Price = 1.50M
            };
            Inventory inventory5 = new Inventory
            {
                Id = 5,
                IngredientName = "Guiness",
                IngredientType = "Alcohol",
                Price = 4.00M
            };

            var repoMock = new Mock<IZVRPubRepository>();
            repoMock.Setup(c => c.GetInventories()).Returns(new List<Inventory>
            {
                inventory1, inventory2, inventory3, inventory4, inventory5
            });

            var controller = new InventoryController(repoMock.Object);
            var result = controller.GetAll();

            Assert.NotNull(result.Value);
            Assert.Same(inventory1, result.Value[0]);
            Assert.Same(inventory2, result.Value[1]);
            Assert.Same(inventory3, result.Value[2]);
            Assert.Same(inventory4, result.Value[3]);
            Assert.Same(inventory5, result.Value[4]);
        }

        /// <summary>
        /// <Purpose>Tests method to search for a single inventory ingredient by name of said ingredient</Purpose>
        /// 
        /// <Result>Test passes if result is not null, result is exactly the searched for ingredients, and all other ingredients are not returned</Result>
        /// </summary>
        [Fact]
        public void InventoryControllerShouldBeAbleToReturnInventoryItemsByIngredientName()
        {
            Inventory inventory1 = new Inventory
            {
                Id = 1,
                IngredientName = "Tomato",
                IngredientType = "Fruit",
                Price = 0.50M
            };
            Inventory inventory2 = new Inventory
            {
                Id = 2,
                IngredientName = "Chicken wing - 8 pieces",
                IngredientType = "Meat",
                Price = 0.25M
            };
            Inventory inventory3 = new Inventory
            {
                Id = 3,
                IngredientName = "Cheese",
                IngredientType = "Dairy",
                Price = 0.00M
            };
            Inventory inventory4 = new Inventory
            {
                Id = 4,
                IngredientName = "Coke",
                IngredientType = "Soda",
                Price = 1.50M
            };
            Inventory inventory5 = new Inventory
            {
                Id = 5,
                IngredientName = "Guiness",
                IngredientType = "Alcohol",
                Price = 4.00M
            };

            var repoMock = new Mock<IZVRPubRepository>();
            repoMock.Setup(c => c.GetInventoriesByName("Cheese")).Returns(inventory3);

            var controller = new InventoryController(repoMock.Object);
            var result = controller.Get("Cheese");

            Assert.NotNull(result.Value);
            Assert.Same(inventory3, result.Value);
            Assert.NotSame(inventory1, result.Value);
            Assert.NotSame(inventory2, result.Value);
            Assert.NotSame(inventory4, result.Value);
            Assert.NotSame(inventory5, result.Value);
        }
    }
}
