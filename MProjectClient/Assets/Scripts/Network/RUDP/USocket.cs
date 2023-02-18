/*****************************************************************//**
 * \file   USocket.cs
 * \brief  C# UDRP 소켓
 * 
 * \author dek0058
 * \date   2023-02-11
 *********************************************************************/
using System;
using System.Net;
using UnityEngine;
using mproject.logger;

namespace mproject.network.rudp
{
    public class USocket<T> where T : struct, IHeader {

        //private readonly Int32 receive_packet_capacity;

        private FPeer self;

        private ref readonly FPeer Self => ref self;

        private readonly logger.ILogger logger;

        public USocket(

            logger.ILogger _logger
        ) {

            logger = _logger;
        }


        public void Dispose() {

        }
        
        public void Close() {

        }

        public void Connect(EndPoint _endpoint) {
            
        }

        public void AsyncSendTo(ReadOnlySpan<byte> _buffer, EndPoint _endpoint) {
            
        }

        public void AsyncSendToAll(ReadOnlySpan<byte> _buffer) {
            
        }

        private void OnReceive(IAsyncResult _result) {
        
        }

        private void Receive() {
            try {

            } catch(Exception _e) {
                logger.WriteLog(ELogLevel.Error, _e.Message);
            }
        }

        private void HeartBear() {



        }

    }
}


