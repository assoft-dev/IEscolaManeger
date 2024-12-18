using ServiceStack.DataAnnotations;

namespace IEscolaEntity.Models
{
    public class Turmas
    {

        [AutoIncrement]
        public int TurmaID { get; set; }

        public string Referencias { get; set; }


        [ForeignKey(typeof(Classes), OnDelete = "CASCADE")]
        public int ClassesID { get; set; }
        [Reference] public Classes Classes { get; set; }


        [ForeignKey(typeof(Periodos), OnDelete = "CASCADE")]
        public int PeriodoID { get; set; }
        [Reference] public Periodos Periodos { get; set; }
    }
}
