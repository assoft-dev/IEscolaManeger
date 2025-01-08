using IEscolaEntity.Models;
using IEscolaEntity.Models.Helps;
using IEscolaEntity.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Interfaces
{
    public interface IUsuarios : ITransationRepository, IGeneric<Usuarios>
    {
        Task<bool> ChangePassword_Mode1(string EMail, string SenhaAntiga, string SenhaNova);
        Task<UsuariosViewModels> Login(string Email, string Senha);
    }
}
