namespace OfflineSync.Core.Infrastructure
{
    public interface INetworkProfile
    {
        bool HasAccessToNetwork { get; }
    }
}
