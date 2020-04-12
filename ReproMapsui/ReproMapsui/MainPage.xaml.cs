using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ReproMapsui
{

    public class Tab
    {
        public Frame TabButton { get; set; }
        public Lazy<View> LazyView { get; set; }
        public View View { get => LazyView.Value; }
        public bool IsInitialized = false;
    }

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private Lazy<View> MakeLazy(Func<View> f)
        {
            return new Lazy<View>(f);
        }

        public const int NumTabs = 5;
        private readonly Tab[] Tabs;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();

            Tabs = new Tab[NumTabs] {
                new Tab {
                    TabButton = Tab1Button,
                    LazyView = MakeLazy(() => new Tab1(1)),
                },
                new Tab {
                    TabButton = Tab2Button,
                    LazyView = MakeLazy(() => new TabMap(2)),
                },
                new Tab {
                    TabButton = Tab3Button,
                    LazyView = MakeLazy(() => new TabMap(3)),
                },
                new Tab {
                    TabButton = Tab4Button,
                    LazyView = MakeLazy(() => new TabMap(4)),
                },
                new Tab {
                    TabButton = Tab5Button,
                    LazyView = MakeLazy(() => new TabMap(5)),
                },
            };
            for (int i = 0; i < NumTabs; ++i) {
                int k = i; // local copy in loop for closure
                Tabs[i].TabButton.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = new Command(() => GoToTab(k)),
                });
            }
            GoToTab(0);
        }

        private void GoToTab(int tabId)
        {
            // hide
            for (int i = 0; i < NumTabs; ++i)
            {
                if (i != tabId && Tabs[i].LazyView.IsValueCreated)
                {
                    Tabs[i].View.IsVisible = false;
                }
            }

            var tab = Tabs[tabId];
            View v = tab.View;
            if (!tab.IsInitialized)
            {
                tab.IsInitialized = true;
                PlaceholderGrid.Children.Add(v, 0, 0);
            }
            v.IsVisible = true;
        }
    }
}
