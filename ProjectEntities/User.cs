using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEntities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "It can not be empty!")]
        [StringLength(20, ErrorMessage = "Max 20 character!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "It can not be empty!")]
        [StringLength(20, ErrorMessage = "Max 20 character!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "It can not be empty!")]
        [StringLength(20, ErrorMessage = "Max 20 character!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "It can not be empty!")]
        [StringLength(50, ErrorMessage = "Max 50 character!")]
        public string Mail { get; set; }

        [StringLength(10)]
        public string Role { get; set; } = "user";
    }
}
