using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Modelo.Dominio;

namespace Negocio.Servico
{
    [ServiceContract]
    public interface IServicoCliente
    {
        [OperationContract]
        void CadastrarCliente(Cliente cliente);

        [OperationContract]
        void AlterarCliente(Cliente cliente);

        [OperationContract]
        void ExcluirCliente(Cliente cliente);

        [OperationContract]
        IList<Cliente> ObterClientes();

        [OperationContract]
        Cliente ObterCliente(long id);

        [OperationContract]
        Cliente BuscarCliente(String cpf);
    }
}
