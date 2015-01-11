using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AppieApplication.Model;
using AppieApplication.ViewModel;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class BrandListViewModelTest
    {

        private IBrandRepository mockBrandRepo;
        private BrandListViewModel bvm;

        public BrandListViewModelTest()
        {
            Mock<IBrandRepository> moq = new Mock<IBrandRepository>();

            List<Brand> brands = new List<Brand> { new Brand{ id = 1, Name = "Calve", Price = 2.25 }, new Brand{id = 2, Name = "Ruiter", Price = 1.75}, new Brand{id = 3, Name = "Albert Heijn", Price = 1}};

            moq.Setup(m => m.Create(It.IsAny<Brand>())).Callback((Brand c) => { c.id = brands.Count + 1; brands.Add(c); });

            moq.Setup(m => m.GetAll()).Returns(brands);

            moq.Setup(m => m.Get(It.IsAny<int>())).Returns((int i) => brands.Where(x => x.id == i).FirstOrDefault());

            moq.Setup(m => m.GetByName(It.IsAny<String>())).Returns((String s) => brands.Where(x => x.Name == s).Single());

            moq.Setup(m => m.Delete(It.IsAny<Brand>())).Callback((Brand c) => brands.Remove(c));

            moq.Setup(m => m.Edit(It.IsAny<Brand>())).Callback((Brand c) =>
            {

                var original = brands.Where(x => x.id.Equals(c.id)).Single();

                if (original != null)
                {
                    original.Name = c.Name;
                    original.Price = c.Price;

                }
            });

            mockBrandRepo = moq.Object;
            bvm = new BrandListViewModel(moq.Object);
        }

        [TestMethod]
        public void AddBrand()
        {
            bvm.BrandName = "Zaanse Hoeve";
            bvm.BrandPrice = 1.33;

            bvm.AddBrand();

            Brand b = mockBrandRepo.Get(4);
            Assert.IsNotNull(b);
            Assert.IsInstanceOfType(b, typeof(Brand));
            Assert.AreEqual(4, b.id);
            Assert.AreEqual("Zaanse Hoeve", b.Name);
        }

        [TestMethod]
        public void DeleteBrand()
        {
            bvm.SelectedBrand = new BrandViewModel { Id = 1, Name = "Calve", Price = 2.25};
            bvm.DeleteBrand();

            Brand b = mockBrandRepo.Get(1);
            Assert.IsNull(b);
        }

        [TestMethod]
        public void UpdateBrand()
        {
            bvm.SelectedBrand = new BrandViewModel { Id = 1, Name = "Calve-Edited", Price = 2.25 };
            bvm.EditBrand();

            Brand b = mockBrandRepo.Get(1);

            Assert.IsNotNull(b);
            Assert.IsInstanceOfType(b, typeof(Brand));
            Assert.AreEqual(1, b.id);
            Assert.AreEqual("Calve-Edited", b.Name);
        }
    }
}
