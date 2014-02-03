using System.Collections.Generic;
using System.ServiceModel;
using Modelo.Dominio;

namespace Negocio.Servico
{
    [ServiceContract]
    public interface IServicoOcupacao
    {
        [OperationContract]
        Ocupacao RegistrarCheckin(long idReserva);

        [OperationContract]
        Ocupacao RegistrarCheckout(long idQuarto);

        [OperationContract]
        void PagarConta(Conta conta);

        [OperationContract]
        void RegistrarTerminoDeLimpeza(long id);

        [OperationContract]
        IList<Quarto> ObterQuartosOcupados();
    }
}
