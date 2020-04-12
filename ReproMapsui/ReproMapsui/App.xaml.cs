using BruTile.Predefined;
using Mapsui.Layers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReproMapsui
{
    public partial class App : Application
    {

        public static ILayer MyTileLayer;
        public App()
        {
            InitializeComponent();

            MyTileLayer = new TileLayer(KnownTileSources.Create());
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
