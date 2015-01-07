using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public class Brand
    {

        public Brand()
        {
            Discounts = new HashSet<Discount>();
        }

        [Key]
        public int id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public double Price { get; set; }
        
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public virtual ICollection<Discount> Discounts { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

    }
}
