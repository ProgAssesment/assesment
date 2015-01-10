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

        [Key]
        public int BrandId { get; set; }
        
        [ForeignKey("BrandId")]
        public virtual Brand brand { get; set; }

        [Required]
        public int Count { get; set; }

    }
}
