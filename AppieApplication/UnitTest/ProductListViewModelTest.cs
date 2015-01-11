using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using AppieApplication.Model;
using AppieApplication.ViewModel;

namespace UnitTest
{
    [TestClass]
    public class ProductListViewModelTest
    {

        private IProductRepository mockProductRepo;
        private ProductListViewModel pvm;

        public ProductListViewModelTest()
        {

            Mock<IProductRepository> moq = new Mock<IProductRepository>();

            List<Product> products = new List<Product> { new Product{ Id = 1, Name = "Pindakaas" }, new Product{ Id = 2, Name = "Melk" }, new Product{Id = 3, Name = "Hagelslag"}};

            moq.Setup(m => m.Create(It.IsAny<Product>())).Callback((Product c) => { c.Id = products.Count + 1; products.Add(c); });

            moq.Setup(m => m.GetAll()).Returns(products);

            moq.Setup(m => m.Get(It.IsAny<int>())).Returns((int i) => products.Where(x => x.Id == i).FirstOrDefault());

            moq.Setup(m => m.GetByName(It.IsAny<String>())).Returns((String s) => products.Where(x => x.Name == s).Single());

            moq.Setup(m => m.Delete(It.IsAny<Product>())).Callback((Product c) => products.Remove(c));

            moq.Setup(m => m.Edit(It.IsAny<Product>())).Callback((Product c) =>
            {

                var original = products.Where(x => x.Id.Equals(c.Id)).Single();

                if (original != null)
                {
                    original.Name = c.Name;

                }
            });

            mockProductRepo = moq.Object;
            pvm = new ProductListViewModel(moq.Object);

        }

        [TestMethod]
        public void AddProduct()
        {
            //arrange
            pvm.ProductName = "Banaan";

            //act
            pvm.AddProduct();

            //assert
            Product p = mockProductRepo.Get(4);
            Assert.IsNotNull(p);
            Assert.IsInstanceOfType(p, typeof(Product));
            Assert.AreEqual(4, p.Id);
        }

        [TestMethod]
        public void DeleteProduct()
        {
            pvm.SelectedProduct = new ProductViewModel { Id = 1, Name = "Pindakaas" };

            pvm.DeleteProduct();

            Product p = mockProductRepo.Get(1);
            Assert.IsNull(p);
        }

        [TestMethod]
        public void UpdateProduct()
        {
            pvm.SelectedProduct = new ProductViewModel { Id = 1, Name = "PindakaasEdited" };

            pvm.EditProduct();

            Product p = mockProductRepo.Get(1);

            Assert.IsNotNull(p);
            Assert.IsInstanceOfType(p, typeof(Product));
            Assert.AreEqual(1, p.Id);
            Assert.AreEqual("PindakaasEdited", p.Name);
        }
    }
}
