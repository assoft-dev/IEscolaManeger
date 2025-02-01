namespace IEscolaEntity.Models
{
    using ServiceStack.DataAnnotations;
    using System.Collections.Generic;

    public class Municipios
    {
        [AutoIncrement]
        public int MunicipiosID { get; set; }

        public string Referencias { get; set; }
        public string Detalhes { get; set; }

        public int ProvinciasID { get; set; }

        [Reference] public List<ProvinciasMunicipios> ProvinciasMunicipios { get; set; }
    }
}
