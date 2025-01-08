using IEscolaEntity.Controllers.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Models;
using IEscolaEntity.Models.Helps;
using IEscolaEntity.Models.ViewModels;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Legacy;
using ServiceStack.Redis;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Repository
{
    public class UsuariosRepository : GenericRepository<Usuarios>, IUsuarios
    {
        IDbConnection dbConnection;
        public UsuariosRepository()
        {
            dbConnection = DataConnectionConfig.Conection().OpenDbConnection();
        }

        public async Task<bool> ChangePassword_Mode1(string EmailUser, string SenhaAntiga, string SenhaNova)
        {
            var senha1 = MD5Create.GetMD5Hash(SenhaAntiga);
            var senha2 = MD5Create.GetMD5Hash(SenhaNova);

            var user = await dbConnection.SingleAsync<Usuarios>(x => x.Email == EmailUser &&
                                                                     x.Senha == senha1);
            if (user == null)
                return false;
            else
            {
                var result =   await dbConnection.UpdateAsync<Usuarios>( new Usuarios { Senha = senha2 } );

                if (result > 0)
                    return true;
                else
                    return false;
            }
        }

        public async Task<UsuariosViewModels> Login(string Email, string Senha)
        {
            var usuariosViewModels = new UsuariosViewModels();

            var md = MD5Create.GetMD5Hash(Senha);

            var user = await dbConnection.SingleAsync<Usuarios>(x => x.Email == Email && 
                                                                     x.Senha == md);
            if (user != null)
            {
                usuariosViewModels = new UsuariosViewModels
                {
                    UsuariosID = user.UsuariosID,
                    FullName = user.FullName,
                };

                var grupos = await dbConnection.LoadSelectAsync<Grupos>(x => x.GruposID == user.GruposID);

                if (grupos != null)
                {
                    var permissiones = grupos.FirstOrDefault().Permissions;
                    if (permissiones != null)
                    {
                        // Nao tem permissoes para entrar
                        usuariosViewModels.Permission = permissiones;

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
                            default:
                                usuariosViewModels.usuariosRetorno = UsuariosRetorno.Initial;
                                break;
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
