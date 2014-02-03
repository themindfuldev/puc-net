using System;
using Modelo.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace Persistencia.ORM
{
    public class ClienteDAO : DAO
    {
        public static Cliente BuscarCliente(string cpf)
        {
            Cliente cliente = null;
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                var criteria = session.CreateCriteria(Type.GetType("Modelo.Dominio.Cliente,Modelo"));
                criteria.Add(Restrictions.Eq("CPF", cpf));
                cliente = criteria.UniqueResult() as Cliente;
            }
            return cliente;
        }
    }
}
