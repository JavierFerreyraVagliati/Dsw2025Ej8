namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    public string Numero { get; }
    public decimal Saldo { get; }
    public Estado Estado{ get; set; }
    //private decimal _tasaDeInteres;
    //private decimal _limiteDeDescubierto;
    //private decimal _comision;
    private string[] _titulares
    public CuentaBancaria(string numero, decimal saldo, TipoCuenta tipo, string[] titulares)
    {
        _numero = numero;
        _saldo = saldo;
        _estado = Estado.Activa;
        _titulares = titulares;
    }
    #region Getters/Setters
/* public string GetNumero()
 {
     return _numero;
 }

 public decimal GetSaldo()
 {
     return _saldo;
 }*/
/*public Estado GetEstado()
{
    return _estado;
   }

public void SetEstado(Estado estado)
{
    _estado = estado;
}

public decimal GetTasaDeInteres()
{
    return _tasaDeInteres;
}

public void SetTasaDeInteres(decimal tasaDeInteres)
{
    _tasaDeInteres = tasaDeInteres;
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
}*/

public string[] GetTitulares()
{
    return _titulares;
}
#endregion

public virtual void Depositar(decimal monto)
{
    if (_tipo == TipoCuenta.CajaDeAhorro)
    {
        _saldo += monto;
    }
    else if (_tipo == TipoCuenta.CuentaCorriente)
    {
        monto -= monto * _comision;
        _saldo += monto;
    }
}

public virtual void Retirar(decimal monto)
{
    if (_tipo == TipoCuenta.CajaDeAhorro)
    {
        _saldo -= monto;
    }
    else if (_tipo == TipoCuenta.CuentaCorriente)
    {
        if (_saldo - monto >= -_limiteDeDescubierto)
        {
            _saldo -= monto;
        }
        if (_saldo < 0)
        {
            _estado = Estado.Suspendida;
        }
    }
}

public void AplicarInteres()
{
    if (_tipo == TipoCuenta.CajaDeAhorro)
    {
        _saldo += _saldo * _tasaDeInteres;
    }
}


}
