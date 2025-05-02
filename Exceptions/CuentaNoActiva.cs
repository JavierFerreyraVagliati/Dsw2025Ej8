using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8.Exceptions
{
    internal class CuentaNoActiva : Exception
    {
        public CuentaNoActiva(Estado estado):base($"No se puede operar con la cuenta {estado}") { }
    
        public CuentaNoActiva(string mensaje):base(mensaje) { }
    }
}
