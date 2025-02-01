using ServiceStack.DataAnnotations;

namespace IEscolaEntity.Models
{
    public class ProvinciasMunicipios
    {
        [AutoIncrement]
        public int ProvinciasMunicipiosID { get; set; }

        [ForeignKey(typeof(Provincias))]
        public int ProvinciasID { get; set; }
        [Reference]  public Provincias  Provincias { get; set; }

        [ForeignKey(typeof(Municipios))]
        public int MunicipiosID { get; set; }
        [Reference]  public Municipios  Municios { get; set; }
    }
}
