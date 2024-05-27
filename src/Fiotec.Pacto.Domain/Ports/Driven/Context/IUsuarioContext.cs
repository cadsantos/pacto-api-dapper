using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Pacto.Domain.Ports.Driven.Context
{
    public interface IUsuarioContext
    {
        bool Autenticado { get; }
        string UsuarioId { get; }
    }
}
