﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WPF.NET5.SQLite.CRUD.Data;

namespace WPF.NET5.SQLite.CRUD
{
    public partial class App : Application
    {
        #region Private members
        private readonly ServiceProvider serviceProvider;
        #endregion
        #region Constructor
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlite("Data Source = Product.db");
            });
            services.AddSingleton<MainWindow>();
            serviceProvider = services.BuildServiceProvider();
        }
        #endregion
        #region Event Handlers
        private void OnStartup(object s, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
        #endregion
    }
}
