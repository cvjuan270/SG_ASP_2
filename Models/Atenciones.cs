﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SG_ASP_2.Models
{
    public class Atenciones
    {
        public Atenciones()
        {
            //Admision = new Admision();
            //Auditoria = new Auditoria();
            //Interconsulta = new HashSet<Interconsulta>();
            Medicina = new HashSet<Medicina>();
        }

        public int Id { get; set; }

        [StringLength(20)]
        public string Local0 { get; set; }

        [StringLength(20)]
        [Display(Name = "Tip. Examen")]
        public string TipExa { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FecAte { get; set; }

        [StringLength(100)]
        [Display(Name = "Nombres y Apellidos")]
        public string NomApe { get; set; }

        [StringLength(20)]
        [Display(Name = "Doc. de Identidad")]
        public string DocIde { get; set; }

        [StringLength(100)]
        [Display(Name = "Empresa")]
        public string Empres { get; set; }

        [StringLength(100)]
        [Display(Name = "Sub Contrata")]
        public string SubCon { get; set; }

        [StringLength(100)]
        [Display(Name = "Proyecto")]
        public string Proyec { get; set; }

        [StringLength(100)]
        public string Perfil { get; set; }

        [StringLength(100)]
        public string Area { get; set; }

        [StringLength(100)]
        [Display(Name = "Puesto de trabajo")]
        public string PueTra { get; set; }

        [StringLength(50)]
        [Display(Name = "Admision")]
        public string PeReAd { get; set; }

        [Display(Name = "Hora de ingreso")]
        public TimeSpan? Hora { get; set; }

        [Display(Name = "Médico")]
        public int Medico { get; set; }

        //public virtual Admision Admision { get; set; }
        public virtual Medico Medicos { get; set; }
        //public virtual Auditoria Auditoria { get; set; }
        //public virtual ICollection<Interconsulta> Interconsulta { get; set; }
        public virtual ICollection<Medicina> Medicina { get; set; }
    }
}