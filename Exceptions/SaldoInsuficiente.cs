using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Exceptions
{
    class SaldoInsuficiente : Exception
    {
        public SaldoInsuficiente(): base(" La cuenta no cuenta con saldo para la operación\r\nsolicitada. Fue suspendida.") { }
    
        public SaldoInsuficiente(string mensaje):base(mensaje) { }
    }
}
