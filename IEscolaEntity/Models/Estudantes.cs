﻿using IEscolaEntity.Models.Biblioteca;
using IEscolaEntity.Models.Helps;
using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace IEscolaEntity.Models
{
    public class Estudantes : ModelsEntityBase
    {
        // Dados Internos
        [AutoIncrement]
        public int EstudantesID { get; set; }


        // Dados dos Encarregados
        public string Telemovel { get; set; }
        public EstadoEstudantes EstadoEstudantes { get; set; }
        public string Entidade { get; set; }

        // Relacionamentos
        [ForeignKey(typeof(EstudantesInscricoes))]
        public int InscricoesID { get; set; }
        [Reference] public EstudantesInscricoes Inscricoes { get; set; }

        [Reference] public List<Pedidos> Pedidos { get; set; }
    }
}
