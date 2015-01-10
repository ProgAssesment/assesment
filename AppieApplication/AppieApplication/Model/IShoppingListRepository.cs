using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public interface IShoppingListRepository
    {
        List<ShoppingList> GetAll();
        void Delete(ShoppingList shoppingList);
        void Create(ShoppingList shoppingList);
        void Edit(ShoppingList shoppingList);
    }
}
