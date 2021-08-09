using ChroZenGC.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChroZenService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Grid_Config_Inlet : ContentView, IAsyncInitialize
    {
        public static readonly BindableProperty InletProperty = BindableProperty.Create("Inlet", typeof(InletSetupWrapper), typeof(Grid_Config_Inlet));

        public InletSetupWrapper Inlet
        {
            get => (InletSetupWrapper)GetValue(InletProperty);
            set => SetValue(InletProperty, value);
        }

        public static readonly BindableProperty TemperatureProperty = BindableProperty.Create("Temperature", typeof(float), typeof(Grid_Config_Inlet));

        public float Temperature
        {
            get => (float)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        public static readonly BindableProperty PressureProperty = BindableProperty.Create("Pressure", typeof(float), typeof(Grid_Config_Inlet));

        public float Pressure
        {
            get => (float)GetValue(PressureProperty);
            set => SetValue(PressureProperty, value);
        }

        public static readonly BindableProperty ColumnFlowProperty = BindableProperty.Create("ColumnFlow", typeof(float), typeof(Grid_Config_Inlet));

        public float ColumnFlow
        {
            get => (float)GetValue(ColumnFlowProperty);
            set => SetValue(ColumnFlowProperty, value);
        }


        public static readonly BindableProperty FlowProperty = BindableProperty.Create("Flow", typeof(float), typeof(ArrayWrapper<float>));

        public ArrayWrapper<float> Flow
        {
            get => (ArrayWrapper<float>)GetValue(FlowProperty);
            set => SetValue(FlowProperty, value);
        }

        public static readonly BindableProperty VelocityProperty = BindableProperty.Create("Velocity", typeof(float), typeof(Grid_Config_Inlet));

        public float Velocity
        {
            get => (float)GetValue(VelocityProperty);
            set => SetValue(VelocityProperty, value);
        }






        public Grid_Config_Inlet()
        {
            InitializeComponent();
        }

        public async Task InitializeAsync()
        {
            await Task.CompletedTask;
        }
    }
}