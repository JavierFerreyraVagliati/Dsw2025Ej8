using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    class CuentaCorriente : CuentaBancaria
    {
        public decimal LimiteDeDescubierto {  get; set; }
        public decimal Comision { get; set; }
        public CuentaCorriente(string numero, decimal saldo) : base(numero, saldo)
        {
        }

        public override void Depositar(decimal monto)
        {
            monto -= monto * Comision;
            Saldo += monto;

        }

        public override void Retirar(decimal monto)
        {

            if (Saldo - monto >= -LimiteDeDescubierto)
            {
                Saldo -= monto;
            }
            if (Saldo < 0)
            {
                Estado = Estado.Suspendida;
            }
        }
    }
}
