﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SG_ASP_2.Models
{
    public class Admision
    {
        [Key]
        public int IdAdmi { get; set; }

        public int IdAtenciones { get; set; }

        [Display(Name ="Hora de ingreso")]
        public TimeSpan? HorIng { get; set; }

        [Display(Name ="Hora de salida")]
        public TimeSpan? HorSal { get; set; }

        [StringLength(200)]
        [Display(Name ="Pendientes")]
        public string Pendie { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        public virtual Atenciones Atenciones { get; set; }
    }
}