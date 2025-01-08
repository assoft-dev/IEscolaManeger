using IEscolaEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Interfaces
{
    internal interface IPermissions : ITransationRepository,  IGeneric<Permission>
    {
    }
}
