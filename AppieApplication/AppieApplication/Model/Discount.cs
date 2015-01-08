using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppieApplication.Model
{
    public class Discount
    {
        [Key]
        public int Coupon { get; set; }
        
        public int BrandId { get; set; }

        [Required]
        public double PriceReduction { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

    }
}
