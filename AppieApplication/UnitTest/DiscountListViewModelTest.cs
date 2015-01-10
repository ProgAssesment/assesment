using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppieApplication.Model;
using Moq;
using System.Collections.Generic;
using AppieApplication.ViewModel;

namespace UnitTest
{
    [TestClass]
    public class DiscountListViewModelTest
    {
        [TestMethod]
        public void DiscountListViewModelTest_AddDiscount_Succes()
        {
            //Arrange
            Mock<IDiscountRepository> moq = new Mock<IDiscountRepository>();
            
            moq.Setup(m => m.GetAll())
                  .Returns(new List<Discount>()
                {
                    new Discount{ Coupon = 13, StartDate = DateTime.Now, EndDate = DateTime.Now, BrandId = 5,}
                });

            var discountViewModel = new DiscountListViewModel(moq.Object);


            //Act

            //Assert
        }
    }
}
