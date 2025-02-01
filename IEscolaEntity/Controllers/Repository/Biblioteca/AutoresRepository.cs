using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Models;
using IEscolaEntity.Models.Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Repository
{
    public class AutoresRepository : GenericRepository<Autores>, IAutores
    {
    }
}
