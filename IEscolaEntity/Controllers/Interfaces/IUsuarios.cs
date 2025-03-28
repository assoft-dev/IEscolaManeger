﻿using IEscolaEntity.Models;
using IEscolaEntity.Models.ViewModels;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Interfaces
{
    public interface IUsuarios : ITransationRepository, IGeneric<Usuarios>
    {
        Task<bool> ChangePassword_Mode1(string EMail, string SenhaAntiga, string SenhaNova);
        Task<bool> ChangePassword_Mode1(string EMail, string SenhaNova);
        Task<UsuariosViewModels> Login(string Email, string Senha);

        Task<bool> GuardarUser(Usuarios usuarios);
    }
}
