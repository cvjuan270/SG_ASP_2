using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SG_ASP_2.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }

        [StringLength(50)]
        [Required]
        public string NomApe { get; set; }
    }
}