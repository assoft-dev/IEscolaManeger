using IEscolaEntity.Models.Helps;
using ServiceStack.DataAnnotations;
using System;

namespace IEscolaEntity.Models
{
    public class EstudantesInscricoes : ModelsEntityBase
    {
        [AutoIncrement]
        public int InscricaoID { get; set; }

        // Dados dos Encarregados
        public GrauParentesco GrauParentesco { get; set; }
        public string NomeEncarregado { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public bool PaiVive { get; set; }
        public bool MaeVive { get; set; }
        public string DocRecenciamentoMilitar { get; set; }

        [ForeignKey(typeof(Cursos))]
        public int CursosID { get; set; }
        [Reference] public Cursos Cursos { get; set; }

        // Informações adicionais (Documentos apresentar)
        public string AdiconalEscolaOrigem { get; set; }
        public ProvinciasLocal AdiconalProvincias { get; set; }
        public decimal AdicionalMedia { get; set; }
        public decimal Media { get; set; }

        public FAZES FAZES { get; set; }
        public bool AdicionalFichaInscricao { get; set; }
        public bool AdicionalCertificados { get; set; }
    }
}
