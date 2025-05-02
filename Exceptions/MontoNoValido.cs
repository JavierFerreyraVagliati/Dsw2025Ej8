using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Exceptions
{
    public class MontoNoValido : Exception
    {
        public MontoNoValido() : base("El monto ingresado no es válido para la operación solicitada") { }

        public MontoNoValido(string mensaje) : base(mensaje) { }
        
    }
}
