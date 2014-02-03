using NHibernate;
using NHibernate.Cfg;
using System.Web;

namespace Persistencia.ORM
{
    public sealed class NHibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory SessionFactory;

        static NHibernateHelper()
        {
            SessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        public static ISession GetCurrentSession()
        {
            ISession currentSession = null;

            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                currentSession = context.Items[CurrentSessionKey] as ISession;
                if (currentSession == null)
                {
                    currentSession = SessionFactory.OpenSession();
                    context.Items[CurrentSessionKey] = currentSession;
                }
            }
            else
            {
                currentSession = SessionFactory.OpenSession();
            }

            return currentSession;
        }

        public static void CloseSession()
        {
            ISession currentSession = null;

            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                currentSession = context.Items[CurrentSessionKey] as ISession;
                if (currentSession == null)
                {
                    return;
                }
                context.Items.Remove(CurrentSessionKey);
                currentSession.Close();
            }
        }

        public static void CloseSessionFactory()
        {
            if (SessionFactory != null)
            {
                SessionFactory.Close();
            }
        }
    }
}