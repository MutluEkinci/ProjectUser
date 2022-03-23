using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEntities
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "It can not be empty!")]
        [StringLength(50, ErrorMessage = "Max 50 character!")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "It can not be empty!")]
        public decimal Price { get; set; }
    }
}
