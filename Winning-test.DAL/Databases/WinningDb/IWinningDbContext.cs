using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Winning_test.DAL.Databases.WinningDb
{
    public interface IWinningDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
