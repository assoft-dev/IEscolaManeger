using IEscolaEntity.Controllers.Helps;
using IEscolaEntity.Models.Biblioteca;
using IEscolaEntity.Models.Helps;
using ServiceStack.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;

namespace IEscolaEntity.Models
{
    public class Estudantes
    {
        // Dados Internos
        [AutoIncrement]
        public int EstudantesID { get; set; }

        [Display(Name = "Código"), System.ComponentModel.DataAnnotations.Required, Unique]
        public string Codigo { get;  set; }

        // Dados dos Encarregados
        public EstadoEstudantes EstadoEstudantes { get; set; }

        [ForeignKey(typeof(Turmas))]
        public int TurmaID { get; set; }
        [Reference] public Turmas Turmas { get; set; }

        // Relacionamentos
        [ForeignKey(typeof(EstudantesInscricoes)), Unique]
        public int InscricoesID { get; set; }
        [Reference] public EstudantesInscricoes Inscricoes { get; set; }


        [Reference] public List<Pedidos> Pedidos { get; set; }

        [Reference] public List<PropinasPagamentos> PropinasPagamentos { get; set; }


        [Ignore]
        public Image Imagens
        {
            get
            {
                if (Inscricoes != null)
                {
                    if (Inscricoes.ImagemURL != null)
                    {
                        var caminho = @"C:\\asinforprest\\IEscola\\Estudantes\\" + Inscricoes.ImagemURL;
                        if (File.Exists(caminho))
                            return GraphicsExtensions.MakeCircleImage(Image.FromFile(caminho));
                        else return null;
                    }
                    else
                        return null;
                }
                return null;            
            }
        }
    }
}
