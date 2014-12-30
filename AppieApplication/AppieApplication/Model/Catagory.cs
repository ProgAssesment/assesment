using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public class Catagory
    {

        public Catagory()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
