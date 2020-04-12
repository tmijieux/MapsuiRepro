
namespace ReproMapsui
{
    public partial class Tab1
    {
        public Tab1(int i)
        {
            InitializeComponent();
            IsVisible = false;
            MyText.Text = "Tab"+i.ToString();
        }
    }
}
