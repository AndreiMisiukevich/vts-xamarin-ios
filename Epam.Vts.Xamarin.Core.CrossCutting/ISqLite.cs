using SQLite;

namespace Epam.Vts.Xamarin.Core.CrossCutting
{
    public interface ISqLite
    {
        SQLiteConnection GetConnection();
    }
}
