using ServiceStack.DataAnnotations;
using System;

namespace IEscolaEntity.Models.Helps
{
    public class ModelsEntityBase
    {
        [Index(Unique = true)]
        public string Codigo { get; set; }

        //Dados Pessoas
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Ignore] public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        // Informação pessoal
        public string BI { get; set; }
        public Nacionalidade Nacionalidade { get; set; }
        public DateTime DataNascimento { get; set; }
        [Ignore] public int Idade { get { return DateTime.Now.Year - DataNascimento.Year; } }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }

        [ForeignKey(typeof(ProvinciasMunicipios), OnDelete = "CASCADE")]
        public int ProvinciaMunicipioID { get; set; }
        [Reference] public ProvinciasMunicipios ProvinciasMunicipios { get; set; }
       
        //Contactos
        public string Residencia { get; set; }
        public string Endereco { get; set; }
        public string Contacto { get; set; }
        public string Celular { get; set; }
        public string EmailFacebbok { get; set; }
        public string Email { get; set; }

        //Documentos de Identificacao
        public ProvinciasLocal LocalEmissao { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataExpiracao { get; set; }
        public DocType DocType { get; set; }
        public string Documento { get; set; }

        //Informacao Final
        public bool IsActived { get; set; }
        public DateTime DataFicha { get; set; }
        public string ImagemURL { get; set; }
    }
}
