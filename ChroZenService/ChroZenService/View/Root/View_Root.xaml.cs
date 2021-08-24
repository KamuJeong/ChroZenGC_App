
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChroZenService
{

    public partial class View_Root : ContentPage
    {

        public View_Root(ViewModel_Root viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;

            Home.Content = Resolver.Resolve<View_Main>();

            if (Footer.FindByName("HomeButton") is ImageButton home)
            {
                home.Clicked += OnHomeButtonClicked;
            }
            if (Footer.FindByName("ConfigButton") is ImageButton config)
            {
                config.Clicked += OnConfigButtonClicked;
            }
            if (Footer.FindByName("SystemButton") is ImageButton system)
            {
                system.Clicked += OnSystemButtonClicked;
            }

            Config.Content = Resolver.Resolve<View_Config>();
            System.Content = Resolver.Resolve<View_System>();
            Initialize();
        }
    
        public void Initialize()
        {
            OnHomeButtonClicked(null, null);
        }

        private void OnHomeButtonClicked(object sender, EventArgs e)
        {
            Home.Content = Resolver.Resolve<View_Main>();
            Home.IsVisible = true;
            Config.IsVisible = false;
            System.IsVisible = false;
        }

        private void OnConfigButtonClicked(object sender, EventArgs e)
        {
            Home.IsVisible = false;
            Config.Content = Resolver.Resolve<View_Config>();
            Config.IsVisible = true;
            System.IsVisible = false;
        }

        private void OnSystemButtonClicked(object sender, EventArgs e)
        {
            Home.IsVisible = false;
            Config.IsVisible = false;
            System.Content = Resolver.Resolve<View_System>();
            System.IsVisible = true;
        }
    }
}
