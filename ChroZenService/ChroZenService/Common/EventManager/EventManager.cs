using System;
using System.Collections.Generic;
using System.Text;
using YC_ChroZenGC_Type;
using static ChroZenService.ChroZenService_Const;
using static YC_ChroZenGC_Type.YC_Const;

namespace ChroZenService
{
    public static class EventManager
    {
        #region RunStarted

        public delegate void RunStarted();
        public static RunStarted onRunStarted;
        public static void RunStartedEvent()
        {
            onRunStarted?.Invoke();
        }

        #endregion RunStarted

        #region RunStopped

        public delegate void RunStopped();
        public static RunStopped onRunStopped;
        public static void RunStoppedEvent()
        {
            onRunStopped?.Invoke();
        }

        #endregion RunStopped

        #region MethodUpdated

        public delegate void MethodUpdated();
        public static MethodUpdated onMethodUpdated;
        public static void MethodUpdatedEvent()
        {
            onMethodUpdated?.Invoke();
        }

        #endregion MethodUpdated

        #region PACKCODE receive
        public delegate void PACKCODE_Receivce(E_PACKCODE e_LC_PACK_CODE, I_CHROZEN_GC_PACKET packet);
        public static PACKCODE_Receivce onPACKCODE_Receivce;
        public static void PACKCODE_ReceivceEvent(E_PACKCODE e_LC_PACK_CODE, I_CHROZEN_GC_PACKET packet)
        {
            onPACKCODE_Receivce?.Invoke(e_LC_PACK_CODE, packet);
        }
        #endregion PACKCODE receive

        #region Socket reconnect
        public delegate void SocketReConnected();
        public static SocketReConnected onSocketReConnected;
        public static void SocketReConnectedEvent()
        {
            onSocketReConnected?.Invoke();
        }
        #endregion Socket reconnect

        #region Disconnected
        public delegate void Disconnected();
        public static Disconnected onDisconnected;
        public static void DisconnectedEvent()
        {
            onDisconnected?.Invoke();
        }
        #endregion Disconnected

        #region Connect Success
        public delegate void ConnectSuccess();
        public static ConnectSuccess onConnectSuccess;
        public static void ConnectSuccessEvent()
        {
            onConnectSuccess?.Invoke();
        }
        #endregion Connect Success

        public delegate void RawDataUpdated();
        public static RawDataUpdated onRawDataUpdated;
        public static void RawDataUpdatedEvent()
        {
            onRawDataUpdated?.Invoke();
        }

        public delegate void ChartDeltaChanged(CHART_DELTA_TYPE cHART_DELTA_TYPE, double deltaX, double deltaY);
        public static ChartDeltaChanged onChartDeltaChanged;
        public static void ChartDeltaChangedEvent(CHART_DELTA_TYPE cHART_DELTA_TYPE, double deltaX, double deltaY)
        {
            onChartDeltaChanged?.Invoke(cHART_DELTA_TYPE, deltaX, deltaY);
        }

        public delegate void InformDelivered();
        public static InformDelivered onInformDelivered;
        public static void InformDeliveredEvent()
        {
            onInformDelivered?.Invoke();
        }
    }
}
