using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList5.Models;
using ToDoList5.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace ToDoList.Tests.ControllerTests
{
    [TestClass]
    public class ControllerTests
    {
        Mock<ICategoryRepository> catMock = new Mock<ICategoryRepository>();
        Mock<IItemRepository> mock = new Mock<IItemRepository>();

        private void DbSetup()
        { 
            catMock.Setup(m => m.Categories).Returns(new Category[]
                {
                new Category {CategoryId = 1, Name = "cleaning" }
                }.AsQueryable());

            mock.Setup(m => m.Items).Returns(new Item[]
            {
                new Item {ItemId = 1, Description = "Wash the dog", CategoryId = 1 },
                new Item {ItemId = 2, Description = "Do the dishes", CategoryId = 1 },
                new Item {ItemId = 3, Description = "Sweep the floor", CategoryId = 1 }
            }.AsQueryable());
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult() // Confirms route returns view
        {
            //Arrange
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexContainsModelData_List() // Confirms model as list of items
        {
            // Arrange
            DbSetup();
            ViewResult indexView = new ItemsController(mock.Object).Index() as ViewResult;

            // Act
            var result = indexView.ViewData.Model;

            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Item>));
        }

        [TestMethod]
        public void Mock_IndexModelContainsItems_Collection() // Confirms presence of known entry
        {
            // Arrange
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);
            Item testItem = new Item();
            testItem.Description = "Wash the dog";
            testItem.ItemId = 1;

            // Act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Item> collection = indexView.ViewData.Model as List<Item>;

            // Assert
            CollectionAssert.Contains(collection, testItem);
        }

        [TestMethod]
        public void Mock_PostViewResultCreate_RedirectToActionResult()
        {
            // Arrange
            Item testItem = new Item
            {
                ItemId = 1,
                Description = "Wash the dog"
            };

            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);

            // Act
            var resultView = controller.Create(testItem) as RedirectToActionResult;


            // Assert
            Assert.IsInstanceOfType(resultView, typeof(RedirectToActionResult));

        }

        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            // Arrange
            Item testItem = new Item
            {
                ItemId = 1,
                Description = "Wash the dog"
            };

            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);

            // Act
            var resultView = controller.Details(testItem.ItemId) as ViewResult;
            var model = resultView.ViewData.Model as Item;

            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Item));
        }
    }
}
