using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_Hero.Logic;
using WPF_Hero.Services;

namespace WPF_Hero
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            Ioc.Default.ConfigureServices(new ServiceCollection()
                .AddSingleton<IHeroLogic, HeroLogic>()
                .AddSingleton<IHeroCreatorViaWindows, HeroCreatorViaWindows>()
                .AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
                .BuildServiceProvider()
                );
        }
    }
}
