namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public string Numero { get; }
    public decimal Saldo { get; protected set; }
    public Estado Estado { get; set; }
    public string[] Titulares { get; }
    protected CuentaBancaria(string numero, decimal saldo)
    {
        Numero = numero;
        Saldo = saldo;
        Estado = Estado.Activa;
    
    }

    public virtual void Depositar(decimal monto)
    {
    }

    public virtual void Retirar(decimal monto)
    {
    }

}
