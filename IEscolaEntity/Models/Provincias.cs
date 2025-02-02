namespace IEscolaEntity.Models
{
    using IEscolaEntity.Models.Helps;
    using ServiceStack.DataAnnotations;
    using System.Collections.Generic;

    public class Provincias
    {
        [AutoIncrement]
        public int ProvinciasID { get; set; }

        [Required]
        public string Referencias { get; set; }

        public string Detalhes { get; set; }

        [Default(0)] public ProvinciasCodigo ProvinciasCodigo { get; set; }

        [Reference] public List<ProvinciasMunicipios> ProvinciasMunicipios { get; set; }
    }
}
