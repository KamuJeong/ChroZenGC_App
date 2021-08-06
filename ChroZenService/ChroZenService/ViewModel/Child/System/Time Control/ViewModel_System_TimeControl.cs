using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using static ChroZenService.ChroZenService_Const;
using static ChroZenService.ViewModel_System_TimeControl_TimeControlType;

namespace ChroZenService
{
    public class ViewModel_System_TimeControl : BindableNotifyBase
    {
        #region 생성자 & 이벤트 헨들러

        public ViewModel_System_TimeControl()
        {
            DefaultCommand = new RelayCommand(DefaultCommandAction);
            Navigation_UpCommand = new RelayCommand(Navigation_UpCommandAction);
            Navigation_DownCommand = new RelayCommand(Navigation_DownCommandAction);

            KeyPadApplyCommand = new RelayCommand(KeyPadApplyCommandAction);
            KeyPadCancelCommand = new RelayCommand(KeyPadCancelCommandAction);
            KeyPadDeleteCommand = new RelayCommand(KeyPadDeleteCommandAction);
            KeyPadKeyPadClickCommand = new RelayCommand(KeyPadKeyPadClickCommandAction);
            KeyPadOffCommand = new RelayCommand(KeyPadOffCommandAction);
            KeyPadOnCommand = new RelayCommand(KeyPadOnCommandAction);

            SetCommand = new RelayCommand(SetCommandAction);
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        public enum E_TIMECONTROL_FUNCTION
        {
            ALL_OFF,
            TEMP_OFF,
            FLOW_OFF,
            DET_OFF,
            METHOD,
            START,
            SET_OVEN,
            SYSTEM_START,
            SYSTEM_SLEEP,
            PROGRAM_END
        }
        #region TimeControl Table

        DateTime _dtDate_1;
        public DateTime dtDate_1 { get { return _dtDate_1; } set { if (_dtDate_1 != value) { _dtDate_1 = value; OnPropertyChanged("dtDate_1"); } } }

        TimeSpan _dtTime_1;
        public TimeSpan dtTime_1 { get { return _dtTime_1; } set { if (_dtTime_1 != value) { _dtTime_1 = value; OnPropertyChanged("dtTime_1"); } } }

        byte _btFunction_1;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_1 { get { return _btFunction_1; } set { if (_btFunction_1 != value) { _btFunction_1 = value; OnPropertyChanged("btFunction_1"); } } }

        float _fValue_1;
        public float fValue_1 { get { return _fValue_1; } set { if (_fValue_1 != value) { _fValue_1 = value; OnPropertyChanged("fValue_1"); } } }

        int _nIndex_1 = 1;
        public int nIndex_1 { get { return _nIndex_1; } set { if (_nIndex_1 != value) { _nIndex_1 = value; OnPropertyChanged("nIndex_1"); } } }

        DateTime _dtDate_2;
        public DateTime dtDate_2 { get { return _dtDate_2; } set { if (_dtDate_2 != value) { _dtDate_2 = value; OnPropertyChanged("dtDate_2"); } } }

        TimeSpan _dtTime_2;
        public TimeSpan dtTime_2 { get { return _dtTime_2; } set { if (_dtTime_2 != value) { _dtTime_2 = value; OnPropertyChanged("dtTime_2"); } } }

        byte _btFunction_2;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_2 { get { return _btFunction_2; } set { if (_btFunction_2 != value) { _btFunction_2 = value; OnPropertyChanged("btFunction_2"); } } }

        float _fValue_2;
        public float fValue_2 { get { return _fValue_2; } set { if (_fValue_2 != value) { _fValue_2 = value; OnPropertyChanged("fValue_2"); } } }

        int _nIndex_2 = 2;
        public int nIndex_2 { get { return _nIndex_2; } set { if (_nIndex_2 != value) { _nIndex_2 = value; OnPropertyChanged("nIndex_2"); } } }


        DateTime _dtDate_3;
        public DateTime dtDate_3 { get { return _dtDate_3; } set { if (_dtDate_3 != value) { _dtDate_3 = value; OnPropertyChanged("dtDate_3"); } } }

        TimeSpan _dtTime_3;
        public TimeSpan dtTime_3 { get { return _dtTime_3; } set { if (_dtTime_3 != value) { _dtTime_3 = value; OnPropertyChanged("dtTime_3"); } } }

        byte _btFunction_3;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_3 { get { return _btFunction_3; } set { if (_btFunction_3 != value) { _btFunction_3 = value; OnPropertyChanged("btFunction_3"); } } }

        float _fValue_3;
        public float fValue_3 { get { return _fValue_3; } set { if (_fValue_3 != value) { _fValue_3 = value; OnPropertyChanged("fValue_3"); } } }

        int _nIndex_3 = 3;
        public int nIndex_3 { get { return _nIndex_3; } set { if (_nIndex_3 != value) { _nIndex_3 = value; OnPropertyChanged("nIndex_3"); } } }


        DateTime _dtDate_4;
        public DateTime dtDate_4 { get { return _dtDate_4; } set { if (_dtDate_4 != value) { _dtDate_4 = value; OnPropertyChanged("dtDate_4"); } } }

        TimeSpan _dtTime_4;
        public TimeSpan dtTime_4 { get { return _dtTime_4; } set { if (_dtTime_4 != value) { _dtTime_4 = value; OnPropertyChanged("dtTime_4"); } } }

        byte _btFunction_4;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_4 { get { return _btFunction_4; } set { if (_btFunction_4 != value) { _btFunction_4 = value; OnPropertyChanged("btFunction_4"); } } }

        float _fValue_4;
        public float fValue_4 { get { return _fValue_4; } set { if (_fValue_4 != value) { _fValue_4 = value; OnPropertyChanged("fValue_4"); } } }

        int _nIndex_4 = 4;
        public int nIndex_4 { get { return _nIndex_4; } set { if (_nIndex_4 != value) { _nIndex_4 = value; OnPropertyChanged("nIndex_4"); } } }


        DateTime _dtDate_5;
        public DateTime dtDate_5 { get { return _dtDate_5; } set { if (_dtDate_5 != value) { _dtDate_5 = value; OnPropertyChanged("dtDate_5"); } } }

        TimeSpan _dtTime_5;
        public TimeSpan dtTime_5 { get { return _dtTime_5; } set { if (_dtTime_5 != value) { _dtTime_5 = value; OnPropertyChanged("dtTime_5"); } } }

        byte _btFunction_5;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_5 { get { return _btFunction_5; } set { if (_btFunction_5 != value) { _btFunction_5 = value; OnPropertyChanged("btFunction_5"); } } }

        float _fValue_5;
        public float fValue_5 { get { return _fValue_5; } set { if (_fValue_5 != value) { _fValue_5 = value; OnPropertyChanged("fValue_5"); } } }

        int _nIndex_5 = 5;
        public int nIndex_5 { get { return _nIndex_5; } set { if (_nIndex_5 != value) { _nIndex_5 = value; OnPropertyChanged("nIndex_5"); } } }


        DateTime _dtDate_6;
        public DateTime dtDate_6 { get { return _dtDate_6; } set { if (_dtDate_6 != value) { _dtDate_6 = value; OnPropertyChanged("dtDate_6"); } } }

        TimeSpan _dtTime_6;
        public TimeSpan dtTime_6 { get { return _dtTime_6; } set { if (_dtTime_6 != value) { _dtTime_6 = value; OnPropertyChanged("dtTime_6"); } } }

        byte _btFunction_6;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_6 { get { return _btFunction_6; } set { if (_btFunction_6 != value) { _btFunction_6 = value; OnPropertyChanged("btFunction_6"); } } }

        float _fValue_6;
        public float fValue_6 { get { return _fValue_6; } set { if (_fValue_6 != value) { _fValue_6 = value; OnPropertyChanged("fValue_6"); } } }

        int _nIndex_6 = 6;
        public int nIndex_6 { get { return _nIndex_6; } set { if (_nIndex_6 != value) { _nIndex_6 = value; OnPropertyChanged("nIndex_6"); } } }


        DateTime _dtDate_7;
        public DateTime dtDate_7 { get { return _dtDate_7; } set { if (_dtDate_7 != value) { _dtDate_7 = value; OnPropertyChanged("dtDate_7"); } } }

        TimeSpan _dtTime_7;
        public TimeSpan dtTime_7 { get { return _dtTime_7; } set { if (_dtTime_7 != value) { _dtTime_7 = value; OnPropertyChanged("dtTime_7"); } } }

        byte _btFunction_7;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_7 { get { return _btFunction_7; } set { if (_btFunction_7 != value) { _btFunction_7 = value; OnPropertyChanged("btFunction_7"); } } }

        float _fValue_7;
        public float fValue_7 { get { return _fValue_7; } set { if (_fValue_7 != value) { _fValue_7 = value; OnPropertyChanged("fValue_7"); } } }

        int _nIndex_7 = 7;
        public int nIndex_7 { get { return _nIndex_7; } set { if (_nIndex_7 != value) { _nIndex_7 = value; OnPropertyChanged("nIndex_7"); } } }


        DateTime _dtDate_8;
        public DateTime dtDate_8 { get { return _dtDate_8; } set { if (_dtDate_8 != value) { _dtDate_8 = value; OnPropertyChanged("dtDate_8"); } } }

        TimeSpan _dtTime_8;
        public TimeSpan dtTime_8 { get { return _dtTime_8; } set { if (_dtTime_8 != value) { _dtTime_8 = value; OnPropertyChanged("dtTime_8"); } } }

        byte _btFunction_8;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_8 { get { return _btFunction_8; } set { if (_btFunction_8 != value) { _btFunction_8 = value; OnPropertyChanged("btFunction_8"); } } }

        float _fValue_8;
        public float fValue_8 { get { return _fValue_8; } set { if (_fValue_8 != value) { _fValue_8 = value; OnPropertyChanged("fValue_8"); } } }

        int _nIndex_8 = 8;
        public int nIndex_8 { get { return _nIndex_8; } set { if (_nIndex_8 != value) { _nIndex_8 = value; OnPropertyChanged("nIndex_8"); } } }


        DateTime _dtDate_9;
        public DateTime dtDate_9 { get { return _dtDate_9; } set { if (_dtDate_9 != value) { _dtDate_9 = value; OnPropertyChanged("dtDate_9"); } } }

        TimeSpan _dtTime_9;
        public TimeSpan dtTime_9 { get { return _dtTime_9; } set { if (_dtTime_9 != value) { _dtTime_9 = value; OnPropertyChanged("dtTime_9"); } } }

        byte _btFunction_9;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_9 { get { return _btFunction_9; } set { if (_btFunction_9 != value) { _btFunction_9 = value; OnPropertyChanged("btFunction_9"); } } }

        float _fValue_9;
        public float fValue_9 { get { return _fValue_9; } set { if (_fValue_9 != value) { _fValue_9 = value; OnPropertyChanged("fValue_9"); } } }

        int _nIndex_9 = 9;
        public int nIndex_9 { get { return _nIndex_9; } set { if (_nIndex_9 != value) { _nIndex_9 = value; OnPropertyChanged("nIndex_9"); } } }


        DateTime _dtDate_10;
        public DateTime dtDate_10 { get { return _dtDate_10; } set { if (_dtDate_10 != value) { _dtDate_10 = value; OnPropertyChanged("dtDate_10"); } } }

        TimeSpan _dtTime_10;
        public TimeSpan dtTime_10 { get { return _dtTime_10; } set { if (_dtTime_10 != value) { _dtTime_10 = value; OnPropertyChanged("dtTime_10"); } } }

        byte _btFunction_10;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_10 { get { return _btFunction_10; } set { if (_btFunction_10 != value) { _btFunction_10 = value; OnPropertyChanged("btFunction_10"); } } }

        float _fValue_10;
        public float fValue_10 { get { return _fValue_10; } set { if (_fValue_10 != value) { _fValue_10 = value; OnPropertyChanged("fValue_10"); } } }

        int _nIndex_10 = 10;
        public int nIndex_10 { get { return _nIndex_10; } set { if (_nIndex_10 != value) { _nIndex_10 = value; OnPropertyChanged("nIndex_10"); } } }


        DateTime _dtDate_11;
        public DateTime dtDate_11 { get { return _dtDate_11; } set { if (_dtDate_11 != value) { _dtDate_11 = value; OnPropertyChanged("dtDate_11"); } } }

        TimeSpan _dtTime_11;
        public TimeSpan dtTime_11 { get { return _dtTime_11; } set { if (_dtTime_11 != value) { _dtTime_11 = value; OnPropertyChanged("dtTime_11"); } } }

        byte _btFunction_11;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_11 { get { return _btFunction_11; } set { if (_btFunction_11 != value) { _btFunction_11 = value; OnPropertyChanged("btFunction_11"); } } }

        float _fValue_11;
        public float fValue_11 { get { return _fValue_11; } set { if (_fValue_11 != value) { _fValue_11 = value; OnPropertyChanged("fValue_11"); } } }

        int _nIndex_11 = 11;
        public int nIndex_11 { get { return _nIndex_11; } set { if (_nIndex_11 != value) { _nIndex_11 = value; OnPropertyChanged("nIndex_11"); } } }


        DateTime _dtDate_12;
        public DateTime dtDate_12 { get { return _dtDate_12; } set { if (_dtDate_12 != value) { _dtDate_12 = value; OnPropertyChanged("dtDate_12"); } } }

        TimeSpan _dtTime_12;
        public TimeSpan dtTime_12 { get { return _dtTime_12; } set { if (_dtTime_12 != value) { _dtTime_12 = value; OnPropertyChanged("dtTime_12"); } } }

        byte _btFunction_12;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_12 { get { return _btFunction_12; } set { if (_btFunction_12 != value) { _btFunction_12 = value; OnPropertyChanged("btFunction_12"); } } }

        float _fValue_12;
        public float fValue_12 { get { return _fValue_12; } set { if (_fValue_12 != value) { _fValue_12 = value; OnPropertyChanged("fValue_12"); } } }

        int _nIndex_12 = 12;
        public int nIndex_12 { get { return _nIndex_12; } set { if (_nIndex_12 != value) { _nIndex_12 = value; OnPropertyChanged("nIndex_12"); } } }


        DateTime _dtDate_13;
        public DateTime dtDate_13 { get { return _dtDate_13; } set { if (_dtDate_13 != value) { _dtDate_13 = value; OnPropertyChanged("dtDate_13"); } } }

        TimeSpan _dtTime_13;
        public TimeSpan dtTime_13 { get { return _dtTime_13; } set { if (_dtTime_13 != value) { _dtTime_13 = value; OnPropertyChanged("dtTime_13"); } } }

        byte _btFunction_13;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_13 { get { return _btFunction_13; } set { if (_btFunction_13 != value) { _btFunction_13 = value; OnPropertyChanged("btFunction_13"); } } }

        float _fValue_13;
        public float fValue_13 { get { return _fValue_13; } set { if (_fValue_13 != value) { _fValue_13 = value; OnPropertyChanged("fValue_13"); } } }

        int _nIndex_13 = 13;
        public int nIndex_13 { get { return _nIndex_13; } set { if (_nIndex_13 != value) { _nIndex_13 = value; OnPropertyChanged("nIndex_13"); } } }


        DateTime _dtDate_14;
        public DateTime dtDate_14 { get { return _dtDate_14; } set { if (_dtDate_14 != value) { _dtDate_14 = value; OnPropertyChanged("dtDate_14"); } } }

        TimeSpan _dtTime_14;
        public TimeSpan dtTime_14 { get { return _dtTime_14; } set { if (_dtTime_14 != value) { _dtTime_14 = value; OnPropertyChanged("dtTime_14"); } } }

        byte _btFunction_14;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_14 { get { return _btFunction_14; } set { if (_btFunction_14 != value) { _btFunction_14 = value; OnPropertyChanged("btFunction_14"); } } }

        float _fValue_14;
        public float fValue_14 { get { return _fValue_14; } set { if (_fValue_14 != value) { _fValue_14 = value; OnPropertyChanged("fValue_14"); } } }

        int _nIndex_14 = 14;
        public int nIndex_14 { get { return _nIndex_14; } set { if (_nIndex_14 != value) { _nIndex_14 = value; OnPropertyChanged("nIndex_14"); } } }


        DateTime _dtDate_15;
        public DateTime dtDate_15 { get { return _dtDate_15; } set { if (_dtDate_15 != value) { _dtDate_15 = value; OnPropertyChanged("dtDate_15"); } } }

        TimeSpan _dtTime_15;
        public TimeSpan dtTime_15 { get { return _dtTime_15; } set { if (_dtTime_15 != value) { _dtTime_15 = value; OnPropertyChanged("dtTime_15"); } } }

        byte _btFunction_15;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_15 { get { return _btFunction_15; } set { if (_btFunction_15 != value) { _btFunction_15 = value; OnPropertyChanged("btFunction_15"); } } }

        float _fValue_15;
        public float fValue_15 { get { return _fValue_15; } set { if (_fValue_15 != value) { _fValue_15 = value; OnPropertyChanged("fValue_15"); } } }

        int _nIndex_15 = 15;
        public int nIndex_15 { get { return _nIndex_15; } set { if (_nIndex_15 != value) { _nIndex_15 = value; OnPropertyChanged("nIndex_15"); } } }


        DateTime _dtDate_16;
        public DateTime dtDate_16 { get { return _dtDate_16; } set { if (_dtDate_16 != value) { _dtDate_16 = value; OnPropertyChanged("dtDate_16"); } } }

        TimeSpan _dtTime_16;
        public TimeSpan dtTime_16 { get { return _dtTime_16; } set { if (_dtTime_16 != value) { _dtTime_16 = value; OnPropertyChanged("dtTime_16"); } } }

        byte _btFunction_16;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_16 { get { return _btFunction_16; } set { if (_btFunction_16 != value) { _btFunction_16 = value; OnPropertyChanged("btFunction_16"); } } }

        float _fValue_16;
        public float fValue_16 { get { return _fValue_16; } set { if (_fValue_16 != value) { _fValue_16 = value; OnPropertyChanged("fValue_16"); } } }

        int _nIndex_16 = 16;
        public int nIndex_16 { get { return _nIndex_16; } set { if (_nIndex_16 != value) { _nIndex_16 = value; OnPropertyChanged("nIndex_16"); } } }


        DateTime _dtDate_17;
        public DateTime dtDate_17 { get { return _dtDate_17; } set { if (_dtDate_17 != value) { _dtDate_17 = value; OnPropertyChanged("dtDate_17"); } } }

        TimeSpan _dtTime_17;
        public TimeSpan dtTime_17 { get { return _dtTime_17; } set { if (_dtTime_17 != value) { _dtTime_17 = value; OnPropertyChanged("dtTime_17"); } } }

        byte _btFunction_17;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_17 { get { return _btFunction_17; } set { if (_btFunction_17 != value) { _btFunction_17 = value; OnPropertyChanged("btFunction_17"); } } }

        float _fValue_17;
        public float fValue_17 { get { return _fValue_17; } set { if (_fValue_17 != value) { _fValue_17 = value; OnPropertyChanged("fValue_17"); } } }

        int _nIndex_17 = 17;
        public int nIndex_17 { get { return _nIndex_17; } set { if (_nIndex_17 != value) { _nIndex_17 = value; OnPropertyChanged("nIndex_17"); } } }


        DateTime _dtDate_18;
        public DateTime dtDate_18 { get { return _dtDate_18; } set { if (_dtDate_18 != value) { _dtDate_18 = value; OnPropertyChanged("dtDate_18"); } } }

        TimeSpan _dtTime_18;
        public TimeSpan dtTime_18 { get { return _dtTime_18; } set { if (_dtTime_18 != value) { _dtTime_18 = value; OnPropertyChanged("dtTime_18"); } } }

        byte _btFunction_18;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_18 { get { return _btFunction_18; } set { if (_btFunction_18 != value) { _btFunction_18 = value; OnPropertyChanged("btFunction_18"); } } }

        float _fValue_18;
        public float fValue_18 { get { return _fValue_18; } set { if (_fValue_18 != value) { _fValue_18 = value; OnPropertyChanged("fValue_18"); } } }

        int _nIndex_18 = 18;
        public int nIndex_18 { get { return _nIndex_18; } set { if (_nIndex_18 != value) { _nIndex_18 = value; OnPropertyChanged("nIndex_18"); } } }


        DateTime _dtDate_19;
        public DateTime dtDate_19 { get { return _dtDate_19; } set { if (_dtDate_19 != value) { _dtDate_19 = value; OnPropertyChanged("dtDate_19"); } } }

        TimeSpan _dtTime_19;
        public TimeSpan dtTime_19 { get { return _dtTime_19; } set { if (_dtTime_19 != value) { _dtTime_19 = value; OnPropertyChanged("dtTime_19"); } } }

        byte _btFunction_19;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_19 { get { return _btFunction_19; } set { if (_btFunction_19 != value) { _btFunction_19 = value; OnPropertyChanged("btFunction_19"); } } }

        float _fValue_19;
        public float fValue_19 { get { return _fValue_19; } set { if (_fValue_19 != value) { _fValue_19 = value; OnPropertyChanged("fValue_19"); } } }

        int _nIndex_19 = 19;
        public int nIndex_19 { get { return _nIndex_19; } set { if (_nIndex_19 != value) { _nIndex_19 = value; OnPropertyChanged("nIndex_19"); } } }


        DateTime _dtDate_20;
        public DateTime dtDate_20 { get { return _dtDate_20; } set { if (_dtDate_20 != value) { _dtDate_20 = value; OnPropertyChanged("dtDate_20"); } } }

        TimeSpan _dtTime_20;
        public TimeSpan dtTime_20 { get { return _dtTime_20; } set { if (_dtTime_20 != value) { _dtTime_20 = value; OnPropertyChanged("dtTime_20"); } } }

        byte _btFunction_20;
        /// <summary>
        /// 0~6 사용 -> 4 : Load Method 사용 안함 2020-12-22 정부장님 검토 사항
        /// </summary>
        public byte btFunction_20 { get { return _btFunction_20; } set { if (_btFunction_20 != value) { _btFunction_20 = value; OnPropertyChanged("btFunction_20"); } } }

        float _fValue_20;
        public float fValue_20 { get { return _fValue_20; } set { if (_fValue_20 != value) { _fValue_20 = value; OnPropertyChanged("fValue_20"); } } }

        int _nIndex_20 = 20;
        public int nIndex_20 { get { return _nIndex_20; } set { if (_nIndex_20 != value) { _nIndex_20 = value; OnPropertyChanged("nIndex_20"); } } }

        #endregion TimeControl Table

        #endregion Property

        #region Command

        #region KeyPad : CancelCommand

        public RelayCommand KeyPadCancelCommand { get; set; }
        private void KeyPadCancelCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModel_Main mainVM = (ViewModel_Main)sender.BindingContext;
            mainVM.ViewModel_KeyPad.IsKeyPadShown = false;
            //ViewModel_KeyPad vmKeyPad = new ViewModel_KeyPad
            //{
            //    IsKeyPadShown = false,
            //};
            //
        }

        #endregion KeyPad : CancelCommand

        #region KeyPad : DeleteCommand

        public RelayCommand KeyPadDeleteCommand { get; set; }
        private void KeyPadDeleteCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModel_Main mainVM = (ViewModel_Main)sender.BindingContext;

            if (mainVM.ViewModel_KeyPad.CurrentValue.Length > 0)
            {
                double tempVal;
                double.TryParse(mainVM.ViewModel_KeyPad.CurrentValue.Substring(0, mainVM.ViewModel_KeyPad.CurrentValue.Length - 1), out tempVal);
                Debug.WriteLine(string.Format("tempVal : {0}", tempVal));
                mainVM.ViewModel_KeyPad.CurrentValue = tempVal.ToString();
            }
            mainVM.ViewModel_KeyPad.IsNeedRefresh = false;
        }

        #endregion KeyPad : DeleteCommand

        #region KeyPad : ApplyCommand

        public RelayCommand KeyPadApplyCommand { get; set; }
        private void KeyPadApplyCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModel_Main mainVM = (ViewModel_Main)sender.BindingContext;

            //.시작 케이스
            if (mainVM.ViewModel_KeyPad.CurrentValue.Length > 0 && mainVM.ViewModel_KeyPad.CurrentValue[0] == '.')
            {
                double tempVal;
                double.TryParse("0" + mainVM.ViewModel_KeyPad.CurrentValue, out tempVal);
                if (tempVal <= mainVM.ViewModel_KeyPad.MaxValue)
                {
                    mainVM.ViewModel_KeyPad.CurrentValue = "0" + mainVM.ViewModel_KeyPad.CurrentValue;
                }
            }
            if (mainVM.ViewModel_KeyPad.CurrentValue.Length > 1 && mainVM.ViewModel_KeyPad.CurrentValue[0] == '-' &&
                mainVM.ViewModel_KeyPad.CurrentValue[0] == '.')
            {
                double tempVal;
                double.TryParse(mainVM.ViewModel_KeyPad.CurrentValue.Insert(1, "0"), out tempVal);
                if (tempVal <= mainVM.ViewModel_KeyPad.MaxValue)
                {
                    mainVM.ViewModel_KeyPad.CurrentValue = mainVM.ViewModel_KeyPad.CurrentValue.Insert(1, "0");
                }
            }
            float tempFloatVal = 0;
            if (float.TryParse(mainVM.ViewModel_KeyPad.CurrentValue, out tempFloatVal))
            {
                switch (mainVM.ViewModel_KeyPad.KEY_PAD_SET_MEASURE_TYPE)
                {
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_1:
                        {
                            dtDate_1 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_1:
                        {
                            dtTime_1 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_1:
                        {
                            fValue_1 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_2:
                        {
                            dtDate_2 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_2:
                        {
                            dtTime_2 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_2:
                        {
                            fValue_2 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_3:
                        {
                            dtDate_3 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_3:
                        {
                            dtTime_3 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_3:
                        {
                            fValue_3 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_4:
                        {
                            dtDate_4 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_4:
                        {
                            dtTime_4 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_4:
                        {
                            fValue_4 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_5:
                        {
                            dtDate_5 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_5:
                        {
                            dtTime_5 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_5:
                        {
                            fValue_5 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_6:
                        {
                            dtDate_6 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_6:
                        {
                            dtTime_6 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_6:
                        {
                            fValue_6 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_7:
                        {
                            dtDate_7 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_7:
                        {
                            dtTime_7 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_7:
                        {
                            fValue_7 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_8:
                        {
                            dtDate_8 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_8:
                        {
                            dtTime_8 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_8:
                        {
                            fValue_8 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_9:
                        {
                            dtDate_9 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_9:
                        {
                            dtTime_9 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_9:
                        {
                            fValue_9 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_10:
                        {
                            dtDate_10 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_10:
                        {
                            dtTime_10 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_10:
                        {
                            fValue_10 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_11:
                        {
                            dtDate_11 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_11:
                        {
                            dtTime_11 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_11:
                        {
                            fValue_11 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_12:
                        {
                            dtDate_12 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_12:
                        {
                            dtTime_12 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_12:
                        {
                            fValue_12 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_13:
                        {
                            dtDate_13 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_13:
                        {
                            dtTime_13 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_13:
                        {
                            fValue_13 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_14:
                        {
                            dtDate_14 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_14:
                        {
                            dtTime_14 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_14:
                        {
                            fValue_14 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_15:
                        {
                            dtDate_15 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_15:
                        {
                            dtTime_15 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_15:
                        {
                            fValue_15 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_16:
                        {
                            dtDate_16 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_16:
                        {
                            dtTime_16 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_16:
                        {
                            fValue_16 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_17:
                        {
                            dtDate_17 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_17:
                        {
                            dtTime_17 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_17:
                        {
                            fValue_17 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_18:
                        {
                            dtDate_18 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_18:
                        {
                            dtTime_18 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_18:
                        {
                            fValue_18 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_19:
                        {
                            dtDate_19 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_19:
                        {
                            dtTime_19 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_19:
                        {
                            fValue_19 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;

                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_20:
                        {
                            dtDate_20 = YC_Util.StringToDate(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_20:
                        {
                            dtTime_20 = YC_Util.StringToTime(mainVM.ViewModel_KeyPad.CurrentValue);
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                    case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_20:
                        {
                            fValue_20 = (byte)tempFloatVal;
                            //DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1.inletPacket.t_YL6700GC_TEMP_CALIB_VALUE.fSet[0] = tempFloatVal;
                        }
                        break;
                }
            }

            mainVM.ViewModel_KeyPad.IsKeyPadShown = false;

            //ViewModel_KeyPad vmKeyPad = new ViewModel_KeyPad
            //{
            //    IsKeyPadShown = false,
            //};
            //
        }

        #endregion KeyPad : ApplyCommand

        #region KeyPad : OnCommand

        public RelayCommand KeyPadOnCommand { get; set; }
        private void KeyPadOnCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModel_Main mainVM = (ViewModel_Main)sender.BindingContext;
        }

        #endregion KeyPad : OnCommand

        #region KeyPad : OffCommand

        public RelayCommand KeyPadOffCommand { get; set; }
        private void KeyPadOffCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModel_Main mainVM = (ViewModel_Main)sender.BindingContext;
        }

        #endregion KeyPad : OffCommand

        #region KeyPad : KeyPadClickCommand

        public RelayCommand KeyPadKeyPadClickCommand { get; set; }
        private void KeyPadKeyPadClickCommandAction(object param)
        {
            Button sender = (param as Button);
            ViewModel_Main mainVM = (ViewModel_Main)sender.BindingContext;
            if (mainVM.ViewModel_KeyPad.IsNeedRefresh)
            {
                mainVM.ViewModel_KeyPad.CurrentValue = "";
                mainVM.ViewModel_KeyPad.IsNeedRefresh = false;
            }

            switch (sender.Text)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    {
                        //.시작 케이스
                        if (mainVM.ViewModel_KeyPad.CurrentValue.Length > 0 && mainVM.ViewModel_KeyPad.CurrentValue[0] == '.')
                        {
                            double tempVal;
                            double.TryParse("0" + mainVM.ViewModel_KeyPad.CurrentValue, out tempVal);
                            if (tempVal <= mainVM.ViewModel_KeyPad.MaxValue)
                            {
                                mainVM.ViewModel_KeyPad.CurrentValue += sender.Text;
                            }
                        }
                        else if (mainVM.ViewModel_KeyPad.CurrentValue.Length > 1 && mainVM.ViewModel_KeyPad.CurrentValue[0] == '-' &&
                            mainVM.ViewModel_KeyPad.CurrentValue[1] == '.')
                        {
                            double tempVal;
                            double.TryParse(mainVM.ViewModel_KeyPad.CurrentValue.Insert(1, "0"), out tempVal);
                            if (tempVal <= mainVM.ViewModel_KeyPad.MaxValue)
                            {
                                mainVM.ViewModel_KeyPad.CurrentValue += sender.Text;
                            }
                        }
                        else if (mainVM.ViewModel_KeyPad.CurrentValue == "0") //20210407 권민경: 기존값이 0일때 0 지우기
                        {
                            double tempVal;
                            double.TryParse(mainVM.ViewModel_KeyPad.CurrentValue + sender.Text, out tempVal);
                            if (tempVal <= mainVM.ViewModel_KeyPad.MaxValue)
                            {
                                mainVM.ViewModel_KeyPad.CurrentValue = sender.Text;
                            }
                        }
                        else
                        {
                            double tempVal;
                            double.TryParse(mainVM.ViewModel_KeyPad.CurrentValue + sender.Text, out tempVal);
                            if (tempVal <= mainVM.ViewModel_KeyPad.MaxValue)
                            {
                                mainVM.ViewModel_KeyPad.CurrentValue += sender.Text;
                            }
                        }
                    }
                    break;
                case ".":
                    {
                        if (!mainVM.ViewModel_KeyPad.CurrentValue.Contains("."))
                        {
                            mainVM.ViewModel_KeyPad.CurrentValue += sender.Text;
                        }
                    }
                    break;
                case "-/+":
                    {
                        if (!mainVM.ViewModel_KeyPad.CurrentValue.Contains("-"))
                        {
                            mainVM.ViewModel_KeyPad.CurrentValue = "-" + mainVM.ViewModel_KeyPad.CurrentValue;
                        }
                    }
                    break;

            }
        }

        #endregion KeyPad : KeyPadClickCommand

        #region DefaultCommand
        public RelayCommand DefaultCommand { get; set; }
        private void DefaultCommandAction(object param)
        {
            //TODO :             
            Debug.WriteLine("DefaultCommand Fired");
        }
        #endregion DefaultCommand 

        #region Navigation_UpCommand
        public RelayCommand Navigation_UpCommand { get; set; }
        private void Navigation_UpCommandAction(object param)
        {
            //TODO :             
            Debug.WriteLine("Navigation_UpCommand Fired");
        }
        #endregion Navigation_UpCommand 

        #region Navigation_DownCommand
        public RelayCommand Navigation_DownCommand { get; set; }
        private void Navigation_DownCommandAction(object param)
        {
            //TODO :             
            Debug.WriteLine("Navigation_DownCommand Fired");
        }
        #endregion Navigation_DownCommand 

        #region SetCommand
        public RelayCommand SetCommand { get; set; }
        private void SetCommandAction(object param)
        {
            ViewModel_KeyPad vmKeyPad = new ViewModel_KeyPad
            {
                IsKeyPadShown = true,
                KeyPadType = KeyPad.E_KEYPAD_TYPE.DOUBLE,
                MinValue = 0,
                CancelCommand = KeyPadCancelCommand,
                ApplyCommand = KeyPadApplyCommand,
                DeleteCommand = KeyPadDeleteCommand,
                OnCommand = KeyPadOnCommand,
                OffCommand = KeyPadOffCommand,
                KeyPadClickCommand = KeyPadKeyPadClickCommand,
            };

            switch ((E_KEY_PAD_SET_MEASURE_TYPE)param)
            {
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_1:
                    {
                        vmKeyPad.Title = "Date 1";
                        vmKeyPad.CurrentValue = dtDate_1.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_1:
                    {
                        vmKeyPad.Title = "Time 1";
                        vmKeyPad.CurrentValue = dtTime_1.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_1;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_1:
                    {
                        vmKeyPad.Title = "Val 1";
                        vmKeyPad.CurrentValue = fValue_1.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_1)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_1;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_2:
                    {
                        vmKeyPad.Title = "Date 2";
                        vmKeyPad.CurrentValue = dtDate_2.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_2:
                    {
                        vmKeyPad.Title = "Time 2";
                        vmKeyPad.CurrentValue = dtTime_2.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_2;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_2:
                    {
                        vmKeyPad.Title = "Val 2";
                        vmKeyPad.CurrentValue = fValue_2.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_2)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_2;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_3:
                    {
                        vmKeyPad.Title = "Date 3";
                        vmKeyPad.CurrentValue = dtDate_3.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_3:
                    {
                        vmKeyPad.Title = "Time 3";
                        vmKeyPad.CurrentValue = dtTime_3.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_3;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_3:
                    {
                        vmKeyPad.Title = "Val 3";
                        vmKeyPad.CurrentValue = fValue_3.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_3)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_3;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_4:
                    {
                        vmKeyPad.Title = "Date 4";
                        vmKeyPad.CurrentValue = dtDate_4.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_4:
                    {
                        vmKeyPad.Title = "Time 4";
                        vmKeyPad.CurrentValue = dtTime_4.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_4;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_4:
                    {
                        vmKeyPad.Title = "Val 4";
                        vmKeyPad.CurrentValue = fValue_4.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_4)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_4;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_5:
                    {
                        vmKeyPad.Title = "Date 5";
                        vmKeyPad.CurrentValue = dtDate_5.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_5:
                    {
                        vmKeyPad.Title = "Time 5";
                        vmKeyPad.CurrentValue = dtTime_5.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_5;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_5:
                    {
                        vmKeyPad.Title = "Val 5";
                        vmKeyPad.CurrentValue = fValue_5.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_5)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_5;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_6:
                    {
                        vmKeyPad.Title = "Date 6";
                        vmKeyPad.CurrentValue = dtDate_6.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_6:
                    {
                        vmKeyPad.Title = "Time 6";
                        vmKeyPad.CurrentValue = dtTime_6.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_6;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_6:
                    {
                        vmKeyPad.Title = "Val 6";
                        vmKeyPad.CurrentValue = fValue_6.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_6)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_6;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_7:
                    {
                        vmKeyPad.Title = "Date 7";
                        vmKeyPad.CurrentValue = dtDate_7.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_7;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_7:
                    {
                        vmKeyPad.Title = "Time 7";
                        vmKeyPad.CurrentValue = dtTime_7.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_7;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_7:
                    {
                        vmKeyPad.Title = "Val 7";
                        vmKeyPad.CurrentValue = fValue_7.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_7)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_7;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_8:
                    {
                        vmKeyPad.Title = "Date 8";
                        vmKeyPad.CurrentValue = dtDate_8.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_8;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_8:
                    {
                        vmKeyPad.Title = "Time 8";
                        vmKeyPad.CurrentValue = dtTime_8.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_8;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_8:
                    {
                        vmKeyPad.Title = "Val 8";
                        vmKeyPad.CurrentValue = fValue_8.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_8)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_8;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_9:
                    {
                        vmKeyPad.Title = "Date 9";
                        vmKeyPad.CurrentValue = dtDate_9.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_9;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_9:
                    {
                        vmKeyPad.Title = "Time 9";
                        vmKeyPad.CurrentValue = dtTime_9.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_9;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_9:
                    {
                        vmKeyPad.Title = "Val 9";
                        vmKeyPad.CurrentValue = fValue_9.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_9)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_9;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_10:
                    {
                        vmKeyPad.Title = "Date 10";
                        vmKeyPad.CurrentValue = dtDate_10.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_10;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_10:
                    {
                        vmKeyPad.Title = "Time 10";
                        vmKeyPad.CurrentValue = dtTime_10.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_10;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_10:
                    {
                        vmKeyPad.Title = "Val 10";
                        vmKeyPad.CurrentValue = fValue_10.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_10)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_10;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_11:
                    {
                        vmKeyPad.Title = "Date 11";
                        vmKeyPad.CurrentValue = dtDate_11.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_11;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_11:
                    {
                        vmKeyPad.Title = "Time 11";
                        vmKeyPad.CurrentValue = dtTime_11.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_11;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_11:
                    {
                        vmKeyPad.Title = "Val 11";
                        vmKeyPad.CurrentValue = fValue_11.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_11)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_11;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_12:
                    {
                        vmKeyPad.Title = "Date 12";
                        vmKeyPad.CurrentValue = dtDate_12.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_12;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_12:
                    {
                        vmKeyPad.Title = "Time 12";
                        vmKeyPad.CurrentValue = dtTime_12.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_12;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_12:
                    {
                        vmKeyPad.Title = "Val 12";
                        vmKeyPad.CurrentValue = fValue_12.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_12)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_12;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_13:
                    {
                        vmKeyPad.Title = "Date 13";
                        vmKeyPad.CurrentValue = dtDate_13.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_13;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_13:
                    {
                        vmKeyPad.Title = "Time 13";
                        vmKeyPad.CurrentValue = dtTime_13.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_13;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_13:
                    {
                        vmKeyPad.Title = "Val 13";
                        vmKeyPad.CurrentValue = fValue_13.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_13)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_13;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_14:
                    {
                        vmKeyPad.Title = "Date 14";
                        vmKeyPad.CurrentValue = dtDate_14.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_14;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_14:
                    {
                        vmKeyPad.Title = "Time 14";
                        vmKeyPad.CurrentValue = dtTime_14.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_14;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_14:
                    {
                        vmKeyPad.Title = "Val 14";
                        vmKeyPad.CurrentValue = fValue_14.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_14)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_14;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_15:
                    {
                        vmKeyPad.Title = "Date 15";
                        vmKeyPad.CurrentValue = dtDate_15.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_15;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_15:
                    {
                        vmKeyPad.Title = "Time 15";
                        vmKeyPad.CurrentValue = dtTime_15.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_15;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_15:
                    {
                        vmKeyPad.Title = "Val 15";
                        vmKeyPad.CurrentValue = fValue_15.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_15)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_15;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_16:
                    {
                        vmKeyPad.Title = "Date 16";
                        vmKeyPad.CurrentValue = dtDate_16.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_16;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_16:
                    {
                        vmKeyPad.Title = "Time 16";
                        vmKeyPad.CurrentValue = dtTime_16.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_16;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_16:
                    {
                        vmKeyPad.Title = "Val 16";
                        vmKeyPad.CurrentValue = fValue_16.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_16)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_16;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_17:
                    {
                        vmKeyPad.Title = "Date 17";
                        vmKeyPad.CurrentValue = dtDate_17.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_17;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_17:
                    {
                        vmKeyPad.Title = "Time 17";
                        vmKeyPad.CurrentValue = dtTime_17.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_17;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_17:
                    {
                        vmKeyPad.Title = "Val 17";
                        vmKeyPad.CurrentValue = fValue_17.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_17)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_17;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_18:
                    {
                        vmKeyPad.Title = "Date 18";
                        vmKeyPad.CurrentValue = dtDate_18.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_18;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_18:
                    {
                        vmKeyPad.Title = "Time 18";
                        vmKeyPad.CurrentValue = dtTime_18.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_18;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_18:
                    {
                        vmKeyPad.Title = "Val 18";
                        vmKeyPad.CurrentValue = fValue_18.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_18)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_18;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_19:
                    {
                        vmKeyPad.Title = "Date 19";
                        vmKeyPad.CurrentValue = dtDate_19.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_19;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_19:
                    {
                        vmKeyPad.Title = "Time 19";
                        vmKeyPad.CurrentValue = dtTime_19.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_19;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_19:
                    {
                        vmKeyPad.Title = "Val 19";
                        vmKeyPad.CurrentValue = fValue_19.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_19)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_19;
                    }
                    break;

                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_20:
                    {
                        vmKeyPad.Title = "Date 20";
                        vmKeyPad.CurrentValue = dtDate_20.ToString("yyyyMMdd");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_DATE_20;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_20:
                    {
                        vmKeyPad.Title = "Time 20";
                        vmKeyPad.CurrentValue = dtTime_20.ToString("hhmm");
                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_TIME_20;
                    }
                    break;
                case E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_20:
                    {
                        vmKeyPad.Title = "Val 20";
                        vmKeyPad.CurrentValue = fValue_20.ToString();
                        switch ((E_TIMECONTROL_FUNCTION)btFunction_20)
                        {
                            case E_TIMECONTROL_FUNCTION.SET_OVEN:
                                {
                                    vmKeyPad.MaxValue = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING.packet.fMaxTemp;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.METHOD:
                                {
                                    vmKeyPad.MaxValue = 20;
                                }
                                break;
                            case E_TIMECONTROL_FUNCTION.START:
                                {
                                    vmKeyPad.MaxValue = 9999;
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }

                        vmKeyPad.KEY_PAD_SET_MEASURE_TYPE = E_KEY_PAD_SET_MEASURE_TYPE.TIMECONTROL_VAL_20;
                    }
                    break;

            }


            //TODO :             
            Debug.WriteLine("SetCommand Fired");
        }
        #endregion SetCommand 

        #endregion Command

        #endregion Binding

        #region Instance Func

        #endregion Instance Func
    }
}
