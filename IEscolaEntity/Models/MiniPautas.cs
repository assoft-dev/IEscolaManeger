using ServiceStack.DataAnnotations;

namespace IEscolaEntity.Models
{
    public class MiniPautas
    {
        [AutoIncrement]
        public int PautasID { get; set; }

        //Trimestre 1
        public decimal MAC { get; set; }
        public decimal NPP { get; set; }
        public decimal NPT { get; set; }

        [Ignore]
        public decimal MT { get { return (MAC * NPP * NPT) / 3; } }

        [Ignore] public char Divid1 { get { return '|'; } }

        //Trimestre 2
        public decimal MAC1 { get; set; }
        public decimal NPP1{ get; set; }
        public decimal NPT1 { get; set; }

        [Ignore]
        public decimal MT1 { get { return (MAC1 * NPP1 * NPT1) / 3; } }
        [Ignore] public char Divid2 { get { return '|'; } }

        //Trimestre 3
        public decimal MAC2 { get; set; }
        public decimal NPP2 { get; set; }
        public decimal NPT2 { get; set; }

        [Ignore]
        public decimal MT2 { get { return (MAC2 * NPP2 * NPT2) / 3; } }
        [Ignore] public char Divid3 { get { return '|'; } }


        [Ignore] public decimal MFD { get { return (MT * MT1 * MT2) / 3; } }
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
