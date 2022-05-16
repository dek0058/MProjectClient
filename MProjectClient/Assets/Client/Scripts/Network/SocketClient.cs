﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using MProject.Manager;

namespace MProject.Network {

    public class SocketClient : SocketAsyncEventArgs {

        private Socket sock;
        private IPEndPoint ip_end_point;
        private int max_packet_size;

        public Action connect_completed;
        public Action disconnect_completed;

        
        public SocketClient(IPAddress _ip_address, int _port, int _max_packet_size) {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ip_end_point = new IPEndPoint(_ip_address, _port);
            max_packet_size = _max_packet_size;

            RemoteEndPoint = ip_end_point;
            Completed += OnConnected;
        }

        private void OnConnected(object _sender, SocketAsyncEventArgs _args) {
            Completed -= OnConnected;
            sock = _args.ConnectSocket;
            UserToken = sock;
            SetBuffer(new byte[max_packet_size], 0, max_packet_size);
            Completed += OnReceive;
            connect_completed.Invoke();
            sock.ReceiveAsync(this);
        }

        private void OnReceive(object _sender, SocketAsyncEventArgs _args) {
            if (false == sock.Connected) {
                Debug.Log("Disconnect server");
                return;
            }

            if (_args.Buffer == null) {
                return;
            }

            var buffer = new Span<byte>(_args.Buffer);

            UInt32 tag = BitConverter.ToUInt32(buffer.Slice(0, GlobalDefine.PACKET_TAG_SIZE));
            UInt32 size = BitConverter.ToUInt32(buffer.Slice(GlobalDefine.PACKET_TAG_SIZE, GlobalDefine.PACKET_LEGNTH_SIZE));
            byte[] hash_code = buffer.Slice(8, GlobalDefine.PACKET_HASH_CODE_SIZE).ToArray();
            byte[] data = buffer.Slice(GlobalDefine.PACKET_HEADER_SIZE, Convert.ToInt32(size)).ToArray();
            FPacket packet = new FPacket(tag, size, hash_code, data);
            NetworkManager.Instance.Handler_Manager.ReceivePacket(packet);
            sock.ReceiveAsync(this);
        }

        public void Accept() {
            sock.ConnectAsync(this);
        }

        public void Disconnect() {
            sock.Disconnect(false);
            sock.Close();
            disconnect_completed.Invoke();
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
