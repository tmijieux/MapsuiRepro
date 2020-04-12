
namespace ReproMapsui
{
    public partial class TabMap
    {
        public TabMap(int i)
        {
            IsVisible = false;
            InitializeComponent();

            MyText.Text = "Tab"+i.ToString();

            MyMap.MyLocationEnabled = true;
            MyMap.MyLocationEnabled = false;

            MyMap.Map.Layers.Add(App.MyTileLayer);
            MyMap.RotationLock = true;
            MyMap.MyLocationFollow = false;
            MyMap.IsMyLocationButtonVisible = false;
            MyMap.IsNorthingButtonVisible = false;
            MyMap.IsZoomButtonVisible = false;
        }
    }
}
