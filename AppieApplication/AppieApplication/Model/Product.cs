using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApplication.Model
{
    public class Product
    {

        public Product()
        {
            Brands = new HashSet<Brand>();
        }

        [Key]
        public int Id { get; set; }
        public int CatagoryId { get; set; }
        [ForeignKey("CatagoryId")]
        public virtual Catagory Catagory { get; set; }
        [Required]
        public String Name { get; set; }


        public virtual ICollection<Brand> Brands { get; set; }
    }
}
