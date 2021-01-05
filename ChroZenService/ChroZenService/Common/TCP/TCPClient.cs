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
                    //Debug.WriteLine("=====================================SyncReceive=========================================");
                }
                else
                {
                    Debug.WriteLine("=====================================AsyncReceive=========================================");
                    //Debug.WriteLine("=====================================AsyncReceive=========================================");
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
                Debug.WriteLine(string.Format("ChroZen GC Process={0}, TCPClient : received PACKCODE queue pumping thread start", Process.GetCurrentProcess().ProcessName));

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
                                        Debug.WriteLine(string.Format("{0} {1}", wrappedPACKCODE.packcode.ToString(), ((T_PACKCODE_CHROZEN_INLET_SETTING)wrappedPACKCODE.packet).packet.btPortNo));
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
                        Debug.WriteLine(string.Format("{0}r\n{1}", ee.StackTrace, ee.Message));
                    }
                }
                Debug.WriteLine(string.Format("Chrozen GC : Process={0} TCPClient: Queue thread died", Process.GetCurrentProcess().ProcessName));
            }));
            threadQueue.Start();
        }
        private void RestartQueueThread()
        {
            try
            {
                threadQueue.Abort();
                Debug.WriteLine(string.Format("Chrozen GC : Process={0} : TCPClient: RestartQueueThread -> threadQueue aborted.", Process.GetCurrentProcess().ProcessName));
            }
            catch (Exception e)
            {

            }
            finally
            {
                InitQueue();
            }
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
                Debug.WriteLine(string.Format("TCPManager:InitTCP{0}r\n{1}", ee.StackTrace, ee.Message));
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
                Debug.WriteLine(string.Format("e.Message={0}, e.StackTrace={1}", e.Message, e.StackTrace));
            }
            try
            {
                Socket_Client_DeviceInterface.Disconnect(false);
            }
            catch (Exception e)
            {
                Debug.WriteLine(string.Format("e.Message={0}, e.StackTrace={1}", e.Message, e.StackTrace));
            }
            try
            {
                Socket_Client_DeviceInterface.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(string.Format("e.Message={0}, e.StackTrace={1}", e.Message, e.StackTrace));
            }

            Debug.WriteLine(string.Format("TCPClient:Disconnect"));
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
                        Debug.WriteLine("TCPClient : Disconnect and ReConnect");
                        EventManager.DisconnectedEvent();

                        InitTCP();
                        ConnectDevice(_ip, _port);
                        //YC_EventManager.SocketReConnectedEvent();
                    }
                }
                //else
                {
                    //Debug.WriteLine("TCPClient : Disconnect and ReConnect");
                    //YC_EventManager.ConnectErrorEvent();

                    //YC_EventManager.SocketReConnectedEvent();
                }
            }
            catch (Exception ee)
            {
                Debug.WriteLine(string.Format("TCPManager:ReConnect{0}r\n{1}", ee.StackTrace, ee.Message));
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
                Debug.WriteLine(string.Format("TCPManager:ConnectDevice{0}r\n{1}", ee.StackTrace, ee.Message));
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

                    Debug.WriteLine("INFORM SET 송신");

                    System.Diagnostics.Debug.WriteLine(string.Format("TCPClient : Connected"));
                    Debug.WriteLine("TCPClient : Connected");
                    //YC_EventManager.ConnectSuccessEvent();
                    Receive(Socket_Client_DeviceInterface);
                }

            }
            catch (Exception ee)
            {
                Debug.WriteLine(string.Format("TCPManager:ChrogenInterface_ConnectCallback{0}r\n{1}", ee.StackTrace, ee.Message));
                System.Diagnostics.Debug.WriteLine(string.Format("{0}\r\n{1}", ee.StackTrace, ee.Message));
                System.Diagnostics.Debug.WriteLine(string.Format("TCPClient : Connect Error"));
            }
            finally
            {
                if (!Socket_Client_DeviceInterface.Connected)
                {
                    ReConnect();
                    Debug.WriteLine("Exception : TCPClient.ChrogenInterface_ConnectCallback");
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

                Debug.WriteLine(string.Format("ReceiveAsync err : {0}, {1}", e.StackTrace, e.Message));
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
                Debug.WriteLine("Exception : TCPClient.Receive");
                Debug.WriteLine(string.Format("{0}r\n{1}", ee.StackTrace, ee.Message));
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
                Debug.WriteLine(string.Format("{0}r\n{1}", ee.StackTrace, ee.Message));
                System.Diagnostics.Debug.WriteLine(string.Format("{0}\r\n{1}", ee.StackTrace, ee.Message));
                System.Diagnostics.Debug.WriteLine(string.Format("TCPClient : ReceiveCallback Error"));
            }
        }

        byte[] reserveBytes = new byte[4096 * 4];
        int nReservedCount;

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
                                if (nReservedCount > 0)
                                {
                                    dissectedPacket = new byte[bytesRead + nReservedCount];
                                    Array.Copy(reserveBytes, 0, dissectedPacket, 0, nReservedCount);
                                    Array.Copy(state.rawBuffer, 0, dissectedPacket, nReservedCount, bytesRead);
                                    Debug.WriteLine(string.Format("=============================Reserve Handled============================== {0}", dissectedPacket.Length));
                                    nReservedCount = 0;
                                }
                                else
                                {
                                    //바이트 배열을 읽은 수 만큼 state.lengthedBuffer에 복사
                                    Array.Copy(state.rawBuffer, dissectedPacket, bytesRead);
                                }
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
                                    else
                                    {
                                        Array.Copy(dissectedPacket, reserveBytes, dissectedPacket.Length);
                                        nReservedCount = dissectedPacket.Length;
                                        Debug.WriteLine(string.Format("=============================Reserve Added============================== {0}", nReservedCount));
                                        break;
                                    }
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
                Debug.WriteLine("Exception : TCPClient.ReceiveCallback");
                Debug.WriteLine(string.Format("{0}r\n{1}", ee.StackTrace, ee.Message));
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
            //Debug.WriteLine(((E_PACKCODE)temp.nPacketCode).ToString() + " 수신");
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
                                    Debug.WriteLine(string.Format("{0}r\n{1}", ee.StackTrace, ee.Message));
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
                                //Debug.WriteLine("INFORM SET 송신");
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

                                Send(T_PACKCODE_CHROZEN_SPECIAL_FUNCTIONManager.MakePACKCODE_REQ());
                                Debug.WriteLine("접속 성공 직후 Method(Oven setting, Aux apc setting, Aux temp setting, Inlet setting, Det setting, Valve setting, Signal setting, Special function  REQ 송신");

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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(((E_PACKCODE)temp.nPacketCode).ToString());
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(((E_PACKCODE)temp.nPacketCode).ToString());
                                    DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_OVEN_SETTING>(packet);
                                    DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send = DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Received;
                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_OVEN_SETTING, DataManager.t_PACKCODE_CHROZEN_OVEN_SETTING_Send);
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                            else
                            {
                                try
                                {
                                    Debug.WriteLine(string.Format("{0}", (E_PACKCODE)temp.nPacketCode).ToString());
                                    receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_INLET_SETTING>(packet), E_PACKCODE.PACKCODE_CHROZEN_INLET_SETTING));
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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

                                    Debug.WriteLine(string.Format("T_PACKCODE_CHROZEN_DET_SETTING packet length : {0}", (uint)Marshal.SizeOf(packCode)));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(((E_PACKCODE)temp.nPacketCode).ToString());
                                    DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_VALVE_SETTING>(packet);
                                    DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send = DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Received;
                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_VALVE_SETTING, DataManager.t_PACKCODE_CHROZEN_VALVE_SETTING_Send);
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(((E_PACKCODE)temp.nPacketCode).ToString());
                                    DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_AUX_TEMP_SETTING>(packet);
                                    DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send = DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Received;

                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_AUX_TEMP_SETTING, DataManager.t_PACKCODE_CHROZEN_AUX_TEMP_SETTING_Send);
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                        }
                    }
                    break;

                case E_PACKCODE.PACKCODE_CHROZEN_LCD_APC_CALIB_READ: //Done
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
                                Send(T_PACKCODE_CHROZEN_LCD_APC_CALIB_READManager.MakePACKCODE_SET(DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Send.packet));
                            }
                        }
                        //Set
                        else
                        {
                            if (bIsSync)
                            {
                                try
                                {
                                    DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ>(packet);
                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_LCD_APC_CALIB_READ, DataManager.T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ_Received);
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                            else
                            {
                                try
                                {
                                    receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_LCD_APC_CALIB_READ>(packet), E_PACKCODE.PACKCODE_CHROZEN_LCD_APC_CALIB_READ));
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                        }
                    }
                    break;

                case E_PACKCODE.PACKCODE_CHROZEN_LCD_APC_SENSOR_VOLTAGE: //Done
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
                                    DataManager.T_PACKCODE_CHROZEN_LCD_APC_SENSOR_VOLTAGE_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_LCD_APC_SENSOR_VOLTAGE>(packet);
                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_LCD_APC_SENSOR_VOLTAGE, DataManager.T_PACKCODE_CHROZEN_LCD_APC_SENSOR_VOLTAGE_Received);
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                            else
                            {
                                try
                                {
                                    receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_LCD_APC_SENSOR_VOLTAGE>(packet), E_PACKCODE.PACKCODE_CHROZEN_LCD_APC_SENSOR_VOLTAGE));
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                        }
                    }
                    break;

                case E_PACKCODE.PACKCODE_CHROZEN_LCD_VOLTAGE_CHECK: //Done
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
                                Send(T_PACKCODE_CHROZEN_LCD_VOLTAGE_CHECKManager.MakePACKCODE_SET(DataManager.T_PACKCODE_CHROZEN_LCD_VOLTAGE_CHECK_Send.packet));
                            }
                        }
                        //Set
                        else
                        {
                            if (bIsSync)
                            {
                                try
                                {
                                    DataManager.T_PACKCODE_CHROZEN_LCD_VOLTAGE_CHECK_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_LCD_VOLTAGE_CHECK>(packet);
                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_LCD_VOLTAGE_CHECK, DataManager.T_PACKCODE_CHROZEN_LCD_VOLTAGE_CHECK_Received);
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                            else
                            {
                                try
                                {
                                    receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_LCD_VOLTAGE_CHECK>(packet), E_PACKCODE.PACKCODE_CHROZEN_LCD_VOLTAGE_CHECK));
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                        }
                    }
                    break;

                case E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP: //Done
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
                                Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXTEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUXTEMP_Send.tempPacket));
                            }
                        }
                        //Set
                        else
                        {
                            if (bIsSync)
                            {
                                try
                                {
                                    DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUXTEMP_Received = YC_Util.ByteToStruct<T_PACKCODE_LCD_COMMAND_TYPE_AUXTEMP>(packet);
                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP, DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUXTEMP_Received);
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                            else
                            {
                                try
                                {
                                    receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_LCD_COMMAND_TYPE_AUXTEMP>(packet), E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_AUXTEMP));
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                        }
                    }
                    break;

                case E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_SIGNAL: //Done
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
                                Send(T_PACKCODE_LCD_COMMAND_TYPE_SIGNALManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_SIGNAL_Send.signalPacket));
                            }
                        }
                        //Set
                        else
                        {
                            if (bIsSync)
                            {
                                try
                                {
                                    DataManager.T_PACKCODE_LCD_COMMAND_TYPE_SIGNAL_Received = YC_Util.ByteToStruct<T_PACKCODE_LCD_COMMAND_TYPE_SIGNAL>(packet);
                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_SIGNAL, DataManager.T_PACKCODE_LCD_COMMAND_TYPE_SIGNAL_Received);
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                            else
                            {
                                try
                                {
                                    receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_LCD_COMMAND_TYPE_SIGNAL>(packet), E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_SIGNAL));
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                        }
                    }
                    break;

                case E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN: //Done
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
                                Send(T_PACKCODE_LCD_COMMAND_TYPE_TEMPManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP_Send.tempPacket, E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));
                            }
                        }
                        //Set
                        else
                        {
                            if (bIsSync)
                            {
                                try
                                {
                                    DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP_Received = YC_Util.ByteToStruct<T_PACKCODE_LCD_COMMAND_TYPE_TEMP>(packet);
                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN, DataManager.T_PACKCODE_LCD_COMMAND_TYPE_TEMP_Received);
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                            else
                            {
                                try
                                {
                                    receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_LCD_COMMAND_TYPE_TEMP>(packet), E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_OVEN));
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                        }
                    }
                    break;

                case E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_INLET: //Done
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
                                switch (temp.nEventIndex)
                                {
                                    case 0:
                                        {
                                            Send(T_PACKCODE_LCD_COMMAND_TYPE_INLETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Send.inletPacket, 0));
                                        }
                                        break;
                                    case 1:
                                        {
                                            Send(T_PACKCODE_LCD_COMMAND_TYPE_INLETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET2_Send.inletPacket, 1));
                                        }
                                        break;
                                    case 2:
                                        {
                                            Send(T_PACKCODE_LCD_COMMAND_TYPE_INLETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET3_Send.inletPacket, 2));
                                        }
                                        break;
                                }
                            }
                        }
                        //Set
                        else
                        {
                            if (bIsSync)
                            {
                                try
                                {
                                    switch (temp.nEventIndex)
                                    {
                                        case 0:
                                            {
                                                DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Received = YC_Util.ByteToStruct<T_PACKCODE_LCD_COMMAND_TYPE_INLET>(packet);
                                                EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_INLET, DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET1_Received);
                                            }
                                            break;
                                        case 1:
                                            {
                                                DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET2_Received = YC_Util.ByteToStruct<T_PACKCODE_LCD_COMMAND_TYPE_INLET>(packet);
                                                EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_INLET, DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET2_Received);
                                            }
                                            break;
                                        case 2:
                                            {
                                                DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET3_Received = YC_Util.ByteToStruct<T_PACKCODE_LCD_COMMAND_TYPE_INLET>(packet);
                                                EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_INLET, DataManager.T_PACKCODE_LCD_COMMAND_TYPE_INLET3_Received);
                                            }
                                            break;
                                    }
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                            else
                            {
                                try
                                {
                                    receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_LCD_COMMAND_TYPE_INLET>(packet), E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_INLET));
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                        }
                    }
                    break;

                case E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_DET: //Done
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
                                switch(temp.nEventIndex)
                                {
                                    case 0:
                                        {
                                            Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET1_Send.detPacket));
                                        }
                                        break;
                                    case 1:
                                        {
                                            Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET2_Send.detPacket));
                                        }
                                        break;
                                    case 2:
                                        {
                                            Send(T_PACKCODE_LCD_COMMAND_TYPE_DETManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET3_Send.detPacket));
                                        }
                                        break;
                                }                                
                            }
                        }
                        //Set
                        else
                        {
                            if (bIsSync)
                            {
                                try
                                {
                                    switch(temp.nEventIndex)
                                    {
                                        case 0:
                                            {
                                                DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET1_Received = YC_Util.ByteToStruct<T_PACKCODE_LCD_COMMAND_TYPE_DET>(packet);
                                                EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_DET, DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET1_Received);
                                            }
                                            break;
                                        case 1:
                                            {
                                                DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET2_Received = YC_Util.ByteToStruct<T_PACKCODE_LCD_COMMAND_TYPE_DET>(packet);
                                                EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_DET, DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET2_Received);
                                            }
                                            break;
                                        case 2:
                                            {
                                                DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET3_Received = YC_Util.ByteToStruct<T_PACKCODE_LCD_COMMAND_TYPE_DET>(packet);
                                                EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_DET, DataManager.T_PACKCODE_LCD_COMMAND_TYPE_DET3_Received);
                                            }
                                            break;
                                    }                                    
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                            else
                            {
                                try
                                {
                                    receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_LCD_COMMAND_TYPE_DET>(packet), E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_DET));
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                        }
                    }
                    break;

                case E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_APCAUX: //Done
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
                                switch (temp.nEventIndex)
                                {
                                    case 0:
                                        {
                                            Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1_Send.auxPacket));
                                        }
                                        break;
                                    case 1:
                                        {
                                            Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2_Send.auxPacket));
                                        }
                                        break;
                                    case 2:
                                        {
                                            Send(T_PACKCODE_LCD_COMMAND_TYPE_AUXManager.MakePACKCODE_SET(DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3_Send.auxPacket));
                                        }
                                        break;
                                }

                            }
                        }
                        //Set
                        else
                        {
                            if (bIsSync)
                            {
                                try
                                {
                                    switch (temp.nEventIndex)
                                    {
                                        case 0:
                                            {
                                                DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1_Received = YC_Util.ByteToStruct<T_PACKCODE_LCD_COMMAND_TYPE_AUX>(packet);
                                                EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_APCAUX, DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX1_Received);
                                            }
                                            break;
                                        case 1:
                                            {
                                                DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2_Received = YC_Util.ByteToStruct<T_PACKCODE_LCD_COMMAND_TYPE_AUX>(packet);
                                                EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_APCAUX, DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX2_Received);
                                            }
                                            break;
                                        case 2:
                                            {
                                                DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3_Received = YC_Util.ByteToStruct<T_PACKCODE_LCD_COMMAND_TYPE_AUX>(packet);
                                                EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_APCAUX, DataManager.T_PACKCODE_LCD_COMMAND_TYPE_AUX3_Received);
                                            }
                                            break;
                                    }

                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                            else
                            {
                                try
                                {
                                    receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_LCD_COMMAND_TYPE_AUX>(packet), E_PACKCODE.PACKCODE_CHROZEN_LCD_CALIB_APCAUX));
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                        }
                    }
                    break;

                case E_PACKCODE.PACKCODE_CHROZEN_LCD_DIAG: //Done
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
                                Send(T_PACKCODE_CHROZEN_LCD_DIAGManager.MakePACKCODE_SET(DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Send.packet));
                            }
                        }
                        //Set
                        else
                        {
                            if (bIsSync)
                            {
                                try
                                {
                                    DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Received = YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_LCD_DIAG>(packet);
                                    EventManager.PACKCODE_ReceivceEvent(E_PACKCODE.PACKCODE_CHROZEN_LCD_DIAG, DataManager.T_PACKCODE_CHROZEN_LCD_DIAG_Received);
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
                                }
                            }
                            else
                            {
                                try
                                {
                                    receivedAsyncPACKCODE_queue.Enqueue(new W_CHROZEN_GC_PACKET_WITH_PACKCODE(YC_Util.ByteToStruct<T_PACKCODE_CHROZEN_LCD_DIAG>(packet), E_PACKCODE.PACKCODE_CHROZEN_LCD_DIAG));
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(string.Format("ParsePacket err : {0}, {1}", e.StackTrace, e.Message));
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
                Debug.WriteLine("Exception : TCPClient.Send");
                Debug.WriteLine(string.Format("{0}r\n{1}", ee.StackTrace, ee.Message));
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
                Debug.WriteLine(string.Format("{0}r\n{1}", ee.StackTrace, ee.Message));
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
                Debug.WriteLine(string.Format("{0}r\n{1}", ee.StackTrace, ee.Message));
                System.Diagnostics.Debug.WriteLine(string.Format("{0}\r\n{1}", ee.StackTrace, ee.Message));
                System.Diagnostics.Debug.WriteLine(string.Format("TCPClient : Send Error"));
            }
        }

        private void SendSync(Socket client, byte[] byteData)
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

                Debug.WriteLine("Exception : TCPClient.SendCallback");
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
                Debug.WriteLine(e.Source + " , " + e.StackTrace);
            }
        }
    }
}
