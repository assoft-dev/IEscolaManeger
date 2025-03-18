using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace IEscolaEntity.Models
{
    public class Permissoes
    {
        [AutoIncrement]
        public int PermissoeID { get; set; }

        // Permissions Geral
        public bool List { get; set; }
        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }


        public bool Classes { get; set; }
        public bool Estudantes { get; set; }
        public bool Grupos { get; set; }
        public bool Logs { get; set; }
        public bool Periodos { get; set; }
        public bool Permissions { get; set; }
        public bool Turmas { get; set; }
        public bool Usuarios { get; set; }

        // Localização
        public bool Provincias { get; set; }
        public bool Municipios { get; set; }
        public bool ProvinciasMunicipios { get; set; }

        public bool Salas { get; set; }
        public bool Cursos { get; set; }
        public bool Categorias { get; set; }
        public bool Autores { get; set; }
        public bool Livros { get; set; }
        public bool PedidosConsultas { get; set; }
        public bool PedidosAquisicao { get; set; }
        public bool EstudantesInscricao { get; set; }

        public bool PropinasPagamento { get; set; }
        public bool PropinasRecibo { get; set; }
        public bool PropinasConfig { get; set; }


        public bool Pais { get; set; }
        public bool Editores { get; set; }


        public bool Disciplinas { get; set; }
        public bool CursoClasseDisciplina { get; set; }
        public bool DisciplinasProgramas { get; set; }

        public bool Professores { get; set; }
        public bool ProfessorAreaFormacao { get; set; }
        public bool ProfessoresDisciplinas { get; set; }
        public bool ProfessoresCategorias { get; set; }

        [Default(0)]
        public bool Escola { get; set; }

        [Default(0)]
        public bool EscolaConvenio { get; set; }


        [Reference] public List<Grupos> grupos { get; set; }
    }
}
