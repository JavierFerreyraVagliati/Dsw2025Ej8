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
    CajaDeAhorro cajaAhorroDos = null;
    CuentaCorriente cuentaCorrienteUno = null;
    CuentaCorriente cuentaCorrienteDos = null;

    public PrincipalView() { }

    public void Iniciar()
    {

        InicializarInstancias();
        Console.WriteLine("Iniciar programa\t");

        Console.WriteLine($"Recorriendo la primera cuenta de {cajaAhorroUno.GetType().Name}");

        //El monto recibido por cualquier operación no puede ser menor o igual a 0
        EjecutarAccion("Depósito de $0 ", () => { 
            cajaAhorroUno.Depositar(0);
            Console.WriteLine($"El saldo de la cuenta luego del depósito es {cajaAhorroUno.Saldo}");
        });
        EjecutarAccion("Retiro de $1000", () => {
            cajaAhorroUno.Retirar(1200);
            Console.WriteLine($"El saldo de la cuenta luego del retiro es {cajaAhorroUno.Saldo}");
        });
        EjecutarAccion("Aplica interes", () =>
        {
            cajaAhorroUno.AplicarInteres();
            Console.WriteLine($"El saldo de la cuenta luego de aplicar intereses es {cajaAhorroUno.Saldo}");
        });

        //Cualquier operación se debe realizar si la cuenta está activa, en cualquier otro caso generar una excepción del tipo CuentaNoActiva

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
        cuentaCorrienteUno = new CuentaCorriente("003", 1000000)
        {
            LimiteDeDescubierto = 3000000m,
            Comision = 0.01m,
            Titulares = ["Juan Perez", "Pepe Perez"]
        };
        cuentaCorrienteDos = new CuentaCorriente("004", 2000000)
        {
            LimiteDeDescubierto = 10000m,
            Comision = 0.10m,
            Titulares = ["Homero Simpson", "Lisa Simpson"]
        };
    }

    private void EjecutarAccion(string mensaje, Action accion)
    {
        try
        {
            accion();
        }
        catch(Exception e)
        {
            Console.WriteLine($"Ocurrió un error realizando {mensaje}");
            Console.WriteLine(e.Message);
        }
    }
}
