using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8.Presentation;

/*10. Instanciar 4 cuentas(dos de cada tipo) y realizar diferentes operaciones que
permitan comprobar todas las funciones posibles.
11. Recorrer las 4 cuentas creadas y mostrar por consola un resumen de cada una, que
incluya número, tipo y saldo(utilizar una clase anónima)*/
internal class PrincipalView
{
    CajaDeAhorro cajaAhorroUno;
    CajaDeAhorro cajaAhorroDos ;
    CuentaCorriente cuentaCorrienteUno;
    CuentaCorriente cuentaCorrienteDos;

    public PrincipalView() { }

    public void Iniciar()
    {
        InicializarInstancias();
        Console.WriteLine("Iniciar programa\t");

        OperarConCuenta(cajaAhorroUno, new List<Action>
    {
        () => EjecutarAccion("Depósito de $0", () => {
            cajaAhorroUno.Depositar(0);
            Console.WriteLine($"->Estado | Deposito | Saldo actual: {cajaAhorroUno.Saldo}");
        }),
        () => EjecutarAccion("Retiro de $1200", () => {
            cajaAhorroUno.Retirar(1200);
            Console.WriteLine($"->Estado | Retiro | Saldo actual: {cajaAhorroUno.Saldo}");
        }),
        () => EjecutarAccion("Aplicar Interés", () => {
            cajaAhorroUno.AplicarInteres();
            Console.WriteLine($"->Estado | Interés | Saldo actual: {cajaAhorroUno.Saldo}");
        })
    });

        OperarConCuenta(cajaAhorroDos, new List<Action>
    {
        () => EjecutarAccion("Depósito de $1500", () => {
            cajaAhorroDos.Depositar(1500);
            Console.WriteLine($"->Estado | Deposito | Saldo actual: {cajaAhorroDos.Saldo}");
        }),
        () => EjecutarAccion("Retiro de $1300", () => {
            cajaAhorroDos.Retirar(1300);
            Console.WriteLine($"->Estado | Retiro | Saldo actual: {cajaAhorroDos.Saldo}");
        }),
        () => EjecutarAccion("Aplicar Interés", () => {
            cajaAhorroDos.AplicarInteres();
            Console.WriteLine($"->Estado | Interés | Saldo actual: {cajaAhorroDos.Saldo}");
        }),
        () => EjecutarAccion("Retiro de $1000", () => {
            cajaAhorroDos.Retirar(1300);
            Console.WriteLine($"->Estado | Retiro | Saldo actual: {cajaAhorroDos.Saldo}");
        })
    });

        OperarConCuenta(cuentaCorrienteUno, new List<Action>
    {
        () => EjecutarAccion("Depósito de $0", () => {
            cuentaCorrienteUno.Depositar(0);
            Console.WriteLine($"->Estado | Deposito | Saldo actual: {cuentaCorrienteUno.Saldo} | Descubierto: {cuentaCorrienteUno.LimiteDeDescubierto}");
        }),
        () => EjecutarAccion("Retiro de $1400", () => {
            cuentaCorrienteUno.Retirar(1400);
            Console.WriteLine($"->Estado | Retiro | Saldo actual: {cuentaCorrienteUno.Saldo} | Descubierto: {cuentaCorrienteUno.LimiteDeDescubierto}");
        })
    });

        OperarConCuenta(cuentaCorrienteDos, new List<Action>
    {
        () => EjecutarAccion("Depósito de $1000", () => {
            cuentaCorrienteDos.Depositar(1000);
            Console.WriteLine($"->Estado | Deposito | Saldo actual: {cuentaCorrienteDos.Saldo} | Descubierto: {cuentaCorrienteDos.LimiteDeDescubierto}");
        }),
        () => EjecutarAccion("Retiro de $1400", () => {
            cuentaCorrienteDos.Retirar(1400);
            Console.WriteLine($"->Estado | Retiro | Saldo actual: {cuentaCorrienteDos.Saldo} | Descubierto: {cuentaCorrienteDos.LimiteDeDescubierto}");
        }),
        () => EjecutarAccion("Depósito de $2000", () => {
            cuentaCorrienteDos.Depositar(2000);
            Console.WriteLine($"->Estado | Deposito | Saldo actual: {cuentaCorrienteDos.Saldo} | Descubierto: {cuentaCorrienteDos.LimiteDeDescubierto}");
        }),
        () => EjecutarAccion("Retiro de $5000", () => {
            cuentaCorrienteDos.Retirar(5000);
            Console.WriteLine($"->Estado | Retiro | Saldo actual: {cuentaCorrienteDos.Saldo} | Descubierto: {cuentaCorrienteDos.LimiteDeDescubierto}");
        })
    });
        new Action(() =>
        {
            Console.WriteLine(cajaAhorroUno.ToString());
            Console.WriteLine(cajaAhorroDos.ToString());
            Console.WriteLine(cuentaCorrienteUno.ToString());
            Console.WriteLine(cuentaCorrienteDos.ToString());
        })();



    }

    private void OperarConCuenta(CuentaBancaria cuenta, List<Action> operaciones)
    {
        Console.WriteLine($"Recorriendo la cuenta: {cuenta.GetType().Name} | Numero : {cuenta.Numero}");
        Console.WriteLine("--------------------------------------------");

        foreach (var operacion in operaciones)
        {
            operacion();
            Console.WriteLine("--------------------------------------------");
        }

        Console.WriteLine("**************************************************************************** \t");
        Console.WriteLine();
    }

    public void InicializarInstancias()
    {
        cajaAhorroUno = new CajaDeAhorro("001", 1000)
        {
            TasaDeInteres = 0.10m,
            Titulares = ["Maria Julieta Vignoli", "Javier Vagliati"]
        };
        cajaAhorroDos = new CajaDeAhorro("002", 0)
        {
            TasaDeInteres = 0.25m,
            Titulares = ["Lucas Chipolari", "Cesar Delgado"]
        };
        cuentaCorrienteUno = new CuentaCorriente("003", 1000)
        {
            LimiteDeDescubierto = 300m,
            Comision = 0.01m,
            Titulares = ["Juan Perez", "Pepe Perez"]
        };
        cuentaCorrienteDos = new CuentaCorriente("004", 1000)
        {
            LimiteDeDescubierto = 1000m,
            Comision = 0.10m,
            Titulares = ["Homero Simpson", "Lisa Simpson"]
        };
    }

    private void EjecutarAccion(string mensaje, Action accion)
    {
        Console.WriteLine($"Operacion: {mensaje}");
        try
        {
            accion();
        }
        catch(Exception e)
        {
            Console.WriteLine($"Ocurrió un error realizando la operacion '{mensaje}' ");
            Console.WriteLine(e.Message);
        }
    }
}
