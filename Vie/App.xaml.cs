using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Vie
{
    public partial class App : Application
    {
        private void App_Startup(object sender, StartupEventArgs e)
        {
            Data.Path = e.Args[0].ToString();
        }
    }
}
