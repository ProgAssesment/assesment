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
    public class RecipeListViewModelTest
    {
        private RecipeListViewModel cvm;
         private IRecipeRepository mockRecipeRepo;

         public RecipeListViewModelTest()
        {
            Mock<IRecipeRepository> moq = new Mock<IRecipeRepository>();

            List<Recipe> recipes = new List<Recipe> { new Recipe { id = 1, Name = "Spaghetti" }, new Recipe { id = 2, Name = "Pizza Mozarella"}, new Recipe { id = 3, Name = "Kalkoen" } };

            moq.Setup(m => m.Create(It.IsAny<Recipe>())).Callback((Recipe c) => { c.id = recipes.Count + 1; recipes.Add(c); });

            moq.Setup(m => m.GetAll()).Returns(recipes);

            moq.Setup(m => m.Get(It.IsAny<int>())).Returns((int i) => recipes.Where(x => x.id == i).FirstOrDefault());

            moq.Setup(m => m.Delete(It.IsAny<Recipe>())).Callback((Recipe c) => recipes.Remove(c));

            moq.Setup(m => m.Edit(It.IsAny<Recipe>())).Callback((Recipe c) =>
            {

                var original = recipes.Where(x => x.id.Equals(c.id)).Single();

                if (original != null)
                {
                    original.Name = c.Name;

                }
            });

            mockRecipeRepo = moq.Object;
            cvm = new RecipeListViewModel(moq.Object);
        }

        [TestMethod]
        public void AddRecipe()
        {

            //arrange
            cvm.SelectedRecipe = new RecipeViewModel { Id = 4, Name = "Soep" };

            //act
            cvm.AddRecipe();

            //assert
            Recipe c = mockRecipeRepo.Get(4);
            Assert.IsNotNull(c);
            Assert.IsInstanceOfType(c, typeof(Recipe));
            Assert.AreEqual(4, c.id);

        }

        // Failed asser is null failed
        //Hij kan geen vergelijking maken met datetime/pricereduction en of brandid
        [TestMethod]
        public void DeleteRecipe()
        {
            cvm.SelectedRecipe = new RecipeViewModel { Id = 1, Name = "Spaghetti" }; 

            cvm.DeleteRecipe();

            Recipe c = mockRecipeRepo.Get(1);
            Assert.IsNull(c);
        }

        [TestMethod]
        public void UpdateRecipe()
        {
            cvm.SelectedRecipe = new RecipeViewModel { Id = 4, Name = "SpaghettiEdited" };

            cvm.UpdateRecipe();

            Recipe c = mockRecipeRepo.Get(1);

            Assert.IsNotNull(c);
            Assert.IsInstanceOfType(c, typeof(Recipe));
            Assert.AreEqual(1, c.id);
            Assert.AreEqual("SpaghettiEdited", c.Name);

        }
    }
}
