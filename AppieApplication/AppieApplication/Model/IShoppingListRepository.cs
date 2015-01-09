using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public interface IShoppingListRepository
    {
        ShoppingList Get(int id);
        void Delete(ShoppingList shoppingList);
        void Create(ShoppingList shoppingList);
        void Edit(ShoppingList shoppingList);
    }
}
