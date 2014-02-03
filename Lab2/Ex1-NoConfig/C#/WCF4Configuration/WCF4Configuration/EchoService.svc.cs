using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Globalization;

namespace WCF4Configuration
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EchoService" in code, svc and config file together.
    public class EchoService : IEchoService
    {
        public string Echo(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException("message");

            return string.Format(CultureInfo.InvariantCulture, "Echo: {0}", message);
        }
    }
}
