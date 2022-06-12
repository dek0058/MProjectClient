using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using MProject.Manager;

namespace MProject.Network {
    public class AsyncClient {

        private IPEndPoint ip_end_point;
        private Socket sock;

        private ManualResetEvent connect_done = new ManualResetEvent(false);
        private ManualResetEvent receive_done = new ManualResetEvent(false);
        private ManualResetEvent send_done = new ManualResetEvent(false);

        private bool connect_complete = false;

        public AsyncClient(byte[] _ip, int _port = 3333) {
            ip_end_point = new IPEndPoint(new IPAddress(_ip), _port);
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public bool IsConnected() {
            return sock.Connected;
        }

        public bool IsConnecteComplete() {
            return connect_complete;
        }

        public void Connect() {
            sock.BeginConnect(ip_end_point, new AsyncCallback(ConnectCallback), null);
            connect_done.WaitOne();

            if(false == IsConnected()) {
                Debug.LogWarning("Server connect fail!");
                return;
            } else {
                connect_complete = true;
            }

            Receive();
        }

        private void ConnectCallback(IAsyncResult _result) {
            if (false == IsConnected()) {
                Disconnect();
                return;
            }
            
            try {
                sock.EndConnect(_result);
                Debug.LogFormat("Socket connected to {0}", sock.RemoteEndPoint.ToString());
                connect_done.Set();
            } catch (Exception _exception) {
                Debug.LogError(_exception.ToString());
            }
        }

        public void Disconnect() {
            connect_complete = false;
            if (true == IsConnected()) {
                Debug.Log("Disconnect server");
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            }
        }        

        public void Receive() {
            if (false == IsConnected()) {
                Disconnect();
                return;
            }

            try {
                byte[] result = new byte[GlobalDefine.RECEIVE_PACKET_MAX_SIZE];
                sock.BeginReceive(result, 0, result.Length, 0, new AsyncCallback(ReceiveCallback), result);
                receive_done.WaitOne();
            } catch (Exception _exception) {
                Debug.Log(_exception.ToString());
            }
        }

        private void ReceiveCallback(IAsyncResult _result) {
            if (false == IsConnected()) {
                Disconnect();
                return;
            }

            try {
                int recv = sock.EndReceive(_result);
                if(recv >= GlobalDefine.PACKET_HEADER_SIZE) {
                    OnReceivePacket(_result.AsyncState as byte[]);
                } else {
                    // TODO : 패킷이 덜 받음    
                }
            } catch (Exception _exception) {
                Debug.Log(_exception.ToString());
            }
            receive_done.Set();
            Receive();
        }

        private void OnReceivePacket(byte[] _buffer) {
            if (_buffer.Length < GlobalDefine.PACKET_HEADER_SIZE) {
                return;
            }
            var buffer = new Span<byte>(_buffer);
            try {
                UInt32 tag = BitConverter.ToUInt32(buffer.Slice(0, GlobalDefine.PACKET_TAG_SIZE));
                UInt32 size = BitConverter.ToUInt32(buffer.Slice(GlobalDefine.PACKET_TAG_SIZE, GlobalDefine.PACKET_LEGNTH_SIZE));
                byte[] hash_code = buffer.Slice(8, GlobalDefine.PACKET_HASH_CODE_SIZE).ToArray();

                if (BitConverter.ToUInt32(hash_code, 0) == 0) { // 더 이상 받을 패킷이 없다.
                    return;
                }

                byte[] data = { 0 };
                if (size > 0) {
                    data = buffer.Slice(GlobalDefine.PACKET_HEADER_SIZE, Convert.ToInt32(size)).ToArray();
                }
                FPacket packet = new FPacket(tag, size, hash_code, data);
                NetworkManager.Instance.Handler_Manager.ReceivePacket(packet);
            } catch (Exception _e) {
                Debug.LogErrorFormat("[Exception]{0}", _e.Message);
            }
        }

        public void Send(FPacket _packet) {
            if (false == IsConnected()) {
                Disconnect();
                return;
            }
            
            try {
                var buffer = _packet.ToBuffer();
                sock.BeginSend(buffer, 0, buffer.Length, 0, new AsyncCallback(SendCallback), null);
                send_done.WaitOne();
            } catch (Exception _exception) {
                Debug.Log(_exception.ToString());
            }
        }

        private void SendCallback(IAsyncResult _result) {
            if (false == IsConnected()) {
                Disconnect();
                return;
            }

            try {
                int send_complete = sock.EndSend(_result);
                Debug.LogFormat("Send {0} bytes to server.", send_complete);
            } catch (Exception _exception) {
                Debug.Log(_exception.ToString());
            }
            send_done.Set();
        }
    }
}
