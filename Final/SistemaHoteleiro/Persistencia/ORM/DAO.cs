using System;
using System.Collections;
using NHibernate;
using NHibernate.Criterion;

namespace Persistencia.ORM
{
    public class DAO
    {
        public static void Save(object entity)
        {
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }


        public static void Update(object entity)
        {
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(entity);
                    transaction.Commit();
                }
            }
        }

        public static void Delete(object entity)
        {
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
        }

        public static object GetById(string name, object id)
        {
            using (ISession session = NHibernateHelper.GetCurrentSession())
                return session.Get(name, id);

        }

        public static IList GetAll(string name)
        {
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                var persistentClass = Type.GetType(name);
                ICriteria criteria = session.CreateCriteria(persistentClass);
                return criteria.List();
            }
        }

        public static IList GetAllInOrder(string name, string attribute)
        {
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                var persistentClass = Type.GetType(name);
                ICriteria criteria = session.CreateCriteria(persistentClass).AddOrder(Order.Asc(attribute));
                return criteria.List();
            }
        }

        public static IList GetAll(string clazz, string field, object value)
        {
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                var persistentClass = Type.GetType(clazz);
                ICriteria criteria = session.CreateCriteria(persistentClass);

                IList results = criteria.Add(Restrictions.Eq(field, value)).List();

                return results;
            }
        }

    }
}
