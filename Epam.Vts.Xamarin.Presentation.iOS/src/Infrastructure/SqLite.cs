using System;
using System.IO;
using Epam.Vts.Xamarin.Core.CrossCutting;
using SQLite;

namespace Epam.Vts.Xamarin.Presentation.iOS.Infrastructure
{
    public class SqLite : ISqLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "VtsEpam.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFilename);
            var conn = new SQLiteConnection(path);
            return conn;
        }
    }
}
