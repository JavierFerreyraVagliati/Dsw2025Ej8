using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8.Presentation;


internal class PrincipalView
{
    private CajaDeAhorro cajaAhorroUno;
    private CajaDeAhorro cajaAhorroDos ;
    private CuentaCorriente cuentaCorrienteUno;
    private CuentaCorriente cuentaCorrienteDos;
    private List<CuentaBancaria> cuentas;
    public PrincipalView() { }

    public void Iniciar()
    {
        InicializarInstancias();
        Console.WriteLine("Iniciar programa\t");

        // Operar con Caja de Ahorro 1
        OperarConCuenta(cajaAhorroUno, new List<Action>
            {
                // Caso de prueba: Monto no válido (monto <= 0)
                () => EjecutarAccion("Depósito de $0 (debería fallar)", () => {
                    cajaAhorroUno.Depositar(0);
                    Console.WriteLine($"->Estado | Deposito | Saldo actual: {cajaAhorroUno.Saldo}");
                }),
                
                // Caso de prueba: Depósito correcto
                () => EjecutarAccion("Depósito de $500", () => {
                    cajaAhorroUno.Depositar(500);
                    Console.WriteLine($"->Estado | Deposito | Saldo actual: {cajaAhorroUno.Saldo}");
                }),
                
                // Caso de prueba: Retiro correcto
                () => EjecutarAccion("Retiro de $300", () => {
                    cajaAhorroUno.Retirar(300);
                    Console.WriteLine($"->Estado | Retiro | Saldo actual: {cajaAhorroUno.Saldo}");
                }),
                
                // Caso de prueba: Aplicar interés
                () => EjecutarAccion("Aplicar Interés", () => {
                    cajaAhorroUno.AplicarInteres();
                    Console.WriteLine($"->Estado | Interés | Saldo actual: {cajaAhorroUno.Saldo}");
                }),
                
                // Caso de prueba: Saldo insuficiente (debería suspender la cuenta)
                () => EjecutarAccion("Retiro de $2000 (debería fallar por saldo insuficiente)", () => {
                    cajaAhorroUno.Retirar(2000);
                    Console.WriteLine($"->Estado | Retiro | Saldo actual: {cajaAhorroUno.Saldo}");
                }),
                
                // Caso de prueba: Cuenta no activa (ya que debería estar suspendida)
                () => EjecutarAccion("Depósito después de suspensión (debería fallar)", () => {
                    cajaAhorroUno.Depositar(100);
                    Console.WriteLine($"->Estado | Deposito | Saldo actual: {cajaAhorroUno.Saldo}");
                })
            });

        OperarConCuenta(cajaAhorroDos, new List<Action>
            {
                // Caso de prueba: Depósito en cuenta con saldo cero
                () => EjecutarAccion("Depósito de $1500 en cuenta nueva", () => {
                    cajaAhorroDos.Depositar(1500);
                    Console.WriteLine($"->Estado | Deposito | Saldo actual: {cajaAhorroDos.Saldo}");
                }),
                
                // Caso de prueba: Aplicar interés a cuenta con saldo positivo
                () => EjecutarAccion("Aplicar Interés (tasa 0.25)", () => {
                    cajaAhorroDos.AplicarInteres();
                    Console.WriteLine($"->Estado | Interés | Saldo actual: {cajaAhorroDos.Saldo}");
                }),
                
                // Caso de prueba: Retiro de monto negativo (debería fallar)
                () => EjecutarAccion("Retiro de -$100 (monto no válido)", () => {
                    cajaAhorroDos.Retirar(-100);
                    Console.WriteLine($"->Estado | Retiro | Saldo actual: {cajaAhorroDos.Saldo}");
                }),
                
                // Caso de prueba: Retiro correcto
                () => EjecutarAccion("Retiro de $500", () => {
                    cajaAhorroDos.Retirar(500);
                    Console.WriteLine($"->Estado | Retiro | Saldo actual: {cajaAhorroDos.Saldo}");
                })
            });

        // Operar con Cuenta Corriente 1
        OperarConCuenta(cuentaCorrienteUno, new List<Action>
            {
                // Caso de prueba: Monto no válido
                () => EjecutarAccion("Depósito de $0 (debería fallar)", () => {
                    cuentaCorrienteUno.Depositar(0);
                    Console.WriteLine($"->Estado | Deposito | Saldo actual: {cuentaCorrienteUno.Saldo} | Descubierto: {cuentaCorrienteUno.LimiteDeDescubierto}");
                }),
                
                // Caso de prueba: Depósito con comisión
                () => EjecutarAccion("Depósito de $1000 con comisión 0.01", () => {
                    cuentaCorrienteUno.Depositar(1000);
                    Console.WriteLine($"->Estado | Deposito | Saldo actual: {cuentaCorrienteUno.Saldo} | Descubierto: {cuentaCorrienteUno.LimiteDeDescubierto}");
                }),
                
                // Caso de prueba: Retiro que deja saldo negativo pero dentro del límite de descubierto
                () => EjecutarAccion("Retiro de $1400 (quedará descubierto pero dentro del límite)", () => {
                    cuentaCorrienteUno.Retirar(1400);
                    Console.WriteLine($"->Estado | Retiro | Saldo actual: {cuentaCorrienteUno.Saldo} | Descubierto: {cuentaCorrienteUno.LimiteDeDescubierto}");
                }),
                
                // Caso de prueba: Retiro que supera el límite de descubierto
                () => EjecutarAccion("Retiro de $1000 (supera el límite de descubierto)", () => {
                    cuentaCorrienteUno.Retirar(1000);
                    Console.WriteLine($"->Estado | Retiro | Saldo actual: {cuentaCorrienteUno.Saldo} | Descubierto: {cuentaCorrienteUno.LimiteDeDescubierto}");
                }),
                
                // Caso de prueba: Operación en cuenta suspendida
                () => EjecutarAccion("Intento de depósito en cuenta suspendida", () => {
                    cuentaCorrienteUno.Depositar(500);
                    Console.WriteLine($"->Estado | Deposito | Saldo actual: {cuentaCorrienteUno.Saldo} | Descubierto: {cuentaCorrienteUno.LimiteDeDescubierto}");
                })
            });

        // Operar con Cuenta Corriente 2
        OperarConCuenta(cuentaCorrienteDos, new List<Action>
            {
                // Caso de prueba: Depósito con comisión alta
                () => EjecutarAccion("Depósito de $1000 con comisión 0.10", () => {
                    cuentaCorrienteDos.Depositar(1000);
                    Console.WriteLine($"->Estado | Deposito | Saldo actual: {cuentaCorrienteDos.Saldo} | Descubierto: {cuentaCorrienteDos.LimiteDeDescubierto}");
                }),
                
                // Caso de prueba: Retiro dentro del saldo
                () => EjecutarAccion("Retiro de $500", () => {
                    cuentaCorrienteDos.Retirar(500);
                    Console.WriteLine($"->Estado | Retiro | Saldo actual: {cuentaCorrienteDos.Saldo} | Descubierto: {cuentaCorrienteDos.LimiteDeDescubierto}");
                }),
                
                // Caso de prueba: Retiro que entra en descubierto
                () => EjecutarAccion("Retiro de $1400 (entra en descubierto)", () => {
                    cuentaCorrienteDos.Retirar(1400);
                    Console.WriteLine($"->Estado | Retiro | Saldo actual: {cuentaCorrienteDos.Saldo} | Descubierto: {cuentaCorrienteDos.LimiteDeDescubierto}");
                }),
                
                // Caso de prueba: Depósito mientras está en descubierto
                () => EjecutarAccion("Depósito de $2000 estando en descubierto", () => {
                    cuentaCorrienteDos.Depositar(2000);
                    Console.WriteLine($"->Estado | Deposito | Saldo actual: {cuentaCorrienteDos.Saldo} | Descubierto: {cuentaCorrienteDos.LimiteDeDescubierto}");
                })
            });

        // Mostrar resumen de cuentas (punto 11 - utilizando clase anónima)
        Console.WriteLine("\nResumen de cuentas utilizando clase anónima:");
        Console.WriteLine("============================================");
        cuentas = new List<CuentaBancaria> { cajaAhorroUno, cajaAhorroDos, cuentaCorrienteUno, cuentaCorrienteDos };

        foreach (var cuenta in cuentas)
        {
            // Crear clase anónima con los datos requeridos
            var resumen = new
            {
                Numero = cuenta.Numero,
                Tipo = cuenta.GetType().Name,
                Saldo = cuenta.Saldo,
                Estado = cuenta.Estado,
                Titulares = string.Join(", ", cuenta.Titulares),
                InfoAdicional = cuenta is CuentaCorriente cc
                    ? $"Límite Descubierto: {cc.LimiteDeDescubierto:C}, Comisión: {cc.Comision:P}"
                    : cuenta is CajaDeAhorro ca
                        ? $"Tasa de Interés: {ca.TasaDeInteres:P}"
                        : ""
            };

            // Mostrar el resumen
            Console.WriteLine($"Cuenta: {resumen.Numero} | Tipo: {resumen.Tipo} | " +
                             $"Saldo: {resumen.Saldo:C} | Estado: {resumen.Estado}");
            Console.WriteLine($"Titulares: {resumen.Titulares}");
            Console.WriteLine($"Info adicional: {resumen.InfoAdicional}");
            Console.WriteLine("--------------------------------------------");
        }



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
