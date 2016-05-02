using System;
using OfflineSync.Core.Infrastructure;
using Windows.Storage;
using System.IO;
using System.Collections.Generic;
using OfflineSync.Core.Model;
using System.Threading.Tasks;

namespace OfflineSync.Uwp
{
    public class SqliteConnection : ISqliteConnetion
    {
        private SQLite.Net.SQLiteConnection _connection;

        public SqliteConnection()
        {
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Test");
            _connection = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            _connection.CreateTable<Banners>();
        }

        public async Task<IEnumerable<T>> Get<T>() where T : class
        {
            return _connection.Table<T>();
        }

        public T Save<T>(T data) where T : class
        {
            _connection.Insert(data);
            return data;
        }

        public async Task<IEnumerable<T>> SaveAll<T>(IEnumerable<T> items) where T : class
        {
            _connection.InsertAll(items);
            return items;
        }
    }
}
