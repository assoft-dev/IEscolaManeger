using IEscolaEntity.Controllers.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Models;
using IEscolaEntity.Models.Helps;
using IEscolaEntity.Models.ViewModels;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Legacy;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Repository
{
    public class UsuariosRepository : GenericRepository<Usuarios>, IUsuarios
    {
        public async Task<bool> ChangePassword_Mode1(string EmailUser, string SenhaNova)
        {
            var senha2 = MD5Create.GetMD5Hash(SenhaNova);

            var user = await DbConection.SingleAsync<Usuarios>(x => (x.Email == EmailUser));
            if (user == null)
                return false;
            else
            {
                user.Senha = senha2;
                var result = await DbConection.UpdateOnlyFieldsAsync<Usuarios>(user, x => x.Senha);

                if (result > 0)
                {
                    await DbConection.InsertAsync<UsuariosLogs>(new UsuariosLogs
                    {
                        Data = DateTime.Now,
                        Descricao = "ALTERADA DA SENHA NO PONTO INICIAL",
                        Local = "lOGIN",
                        UsuariosID = user.UsuariosID,
                    });
                    return true;
                }
                else
                    return false;
            }
        }

        public async Task<bool> ChangePassword_Mode1(string EmailUser, string SenhaAntiga, string SenhaNova)
        {
            var senha1 = MD5Create.GetMD5Hash(SenhaAntiga);
            var senha2 = MD5Create.GetMD5Hash(SenhaNova);

            var user = await DbConection.SingleAsync<Usuarios>(x => (x.Email == EmailUser || 
                                                                      x.FirstName == EmailUser ||
                                                                      x.LastName == EmailUser) &&
                                                                      x.Senha == senha1);
            if (user == null)
                return false;
            else
            {
                user.Senha = senha2;
                var result =   await DbConection.UpdateOnlyFieldsAsync<Usuarios>(user, x=> x.Senha);

                await DbConection.InsertAsync<UsuariosLogs>(new UsuariosLogs { 
                     Data = DateTime.Now,
                     Descricao = "ALTERADA DA SENHA NO PONTO INICIAL (Change password)",
                     Local = "lOGIN",
                     UsuariosID = user.UsuariosID,
                });

                if (result > 0)
                    return true;
                else
                    return false;
            }
        }

        public async Task<bool> GuardarUser(Usuarios usuarios)
        {
            var md = MD5Create.GetMD5Hash(usuarios.Senha);

            usuarios.Senha = md;

            if (usuarios.UsuariosID == 0)
                return await DbConection.SaveAsync<Usuarios>(usuarios);
            else
                return await DbConection.UpdateAsync<Usuarios>(usuarios) > 0;
        }

        public async Task<UsuariosViewModels> Login(string Email, string Senha)
        {
            var usuariosViewModels = new UsuariosViewModels();

            var md = MD5Create.GetMD5Hash(Senha);

            var user = await DbConection.SingleAsync<Usuarios>(x => (x.Email == Email || x.FirstName == Email || x.LastName == Email) &&
                                                                      x.Senha == md);
            if (user != null)
            {
                usuariosViewModels = new UsuariosViewModels
                {
                    UsuariosID = user.UsuariosID,
                    FullName = user.FullName,   
                    Email = user.Email,
                };

                var grupos = await DbConection.LoadSelectAsync<Grupos>(x => x.GruposID == user.GruposID);

                if (grupos != null)
                {
                    var permissiones = grupos.FirstOrDefault().Permissions;
                    if (permissiones != null)
                    {
                        // Nao tem permissoes para entrar
                        usuariosViewModels.Permission = permissiones;

                        // Retorno do Usuario Caso Logs
                        var logs = await DbConection.SingleAsync<UsuariosLogs>(x => x.UsuariosID == user.UsuariosID);
                        if (logs == null)
                        {
                            usuariosViewModels.usuariosRetorno = UsuariosRetorno.PrimeiraVez;
                        }
                        else
                        {
                            // Retorno do usuario case Estado
                            switch (user.Estado)
                            {
                                case Estado.Activado:
                                    usuariosViewModels.usuariosRetorno = UsuariosRetorno.Valido;
                                    break;
                                case Estado.Desativado:
                                    usuariosViewModels.usuariosRetorno = UsuariosRetorno.Desativado;
                                    break;
                                case Estado.Desativado_Temp:
                                    usuariosViewModels.usuariosRetorno = UsuariosRetorno.Desativado_Temp;
                                    break;
                                case Estado.Excluido:
                                    usuariosViewModels.usuariosRetorno = UsuariosRetorno.Excluido;
                                    break;
                                default:
                                    usuariosViewModels.usuariosRetorno = UsuariosRetorno.Initial;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        // Nao tem permissoes para entrar
                        usuariosViewModels.usuariosRetorno = UsuariosRetorno.Permissoes_Invalida;
                    }
                }
                else
                {
                    // Nao tem permissoes para entrar
                    usuariosViewModels.usuariosRetorno = UsuariosRetorno.Agrupamento_Invalida;
                }    
                return usuariosViewModels;
            }
            else
            {
                // Verifcar se e a primeira vez
                var UserCount = DoGetCount<Usuarios>();

                if (UserCount == 0)
                    usuariosViewModels = new UsuariosViewModels() { usuariosRetorno = UsuariosRetorno.Initial, };
                else
                    usuariosViewModels = new UsuariosViewModels() { usuariosRetorno = UsuariosRetorno.Invalido, };
                return usuariosViewModels;
            }
        }
    }
}
