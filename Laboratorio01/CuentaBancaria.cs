using System;

namespace Laboratorio01
{
    public class CuentaBancaria
    {
        public int Pin { get; private set; }
        public double Saldo { get; protected set; }
        public int NumberCount { get; protected set; }
        public string TitularCount { get; protected set; }

        public CuentaBancaria(int pin, double saldo, int numberCount, string titularCount)
        {
            Pin = pin;
            Saldo = saldo;
            NumberCount = numberCount;
            TitularCount = titularCount;
        }
    }
}
