using ServiceStack.DataAnnotations;
using System.Collections.Generic;
using System.Security.Permissions;

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


        [Ignore]
        public string Descricao
        {
            get
            {
                {
                    if (Municios != null && Provincias != null)
                        return string.Format("{0} -> {1}", Provincias.Referencias, Municios.Referencias);
                    else
                        return string.Empty;
                };
            }
        }

        [Reference] public List<EstudantesInscricoes>  Inscricoes { get; set; }
    }
}
