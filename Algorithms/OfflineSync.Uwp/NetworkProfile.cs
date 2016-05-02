using OfflineSync.Core.Infrastructure;

namespace OfflineSync.Uwp
{
    public class NetworkProfile : INetworkProfile
    {
        public bool HasAccessToNetwork
        {
            get
            {
                return false;
            }
        }
    }
}
