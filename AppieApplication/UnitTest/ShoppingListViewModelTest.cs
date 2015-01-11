using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppieApplication.ViewModel;
using AppieApplication.Model;
using Moq;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class ShoppingListViewModelTest
    {

        private IShoppingListRepository mockCatagoryRepo;
        private ShoppingListViewModel svm;

        public ShoppingListViewModelTest()
        {
            Mock<IShoppingListRepository> moq = new Mock<IShoppingListRepository>();

            Brand b1 = new Brand { id = 1, Name = "Calve", Price = 2.50 };
            Brand b2 = new Brand { id = 1, Name = "Ruiter", Price = 2.20 };
            Brand b3 = new Brand { id = 1, Name = "Ah", Price = 1.00 };

            Product p1 = new Product { Id = 1, Name = "Pindakaas", Brands = new List<Brand> { b1, b2 } };
            Product p2 = new Product { Id = 1, Name = "Melk", Brands = new List<Brand> { b3 } };

            b1.Product = p1;
            b2.Product = p1;
            b3.Product = p2;

            List<ShoppingList> shoppingList = new List<ShoppingList> { new ShoppingList { brand = b1, Count = 2 }, new ShoppingList { brand = b2, Count = 1 }, new ShoppingList { brand = b3, Count = 3 } };

            moq.Setup(m => m.Create(It.IsAny<ShoppingList>())).Callback((ShoppingList c) => { c.BrandId = shoppingList.Count + 1; shoppingList.Add(c); });

            moq.Setup(m => m.GetAll()).Returns(shoppingList);

            moq.Setup(m => m.Delete(It.IsAny<ShoppingList>())).Callback((ShoppingList c) => shoppingList.Remove(c));

            mockCatagoryRepo = moq.Object;
            svm = new ShoppingListViewModel(moq.Object);
        }

        [TestMethod]
        public void TotalPrice()
        {
            svm.SetupList();
            Assert.AreEqual(10.20, svm.TotalPrice);
        }
    }
}
