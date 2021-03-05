using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using static ChroZenService.ChroZenService_Const;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_SYSTEM_CONFIG;
using static YC_ChroZenGC_Type.T_CHROZEN_INLET;

namespace ChroZenService
{
    public class E_DET_TYPEToAutoZeroUIHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is E_DET_TYPE)
            {
                switch ((E_DET_TYPE)(value))
                {

                    case E_DET_TYPE.FID:
                    case E_DET_TYPE.FPD:
                    case E_DET_TYPE.NPD:
                    case E_DET_TYPE.PFPD:
                        {
                            return Application.Current.Resources["HEIGHT_DET_CONFIG_GROUP_4ROW"];
                        }
                    case E_DET_TYPE.TCD:
                    case E_DET_TYPE.uTCD:
                    case E_DET_TYPE.ECD:
                    case E_DET_TYPE.uECD:
                    case E_DET_TYPE.PDD:
                    default:
                        return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class E_DET_TYPEToAutoZeroUIIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is E_DET_TYPE)
            {
                switch ((E_DET_TYPE)(value))
                {

                    case E_DET_TYPE.FID:
                    case E_DET_TYPE.FPD:
                    case E_DET_TYPE.NPD:
                    case E_DET_TYPE.PFPD:
                        {
                            return 2;
                        }
                    case E_DET_TYPE.TCD:
                    case E_DET_TYPE.uTCD:
                    case E_DET_TYPE.ECD:
                    case E_DET_TYPE.uECD:
                    case E_DET_TYPE.PDD:
                    default:
                        return 1;
                }
            }
            else
            {
                return 1;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class E_DET_TYPEToDetConfigIgniteUIVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is E_DET_TYPE)
            {
                switch ((E_DET_TYPE)(value))
                {
                    
                    case E_DET_TYPE.FID:
                    case E_DET_TYPE.FPD:
                    case E_DET_TYPE.NPD:
                    case E_DET_TYPE.PFPD:
                        {
                            return true;
                        }
                    case E_DET_TYPE.TCD:
                    case E_DET_TYPE.uTCD:
                    case E_DET_TYPE.ECD:
                    case E_DET_TYPE.uECD:
                    case E_DET_TYPE.PDD:                    
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DET_CONFIG_PickerIndexToiSignalRangeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((int)value)
            {
                case -10:
                    {
                        return 0;
                    }                    
                case -9:
                    {
                        return 1;
                    }                    
                case -8:
                    {
                        return 2;
                    }                    
                case -7:
                    {
                        return 3;
                    }                    
                case -6:
                    {
                        return 4;
                    }                    
                case -5:
                    {
                        return 5;
                    }                    
                case -4:
                    {
                        return 6;
                    }                    
                case -3:
                    {
                        return 7;
                    }                    
                case -2:
                    {
                        return 8;
                    }                    
                case -1:
                    {
                        return 9;
                    }                    
                case 0:
                    {
                        return 10;
                    }                    
                case 1:
                    {
                        return 11;
                    }                    
                case 2:
                    {
                        return 12;
                    }                    
                case 3:
                    {
                        return 13;
                    }                    
                case 4:
                    {
                        return 14;
                    }                    
                case 5:
                    {
                        return 15;
                    }                    
                case 6:
                    {
                        return 16;
                    }                    
                case 7:
                    {
                        return 17;
                    }                    
                case 8:
                    {
                        return 18;
                    }                    
                case 9:
                    {
                        return 19;
                    }                    
                case 10:
                    {
                        return 20;
                    }
                default:
                    {
                        return 0;
                    }
            }            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((int)value)
            {
                case 0:
                    {
                        return -10;
                    }
                case 1:
                    {
                        return -9;
                    }
                case 2:
                    {
                        return -8;
                    }
                case 3:
                    {
                        return -7;
                    }
                case 4:
                    {
                        return -6;
                    }
                case 5:
                    {
                        return -5;
                    }
                case 6:
                    {
                        return -4;
                    }
                case 7:
                    {
                        return -3;
                    }
                case 8:
                    {
                        return -2;
                    }
                case 9:
                    {
                        return -1;
                    }
                case 10:
                    {
                        return 0;
                    }
                case 11:
                    {
                        return 1;
                    }
                case 12:
                    {
                        return 2;
                    }
                case 13:
                    {
                        return 3;
                    }
                case 14:
                    {
                        return 4;
                    }
                case 15:
                    {
                        return 5;
                    }
                case 16:
                    {
                        return 6;
                    }
                case 17:
                    {
                        return 7;
                    }
                case 18:
                    {
                        return 8;
                    }
                case 19:
                    {
                        return 9;
                    }
                case 20:
                    {
                        return 10;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }
    }

    public class E_INLET_TYPEToOnColumnOrPackedUIVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is E_INLET_TYPE)
            {
                switch ((E_INLET_TYPE)(value))
                {
                    case E_INLET_TYPE.On_Column:
                    case E_INLET_TYPE.Packed:
                        return true;
                    case E_INLET_TYPE.Not_Installed:
                    case E_INLET_TYPE.Capillary:                    
                        return false;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class E_INLET_TYPEToCapillaryOrOnColumnVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is E_INLET_TYPE)
            {
                switch ((E_INLET_TYPE)(value))
                {
                    case E_INLET_TYPE.Capillary:
                    case E_INLET_TYPE.On_Column:
                        return true;
                    case E_INLET_TYPE.Not_Installed:                    
                    case E_INLET_TYPE.Packed:
                        return false;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class E_INLET_TYPEToPressureGroupUIIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is E_INLET_TYPE)
            {
                switch ((E_INLET_TYPE)(value))
                {
                    case E_INLET_TYPE.On_Column:
                        return 4;
                    case E_INLET_TYPE.Not_Installed:
                    case E_INLET_TYPE.Capillary:
                    case E_INLET_TYPE.Packed:
                        return 5;
                    default:
                        return 5;
                }
            }
            else
            {
                return 5;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class E_INLET_TEMP_MODEToTemperatureTableEnableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is E_INLET_TEMP_MODE)
            {
                switch ((E_INLET_TEMP_MODE)(value))
                {
                    case E_INLET_TEMP_MODE.PROGRAM:
                        return true;
                    case E_INLET_TEMP_MODE.ISO_THERMAL:
                    case E_INLET_TEMP_MODE.TRACK_OVEN:
                        return false;
                    default:
                        return false;                }
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class E_INLET_TYPEToOnColumnUIVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is E_INLET_TYPE)
            {
                switch ((E_INLET_TYPE)(value))
                {
                    case E_INLET_TYPE.On_Column:
                        return true;
                    case E_INLET_TYPE.Not_Installed:
                    case E_INLET_TYPE.Capillary:
                    case E_INLET_TYPE.Packed:
                        return false;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class E_INLET_TYPEToCapillaryUIVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is E_INLET_TYPE)
            {
                switch ((E_INLET_TYPE)(value))
                {
                    case E_INLET_TYPE.Capillary:
                        return true;
                    case E_INLET_TYPE.Not_Installed:
                    case E_INLET_TYPE.On_Column:
                    case E_INLET_TYPE.Packed:
                        return false;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class E_INLET_TYPEToPackedUIVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is E_INLET_TYPE)
            {
                switch ((E_INLET_TYPE)(value))
                {
                    case E_INLET_TYPE.Packed:
                        return true;
                    case E_INLET_TYPE.Not_Installed:
                    case E_INLET_TYPE.On_Column:
                    case E_INLET_TYPE.Capillary:

                        return false;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class ApcModeToFlowTableEnableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                switch ((E_INLET_APC_MODE)((byte)value))
                {
                    case E_INLET_APC_MODE.PROGRAMMED_FLOW:
                        return true;
                    case E_INLET_APC_MODE.CONSTANT_FLOW:
                    case E_INLET_APC_MODE.CONSTANT_PRESSURE:
                    case E_INLET_APC_MODE.PROGRAMMED_PRESSURE:
                        return false;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ApcModeToPressureTableEnableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                switch ((E_INLET_APC_MODE)((byte)value))
                {
                    case E_INLET_APC_MODE.CONSTANT_FLOW:
                    case E_INLET_APC_MODE.PROGRAMMED_FLOW:
                    case E_INLET_APC_MODE.CONSTANT_PRESSURE:
                        return false;
                    case E_INLET_APC_MODE.PROGRAMMED_PRESSURE:
                        return true;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ApcModeToPressureTableVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                switch ((E_INLET_APC_MODE)((byte)value))
                {
                    case E_INLET_APC_MODE.CONSTANT_FLOW:
                    case E_INLET_APC_MODE.PROGRAMMED_FLOW:
                        return false;
                    case E_INLET_APC_MODE.CONSTANT_PRESSURE:
                    case E_INLET_APC_MODE.PROGRAMMED_PRESSURE:
                        return true;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ApcModeToFlowTableVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                switch ((E_INLET_APC_MODE)((byte)value))
                {
                    case E_INLET_APC_MODE.CONSTANT_FLOW:
                    case E_INLET_APC_MODE.PROGRAMMED_FLOW:
                        return true;
                    case E_INLET_APC_MODE.CONSTANT_PRESSURE:
                    case E_INLET_APC_MODE.PROGRAMMED_PRESSURE:
                        return false;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class ApcModeToFlowSetAvailableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                switch ((E_INLET_APC_MODE)((byte)value))
                {
                    case E_INLET_APC_MODE.CONSTANT_FLOW:
                    case E_INLET_APC_MODE.PROGRAMMED_FLOW:
                        return true;
                    case E_INLET_APC_MODE.CONSTANT_PRESSURE:
                    case E_INLET_APC_MODE.PROGRAMMED_PRESSURE:
                        return false;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ApcModeToPressureSetAvailableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                switch ((E_INLET_APC_MODE)((byte)value))
                {
                    case E_INLET_APC_MODE.CONSTANT_FLOW:
                    case E_INLET_APC_MODE.PROGRAMMED_FLOW:
                        return false;
                    case E_INLET_APC_MODE.CONSTANT_PRESSURE:
                    case E_INLET_APC_MODE.PROGRAMMED_PRESSURE:
                        return true;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class bMethanizerToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                switch ((E_METHANIZER)((byte)value))
                {
                    case E_METHANIZER.Valve:
                        return "Valve";
                    case E_METHANIZER.Methanizer:
                        return "Methanizer";
                    case E_METHANIZER.TransferLine:
                        return "Transfer line";
                    default:
                        return "--";
                }
            }
            else
            {
                return "OFF";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ValveProgramSelectedIndexToParameterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as SelectedItemChangedEventArgs;
            var strIndex = eventArgs.SelectedItem as string;

            return new Tuple<string, E_GLOBAL_COMMAND_TYPE>(strIndex, (E_GLOBAL_COMMAND_TYPE)parameter);

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ValveProgramStateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if ((byte)value > 0)
                {
                    return "ON";
                }
                else return "OFF";
            }
            else
            {
                return "OFF";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ValveInitialStateToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if ((byte)value > 0)
                {
                    return true;
                }
                else return false;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToSettingInputBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if ((bool)value)
                {
                    return Application.Current.Resources["LGB_CONTROL_SYSTEM_EDITOR_BACKGROUND_BLUE_0"];
                }
                else return Application.Current.Resources["SCB_CONTROL_SYSTEM_EDITOR_BACKGROUND_GRAY_0"];
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToAuxTempInstallConditionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int tempVal;
            if (value != null)
            {
                if (int.TryParse(value.ToString(), out tempVal))
                {
                    if (tempVal != 0)
                    {
                        return "Installed";
                    }
                    else return "Not installed";
                }
                else return "Not installed";
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class DetTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                switch ((E_DET_TYPE)value)
                {
                    case E_DET_TYPE.ECD:
                    case E_DET_TYPE.FID:
                    case E_DET_TYPE.FPD:
                    case E_DET_TYPE.Not_Installed:
                    case E_DET_TYPE.NPD:
                    case E_DET_TYPE.PDD:
                    case E_DET_TYPE.PFPD:
                    case E_DET_TYPE.TCD:
                    case E_DET_TYPE.uECD:
                    case E_DET_TYPE.uTCD:
                        {
                            return ((E_DET_TYPE)value).ToString().Replace("_", " ");
                        }
                    default:
                        {
                            E_DET_TYPE.Not_Installed.ToString().Replace("_", " ");
                        }
                        break;
                }
                return E_DET_TYPE.Not_Installed.ToString().Replace("_", " ");

            }
            else
            {
                return E_DET_TYPE.Not_Installed.ToString().Replace("_", " ");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class InletTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is E_INLET_TYPE)
            {
                switch ((E_INLET_TYPE)value)
                {
                    case E_INLET_TYPE.Capillary:
                    case E_INLET_TYPE.Not_Installed:
                    case E_INLET_TYPE.On_Column:
                    case E_INLET_TYPE.Packed:
                        {
                            return ((E_INLET_TYPE)value).ToString().Replace("_", " ");
                        }
                    default:
                        {
                            E_INLET_TYPE.Not_Installed.ToString().Replace("_", " ");
                        }
                        break;
                }
                return E_INLET_TYPE.Not_Installed.ToString().Replace("_", " ");

            }
            else
            {
                return E_INLET_TYPE.Not_Installed.ToString().Replace("_", " ");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class E_INLET_TYPEToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is E_INLET_TYPE)
            {
                if ((E_INLET_TYPE)value == E_INLET_TYPE.Not_Installed) return false;
                else return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class E_DET_TYPEToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is E_DET_TYPE)
            {
                if ((E_DET_TYPE)value == E_DET_TYPE.Not_Installed) return false;
                else return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolReverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return !(bool)value;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class E_SYSTEM_SUB_MENU_TYPEToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is E_SYSTEM_SUB_MENU_TYPE)
            {
                if ((E_SYSTEM_SUB_MENU_TYPE)value == (E_SYSTEM_SUB_MENU_TYPE)parameter) return true;
                else return false;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class E_SYSTEM_MENU_TYPEToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is E_SYSTEM_MENU_TYPE)
            {
                if ((E_SYSTEM_MENU_TYPE)value == (E_SYSTEM_MENU_TYPE)parameter) return true;
                else return false;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class E_CONFIG_SUB_MENU_TYPEToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is E_CONFIG_SUB_MENU_TYPE)
            {
                if ((E_CONFIG_SUB_MENU_TYPE)value == (E_CONFIG_SUB_MENU_TYPE)parameter) return true;
                else return false;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class E_CONFIG_MENU_TYPEToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is E_CONFIG_MENU_TYPE)
            {
                if ((E_CONFIG_MENU_TYPE)value == (E_CONFIG_MENU_TYPE)parameter) return true;
                else return false;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class InletTypeToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                switch (value)
                {
                    case "Capillary":
                        {
                            return true;
                        }
                    default:
                        {
                            return false;
                        }
                }
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DoubleToGridLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                return new GridLength((double)parameter);
            }
            else
            {
                return new GridLength(0);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

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
                if (int.Parse(value.ToString()) == 1) return true;
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
