﻿using IEscolaEntity.Models;

namespace IEscolaEntity.Controllers.Interfaces
{
    public interface INotificacoes: IGeneric<Notificacoes>, ITransationRepository
    {
        string Alert(int i);
    }
}
