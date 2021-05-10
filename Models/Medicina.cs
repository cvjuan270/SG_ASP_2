using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SG_ASP_2.Models
{
    public class Medicina
    {
        public int Id { get; set; }

        [Display(Name = "Hora Ingreso")]
        public TimeSpan? HorIng { get; set; }

        [Display(Name = "Hora Salida")]
        public TimeSpan? HorSal { get; set; }

        [StringLength(50)]
        [Display(Name = "Aptitud")]
        public string Aptitu { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha de aptitud")]
        public DateTime? FecApt { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha de envío")]
        public DateTime? FecEnv { get; set; }

        [StringLength(100)]
        [Display(Name = "Comentarios")]
        public string Coment { get; set; }

        [StringLength(100)]
        [Display(Name = "Observaciones")]
        public string Observ { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        //[Display(Name = "Médico")]
        //public ICollection<Medico> Medico { get; set; }

        public virtual Atenciones Atenciones { get; set; }
    }
}
