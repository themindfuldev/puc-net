using System;
using System.Collections;
using Modelo.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace Persistencia.ORM
{
    public class OcupacaoDAO : DAO
    {
        public static Ocupacao BuscarOcupacao(long idQuarto)
        {
            Ocupacao ocupacao = null;
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                var criteria = session.CreateCriteria(Type.GetType("Modelo.Dominio.Ocupacao,Modelo"));
                criteria.Add(Restrictions.Eq("Quarto.Id", idQuarto));
                ocupacao = criteria.UniqueResult() as Ocupacao;
            }
            return ocupacao;
        }

        public static float ObterFaturamentoPorPeriodo(DateTime dataInicio, DateTime dataFinal)
        {
            IList ocupacoes;
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                var criteria = session.CreateCriteria(Type.GetType("Modelo.Dominio.Ocupacao,Modelo"));
                criteria.Add(Restrictions.Ge("DataCheckIn", dataInicio));
                criteria.Add(Restrictions.Le("DataCheckOut", dataFinal));
                criteria.CreateCriteria("Conta").Add(Restrictions.Eq("Estado", Conta.EstadoDeConta.Pago));
                ocupacoes = criteria.List();
            }

            float faturamento = 0;
            foreach (Ocupacao ocupacao in ocupacoes)
            {
                faturamento += ocupacao.Conta.ValorTotal;
            }

            return faturamento;
        }
    }
}
