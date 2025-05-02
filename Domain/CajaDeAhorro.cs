using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Exceptions;

namespace Dsw2025Ej8.Domain
{
    class CajaDeAhorro : CuentaBancaria
    {
        public decimal TasaDeInteres { get; init; }
        public CajaDeAhorro(string numero, decimal saldo) : base(numero, saldo)
        {
            TasaDeInteres = 0;
        }
        public override void Depositar(decimal monto)
        {
            ValidarCuenta();
            ValidarMonto(monto);
            Saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            ValidarCuenta();
            ValidarMonto(monto);
            if (Saldo <= 0 || monto > Saldo)
            {
                Estado = Estado.Suspendida;
                throw new SaldoInsuficiente();
            }
            Saldo -= monto;
        }

        public void AplicarInteres()
        {
            ValidarCuenta();
            Saldo += Saldo * TasaDeInteres;
        }
        
    }
}
