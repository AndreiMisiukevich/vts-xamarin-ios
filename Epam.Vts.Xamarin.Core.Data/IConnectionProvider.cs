namespace Epam.Vts.Xamarin.Core.Data
{
    public interface IConnectionProvider
    {
        bool IsConnected { get; }
    }

    public class ConnectionProvider : IConnectionProvider
    {
        public bool IsConnected => Plugin.Connectivity.CrossConnectivity.Current.IsConnected;
    }

    public class FakeConnectionProvider : IConnectionProvider
    {
        public bool IsConnected => false;
    }
}
