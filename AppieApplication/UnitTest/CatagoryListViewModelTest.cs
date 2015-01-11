using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppieApplication.Model;
using Moq;
using System.Collections.Generic;
using AppieApplication.ViewModel;

namespace UnitTest
{
    [TestClass]
    public class CatagoryListViewModelTest
    {


        private ICatagoryRepository mockCatagoryRepo;
        private CatagoryListViewModel cvm;

        public CatagoryListViewModelTest()
        {
            Mock<ICatagoryRepository> moq = new Mock<ICatagoryRepository>();

            List<Catagory> catagories = new List<Catagory> { new Catagory { Id = 1, Name = "Zuivel" }, new Catagory { Id = 2, Name = "Broodbeleg" }, new Catagory { Id = 3, Name = "Snoep" } };

            moq.Setup(m => m.Create(It.IsAny<Catagory>())).Callback((Catagory c) => { c.Id = catagories.Count + 1; catagories.Add(c); });

            moq.Setup(m => m.GetAll()).Returns(catagories);

            moq.Setup(m => m.Get(It.IsAny<int>())).Returns((int i) => catagories.Where(x => x.Id == i).FirstOrDefault());

            moq.Setup(m => m.GetByName(It.IsAny<String>())).Returns((String s) => catagories.Where(x => x.Name == s).Single());

            moq.Setup(m => m.Delete(It.IsAny<Catagory>())).Callback((Catagory c) => catagories.Remove(c));

            moq.Setup(m => m.Edit(It.IsAny<Catagory>())).Callback((Catagory c) => 
            {

                var original = catagories.Where(x => x.Id.Equals(c.Id)).Single();

                if (original != null)
                {
                    original.Name = c.Name;
                    
                }
            });

            mockCatagoryRepo = moq.Object;
            cvm = new CatagoryListViewModel(moq.Object);

        }


        [TestMethod]
        public void AddCatagory()
        {
            //arrange
            cvm.CatagoryName = "Brood";

            //act
            cvm.AddCatagory();

            //assert
            Catagory c = mockCatagoryRepo.Get(4);
            Assert.IsNotNull(c);
            Assert.IsInstanceOfType(c, typeof(Catagory));
            Assert.AreEqual(4, c.Id);
            Assert.AreEqual("Brood", c.Name);
        }

        [TestMethod]
        public void DeleteCatagory()
        {
            cvm.SelectedCatagory = new CatagoryViewModel { Id = 1, Name = "Zuivel" };

            cvm.DeleteCatagory();

            Catagory c = mockCatagoryRepo.Get(1);
            Assert.IsNull(c);
        }

        [TestMethod]
        public void UpdateCatagory()
        {
            cvm.SelectedCatagory = new CatagoryViewModel { Id = 1, Name = "ZuivelEdited" };

            cvm.EditCatagory();

            Catagory c = mockCatagoryRepo.Get(1);

            Assert.IsNotNull(c);
            Assert.IsInstanceOfType(c, typeof(Catagory));
            Assert.AreEqual(1, c.Id);
            Assert.AreEqual("ZuivelEdited", c.Name);

        }

    }
}
