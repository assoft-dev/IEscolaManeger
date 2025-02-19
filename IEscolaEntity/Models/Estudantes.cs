using IEscolaEntity.Models.Biblioteca;
using IEscolaEntity.Models.Helps;
using ServiceStack.DataAnnotations;
using ServiceStack.Script;
using System;
using System.Collections.Generic;

namespace IEscolaEntity.Models
{
    public class Estudantes : ModelsEntityBase
    {

        // Dados Internos
        [AutoIncrement]
        public int EstudantesID { get; set; }
   
        public Sexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        [Ignore] public int Idade { get { return DateTime.Now.Year - DataNascimento.Year; } }

        // Dados dos Encarregados
        public string Telemovel { get; set; }
        public string NomeEncarregado { get; set; }


        [Index(Unique = true)]
        public string Email { get; set; }
        public string Endereco { get; set; }

        // Relacionamentos

        [ForeignKey(typeof(Turmas))]
        public int TurmasID { get; set; }
        [Reference] public Turmas Turmas { get; set; }


        [Reference] public List<Pedidos> Pedidos { get; set; }
    }
}
