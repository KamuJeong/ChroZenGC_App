using ChroZenGC.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{ 
    public class ViewModel_Config : Observable
    {
        public Model Model { get; }

        public ViewModel_Config()
        {
            Model = Resolver.Resolve<Model>();

            ScaleX = 1.798 * App.ScreenWidth / BackgroundImageSize.Width;
            ScaleY = 2.01 * App.ClientHeight / BackgroundImageSize.Height;
        }


        private Size BackgroundImageSize = new Size(569, 792);

        public double ScaleX { get; }
        public double ScaleY { get; }
    }
}
