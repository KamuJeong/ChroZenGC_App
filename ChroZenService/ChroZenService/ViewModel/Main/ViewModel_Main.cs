using ChroZenGC.Core;
using ChroZenGC.Core.Wrappers;
using ChroZenService.ViewModel.Main;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_STATE;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_SYSTEM_CONFIG;

namespace ChroZenService
{
    public class ViewModel_Main : Observable
    {
        private Model model;

        public ConfigurationWrapper Configuration => model.Configuration;

        public StateWrapper State => model.State;

        public OvenWrapper Oven => model.Oven;

        public IList<InletSetupWrapper> Inlet => model.Inlets;


        public ViewModel_Main_Center Center { get; }

        public ViewModel_Main_Chart Chart { get; }

        public ViewModel_Main_Top Top { get; }

        public ViewModel_Main(ViewModel_Main_Top top, ViewModel_Main_Chart chart, ViewModel_Main_Center center)
        {
            model = Resolver.Resolve<Model>();

            Center = center;
            Chart = chart;
            Top = top;
         }













        #region Binding

        #region Property

        ViewModel_KeyPad _ViewModel_KeyPad = new ViewModel_KeyPad();
        public ViewModel_KeyPad ViewModel_KeyPad { get { return _ViewModel_KeyPad; } set { if (_ViewModel_KeyPad != value) { _ViewModel_KeyPad = value; OnPropertyChanged("ViewModel_KeyPad"); } } }


        ViewModelConfigPage _ViewModelConfigPage = new ViewModelConfigPage();
        public ViewModelConfigPage ViewModelConfigPage { get { return _ViewModelConfigPage; } set { if (_ViewModelConfigPage != value) { _ViewModelConfigPage = value; OnPropertyChanged("ViewModelConfigPage"); } } }

        ViewModelSystemPage _ViewModelSystemPage = new ViewModelSystemPage();
        public ViewModelSystemPage ViewModelSystemPage { get { return _ViewModelSystemPage; } set { if (_ViewModelSystemPage != value) { _ViewModelSystemPage = value; OnPropertyChanged("ViewModelSystemPage"); } } }
        #endregion Property



        #endregion Binding

    }
}
