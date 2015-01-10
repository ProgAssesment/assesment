using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public class ShoppingList
    {

        public ShoppingList()
        {
            Products = new HashSet<Brand>();
        }

        [Key]
        public int Id { get; set; }

        public virtual ICollection<Brand> Products { get; set; }

    }
}
