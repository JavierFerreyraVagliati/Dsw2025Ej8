using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    class CuentaCorriente : CuentaBancaria
    {
        private decimal _limiteDeDescubierto;
        private decimal _comision;
        public CuentaCorriente(decimal limiteDeDescubierto, decimal comision, string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
        {
            _limiteDeDescubierto = limiteDeDescubierto;
            _comision = comision;
        }

        public override void Depositar(decimal monto)
        {
            monto -= monto * _comision;
            saldo += monto;

        }

        public override void Retirar(decimal monto)
        {

            if (saldo - monto >= -_limiteDeDescubierto)
            {
                saldo -= monto;
            }
            if (saldo < 0)
            {
                estado = Estado.Suspendida;
            }
        }
        public decimal GetLimiteDeDescubierto()
        {
            return _limiteDeDescubierto;
        }

        public void SetLimiteDeDescubierto(decimal limiteDeDescubierto)
        {
            _limiteDeDescubierto = limiteDeDescubierto;
        }

        public decimal GetComision()
        {
            return _comision;
        }

        public void SetComision(decimal comision)
        {
            _comision = comision;
        }
    }
}
