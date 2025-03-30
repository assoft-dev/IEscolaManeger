using ServiceStack.DataAnnotations;

namespace IEscolaEntity.Models
{
    public class MiniPautas
    {
        [AutoIncrement]
        public int PautasID { get; set; }

        public decimal MAC { get; set; }
        public decimal NPP { get; set; }
        public decimal NPT { get; set; }
        public decimal MT { get; set; }
        public decimal MFD { get; set; }
        public string OBS { get; set; }


        [ForeignKey(typeof(Turmas))]
        public int TurmasID { get; set; }
        [Reference] public Turmas Turmas { get; set; }


        [ForeignKey(typeof(MiniPauta_Trimestre))]
        public int Pautas_TrimestresID { get; set; }
        [Reference] public MiniPauta_Trimestre Pautas_Trimestres { get; set; }


        [ForeignKey(typeof(Estudantes))]
        public int EstudantesID { get; set; }
        [Reference] public Estudantes Estudantes { get; set; }


        [ForeignKey(typeof(ProfessoresDisciplinas))]
        public int ProfessoresCursosID { get; set; }
        [Reference] public ProfessoresDisciplinas ProfessoresDisciplinas { get; set; }
    }
}
