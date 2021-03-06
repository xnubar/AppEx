﻿using AppEx.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AppEx
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var viewModelLocator = new ViewModelLocator();
            var app = new AppView();
            app.DataContext = viewModelLocator.appViewModel;
            app.ShowDialog();
        }
    }
}
