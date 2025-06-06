﻿using IEscolaEntity.Models.Helps;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IEscolaEntity.Models
{
    public class MiniPauta_Trimestre
    {
        [AutoIncrement, Display(Name = "Código")]
        public int TrimestreID { get; set; }

        [Display(Name = "Referência")]
        public string Descricao { get; set; }

        [Display(Name = "Inicio")]
        public DateTime PeriodoInicio { get; set; }

        [Display(Name = "Fim")]
        public DateTime PeriodoFim { get; set; }

        [Display(Name = "Tolerância")]
        public int Tolerancia { get; set; }

        [Display(Name = "Ano Academico")]
        public Anos Anos { get; set; }

        [Ignore] public bool Estado
        {
            get
            {
                if (DateTime.Now.Date > PeriodoInicio.Date && DateTime.Now.Date < PeriodoFim.Date)
                    return true;
                return false;
            }
        }
    }
}
