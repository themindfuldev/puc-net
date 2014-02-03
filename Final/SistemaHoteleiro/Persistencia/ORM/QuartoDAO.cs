using System;
using System.Collections;
using System.Collections.Generic;
using Modelo.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace Persistencia.ORM
{
    public class QuartoDAO : DAO
    {
        public static IList ConsultarQuartosPorCategoria(CategoriaDeQuarto categoriaDeQuarto)
        {
            IList quartos;
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                var criteria =
                    session.CreateCriteria(Type.GetType("Modelo.Dominio.Quarto,Modelo"));
                criteria.Add(Restrictions.Eq("CategoriaDeQuarto", categoriaDeQuarto));
                criteria.Add(
                    Restrictions.Not(Restrictions.Eq("Estado", Quarto.EstadoDeQuarto.EmManutencao)));
                criteria.AddOrder(Order.Asc("Numero"));
                quartos = criteria.List();
            }

            return quartos;
        }

        public static IList ConsultarQuartosEmOrdem(CategoriaDeQuarto categoriaDeQuarto)
        {
            IList quartos;
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                var criteria =
                    session.CreateCriteria(Type.GetType("Modelo.Dominio.Quarto,Modelo"));
                criteria.Add(Restrictions.Eq("CategoriaDeQuarto", categoriaDeQuarto));
                criteria.Add(
                    Restrictions.Not(Restrictions.Eq("Estado", Quarto.EstadoDeQuarto.EmManutencao)));
                criteria.AddOrder(Order.Asc("Numero"));
                quartos = criteria.List();
            }

            return quartos;
        }

        public static IList ConsultarQuartosDisponiveis(CategoriaDeQuarto categoriaDeQuarto)
        {
            IList quartos;
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                var criteria =
                    session.CreateCriteria(Type.GetType("Modelo.Dominio.Quarto,Modelo"));
                criteria.Add(Restrictions.Eq("CategoriaDeQuarto", categoriaDeQuarto));
                criteria.Add(Restrictions.Eq("Estado", Quarto.EstadoDeQuarto.Disponivel));
                criteria.AddOrder(Order.Asc("Numero"));
                quartos = criteria.List();
            }

            return quartos;
        }

        public static Quarto BuscarQuarto(byte numeroDoQuarto)
        {
            Quarto quarto = null;
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                var criteria = session.CreateCriteria(Type.GetType("Modelo.Dominio.Quarto,Modelo"));
                criteria.Add(Restrictions.Eq("Numero", numeroDoQuarto));
                quarto = criteria.UniqueResult() as Quarto;
            }
            return quarto;
        }

        public static IList ObterQuartosEmLimpeza()
        {
            IList quartos;
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                var criteria =
                    session.CreateCriteria(Type.GetType("Modelo.Dominio.Quarto,Modelo"));
                criteria.Add(Restrictions.Eq("Estado", Quarto.EstadoDeQuarto.EmLimpeza));
                criteria.AddOrder(Order.Asc("Numero"));
                quartos = criteria.List();
            }

            return quartos;
        }

        public static IList ObterQuartosPorCategoria(long categoriaDeQuartoId)
        {
            IList quartos;
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                var criteria =
                    session.CreateCriteria(Type.GetType("Modelo.Dominio.Quarto,Modelo"));
                criteria.Add(Restrictions.Eq("CategoriaDeQuarto.Id", categoriaDeQuartoId));
                criteria.AddOrder(Order.Asc("Numero"));
                quartos = criteria.List();
            }

            return quartos;
        }

        public static IList ObterQuartosOcupados()
        {
            IList quartos;
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                var criteria =
                    session.CreateCriteria(Type.GetType("Modelo.Dominio.Quarto,Modelo"));
                criteria.Add(Restrictions.Eq("Estado", Quarto.EstadoDeQuarto.Ocupado));
                criteria.AddOrder(Order.Asc("Numero"));
                quartos = criteria.List();
            }

            return quartos;
        }
    }

}
