using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaverikDesktop.Models
{

    public class User
    {
        [Key]
        public String id { get; set; }
        [Required]
        public String nombre { get; set; }
        [Required]
        public String apellido { get; set; }
        [Required]
        [MaxLength(15)]
        [Index(IsUnique = true)]
        public String usuario { get; set; }
        [Required]
        [MaxLength(15)]
        public String password { get; set; }

        public User()
        {
        }


    }
}



