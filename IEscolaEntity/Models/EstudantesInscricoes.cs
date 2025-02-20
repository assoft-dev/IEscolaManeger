using IEscolaEntity.Models.Helps;
using ServiceStack.DataAnnotations;
using System;

namespace IEscolaEntity.Models
{
    public class EstudantesInscricoes : ModelsEntityBase
    {
        [AutoIncrement]
        public int InscricaoID { get; set; }

        // Informação pessoal
        public string BI { get; set; }
        public string Naturalidade { get; set; }
        public Nacionalidade Nacionalidade { get; set; }
        public DateTime DataNascimento { get; set; }
        [Ignore] public int Idade { get { return DateTime.Now.Year - DataNascimento.Year; } }


        [ForeignKey(typeof(ProvinciasMunicipios), OnDelete = "CASCADE")]
        public int ProvinciaMunicipioID { get; set; }
        [Reference] public ProvinciasMunicipios ProvinciasMunicipios { get; set; }


        // Dados dos Encarregados
        public GrauParentesco GrauParentesco { get; set; }
        public bool NomePai { get; set; }
        public bool PaiVive { get; set; }
        public bool NomeMae { get; set; }
        public bool MaeVive { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }

        //Contactos
        public string Residencia { get; set; }
        public string Endereco { get; set; }
        public string Contacto { get; set; }
        public string Celular { get; set; }
        public string EmailFacebbok { get; set; }
        public string Email { get; set; }
        public string NomeEncarregado { get; set; }

        //Documentos de Identificacao
        public string LocalEmissao { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataExpiracao { get; set; }
        public string DocType { get; set; }
        public string Documento { get; set; }
        public string DocRecenciamentoMilitar { get; set; }
        public string DocRecenciamentoEmissao { get; set; }

        [ForeignKey(typeof(Cursos))]
        public int CursosID { get; set; }
        [Reference] public Cursos Cursos { get; set; }


        // Informações adicionais (Documentos apresentar)
        public string AdicionalFichaInscricao { get; set; }
        public string AdicionalBI { get; set; }
        public string AdicionalCertificados { get; set; }
        public string AdicionalRececiamentoMilitar { get; set; }
        public string AdiconalEscolaOrigem { get; set; }
        public string AdiconalProvincias { get; set; }
        public string AdicionalMedia { get; set; }
        public string IsActived { get; set; }
        public string Media { get; set; }
        public DateTime DataFicha { get; set; }
        public FAZES FAZES { get; set; }

    }
}
