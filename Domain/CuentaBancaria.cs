using Dsw2025Ej8.Exceptions;

namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public string Numero { get; }
    public decimal Saldo { get; protected set; }
    public Estado Estado { get; protected set; }
    public string[] Titulares { get; init; }
    protected CuentaBancaria(string numero, decimal saldo)
    {
        Numero = numero;
        Saldo = saldo;
        Estado = Estado.Activa;
        Titulares = Array.Empty<string>();
    }

    public virtual void Depositar(decimal monto)
    {
    }

    public virtual void Retirar(decimal monto)
    {
    }

    public void ValidarMonto(decimal monto) {
        if (monto <= 0) {
            throw new MontoNoValido();
        }
    }
    public void ValidarCuenta() { 
    
        if (Estado != Estado.Activa) { throw new CuentaNoActiva(Estado); }
    }


}
