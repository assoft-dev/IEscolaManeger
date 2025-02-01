using IEscolaEntity.Models.Helps;

namespace IEscolaEntity.Models.ViewModels
{
    public class UsuariosViewModels
    {
        public int UsuariosID { get; set; }
        public string FullName { get; set; }

        public UsuariosRetorno usuariosRetorno{ get; set; }
        public  Permissoes Permission { get; set; }
    }
}
