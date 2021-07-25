using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{
    public class ViewModel_Root : INotifyPropertyChanged
    {
        private View mainView;
        public View MainView 
        {
            get => mainView;
            set
            {
                if(mainView != value)
                {
                    mainView = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MainView)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
