using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList5.Models;
using ToDoList5.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ToDoList.Tests.ControllerTests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void ItemsController_AddsItemToIndexModelData_Collection()
        {
            // Arrange
            ItemsController controller = new ItemsController();
            var testCategory = new Category();
            var testItem = new Item();
            testCategory.Name = "test category";
            testItem.Description = "test item";
            testItem.Category = testCategory;

            // Act
            controller.Create(testItem);
            ViewResult indexView = new ItemsController().Index() as ViewResult;
            var collection = indexView.ViewData.Model as List<Item>;

            // Assert
            CollectionAssert.Contains(collection, testItem);
        }
    }
}
