using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ChroZenService
{
    /// <summary>
    /// 保存ファイルはLog_20090101.logになります。
    /// </summary>
    public class TraceManager
    {
        public TraceManager()
        {
            startupFolder = AppDomain.CurrentDomain.BaseDirectory;
        }

        static bool useSaveLog = true;
        /// <summary>
        /// ログファイルを保存するかのフラグ
        /// </summary>
        public static bool UseSaveLog
        {
            get { return TraceManager.useSaveLog; }
            set { TraceManager.useSaveLog = value; }
        }

        static int traceMaxDay = 7;

        /// <summary>
        /// 保存する最大日
        /// </summary>
        public static int TraceMaxDay
        {
            get { return TraceManager.traceMaxDay; }
            set
            {
                TraceManager.traceMaxDay = value;
                if (traceMaxDay <= 0) traceMaxDay = 1;
            }
        }

        static string logFoler = "Trace";

        /// <summary>
        /// 保存するログフォルダ
        /// </summary>
        public static string LogFoler
        {
            get { return TraceManager.logFoler; }
            set { TraceManager.logFoler = value; }
        }



        static string startupFolder = System.AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// ex) c:\\startup  뒤쪽에 \\를 붙이지 말것
        /// default = Application.Startup
        /// </summary>
        public static string StartupFolder
        {
            get { return TraceManager.startupFolder; }
            set { TraceManager.startupFolder = value; }
        }


        /// <summary>
        /// ログを追加
        /// 内部できに日時を入れて保存
        /// </summary>
        /// <param name="log"></param>
        public static void AddLog(string log)
        {
            Debug.WriteLine(log);
            Console.WriteLine(log);
            if (!UseSaveLog) return;

            try
            {
                //読み込むファイルの名前
                string folder = Path.Combine(startupFolder, LogFoler);

                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                string fileName = folder + "\\" + "Trace_" + DateTime.Now.ToString("yyyyMMdd") + ".log";

                DateTime dtm = DateTime.Now;
                string formatDateTime = string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00} [{6:000}] ",
                    dtm.Year, dtm.Month, dtm.Day, dtm.Hour, dtm.Minute, dtm.Second, dtm.Millisecond);
                log = formatDateTime + log;

                System.IO.StreamWriter sw = null;
                using (sw = File.AppendText(fileName))
                {
                    sw.WriteLine(log);
                    //sw.Close();
                }
                sw = null;

                CheckRemoveFiles(folder);
            }
            catch
            {
            }

        }
        public static void AddLog2(string log)
        {
            Console.WriteLine(log);
            if (!UseSaveLog) return;

            try
            {
                //読み込むファイルの名前
                string folder = Path.Combine(startupFolder, LogFoler);

                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                string fileName = folder + "\\" + "SYSMGR_SYS_STATUS_INFO_" + DateTime.Now.ToString("yyyyMMdd") + ".log";

                DateTime dtm = DateTime.Now;
                string formatDateTime = string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00} [{6:000}] ",
                    dtm.Year, dtm.Month, dtm.Day, dtm.Hour, dtm.Minute, dtm.Second, dtm.Millisecond);
                log = formatDateTime + log;

                System.IO.StreamWriter sw = File.AppendText(fileName);
                sw.WriteLine(log);
                sw.Close();
                sw = null;

                CheckRemoveFiles(folder);
            }
            catch
            {
            }

        }

        public static void AddLog3(string log)
        {
            Console.WriteLine(log);
            if (!UseSaveLog) return;

            try
            {
                //読み込むファイルの名前
                string folder = Path.Combine(startupFolder, LogFoler);

                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                string fileName = folder + "\\" + "SYSMGR_COMPONENT_STATUS_INFO_" + DateTime.Now.ToString("yyyyMMdd") + ".log";

                DateTime dtm = DateTime.Now;
                string formatDateTime = string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00} [{6:000}] ",
                    dtm.Year, dtm.Month, dtm.Day, dtm.Hour, dtm.Minute, dtm.Second, dtm.Millisecond);
                log = formatDateTime + log;

                System.IO.StreamWriter sw = null;
                using (sw = File.AppendText(fileName))
                {
                    sw.WriteLine(log);
                    //sw.Close();                  
                }
                sw = null;

                CheckRemoveFiles(folder);
            }
            catch
            {
            }

        }
        static void CheckRemoveFiles(string folder)
        {
            int maxHour = TraceMaxDay * 24; //

            string[] files = Directory.GetFiles(folder);
            for (int i = 0; i < files.Length; i++)
            {
                DateTime tm = File.GetLastAccessTime(files[i]);
                TimeSpan span = DateTime.Now - tm;
                if (span.TotalHours >= maxHour)
                {
                    File.Delete(files[i]);
                }
            }
        }

        /// <summary>
        /// NAV Info 수신 정보 출력용: 20160901 
        /// </summary>
        /// <param name="log"></param>
        public static void AddLogForNavInfo(string log)
        {
            /*
             *화면 출력은 하지않도록 
            Console.WriteLine(log);
            if (!UseSaveLog) return;
            */

            try
            {
                //読み込むファイルの名前
                string folder = Path.Combine(startupFolder, LogFoler);

                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                string fileName = folder + "\\" + "Trace_NAV_" + DateTime.Now.ToString("yyyyMMdd") + ".log";

                DateTime dtm = DateTime.Now;
                string formatDateTime = string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}.{6:000} ",
                    dtm.Year, dtm.Month, dtm.Day, dtm.Hour, dtm.Minute, dtm.Second, dtm.Millisecond);
                log = formatDateTime + log;

                System.IO.StreamWriter sw = null;
                using (sw = File.AppendText(fileName))
                {
                    sw.WriteLine(log);
                    //sw.Close();
                }
                sw = null;

                CheckRemoveFiles(folder);
            }
            catch
            {
            }

        }

        /// <summary>
        /// 경고 경보 
        /// </summary>
        /// <param name="log"></param>
        public static void AddLogAlarm(string log)
        {
            try
            {
                //読み込むファイルの名前
                string folder = Path.Combine(startupFolder, LogFoler);

                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                string fileName = folder + "\\" + "Trace_Alarm_" + DateTime.Now.ToString("yyyyMMdd") + ".log";

                DateTime dtm = DateTime.Now;
                string formatDateTime = string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}.{6:000} ",
                    dtm.Year, dtm.Month, dtm.Day, dtm.Hour, dtm.Minute, dtm.Second, dtm.Millisecond);
                log = formatDateTime + log;

                System.IO.StreamWriter sw = null;
                using (sw = File.AppendText(fileName))
                {
                    sw.WriteLine(log);
                    //sw.Close();
                }
                sw = null;

                CheckRemoveFiles(folder);
            }
            catch
            {
            }

        }

    }
}
