using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalculadoraWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICalculadora" in both code and config file together.
    [ServiceContract]
    public interface ICalculadora
    {
        [OperationContract]
        double Soma(params double[] fatores);

        [OperationContract]
        double Subtracao(params double[] fatores);

        [OperationContract]
        double Multiplicacao(params double[] fatores);

        [OperationContract]
        double Divisao(double dividendo, double divisor);

        [OperationContract]
        int Quociente(double dividendo, double divisor);

        [OperationContract]
        int Resto(double dividendo, double divisor);

        [OperationContract]
        int Fatorial(int n);

        [OperationContract]
        int Fibonacci(int posicao);
    }
}
