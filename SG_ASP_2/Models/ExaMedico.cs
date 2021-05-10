using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SG_ASP_2.Models
{
    public class ExaMedico
    {
        [Key]
        public int IdExMed { get; set; }
        public String Examen { get; set; }
        public virtual ICollection<Auditoria> Auditorias { get; set; }
    }
}