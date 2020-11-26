﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{
    public class VToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                string[] xx = parameter.ToString().Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string x in xx)
                {
                    if (value.ToString().Equals(x))
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (int.Parse( value.ToString()) == 1) return true;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class XToMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int x = int.Parse(value.ToString());
            double t = 79 + x * 100 + ((int)Math.Floor((x - 1) / 3.0)) * 10;
            return new Thickness(0, t, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class NToMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int x = int.Parse(value.ToString());
            double t = 69 + x * 100;
            return new Thickness(0, t, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ByteToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (byte)value == 0x00 ? false : true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value == true)
            {
                return (byte)0x01;
            }
            return (byte)0x00;
        }
    }

    public class FloatToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (float)value == 0 ? false : true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ByteToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (int)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class FloatToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter != null)
            {
                string p = parameter.ToString();
                if ("0".Equals(p))
                {
                    return ((float)value).ToString("0");
                }
                else if ("1".Equals(p))
                {
                    return ((float)value).ToString("0.0");
                }
                else if ("2".Equals(p))
                {
                    return ((float)value).ToString("0.00");
                }
                else if ("3".Equals(p))
                {
                    return ((float)value).ToString("0.000");
                }
            }
            return ((float)value).ToString("0.0");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return double.Parse(((float)value).ToString());
        }
    }

    public class FunctionToSelectedIndex : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int idx = int.Parse(value.ToString());
            if (idx < 0 || idx > 9) return 10;
            return idx;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int idx = int.Parse(value.ToString());
            if (idx < 0 || idx > 9) return 10;
            return (byte)idx;
        }
    }

    //public class IndexConverter : IValueConverter
    //{
    //    public object Convert(object value, Type TargetType, object parameter, CultureInfo culture)
    //    {
    //        ListViewItem item = (ListViewItem)value;
    //        ListView listView = ItemsControl.ItemsControlFromItemContainer(item) as ListView;
    //        int index = listView.ItemContainerGenerator.IndexFromContainer(item);
    //        if (parameter != null)
    //        {
    //            return "{0}_{1}".FormatA(parameter, (index + 1));
    //        }
    //        return (index + 1).ToString();
    //    }
    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class OvenPrgmToBoolConverter : IValueConverter
    //{
    //    public object Convert(object value, Type TargetType, object parameter, CultureInfo culture)
    //    {
    //        if (value == null) return true;
    //        if (value.GetType() == typeof(PacketOvenPrgm))
    //        {
    //            var t = (PacketOvenPrgm)value;
    //            if (t.FinalTime > 0 || t.FinalTemp > 0)
    //            {
    //                return true;
    //            }
    //            return false;
    //        }
    //        else if (value.GetType() == typeof(MVVM.ViewModels.TempPrgm))
    //        {
    //            var t = (MVVM.ViewModels.TempPrgm)value;
    //            if (t.FinalTemp == 0 && t.FinalTime == 0)
    //            {
    //                return false;
    //            }
    //            if (t.IDX > 0 && t.IDX < 25) return false;

    //            return true;
    //        }
    //        return true;
    //    }
    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}


    //public class RowNumberConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        ListBoxItem item = (ListBoxItem)value;
    //        ListBox listView = ItemsControl.ItemsControlFromItemContainer(item) as ListBox;
    //        int index = listView.ItemContainerGenerator.IndexFromContainer(item);
    //        if (parameter != null)
    //        {
    //            return string.Format("{0}_{1}", parameter, (index + 1));
    //        }
    //        return (index + 1).ToString();
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public class TimeFuncToTextVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type TargetType, object parameter, CultureInfo culture)
        {
            byte f = (byte)value;
            if (f == 0x10) return false;
            return true;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class OnOffConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            byte state = (byte)values[0];
            byte number = (byte)values[1];
            if (number == 0x08 || number == 0x09)
                return string.Format("{0}", (int)state);

            if (state == 0x00) return "OFF";
            return "ON";
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if ("ON".Equals(value)) return new object[] { 0x01, 0x00 };
            else if ("OFF".Equals(value)) return new object[] { 0x00, 0x00 };
            return new object[] { value, 0x00 };
            //throw new NotImplementedException();
        }
    }


}
