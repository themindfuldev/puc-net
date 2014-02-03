using System;
using System.Collections;
using System.Collections.Generic;
using Modelo.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace Persistencia.ORM
{
    public class ReservaDAO : DAO
    {
        public static IList ConsultarReservas(DateTime dataInicio, DateTime dataFim, CategoriaDeQuarto categoriaDeQuarto)
        {
            IList reservas;
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                var criteriaReservas = session.CreateCriteria(Type.GetType("Modelo.Dominio.Reserva,Modelo"));
                criteriaReservas.Add(Restrictions.Ge("DataFim", dataInicio));
                criteriaReservas.Add(Restrictions.Le("DataInicio", dataFim));
                criteriaReservas.Add(Restrictions.Eq("CategoriaDeQuarto", categoriaDeQuarto));
                reservas = criteriaReservas.List();
            }

            return reservas as IList;
        }

        public static IList ConsultarReservas(Cliente cliente)
        {
            IList reservas;
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                var criteriaReservas = session.CreateCriteria(Type.GetType("Modelo.Dominio.Reserva,Modelo"));
                criteriaReservas.Add(Restrictions.Eq("Cliente", cliente));
                reservas = criteriaReservas.List();
            }

            return reservas;
        }

        public static IList ObterReservasParaCheckin()
        {
            IList reservas;
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                var criteriaReservas = session.CreateCriteria(Type.GetType("Modelo.Dominio.Reserva,Modelo"));
                criteriaReservas.Add(Restrictions.Le("DataInicio", DateTime.Now));
                criteriaReservas.Add(Restrictions.Ge("DataInicio", DateTime.Now.AddDays(-1)));
                criteriaReservas.Add(Restrictions.Eq("Estado", Reserva.EstadoDeReserva.Ativa));
                reservas = criteriaReservas.List();
            }

            return reservas as IList;
        }

        public static IList ObterReservasVencidas()
        {
            IList reservas;
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                var criteriaReservas = session.CreateCriteria(Type.GetType("Modelo.Dominio.Reserva,Modelo"));
                criteriaReservas.Add(Restrictions.Lt("DataInicio", DateTime.Now.AddDays(-1)));
                criteriaReservas.Add(Restrictions.Eq("Estado", Reserva.EstadoDeReserva.Ativa));
                reservas = criteriaReservas.List();
            }

            return reservas as IList;
        }
    }
}
