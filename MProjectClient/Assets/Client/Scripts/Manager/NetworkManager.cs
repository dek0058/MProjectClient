using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using MProject.Utility;
using MProject.Network;
using MProject.Packet;
using MProject.Protocol;

namespace MProject.Manager {
    public class NetworkManager : USingleton<NetworkManager> {

        private SocketClient client;
        
        public SocketClient Client {
            get => client;
        }

        public HandlerManager Handler_Manager {
            get; private set;
        }

        public Action initialize_completed;

        public Queue<Action> recv_callback = new Queue<Action>();

        [SerializeField]
        private byte[] address = new byte[4];
        [SerializeField]
        private int port = 3333;

        protected override void Enable() {
;           client = new SocketClient(new IPAddress(address), port, GlobalDefine.PACKET_MAX_SIZE);
            Handler_Manager = new HandlerManager();
            Handler_Manager.RegisterHandler((UInt32)Tag.Create, new ProtocolMessageHandler());
        }
        

        public void Connect() {
            client.Accept();
        }

        public void SendPacket(FPacket _packet) {
            Client.SendPacket(_packet);
        }


        private void LateUpdate() {
            
            if(recv_callback.Count > 0) {
                recv_callback.Dequeue()();
            }

        }

    }
}
