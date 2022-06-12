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

        //private SocketClient client;
        private AsyncClient client;
        
        

        public HandlerManager Handler_Manager {
            get; private set;
        }

        public Queue<Action> recv_callback = new Queue<Action>();

        [SerializeField]
        private byte[] address = new byte[4];
        [SerializeField]
        private int port = 3333;


        public bool IsConnect() {
            return client.IsConnected(); // TODO &&
        }


        protected override void Enable() {
            client = new AsyncClient(address, port);
;           //client = new SocketClient(new IPAddress(address), port, GlobalDefine.PACKET_MAX_SIZE);
            Handler_Manager = new HandlerManager();
        }

        protected override void Quit() {
            client.Disconnect();
        }


        private void LateUpdate() {

            if (false == client.IsConnected()) {
                client.Connect();
                //client.Accept();
            }

            
            //if(true == client.IsConneteComplete()) {
                
            //    client.Sock.ReceiveAsync(client);4
            //}


            //if(recv_callback.Count > 0) {
            //    recv_callback.Dequeue()();
            //}

        }

        public void SendPacket(FPacket _packet) {
            Debug.LogFormat("[Send Packet]{0}", (Packet.Tag)_packet.tag);
            client.Send(_packet);
        }


        

    }
}
