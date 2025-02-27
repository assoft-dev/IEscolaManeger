using IEscolaEntity.Models.Helps;
using ServiceStack.DataAnnotations;
using System;
using System.IO;

namespace IEscolaEntity.Models
{
    public class EstudantesInscricoes : ModelsEntityBase
    {
        [AutoIncrement]
        public int InscricaoID { get; set; }

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


        // Dados dos Encarregados
        public GrauParentesco GrauParentesco { get; set; }
        public string NomeEncarregado { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public bool PaiVive { get; set; }
        public bool MaeVive { get; set; }

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
        public string DocRecenciamentoMilitar { get; set; }

        [ForeignKey(typeof(Cursos))]
        public int CursosID { get; set; }
        [Reference] public Cursos Cursos { get; set; }

        // Informações adicionais (Documentos apresentar)
        public string AdiconalEscolaOrigem { get; set; }
        public ProvinciasLocal AdiconalProvincias { get; set; }
        public decimal AdicionalMedia { get; set; }

        public bool IsActived { get; set; }
        public decimal Media { get; set; }
        public DateTime DataFicha { get; set; }

        public FAZES FAZES { get; set; }
        public bool AdicionalFichaInscricao { get; set; }
        public bool AdicionalCertificados { get; set; }

        public string ImagemURL { get; set; }
    }
}
