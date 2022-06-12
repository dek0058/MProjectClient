using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace MProject.Network {
    public class StateObject {
        public Socket sock = null;
        public int buffer_size = GlobalDefine.RECEIVE_PACKET_MAX_SIZE;
        public byte[] buffer = new byte[GlobalDefine.RECEIVE_PACKET_MAX_SIZE];
        public FPacket packet;
    }
}
