using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using MProject.Manager;
using MProject.Utility;

namespace MProject.Network {

    public class SocketClient : SocketAsyncEventArgs {

        private Socket sock;
        private IPEndPoint ip_end_point;
        private int max_packet_size;

        public Action connect_completed;
        public Action disconnect_completed;

        
        private bool connected = false;


        //! Getter

        public bool IsConnected() {
            return connected;
        }

        
        public SocketClient(IPAddress _ip_address, int _port, int _max_packet_size) {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ip_end_point = new IPEndPoint(_ip_address, _port);
            max_packet_size = _max_packet_size;

            RemoteEndPoint = ip_end_point;
            Completed += OnConnected;
        }

        private void OnConnected(object _sender, SocketAsyncEventArgs _args) {
            Debug.Log("Connect server");
            Completed -= OnConnected;
            sock = _args.ConnectSocket;
            UserToken = sock;
            SetBuffer(new byte[max_packet_size], 0, max_packet_size);
            Completed += OnReceive;
            if(null != connect_completed) {
                connect_completed.Invoke();
            }
            sock.ReceiveAsync(this);
        }

        private void OnReceive(object _sender, SocketAsyncEventArgs _args) {
            if (false == sock.Connected) {
                connected = false;
                Debug.Log("Disconnect server");
                return;
            }

            if (_args.Buffer == null) {
                return;
            }

            OnReceivePacket(_args.Buffer);

            
            var buffer = new Span<byte>(_args.Buffer);

            UInt32 tag = BitConverter.ToUInt32(buffer.Slice(0, GlobalDefine.PACKET_TAG_SIZE));
            UInt32 size = BitConverter.ToUInt32(buffer.Slice(GlobalDefine.PACKET_TAG_SIZE, GlobalDefine.PACKET_LEGNTH_SIZE));
            byte[] hash_code = buffer.Slice(8, GlobalDefine.PACKET_HASH_CODE_SIZE).ToArray();
            byte[] data = buffer.Slice(GlobalDefine.PACKET_HEADER_SIZE, Convert.ToInt32(size)).ToArray();
            FPacket packet = new FPacket(tag, size, hash_code, data);
            NetworkManager.Instance.Handler_Manager.ReceivePacket(packet);
            sock.ReceiveAsync(this);
        }

        private void OnReceivePacket(byte[] _buffer) {
            if(_buffer.Length < GlobalDefine.PACKET_HEADER_SIZE) {
                return;
            }
            var buffer = new Span<byte>(_buffer);
            UInt32 tag = BitConverter.ToUInt32(buffer.Slice(0, GlobalDefine.PACKET_TAG_SIZE));
            UInt32 size = BitConverter.ToUInt32(buffer.Slice(GlobalDefine.PACKET_TAG_SIZE, GlobalDefine.PACKET_LEGNTH_SIZE));
            byte[] hash_code = buffer.Slice(8, GlobalDefine.PACKET_HASH_CODE_SIZE).ToArray();
            byte[] data = buffer.Slice(GlobalDefine.PACKET_HEADER_SIZE, Convert.ToInt32(size)).ToArray();
            FPacket packet = new FPacket(tag, size, hash_code, data);
            NetworkManager.Instance.Handler_Manager.ReceivePacket(packet);

            //byte[] next = buffer.Slice(GlobalDefine.PACKET_HEADER_SIZE + Convert.ToInt32(size)).ToArray();
            //if (next.Length >= GlobalDefine.PACKET_HEADER_SIZE) {
            //    var next_buffer = new Span<byte>(next);
            //    UInt32 next_tag = BitConverter.ToUInt32(next_buffer.Slice(0, GlobalDefine.PACKET_TAG_SIZE));
            //    UInt32 next_size = BitConverter.ToUInt32(next_buffer.Slice(GlobalDefine.PACKET_TAG_SIZE, GlobalDefine.PACKET_LEGNTH_SIZE));
            //    byte[] next_hash_code = next_buffer.Slice(8, GlobalDefine.PACKET_HASH_CODE_SIZE).ToArray();
            //    if (next_tag != 0 && next_size != 0 && UniversalToolkit.Digest2Hex(next_hash_code) != "00000000000000000000000000000000") {
            //        OnReceivePacket(next);
            //    }
            //}
        }
        


        public void Accept() {
            if(true == IsConnected()) {
                return; // 연결 중이거나 연결되어 있으면 연결 요청을 하지 않는다.
            }
            connected = true;
            sock.ConnectAsync(this);
        }

        public void Disconnect() {
            Debug.Log("Disconnect server");
            connected = false;
            sock.Disconnect(false);
            sock.Close();
            
            if(null != disconnect_completed) {
                disconnect_completed.Invoke();
            }
        }

        public void SendPacket(FPacket _packet) {
            byte[] tag = BitConverter.GetBytes(_packet.tag);
            byte[] legnth = BitConverter.GetBytes(_packet.length);
            List<byte> data = new List<byte>();
            data.AddRange(tag);
            data.AddRange(legnth);
            data.AddRange(_packet.hash_code);
            data.AddRange(_packet.data);

            byte[] buffer = data.ToArray();
            sock.Send(buffer, SocketFlags.None);
        }

        
        

    }
}
