using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SG_ASP_2.Models
{
    public class Aptitud
    {
        [Key]
        public int IdApti { get; set; }

        [StringLength(50)]
        [Required]
        public string Descri { get; set; }
    }
}