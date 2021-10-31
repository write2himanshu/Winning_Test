using System;
using System.Collections.Generic;
using System.Text;

namespace Winning_test.DAL.Databases.WinningDb
{
    interface IWinningDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
