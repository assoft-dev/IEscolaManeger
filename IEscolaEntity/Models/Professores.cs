using IEscolaEntity.Models.Biblioteca;
using IEscolaEntity.Models.Helps;
using ServiceStack.DataAnnotations;
using System;

namespace IEscolaEntity.Models
{
    public class Professores: ModelsEntityBase
    {
        [AutoIncrement]
        public int ProfessoresID { get; set; }
        public string NumeroAgente  { get; set; }
        
        public Escolaridade Escolaridade { get; set; }
        public AbilitacoesLiterarias abilitacoesLiterarias { get; set; }
        public string AreaEscola { get; set; }
        public int AreaDuracao { get; set; }
        public DateTime AreaData { get; set; }
        public ProvinciasLocal AreaProvincia { get; set; }

        [ForeignKey(typeof(ProfessoresCategorias))]
        public int ProfessorCategoriaID { get; set; }
        [Reference] public ProfessoresCategorias  ProfessoresCategorias { get; set; }

        [ForeignKey(typeof(ProfessorAreaFormacao))]
        public int ProfessorAreaFormacaoID { get; set; }
        [Reference] public ProfessorAreaFormacao ProfessorAreaFormacao { get; set; }
    }
}
