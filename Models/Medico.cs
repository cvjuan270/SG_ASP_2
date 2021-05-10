using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SG_ASP_2.Models
{
    public class Medico
    {
        
        public int Id { get; set; }

       [StringLength(250)]
        public string NomApe { get; set; }

    }
}