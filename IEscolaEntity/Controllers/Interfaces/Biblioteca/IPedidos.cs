﻿using IEscolaEntity.Models;
using IEscolaEntity.Models.Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Interfaces
{
    public interface IPedidos: ITransationRepository, IGeneric<Pedidos>
    {
        Task<string> GetQR();
    }
}
