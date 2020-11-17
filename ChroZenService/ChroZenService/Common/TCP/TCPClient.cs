using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using YC_ChroZenGC_Type;
using static YC_ChroZenGC_Type.YC_Const;

namespace ChroZenService
{
    public static class TCPClient
    {
        public class TCPManager : IDisposable
        {           

            Queue<W_CHROZEN_GC_PACKET_WITH_PACKCODE> receivedAsyncPACKCODE_queue = new Queue<W_CHROZEN_GC_PACKET_WITH_PACKCODE>();

            /// <summary>
            /// TCP 동기/비동기 순차 실행 : 초기 상태 대기 해제
            /// WaitOne : 대기 설정
            /// Set : 대기 해제
            /// </summary>
            //public static ManualResetEvent TcpManualResetEvent = new ManualResetEvent(true);
            bool _bIsSync = false;
            public bool bIsSync
            {
                get { return _bIsSync; }
                set
                {
                    if (value == true)
                    {
                        Debug.WriteLine("=====================================SyncReceive=========================================");
                        TraceManager.AddLog("=====================================SyncReceive=========================================");
                    }
                    else
                    {
                        Debug.WriteLine("=====================================AsyncReceive=========================================");
                        TraceManager.AddLog("=====================================AsyncReceive=========================================");
                    }
                    _bIsSync = value;
                }
            }

            public bool IsSocketConnected
            {
                get
                {
                    if (Socket_Client_DeviceInterface != null)
                        return Socket_Client_DeviceInterface.Connected;
                    else return false;
                }
            }

            Socket Socket_Client_DeviceInterface;

            public TCPManager()
            {
                InitTCP();
                InitQueue();
                AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
            }

            private void CurrentDomain_ProcessExit(object sender, EventArgs e)
            {
                bIsThreadQueueProceed = false;
            }
            public void KillQueueThread()
            {
                bIsThreadQueueProceed = false;
            }

            Thread threadQueue;
            bool bIsThreadQueueProceed = true;
            private void InitQueue()
            {
                threadQueue = new Thread(new ThreadStart(delegate
                {
                    Thread.CurrentThread.Priority = ThreadPriority.Highest;
                    TraceManager.AddLog(string.Format("ChroZen GC Process={0}, TCPClient : received PACKCODE queue pumping thread start", Process.GetCurrentProcess().ProcessName));

                    while (bIsThreadQueueProceed)
                    {
                        Thread.Sleep(10);
                        try
                        {
                            while (receivedAsyncPACKCODE_queue.Count > 0)
                            {
                                W_CHROZEN_GC_PACKET_WITH_PACKCODE wrappedPACKCODE = receivedAsyncPACKCODE_queue.Dequeue();
                                //동기식 처리가 필요한 경우 이벤트 처리
                                switch (wrappedPACKCODE.packcode)
                                {
                                    case E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_INFORM:
                                        {
                                            DataManager.t_PACKCODE_CHROZEN_SYSTEM_INFORM_Received = (T_PACKCODE_CHROZEN_SYSTEM_INFORM)wrappedPACKCODE.packet;
                                        }
                                        break;
                                    case E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_CONFIG:
                                        {
                                            DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received = (T_PACKCODE_CHROZEN_SYSTEM_CONFIG)wrappedPACKCODE.packet;
                                        }
                                        break;
                                    case E_PACKCODE.PACKCODE_CHROZEN_OVEN_SETTING:
                                        {
                                            DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received = (T_PACKCODE_CHROZEN_OVEN_SETTING)wrappedPACKCODE.packet;
                                        }
                                        break;
                                    case E_PACKCODE.PACKCODE_CHROZEN_INLET_SETTING:
                                        {
                                            switch (((T_PACKCODE_CHROZEN_INLET_SETTING)wrappedPACKCODE.packet).packet.btPortNo)
                                            {
                                                case 0:
                                                    {
                                                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received = (T_PACKCODE_CHROZEN_INLET_SETTING)wrappedPACKCODE.packet;
                                                    }
                                                    break;
                                                case 1:
                                                    {
                                                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received = (T_PACKCODE_CHROZEN_INLET_SETTING)wrappedPACKCODE.packet;
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received = (T_PACKCODE_CHROZEN_INLET_SETTING)wrappedPACKCODE.packet;
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case E_PACKCODE.PACKCODE_CHROZEN_DET_SETTING:
                                        {
                                            switch (((T_PACKCODE_CHROZEN_DET_SETTING)wrappedPACKCODE.packet).packet.btPort)
                                            {
                                                case 0:
                                                    {
                                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front_Received = (T_PACKCODE_CHROZEN_DET_SETTING)wrappedPACKCODE.packet;
                                                    }
                                                    break;
                                                case 1:
                                                    {
                                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center_Received = (T_PACKCODE_CHROZEN_DET_SETTING)wrappedPACKCODE.packet;
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear_Received = (T_PACKCODE_CHROZEN_DET_SETTING)wrappedPACKCODE.packet;
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case E_PACKCODE.PACKCODE_CHROZEN_VALVE_SETTING:
                                        {
                                            DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received = (T_PACKCODE_CHROZEN_VALVE_SETTING)wrappedPACKCODE.packet;
                                        }
                                        break;
                                    case E_PACKCODE.PACKCODE_CHROZEN_AUX_TEMP_SETTING:
                                        {
                                            DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received = (T_PACKCODE_CHROZEN_AUX_TEMP_SETTING)wrappedPACKCODE.packet;
                                        }
                                        break;
                                    case E_PACKCODE.PACKCODE_CHROZEN_AUX_APC_SETTING:
                                        {
                                            switch (((T_PACKCODE_CHROZEN_AUX_APC_SETTING)wrappedPACKCODE.packet).packet.btPort)
                                            {
                                                case 0:
                                                    {
                                                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Received = (T_PACKCODE_CHROZEN_AUX_APC_SETTING)wrappedPACKCODE.packet;
                                                    }
                                                    break;
                                                case 1:
                                                    {
                                                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Received = (T_PACKCODE_CHROZEN_AUX_APC_SETTING)wrappedPACKCODE.packet;
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Received = (T_PACKCODE_CHROZEN_AUX_APC_SETTING)wrappedPACKCODE.packet;
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case E_PACKCODE.PACKCODE_YL6200_SIGNAL_SETTING:
                                        {
                                            switch (((T_PACKCODE_CHROZEN_DET_SIGNAL_SETTING)wrappedPACKCODE.packet).packet.btPort)
                                            {
                                                case 0:
                                                    {
                                                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Received = (T_PACKCODE_CHROZEN_DET_SIGNAL_SETTING)wrappedPACKCODE.packet;
                                                    }
                                                    break;
                                                case 1:
                                                    {
                                                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Received = (T_PACKCODE_CHROZEN_DET_SIGNAL_SETTING)wrappedPACKCODE.packet;
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Received = (T_PACKCODE_CHROZEN_DET_SIGNAL_SETTING)wrappedPACKCODE.packet;
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case E_PACKCODE.PACKCODE_CHROZEN_SPECIAL_FUNCTION:
                                        {
                                            DataManager.t_PACKCODE_CHROZEN_SPECIAL_FUNCTION_Received = (T_PACKCODE_CHROZEN_SPECIAL_FUNCTION)wrappedPACKCODE.packet;
                                        }
                                        break;
                                    case E_PACKCODE.PACKCODE_YL6200_TIME_CTRL_SETTING:
                                        {
                                            DataManager.t_PACKCODE_CHROZEN_TIME_CTRL_SETTING_Received = (T_PACKCODE_CHROZEN_TIME_CTRL_SETTING)wrappedPACKCODE.packet;
                                        }
                                        break;
                                    case E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_STATE:
                                        {
                                            DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received = (T_PACKCODE_CHROZEN_SYSTEM_STATE)wrappedPACKCODE.packet;
                                        }
                                        break;
                                    case E_PACKCODE.PACKCODE_YL6200_SLFEMSG:
                                        {
                                            DataManager.t_PACKCODE_CHROZEN_SLFEMSG_Received = (T_PACKCODE_CHROZEN_SLFEMSG)wrappedPACKCODE.packet;
                                        }
                                        break;
                                    case E_PACKCODE.PACKCODE_YL6200_COMMAND:
                                        {
                                            DataManager.t_PACKCODE_CHROZEN_COMMAND_Received = (T_PACKCODE_CHROZEN_COMMAND)wrappedPACKCODE.packet;
                                        }
                                        break;
                                    case E_PACKCODE.PACKCODE_YL6200_SIGNAL:
                                        {
                                            DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received = (T_PACKCODE_CHROZEN_SIGNAL)wrappedPACKCODE.packet;
                                        }
                                        break;
                                }

                                EventManager.PACKCODE_ReceivceEvent(wrappedPACKCODE.packcode, wrappedPACKCODE.packet);
                                //비동기식 빠른 처리가 필요한 경우 쓰레드 처리
                            }
                        }
                        catch (Exception ee)
                        {
                            TraceManager.AddLog(string.Format("{0}r\n{1}", ee.StackTrace, ee.Message));
                        }
                    }
                    TraceManager.AddLog(string.Format("Chrozen GC : Process={0} TCPClient: Queue thread died", Process.GetCurrentProcess().ProcessName));
                }));
                threadQueue.Start();
            }
            private void RestartQueueThread()
            {
                try
                {
                    threadQueue.Abort();
                    TraceManager.AddLog(string.Format("Chrozen GC : Process={0} : TCPClient: RestartQueueThread -> threadQueue aborted.", Process.GetCurrentProcess().ProcessName));
                }
                catch (Exception e)
                {

                }
                finally
                {
                    InitQueue();
                }
            }

            ~TCPManager()
            {
                Disconnect();
                TraceManager.AddLog("TCPClient:Destructor");
            }

            public void InitTCP()
            {
                try
                {
                    Socket_Client_DeviceInterface = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    Socket_Client_DeviceInterface.NoDelay = true;
                }
                catch (Exception ee)
                {
                    ReConnect();
                    TraceManager.AddLog(string.Format("TCPManager:InitTCP{0}r\n{1}", ee.StackTrace, ee.Message));
                    System.Diagnostics.Debug.WriteLine(string.Format("{0}\r\n{1}", ee.StackTrace, ee.Message));
                }
            }

            public void Disconnect()
            {
                try
                {
                    Socket_Client_DeviceInterface.Shutdown(SocketShutdown.Both);
                }
                catch (Exception e)
                {
                    TraceManager.AddLog(string.Format("e.Message={0}, e.StackTrace={1}", e.Message, e.StackTrace));
                }
                try
                {
                    Socket_Client_DeviceInterface.Disconnect(false);
                }
                catch (Exception e)
                {
                    TraceManager.AddLog(string.Format("e.Message={0}, e.StackTrace={1}", e.Message, e.StackTrace));
                }
                try
                {
                    Socket_Client_DeviceInterface.Close();
                }
                catch (Exception e)
                {
                    TraceManager.AddLog(string.Format("e.Message={0}, e.StackTrace={1}", e.Message, e.StackTrace));
                }

                TraceManager.AddLog(string.Format("TCPClient:Disconnect"));
            }
            public void ReConnect()
            {
                try
                {
                    EventManager.DisconnectedEvent();
                    if (bIsThreadQueueProceed == false) return;
                    if (!Socket_Client_DeviceInterface.Connected)
                    {
                        try
                        {
                            RestartQueueThread();
                            Disconnect();
                            //Socket_Client_DeviceInterface.Disconnect(true);
                            //Socket_Client_DeviceInterface.Dispose();
                        }
                        catch (Exception ex)
                        {
                            //LogEvent?.Invoke(13, "{0} : {1}".FormatA("Dispose", ex.Message));
                        }
                        finally
                        {
                            TraceManager.AddLog("TCPClient : Disconnect and ReConnect");
                            EventManager.DisconnectedEvent();

                            InitTCP();
                            ConnectDevice(_ip, _port);
                            //YC_EventManager.SocketReConnectedEvent();
                        }
                    }
                    //else
                    {
                        //TraceManager.AddLog("TCPClient : Disconnect and ReConnect");
                        //YC_EventManager.ConnectErrorEvent();

                        //YC_EventManager.SocketReConnectedEvent();
                    }
                }
                catch (Exception ee)
                {
                    TraceManager.AddLog(string.Format("TCPManager:ReConnect{0}r\n{1}", ee.StackTrace, ee.Message));
                }
            }

         
            string _ip;
            int _port;
            public void ConnectDevice(string ip, int port)
            {
                try
                {
                    _ip = ip;
                    _port = port;

                    Socket_Client_DeviceInterface.BeginConnect(ip, port, new AsyncCallback(ChrogenInterface_ConnectCallback), Socket_Client_DeviceInterface);
                }
                catch (Exception ee)
                {
                    ReConnect();
                    TraceManager.AddLog(string.Format("TCPManager:ConnectDevice{0}r\n{1}", ee.StackTrace, ee.Message));
                    System.Diagnostics.Debug.WriteLine(string.Format("{0}\r\n{1}", ee.StackTrace, ee.Message));
                }
            }

            private void ChrogenInterface_ConnectCallback(IAsyncResult ar)
            {
                try
                {
                    Socket_Client_DeviceInterface = (Socket)ar.AsyncState;
                    Socket_Client_DeviceInterface.EndConnect(ar);

                    if (Socket_Client_DeviceInterface.Connected)
                    {

                        //T_CHROZEN_GC_SYSTEM_INFORM t_CHROZEN_GC_SYSTEM_INFORM = new T_CHROZEN_GC_SYSTEM_INFORM();
                        //t_CHROZEN_GC_SYSTEM_INFORM.Model = YC_Util.StringToCharArray("PUMP ver. 1.0.0", 32);
                        //t_CHROZEN_GC_SYSTEM_INFORM.nVersion = 100;

                        TraceManager.AddLog("INFORM SET 송신");

                        System.Diagnostics.Debug.WriteLine(string.Format("TCPClient : Connected"));
                        TraceManager.AddLog("TCPClient : Connected");
                        //YC_EventManager.ConnectSuccessEvent();
                        Receive(Socket_Client_DeviceInterface);
                    }

                }
                catch (Exception ee)
                {
                    TraceManager.AddLog(string.Format("TCPManager:ChrogenInterface_ConnectCallback{0}r\n{1}", ee.StackTrace, ee.Message));
                    System.Diagnostics.Debug.WriteLine(string.Format("{0}\r\n{1}", ee.StackTrace, ee.Message));
                    System.Diagnostics.Debug.WriteLine(string.Format("TCPClient : Connect Error"));
                }
                finally
                {
                    if (!Socket_Client_DeviceInterface.Connected)
                    {
                        ReConnect();
                        TraceManager.AddLog("Exception : TCPClient.ChrogenInterface_ConnectCallback");
                    }
                }
            }

            public void ReceiveAsync()
            {
                try
                {
                    bIsSync = false;
                    Receive(Socket_Client_DeviceInterface);

                }
                catch (Exception e)
                {

                    TraceManager.AddLog(string.Format("ReceiveAsync err : {0}, {1}", e.StackTrace, e.Message));
                }
            }

            private void Receive(Socket client)
            {
                try
                {
                    // Create the state object.  
                    SocketStateObject state = new SocketStateObject();
                    state.workSocket = client;

                    // Begin receiving the data from the remote device.  
                    client.BeginReceive(state.rawBuffer, 0, SocketStateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                catch (Exception ee)
                {
                    ReConnect();
                    TraceManager.AddLog("Exception : TCPClient.Receive");
                    TraceManager.AddLog(string.Format("{0}r\n{1}", ee.StackTrace, ee.Message));
                    System.Diagnostics.Debug.WriteLine(string.Format("{0}\r\n{1}", ee.StackTrace, ee.Message));
                    System.Diagnostics.Debug.WriteLine(string.Format("TCPClient : Receive Error"));
                }
            }

            private void ReceiveSync(byte[] rawBytes, int readCount)
            {
                try
                {

                    // Read data from the remote device.  
                    int bytesRead = readCount;
                    {
                        if (bytesRead > 0)
                        {
                            byte[] dissectedPacket = new byte[bytesRead];
                            //바이트 배열을 읽은 수 만큼 state.lengthedBuffer에 복사
                            Array.Copy(rawBytes, dissectedPacket, bytesRead);

                            while (true)
                            {
                                int packetLength = (dissectedPacket[0]) + (dissectedPacket[1] << 8) + (dissectedPacket[2] << 16) + (dissectedPacket[3] << 24);

                                if ((dissectedPacket.Length >= 24) && (dissectedPacket.Length >= packetLength) && (packetLength >= 24))
                                {
                                    //System.Diagnostics.Debug.WriteLine(string.Format("ReceiveSync : bytes to read == {0}", bytesRead));
                                    byte[] packet = new byte[packetLength];
                                    //읽은 바이트 배열을 nPacketLength 크기에 따라 분할하여 처리
                                    Array.Copy(dissectedPacket, packet, packetLength);

                                    //원본 바이트 배열에서 nPacketLength 만큼을 제거 후 다시 할당
                                    dissectedPacket = dissectedPacket.Skip(packetLength).ToArray();

                                    //nPacketLength 크기에 따라 분할한 packet을 parsing
                                    ParsePacket(packet, true);
                                    if (dissectedPacket.Length < 4) break;
                                }
                                else break;
                            }
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine(string.Format("TCPClient : bytes to read == 0"));
                        }
                    }

                }
                catch (Exception ee)
                {
                    TraceManager.AddLog(string.Format("{0}r\n{1}", ee.StackTrace, ee.Message));
                    System.Diagnostics.Debug.WriteLine(string.Format("{0}\r\n{1}", ee.StackTrace, ee.Message));
                    System.Diagnostics.Debug.WriteLine(string.Format("TCPClient : ReceiveCallback Error"));
                }
            }

            private void ReceiveCallback(IAsyncResult ar)
            {
                try
                {

                    // Retrieve the state object and the client socket   
                    // from the asynchronous state object.  
                    SocketStateObject state = (SocketStateObject)ar.AsyncState;
                    Socket client = state.workSocket;

                    if (client.Connected == true)
                    {
                        {
                            // Read data from the remote device.  
                            int bytesRead = client.EndReceive(ar);
                            {
                                if (bytesRead > 0)
                                {
                                    byte[] dissectedPacket = new byte[bytesRead];
                                    //바이트 배열을 읽은 수 만큼 state.lengthedBuffer에 복사
                                    Array.Copy(state.rawBuffer, dissectedPacket, bytesRead);

                                    while (true)
                                    {
                                        int packetLength = (dissectedPacket[0]) + (dissectedPacket[1] << 8) + (dissectedPacket[2] << 16) + (dissectedPacket[3] << 24);

                                        if (
                                            (dissectedPacket.Length >= packetLength) &&
                                            (packetLength >= 24)
                                            )
                                        {
                                            //System.Diagnostics.Debug.WriteLine(string.Format("ReceiveCallback : bytes to read == {0}", bytesRead));
                                            byte[] packet = new byte[packetLength];
                                            //읽은 바이트 배열을 nPacketLength 크기에 따라 분할하여 처리
                                            Array.Copy(dissectedPacket, packet, packetLength);

                                            //원본 바이트 배열에서 nPacketLength 만큼을 제거 후 다시 할당
                                            dissectedPacket = dissectedPacket.Skip(packetLength).ToArray();
                                            //nPacketLength 크기에 따라 분할한 packet을 parsing
                                            ParsePacket(packet, false);
                                            if (dissectedPacket.Length < 4) break;
                                        }
                                        else break;
                                    }

                                    if (!bIsSync)
                                        // Get the rest of the data.  
                                        client.BeginReceive(state.rawBuffer, 0, SocketStateObject.BufferSize, 0,
                                            new AsyncCallback(ReceiveCallback), state);

                                }

                                else
                                {
                                    System.Diagnostics.Debug.WriteLine(string.Format("TCPClient : bytes to read == 0"));
                                }
                            }
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format("TCPClient.ReceiveCallback : client.Connected == false"));
                    }
                }
                catch (Exception ee)
                {
                    ReConnect();
                    TraceManager.AddLog("Exception : TCPClient.ReceiveCallback");
                    TraceManager.AddLog(string.Format("{0}r\n{1}", ee.StackTrace, ee.Message));
                    System.Diagnostics.Debug.WriteLine(string.Format("{0}\r\n{1}", ee.StackTrace, ee.Message));
                    System.Diagnostics.Debug.WriteLine(string.Format("TCPClient : ReceiveCallback Error"));
                }
            }

            private void ParsePacket(byte[] packet, bool bIsSync)
            {
                byte[] bArr_T_YL9000HPLC_PACKET = new byte[24];
                Array.Copy(packet, bArr_T_YL9000HPLC_PACKET, 24);
                //CL_ReceivedPacket_ChrogenInterface.Add(state.lengthedBuffer);
                T_HEADER_PACKET temp = YC_Util.ByteToStruct<T_HEADER_PACKET>(bArr_T_YL9000HPLC_PACKET);
                //Debug.WriteLine(((E_PACKCODE)temp.nPacketCode).ToString());
                //TraceManager.AddLog(((E_PACKCODE)temp.nPacketCode).ToString() + " 수신");
                switch ((E_PACKCODE)temp.nPacketCode)
                {
                    case E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_INFORM:
                        {
                            if (temp.nPacketLength == 24) // 최초 접속시 장비가 플러그인으로 INFORM_REQ를 송신 
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {
                                    try
                                    {
                                        #region 20200519 권민경 : Inform정보 전송후 ack 받으면 Config 요청 


                                        if (bIsSync)
                                            SendSync(T_PACKCODE_CHROZEN_SYSTEM_CONFIGManager.MakePACKCODE_REQ());
                                        else
                                            Send(T_PACKCODE_CHROZEN_SYSTEM_CONFIGManager.MakePACKCODE_REQ());
                                        #endregion
                                    }
                                    catch (Exception ee)
                                    {
                                        TraceManager.AddLog(string.Format("{0}r\n{1}", ee.StackTrace, ee.Message));
                                        System.Diagnostics.Debug.WriteLine(string.Format("{0}\r\n{1}", ee.StackTrace, ee.Message));
                                        System.Diagnostics.Debug.WriteLine(string.Format("TCPClient : Send Error"));
                                    }
                                }
                                //Req
                                else
                                {

                                    #region 20200514 권민경 : 처음접속시 1번 Inform 송신

                                    //T_YL9010_PUMP_INFORM t_YL9010_PUMP_INFORM = new T_YL9010_PUMP_INFORM();
                                    //t_YL9010_PUMP_INFORM.Model = YC_Util.StringToCharArray("PUMP ver. 1.0.0", 32);
                                    //t_YL9010_PUMP_INFORM.nVersion = 100;
                                    //Send(T_PACKCODE_YL9010_INFORMManager.MakePACKCODE_SET(t_YL9010_PUMP_INFORM));
                                    //TraceManager.AddLog("INFORM SET 송신");
                                    Send(T_PACKCODE_CHROZEN_SYSTEM_INFORMManager.MakePACKCODE_SET(T_CHROZEN_GC_SYSTEM_INFORMManager.InitiatedInstance));
                                    Send(T_PACKCODE_CHROZEN_SYSTEM_INFORMManager.MakePACKCODE_REQ());
                                    Send(T_PACKCODE_CHROZEN_SYSTEM_CONFIGManager.MakePACKCODE_REQ());

                                    //20.08.11 박상수 : 메소드 요청 -> 추후 Config 수신 이후로 이동
                                    //OVEN_SETTING 요청
                                    Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_REQ());

                                    //AUX_APC_SETTING 요청
                                    Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_REQ(0));
                                    Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_REQ(1));
                                    Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_REQ(2));

                                    //AUX_TEMP_SETTING 요청
                                    Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_REQ());

                                    //INLET_SETTING 요청
                                    Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_REQ(0));
                                    Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_REQ(1));
                                    Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_REQ(2));

                                    //DET_SETTING 요청
                                    Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_REQ(0));
                                    Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_REQ(1));
                                    Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_REQ(2));

                                    //VALVE_SETTING 요청
                                    Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_REQ());

                                    //SIGNAL_SETTING 요청
                                    Send(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_REQ(0));
                                    Send(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_REQ(1));
                                    Send(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_REQ(2));

                                    //SPECIAL_FUNCTION 요청 -> 요청 필요성 재고 필요
                                    Send(T_PACKCODE_CHROZEN_SPECIAL_FUNCTIONManager.MakePACKCODE_REQ());
                                    TraceManager.AddLog("접속 성공 직후 Method(Oven setting, Aux apc setting, Aux temp setting, Inlet setting, Det setting, Valve setting, Signal setting, Special function  REQ 송신");

                                    //9131 Ack 안줌
                                    //접속 성공

                                    EventManager.ConnectSuccessEvent();

                                    #endregion
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    DataManager.t_PACKCODE_CHROZEN_SYSTEM_INFORM_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SYSTEM_INFORM>(packet);
                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_INFORM, DataManager.t_PACKCODE_CHROZEN_SYSTEM_INFORM_Received);
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SYSTEM_INFORM>(packet), E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_INFORM));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }

                            }
                        }
                        break;
                    case E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_CONFIG:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    if (bIsSync)
                                        SendSync(T_PACKCODE_CHROZEN_SYSTEM_CONFIGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Send.packet));
                                    else
                                        Send(T_PACKCODE_CHROZEN_SYSTEM_CONFIGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SYSTEM_CONFIG>(packet);
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_CONFIG, DataManager.t_PACKCODE_CHROZEN_SYSTEM_CONFIG_Received);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SYSTEM_CONFIG>(packet), E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_CONFIG));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;
                    case E_PACKCODE.PACKCODE_CHROZEN_OVEN_SETTING:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    if (bIsSync)
                                    {
                                        SendSync(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                                    }
                                    else
                                        Send(T_PACKCODE_CHROZEN_OVEN_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_OVEN_SETTING>(packet);
                                        DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received;
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_OVEN_SETTING, DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_OVEN_SETTING>(packet), E_PACKCODE.PACKCODE_CHROZEN_OVEN_SETTING));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }


                            }
                        }
                        break;
                    case E_PACKCODE.PACKCODE_CHROZEN_INLET_SETTING:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    //if (bIsSync)
                                    //{                                    
                                    //    SendSync(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Send.packet));
                                    //}
                                    //else
                                    //    Send(T_PACKCODE_CHROZEN_INLET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        T_PACKCODE_CHROZEN_INLET_SETTING packCode = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_INLET_SETTING>(packet);
                                        switch (packCode.packet.btPortNo)
                                        {
                                            case 0:
                                                {
                                                    DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received = packCode;
                                                    DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Received;
                                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_INLET_SETTING, DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Front_Send);
                                                }
                                                break;
                                            case 1:
                                                {
                                                    DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received = packCode;
                                                    DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Received;
                                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_INLET_SETTING, DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Center_Send);
                                                }
                                                break;
                                            case 2:
                                                {
                                                    DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received = packCode;
                                                    DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send = DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Received;
                                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_INLET_SETTING, DataManager.t_PACKCODE_CHROZEN_INLET_SETTING_Rear_Send);
                                                }
                                                break;
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_INLET_SETTING>(packet), E_PACKCODE.PACKCODE_CHROZEN_INLET_SETTING));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;
                    case E_PACKCODE.PACKCODE_CHROZEN_DET_SETTING:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    //if (bIsSync)
                                    //{
                                    //    SendSync(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Send.packet));
                                    //}
                                    //else
                                    //    Send(T_PACKCODE_CHROZEN_DET_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Send.packet));
                                }
                            }
                            //Set
                            else
                            {

                                if (bIsSync)
                                {
                                    try
                                    {
                                        T_PACKCODE_CHROZEN_DET_SETTING packCode = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_DET_SETTING>(packet);
                                        TraceManager.AddLog(string.Format("T_PACKCODE_CHROZEN_DET_SETTING packet length : {0}", (uint)Marshal.SizeOf(packCode)));
                                        switch (packCode.packet.btPort)
                                        {
                                            case 0:
                                                {
                                                    DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front_Received = packCode;
                                                    DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front_Send = DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front_Received;
                                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_DET_SETTING, DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Front_Send);
                                                }
                                                break;
                                            case 1:
                                                {
                                                    DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center_Received = packCode;
                                                    DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center_Send = DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center_Received;
                                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_DET_SETTING, DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Center_Send);
                                                }
                                                break;
                                            case 2:
                                                {
                                                    DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear_Received = packCode;
                                                    DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear_Send = DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear_Received;
                                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_DET_SETTING, DataManager.t_PACKCODE_CHROZEN_DET_SETTING_Rear_Send);
                                                }
                                                break;
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }

                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_DET_SETTING>(packet), E_PACKCODE.PACKCODE_CHROZEN_DET_SETTING));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }


                            }
                        }
                        break;
                    case E_PACKCODE.PACKCODE_CHROZEN_VALVE_SETTING:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    if (bIsSync)
                                    {
                                        SendSync(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                                    }
                                    else
                                        Send(T_PACKCODE_CHROZEN_VALVE_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_VALVE_SETTING>(packet);
                                        DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received;
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_VALVE_SETTING, DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_VALVE_SETTING>(packet), E_PACKCODE.PACKCODE_CHROZEN_VALVE_SETTING));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }


                            }
                        }
                        break;
                    case E_PACKCODE.PACKCODE_CHROZEN_AUX_TEMP_SETTING:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    if (bIsSync)
                                    {
                                        SendSync(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));
                                    }
                                    else
                                        Send(T_PACKCODE_CHROZEN_AUX_TEMP_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_AUX_TEMP_SETTING>(packet);
                                        DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send = DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received;

                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_AUX_TEMP_SETTING, DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_AUX_TEMP_SETTING>(packet), E_PACKCODE.PACKCODE_CHROZEN_AUX_TEMP_SETTING));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }


                            }
                        }
                        break;
                    case E_PACKCODE.PACKCODE_CHROZEN_AUX_APC_SETTING:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    //if (bIsSync)
                                    //{
                                    //    SendSync(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Send.packet));
                                    //}
                                    //else
                                    //    Send(T_PACKCODE_CHROZEN_AUX_APC_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        T_PACKCODE_CHROZEN_AUX_APC_SETTING packCode = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_AUX_APC_SETTING>(packet);
                                        switch (packCode.packet.btPort)
                                        {
                                            case 0:
                                                {
                                                    DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Received = packCode;
                                                    DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Received;
                                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_AUX_APC_SETTING, DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Front_Send);
                                                }
                                                break;
                                            case 1:
                                                {
                                                    DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Received = packCode;
                                                    DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Received;
                                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_AUX_APC_SETTING, DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Center_Send);
                                                }
                                                break;
                                            case 2:
                                                {
                                                    DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Received = packCode;
                                                    DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send = DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Received;
                                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_AUX_APC_SETTING, DataManager.t_PACKCODE_CHROZEN_AUX_APC_SETTING_Rear_Send);
                                                }
                                                break;
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_AUX_APC_SETTING>(packet), E_PACKCODE.PACKCODE_CHROZEN_AUX_APC_SETTING));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;
                    case E_PACKCODE.PACKCODE_YL6200_SIGNAL_SETTING:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    //if (bIsSync)
                                    //{
                                    //    SendSync(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Send.packet));
                                    //}
                                    //else
                                    //    Send(T_PACKCODE_CHROZEN_DET_SIGNAL_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        T_PACKCODE_CHROZEN_DET_SIGNAL_SETTING packCode = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_DET_SIGNAL_SETTING>(packet);
                                        switch (packCode.packet.btPort)
                                        {
                                            case 0:
                                                {
                                                    DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Received = packCode;
                                                    DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Received;
                                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_YL6200_SIGNAL_SETTING, DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Front_Send);
                                                }
                                                break;
                                            case 1:
                                                {
                                                    DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Received = packCode;
                                                    DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Received;
                                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_YL6200_SIGNAL_SETTING, DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Center_Send);
                                                }
                                                break;
                                            case 2:
                                                {
                                                    DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Received = packCode;
                                                    DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send = DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Received;
                                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_YL6200_SIGNAL_SETTING, DataManager.t_PACKCODE_CHROZEN_DET_SIGNAL_SETTING_Rear_Send);
                                                }
                                                break;
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_DET_SIGNAL_SETTING>(packet), E_PACKCODE.PACKCODE_YL6200_SIGNAL_SETTING));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;
                    case E_PACKCODE.PACKCODE_CHROZEN_SPECIAL_FUNCTION:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    if (bIsSync)
                                    {
                                        SendSync(T_PACKCODE_CHROZEN_SPECIAL_FUNCTIONManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_SPECIAL_FUNCTION_Send.packet));
                                    }
                                    else
                                        Send(T_PACKCODE_CHROZEN_SPECIAL_FUNCTIONManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_SPECIAL_FUNCTION_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_SPECIAL_FUNCTION_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SPECIAL_FUNCTION>(packet);
                                        DataManager.t_PACKCODE_CHROZEN_SPECIAL_FUNCTION_Send = DataManager.t_PACKCODE_CHROZEN_SPECIAL_FUNCTION_Received;
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_SPECIAL_FUNCTION, DataManager.t_PACKCODE_CHROZEN_SPECIAL_FUNCTION_Send);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SPECIAL_FUNCTION>(packet), E_PACKCODE.PACKCODE_CHROZEN_SPECIAL_FUNCTION));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }


                            }
                        }
                        break;
                    case E_PACKCODE.PACKCODE_YL6200_TIME_CTRL_SETTING:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    if (bIsSync)
                                    {
                                        SendSync(T_PACKCODE_CHROZEN_TIME_CTRL_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_TIME_CTRL_SETTING_Send.packet));
                                    }
                                    else
                                        Send(T_PACKCODE_CHROZEN_TIME_CTRL_SETTINGManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_TIME_CTRL_SETTING_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_TIME_CTRL_SETTING_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_TIME_CTRL_SETTING>(packet);
                                        DataManager.t_PACKCODE_CHROZEN_TIME_CTRL_SETTING_Send = DataManager.t_PACKCODE_CHROZEN_TIME_CTRL_SETTING_Received;
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_YL6200_TIME_CTRL_SETTING, DataManager.t_PACKCODE_CHROZEN_TIME_CTRL_SETTING_Send);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_TIME_CTRL_SETTING>(packet), E_PACKCODE.PACKCODE_YL6200_TIME_CTRL_SETTING));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;
                    case E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_STATE:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    //YC_EventManager.UpdatePACKCODEBeforeSendEvent(E_PACKCODE.PACKCODE_YL9010_EVENT);

                                    //Send(T_PACKCODE_YL9010_EVENTManager.MakePACKCODE_SET(YC_DataManager.Sent.t_.t_YL9010_PUMP_EVENT));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SYSTEM_STATE>(packet);
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_STATE, DataManager.t_PACKCODE_CHROZEN_SYSTEM_STATE_Received);

                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SYSTEM_STATE>(packet), E_PACKCODE.PACKCODE_CHROZEN_SYSTEM_STATE));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;
                    case E_PACKCODE.PACKCODE_YL6200_SLFEMSG:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_SLFEMSG_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SLFEMSG>(packet);
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_YL6200_SLFEMSG, DataManager.t_PACKCODE_CHROZEN_SLFEMSG_Received);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SLFEMSG>(packet), E_PACKCODE.PACKCODE_YL6200_SLFEMSG));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;
                    case E_PACKCODE.PACKCODE_YL6200_COMMAND:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_COMMAND_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_COMMAND>(packet);
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_YL6200_COMMAND, DataManager.t_PACKCODE_CHROZEN_COMMAND_Received);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_COMMAND>(packet), E_PACKCODE.PACKCODE_YL6200_COMMAND));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;
                    case E_PACKCODE.PACKCODE_YL6200_SIGNAL:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    Send(T_PACKCODE_CHROZEN_SIGNALManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_SIGNAL_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet);
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_YL6200_SIGNAL, DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet), E_PACKCODE.PACKCODE_YL6200_SIGNAL));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;

                    #region LCD

                    case E_PACKCODE.PACKCODE_CHROZEN_LCD_SIGNAL:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    Send(T_PACKCODE_CHROZEN_SIGNALManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_SIGNAL_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet);
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_YL6200_SIGNAL, DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet), E_PACKCODE.PACKCODE_YL6200_SIGNAL));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;

                    case E_PACKCODE.PACKCODE_CHROZEN_LCD_APC_CALIB_READ:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    Send(T_PACKCODE_CHROZEN_SIGNALManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_SIGNAL_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet);
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_YL6200_SIGNAL, DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet), E_PACKCODE.PACKCODE_YL6200_SIGNAL));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;

                    case E_PACKCODE.PACKCODE_CHROZEN_LCD_APC_SENSOR_VOLTAGE:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    Send(T_PACKCODE_CHROZEN_SIGNALManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_SIGNAL_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet);
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_YL6200_SIGNAL, DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet), E_PACKCODE.PACKCODE_YL6200_SIGNAL));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;

                    case E_PACKCODE.PACKCODE_CHROZEN_LCD_VOLTAGE_CHECK:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    Send(T_PACKCODE_CHROZEN_SIGNALManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_SIGNAL_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet);
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_YL6200_SIGNAL, DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet), E_PACKCODE.PACKCODE_YL6200_SIGNAL));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;

                    case E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    Send(T_PACKCODE_CHROZEN_SIGNALManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_SIGNAL_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet);
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_YL6200_SIGNAL, DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet), E_PACKCODE.PACKCODE_YL6200_SIGNAL));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;

                    case E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_SIGNAL:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    Send(T_PACKCODE_CHROZEN_SIGNALManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_SIGNAL_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet);
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_YL6200_SIGNAL, DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet), E_PACKCODE.PACKCODE_YL6200_SIGNAL));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;

                    case E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    Send(T_PACKCODE_CHROZEN_SIGNALManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_SIGNAL_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet);
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_YL6200_SIGNAL, DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet), E_PACKCODE.PACKCODE_YL6200_SIGNAL));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;

                    case E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_INLET:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    Send(T_PACKCODE_CHROZEN_SIGNALManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_SIGNAL_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet);
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_YL6200_SIGNAL, DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet), E_PACKCODE.PACKCODE_YL6200_SIGNAL));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;

                    case E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_DET:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    Send(T_PACKCODE_CHROZEN_SIGNALManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_SIGNAL_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet);
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_YL6200_SIGNAL, DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet), E_PACKCODE.PACKCODE_YL6200_SIGNAL));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;

                    case E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_APCAUX:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    Send(T_PACKCODE_CHROZEN_SIGNALManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_SIGNAL_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet);
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_YL6200_SIGNAL, DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet), E_PACKCODE.PACKCODE_YL6200_SIGNAL));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;

                    case E_PACKCODE.PACKCODE_CHROZEN_LCD_DIAG:
                        {
                            if (temp.nPacketLength == 24)
                            {
                                //Ack
                                if (temp.nSlotSize == 0)
                                {

                                }
                                //Req
                                else
                                {
                                    Send(T_PACKCODE_CHROZEN_SIGNALManager.MakePACKCODE_SET(DataManager.t_PACKCODE_CHROZEN_SIGNAL_Send.packet));
                                }
                            }
                            //Set
                            else
                            {
                                if (bIsSync)
                                {
                                    try
                                    {
                                        DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet);
                                        EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_YL6200_SIGNAL, DataManager.t_PACKCODE_CHROZEN_SIGNAL_Received);
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_SIGNAL>(packet), E_PACKCODE.PACKCODE_YL6200_SIGNAL));
                                    }
                                    catch (Exception e)
                                    {
                                        TraceManager.AddLog(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                    }
                                }
                            }
                        }
                        break;

                        #endregion LCD
                }
            }

            public void Send(byte[] byteArr)
            {
                try
                {
                    if (Socket_Client_DeviceInterface.Connected == true)
                    {
                        Send(Socket_Client_DeviceInterface, byteArr);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format("TCPClient.Send() : client.Connected == false"));
                    }
                }
                catch (Exception ee)
                {
                    ReConnect();
                    TraceManager.AddLog("Exception : TCPClient.Send");
                    TraceManager.AddLog(string.Format("{0}r\n{1}", ee.StackTrace, ee.Message));
                    System.Diagnostics.Debug.WriteLine(string.Format("{0}\r\n{1}", ee.StackTrace, ee.Message));
                    System.Diagnostics.Debug.WriteLine(string.Format("TCPClient : Send Error"));
                }
            }
            public void ReceiveSync()
            {
                try
                {
                    if (Socket_Client_DeviceInterface.Connected == true)
                    {
                        byte[] buffer = new byte[4096];
                        int receiveCount = Socket_Client_DeviceInterface.Receive(buffer);
                        System.Diagnostics.Debug.WriteLine(string.Format("TCPClient.ReceiveSync() : receiveCount == {0}", receiveCount));
                        ReceiveSync(buffer, receiveCount);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format("TCPClient.ReceiveSync() : client.Connected == false"));
                    }
                }
                catch (Exception ee)
                {
                    TraceManager.AddLog(string.Format("{0}r\n{1}", ee.StackTrace, ee.Message));
                    System.Diagnostics.Debug.WriteLine(string.Format("{0}\r\n{1}", ee.StackTrace, ee.Message));
                    System.Diagnostics.Debug.WriteLine(string.Format("TCPClient : Send Error"));
                }
            }
            public void SendSync(byte[] byteArr)
            {
                try
                {
                    if (Socket_Client_DeviceInterface.Connected == true)
                    {

                        SendSync(Socket_Client_DeviceInterface, byteArr);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format("TCPClient.Send() : client.Connected == false"));
                    }
                }
                catch (Exception ee)
                {
                    TraceManager.AddLog(string.Format("{0}r\n{1}", ee.StackTrace, ee.Message));
                    System.Diagnostics.Debug.WriteLine(string.Format("{0}\r\n{1}", ee.StackTrace, ee.Message));
                    System.Diagnostics.Debug.WriteLine(string.Format("TCPClient : Send Error"));
                }
            }

            private static void SendSync(Socket client, byte[] byteData)
            {
                //// Convert the string data to byte data using ASCII encoding.  
                //byte[] byteData = Encoding.ASCII.GetBytes(data);

                // Begin sending the data to the remote device.  
                client.Send(byteData);
            }

            private void Send(Socket client, byte[] byteData)
            {

                //// Convert the string data to byte data using ASCII encoding.  
                //byte[] byteData = Encoding.ASCII.GetBytes(data);

                // Begin sending the data to the remote device.  
                client.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendCallback), client);

            }

            private void SendCallback(IAsyncResult ar)
            {
                try
                {
                    // Retrieve the socket from the state object.  
                    Socket client = (Socket)ar.AsyncState;

                    // Complete sending the data to the remote device.  
                    int bytesSent = client.EndSend(ar);
                    Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                }
                catch (Exception e)
                {
                    ReConnect();

                    TraceManager.AddLog("Exception : TCPClient.SendCallback");
                }
            }

            public void Dispose()
            {
                try
                {
                    if (Socket_Client_DeviceInterface != null)
                    {
                        if (Socket_Client_DeviceInterface.Connected)
                        {
                            try
                            {
                                //Socket_Client_DeviceInterface.Shutdown(SocketShutdown.Both);
                                Socket_Client_DeviceInterface.Disconnect(false);
                                Socket_Client_DeviceInterface.Close();
                            }
                            catch (Exception ex)
                            {
                                //LogEvent?.Invoke(13, "{0} : {1}".FormatA("Dispose", ex.Message));
                            }
                        }
                        //Socket_Client_DeviceInterface.Dispose();
                    }
                }
                catch (Exception e)
                {
                    TraceManager.AddLog(e.Source + " , " + e.StackTrace);
                }
            }
        }
    }
}
