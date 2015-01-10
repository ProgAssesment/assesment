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

            moq.Setup(m => m.GetAll()).Returns(catagories);

            moq.Setup(m => m.Get(It.IsAny<int>())).Returns((int i) => catagories.Where(x => x.Id == i).Single());

            moq.Setup(m => m.GetByName(It.IsAny<String>())).Returns((String s) => catagories.Where(x => x.Name == s).Single());

            moq.Setup(m => m.Create(It.IsAny<Catagory>())).Callback((Catagory c) => catagories.Add(c));

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
            cvm.SelectedCatagory = new CatagoryViewModel { Id = 4, Name = "Brood" };

            //act
            cvm.AddCatagory();

            //assert
            Catagory c = mockCatagoryRepo.GetByName("Brood");
            Assert.IsNotNull(c);
            Assert.IsInstanceOfType(c, typeof(Catagory));
            Assert.AreEqual(4, c.Id);

        }
    }
}
