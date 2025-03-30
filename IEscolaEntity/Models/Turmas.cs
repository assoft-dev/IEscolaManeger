using ServiceStack.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace IEscolaEntity.Models
{
    public class Turmas
    {

        [AutoIncrement]
        public int TurmaID { get; set; }

        [Required]
        public string Descricao { get; set; }


        [Ignore]
        public string Detalhes { 
            get 
            {
                var deta =new StringBuilder();

                if (Cursos != null) 
                    deta.Append("[ " + Cursos.Descricao);

                if (Classes != null)
                    deta.Append(" / " + Classes.Descricao);

                if (Periodos != null)
                    deta.Append(" / " + Periodos.Descricao + " ]");

                return deta.ToString();
            }
        }


        public int Quantidade { get; set; }
        public int Idades1 { get; set; }
        public int Idades2 { get; set; }


        [ForeignKey(typeof(Cursos))]
        public int CursosID { get; set; }
        [Reference] public Cursos  Cursos { get; set; }


        [ForeignKey(typeof(Classes))]
        public int ClassesID { get; set; }
        [Reference] public Classes Classes { get; set; }


        [ForeignKey(typeof(Salas))]  
        public int SalasID { get; set; }
        [Reference] public Salas  Salas { get; set; }


        [ForeignKey(typeof(Periodos), OnDelete = "CASCADE")]
        public int PeriodosID { get; set; }
        [Reference] public Periodos Periodos { get; set; }

        [Reference] public List<Estudantes> Estudantes { get; set; }

        [Reference] public List<Pautas_Mini> pautas_Minis { get; set; }
    }
}
