using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pizza_Palace_Coding_Problem.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Pizza_Palace_Coding_Problem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ConfigureServices(IConfiguration configuration,
        IServiceCollection services)
        {

            // Register all ViewModels.
            services.AddSingleton<MainWindowViewModel>();

            // Register all the Windows of the applications.
            services.AddTransient<MainWindow>();
        }
    }
}
