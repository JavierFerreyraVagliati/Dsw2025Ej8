using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Exceptions;

namespace Dsw2025Ej8.Domain
{
    class CuentaCorriente : CuentaBancaria
    {
        public decimal LimiteDeDescubierto {  get; init; }
        public decimal Comision { get; set; }
        public CuentaCorriente(string numero, decimal saldo) : base(numero, saldo)
        {
        }

        public override void Depositar(decimal monto)
        {
            ValidarCuenta();
            ValidarMonto(monto);
            monto -= monto * Comision;
            Saldo += monto;

        }

        public override void Retirar(decimal monto)
        {
            ValidarCuenta();
            ValidarMonto(monto);
            if (Saldo - monto >= -LimiteDeDescubierto)
            {
                Saldo -= monto;
                if (Saldo < 0) Estado = Estado.Suspendida;
            }
            else
            {
                Estado = Estado.Suspendida;
                throw new SaldoInsuficiente();
            }
        }
    }
}
