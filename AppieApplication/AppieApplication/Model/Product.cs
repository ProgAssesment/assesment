using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public class Product
    {

        private List<Discount> discountList;

        public Product()
        {
            discountList = new List<Discount>();
        }


        [Key]
        public int Id { get; set; }
        [Required]
        public String Type { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Brand { get; set; }
        [Required]
        public double Price { get; set; }

    }
}
