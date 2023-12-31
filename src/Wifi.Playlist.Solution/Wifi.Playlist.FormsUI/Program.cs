﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wifi.Playlist.CoreTypes;
using Wifi.Playlist.Factories;
using Wifi.Playlist.WeatherExtension;

namespace Wifi.Playlist.FormsUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //builder erzeugen 
            var builder = new ContainerBuilder();

            //typen registrieren 
            //builder.RegisterType<DummyEditor>().As<INewPlaylistDataProvider>();
            builder.RegisterType<NewPlaylistForm>().As<INewPlaylistDataProvider>();
            builder.RegisterType<PlaylistItemFactory>().As<IPlaylistItemFactory>();
            builder.RegisterType<RepositoryFactory>().As<IRepositoryFactory>();
            //builder.RegisterType<CurrentWeatherService>().As<ICurrentWeatherService>();
            builder.RegisterType<CurrentWeatherProxy>().As<ICurrentWeatherService>();
            builder.RegisterType<MainForm>();

            var container = builder.Build();

            var mainForm = container.Resolve<MainForm>();

            // Create types
            //var provider = new NewPlaylistForm();
            //-var provider = new DummyEditor();

            // factories erzeugen
            //-var itemFactory = new PlaylistItemFactory();
            //-var repositoryFactory = new RepositoryFactory(itemFactory);

            Application.Run(mainForm);
            //-Application.Run(new MainForm(provider, itemFactory, repositoryFactory));
        }
    }
}
