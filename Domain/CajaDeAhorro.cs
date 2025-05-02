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
        }
        public override void Depositar(decimal monto)
        {
            ValidarCuenta(Estado);
            ValidarMonto(monto);
            Saldo += monto;

        }

        public override void Retirar(decimal monto)
        {
            ValidarCuenta(Estado);
            ValidarMonto(monto);
            if (Saldo <= 0) {
                throw new SaldoInsuficiente();
            }
            Saldo -= monto;

        }

        public void AplicarInteres()
        {
            ValidarCuenta(Estado);
            Saldo += Saldo * TasaDeInteres;

        }
    }



}
