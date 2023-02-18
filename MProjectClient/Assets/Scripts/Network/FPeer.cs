/*****************************************************************//**
 * \file   Peer.h
 * \brief  네트워크 연결 정보 구조체 정의
 * 
 * \author dek0058
 * \date   2023-02-18
 *********************************************************************/
using System;
using System.Net;
using UnityEditor;

namespace mproject.network {

    public struct FPeer {

        public GUID uuid;
        public EndPoint endpoint;
        public DateTime last_packet_timestamp;

        public FPeer(EndPoint _endpoint)
            => (endpoint, uuid, last_packet_timestamp) = (_endpoint, GUID.Generate(), DateTime.Now);

        public FPeer(EndPoint _endpoint, GUID _uuid)
            => (endpoint, uuid, last_packet_timestamp) = (_endpoint, _uuid, DateTime.Now);

        public FPeer(EndPoint _endpoint, GUID _uuid, DateTime _timestamp)
            => (endpoint, uuid, last_packet_timestamp) = (_endpoint, _uuid, _timestamp);
    }
    
}
