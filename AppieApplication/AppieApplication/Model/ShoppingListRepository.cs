using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public class ShoppingListRepository : IShoppingListRepository
    {

        private DBcontext context;

        public ShoppingListRepository()
        {
            context = new DBcontext();
        }

        public ShoppingList Get(int id)
        {
            return context.ShoppingLists.Where(x => x.Id.Equals(id)).First();
        }

        public void Delete(ShoppingList shoppingList)
        {
            context.ShoppingLists.Remove(shoppingList);
            context.SaveChanges();
        }

        public void Create(ShoppingList shoppingList)
        {
            context.ShoppingLists.Add(shoppingList);
            context.SaveChanges();
        }

        public void Edit(ShoppingList shoppingList)
        {
            context.Entry(shoppingList).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
