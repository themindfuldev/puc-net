using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Discovery;

namespace ChatProxy
{
    internal class ChatServiceCollection : SynchronizedKeyedCollection<Uri, EndpointDiscoveryMetadata>
    {
        protected override Uri GetKeyForItem(EndpointDiscoveryMetadata item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            return item.Address.Uri;
        }
    }
}
