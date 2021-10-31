using System;
using System.Collections.Generic;
using System.Text;

namespace Winning_test.DAL.Databases.WinningDb
{
    public class WinningDbSettings : IWinningDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
