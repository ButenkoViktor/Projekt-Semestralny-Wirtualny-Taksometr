﻿using System.Configuration;
using System.Data;
using System.Windows;
using WpfProjektWirtualnyTaksometr.BazaDanych;

namespace WpfProjektWirtualnyTaksometr
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var context = new TaksometrDbContext())
            {
                context.EnsureCreated();
            }

            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
