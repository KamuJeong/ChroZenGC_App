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

        #region KeyPadOnOff

        public delegate void KeyPadRequest(ViewModel_KeyPad viewModel_KeyPad);
        public static KeyPadRequest onKeyPadRequest;
        public static void KeyPadRequestEvent(ViewModel_KeyPad viewModel_KeyPad)
        {
            onKeyPadRequest?.Invoke(viewModel_KeyPad);
        }

        #endregion MainInitialized

        #region MainInitialized

        public delegate void MainInitialized(TCPManager tCPManager);
        public static MainInitialized onMainInitialized;
        public static void MainInitializedEvent(TCPManager tCPManager)
        {
            onMainInitialized?.Invoke(tCPManager);
        }

        #endregion MainInitialized

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

        public delegate void TemperatureUpdated();
        public static TemperatureUpdated onTemperatureUpdated;
        public static void TemperatureUpdatedEvent()
        {
            onTemperatureUpdated?.Invoke();
        }

        public delegate void RawDataUpdated();
        public static RawDataUpdated onRawDataUpdated;
        public static void RawDataUpdatedEvent()
        {
            onRawDataUpdated?.Invoke();
        }

        public delegate void ChartDeltaChanged( double deltaX, float deltaY);
        public static ChartDeltaChanged onChartDeltaChanged;
        public static void ChartDeltaChangedEvent( double deltaX, float deltaY)
        {
            onChartDeltaChanged?.Invoke( deltaX, deltaY);
        }

        public delegate void ChartOffsetChanged( double deltaX, float deltaY);
        public static ChartOffsetChanged onChartOffsetChanged;
        public static void ChartOffsetChangedEvent( double deltaX, float deltaY)
        {
            onChartOffsetChanged?.Invoke( deltaX, deltaY);
        }

        public delegate void InformDelivered();
        public static InformDelivered onInformDelivered;
        public static void InformDeliveredEvent()
        {
            onInformDelivered?.Invoke();
        }

        public delegate void DetectorSelectionChangedTo(int nDetIndex);
        public static DetectorSelectionChangedTo onDetectorSelectionChangedTo;
        public static void DetectorSelectionChangedToEvent(int nDetIndex)
        {
            onDetectorSelectionChangedTo?.Invoke(nDetIndex);
        }
    }
}
