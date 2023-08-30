using System;

namespace Laboratorio01
{
    public class CajeroAutomatico : CuentaBancaria
    {
        private double limiteDiarioRetiro;
        private double montoRetiradoHoy;

        public CajeroAutomatico(int pin, double saldo, int numberCount, string titularCount, double limiteDiarioRetiro)
            : base(pin, saldo, numberCount, titularCount)
        {
            this.limiteDiarioRetiro = limiteDiarioRetiro;
            this.montoRetiradoHoy = 0;
        }

        public double ConsultarSaldo()
        {
            return Saldo;
        }

        public void AgregarFondos(double cantidad)
        {
            Saldo += cantidad;
            Console.WriteLine("Se han agregado " + cantidad + " fondos a la cuenta.");
        }

        public void RetirarEfectivo(double cantidad)
        {
            if (cantidad <= 0)
            {
                Console.WriteLine("La cantidad de retiro debe ser mayor que cero.");
                return;
            }

            if (cantidad > Saldo)
            {
                Console.WriteLine("No hay suficientes fondos en la cuenta.");
                return;
            }

            if (cantidad + montoRetiradoHoy > limiteDiarioRetiro)
            {
                Console.WriteLine("Se ha alcanzado el límite diario de retiro.");
                return;
            }

            Saldo -= cantidad;
            montoRetiradoHoy += cantidad;
            Console.WriteLine("Se han retirado " + cantidad + " de la cuenta.");
        }
    }
}
