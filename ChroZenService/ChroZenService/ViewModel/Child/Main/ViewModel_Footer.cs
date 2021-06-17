using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_Footer : Observable
    {
        string _SelectedWindow;
        public string SelectedWindow { get { return _SelectedWindow; } set { { _SelectedWindow = value; OnPropertyChanged("SelectedWindow"); } } }

        public ViewModel_Footer()
        {

        }
    }
}
