using IEscolaEntity.Models.Helps;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Models
{
    public class Entidade
    {
        [AutoIncrement]
        [Display(Name = "Código")]
        public int EntidadeID { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public string AssinaturaDirector { get; set; }
        public string AssinaturaSubDirector { get; set; }

        public string Header1 { get; set; }
        public string Header2 { get; set; }
        public string Header3 { get; set; }

        public string EscolaCodigo { get; set; }
        public EscolaEstatuto Estatuto { get; set; }
        public bool FazemTeste { get; set; }

        [ForeignKey(typeof(ProvinciasMunicipios))]
        public int ProvinciaMunicipioID { get; set; }
        [Reference] public ProvinciasMunicipios  ProvinciasMunicipios { get; set; }

        [Reference] public List<EntidadeConvenios> EntidadeConvenios  { get; set; }
    }
}
