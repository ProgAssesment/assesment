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
    public class DiscountListViewModelTest
    {

        private IDiscountRepository mockDiscountRepo;
        private DiscountListViewModel cvm;

        public DiscountListViewModelTest()
        {
            Mock<IDiscountRepository> moq = new Mock<IDiscountRepository>();

            //Brand b1 = new Brand { id = 1, Name = "Calve", Price = 2.50 };
            //Brand b2 = new Brand { id = 1, Name = "Ruiter", Price = 2.20 };
            //Brand b3 = new Brand { id = 1, Name = "Ah", Price = 1.00 };

            List<Discount> discounts = new List<Discount> { new Discount { Coupon = 1, StartDate = DateTime.Now, EndDate = DateTime.Now, PriceReduction = 2, BrandId = 1 }, new Discount { Coupon = 2, StartDate = new DateTime(2015, 1, 1), EndDate = new DateTime(2015, 1, 5), PriceReduction = 0.75, BrandId = 2 }, new Discount { Coupon = 1, StartDate = new DateTime(2016, 1, 1), EndDate = new DateTime(2016, 1, 5), PriceReduction = 0.25, BrandId = 3 } };

            moq.Setup(m => m.Create(It.IsAny<Discount>())).Callback((Discount c) => { c.Coupon = discounts.Count + 1; discounts.Add(c); });

            moq.Setup(m => m.GetAll()).Returns(discounts);

            moq.Setup(m => m.Get(It.IsAny<int>())).Returns((int i) => discounts.Where(x => x.Coupon == i).FirstOrDefault());

            moq.Setup(m => m.Delete(It.IsAny<Discount>())).Callback((Discount c) => discounts.Remove(c));

            moq.Setup(m => m.Edit(It.IsAny<Discount>())).Callback((Discount c) =>
            {

                var original = discounts.Where(x => x.Coupon.Equals(c.Coupon)).Single();

                if (original != null)
                {
                    original.BrandId = c.BrandId;

                }
            });

            mockDiscountRepo = moq.Object;
            //cvm = new DiscountListViewModel(moq.Object);
        }

        [TestMethod]
        public void AddDiscount()
        {

            //arrange
            cvm.SelectedDiscount = new DiscountViewModel { Coupon = 4, StartDate = new DateTime(2014, 1, 1), EndDate = new DateTime(2014, 1, 5), PriceReduction = 0.60, BrandId = 1 };

            //act
            cvm.AddDiscount();

            //assert
            Discount c = mockDiscountRepo.Get(4);
            Assert.IsNotNull(c);
            Assert.IsInstanceOfType(c, typeof(Discount));
            Assert.AreEqual(4, c.Coupon);

        }

        // Failed asser is null failed
        //Hij kan geen vergelijking maken met datetime/pricereduction en of brandid
        [TestMethod]
        public void DeleteDiscount()
        {
            cvm.SelectedDiscount = new DiscountViewModel { Coupon = 1, StartDate = DateTime.Now, EndDate = DateTime.Now, PriceReduction = 2, BrandId = 1 };

            cvm.DeleteDiscount();

            Discount c = mockDiscountRepo.Get(1);
            Assert.IsNull(c);
        }

        [TestMethod]
        public void UpdateDiscount()
        {
            cvm.SelectedDiscount = new DiscountViewModel { Coupon = 1, StartDate = new DateTime(2017, 1, 1), EndDate = new DateTime(2017, 1, 5), PriceReduction = 0.30, BrandId = 2 };

            cvm.UpdateDiscount();

            Discount c = mockDiscountRepo.Get(1);

            Assert.IsNotNull(c);
            Assert.IsInstanceOfType(c, typeof(Discount));
            Assert.AreEqual(1, c.Coupon);
            Assert.AreEqual(DateTime.Now, c.StartDate);
            Assert.AreEqual(DateTime.Now, c.EndDate);
            Assert.AreEqual(0.30, c.PriceReduction);
            Assert.AreEqual(2, c.BrandId);

        }
    }
}
