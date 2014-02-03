using System.Collections.Generic;
using Modelo.Dominio;
using Persistencia.ORM;

namespace Negocio.Servico
{
    public class ServicoCliente : IServicoCliente
    {
        public void CadastrarCliente(Cliente cliente)
        {
            DAO.Save(cliente);
        }

        public void AlterarCliente(Cliente cliente)
        {
            DAO.Update(cliente);
        }

        public void ExcluirCliente(Cliente cliente)
        {
            DAO.Delete(cliente);
        }

        public IList<Cliente> ObterClientes()
        {
            var consulta = DAO.GetAllInOrder("Modelo.Dominio.Cliente,Modelo", "Nome");
            var clientes = new List<Cliente>();

            foreach (var cliente in consulta)
            {
                clientes.Add(cliente as Cliente);
            }

            return clientes;
        }

        public Cliente ObterCliente(long id)
        {
            return DAO.GetById("Modelo.Dominio.Cliente,Modelo", id) as Cliente;
        }

        public Cliente BuscarCliente(string cpf)
        {
            return ClienteDAO.BuscarCliente(cpf);
        }
    }
}
