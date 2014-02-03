using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalculadoraWCF
{
    public class Calculadora : ICalculadora
    {

        public double Soma(params double[] fatores)
        {
            double total = 0;

            foreach (double fator in fatores)
            {
                total += fator;
            }

            return total;
        }

        public double Subtracao(params double[] fatores)
        {
            double total = fatores.Length > 0 ? fatores[0] : 0;

            for (int i = 1; i < fatores.Length; i++)
            {
                total -= fatores[i];
            }

            return total;
        }

        public double Multiplicacao(params double[] termos)
        {
            double produto = 1;

            foreach (double termo in termos)
            {
                produto *= termo;
            }

            return produto;
        }

        public double Divisao(double dividendo, double divisor) 
        {
            return dividendo / divisor;
        }

        public int Quociente(double dividendo, double divisor)
        {
            return (int)(dividendo / divisor);
        }

        public int Resto(double dividendo, double divisor)
        {
            return (int)(dividendo % divisor);
        }

        public int Fatorial(int n)
        {
            if (n < 1) return 0;

            int fatorial = 1;

            for (int i = 2; i <= n; i++)
            {
                fatorial *= i;
            }

            return fatorial;
        }

        public int Fibonacci(int posicao)
        {
            if (posicao < 1) return 0;
            if (posicao == 1) return 1;

            return Fibonacci(posicao - 1) + Fibonacci(posicao - 2);
        }
    }
}
