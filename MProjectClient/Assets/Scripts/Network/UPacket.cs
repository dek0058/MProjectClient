/*****************************************************************//**
* \file   UPacket.cs
* \brief  패킷 정의
* 
* \author dek0058
* \date   2023-02-11
*********************************************************************/
using mproject.utility;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace mproject.network
{
    public class UPacket<THeader> where THeader : struct, IHeader {

        private readonly THeader header;
        private readonly byte[] buffer;

        public ref readonly THeader Header => ref header;
        public ReadOnlySpan<byte> Buffer => buffer;

        public UPacket(ReadOnlySpan<byte> _buffer) {
            int header_length = Marshal.SizeOf<THeader>();
            if(_buffer.Length < header_length) {
                throw new InvalidDataException(new String("Packet buffer is too small."));
            }
            THeader? temp = ConvertUtility.ToObject<THeader>(_buffer.ToArray());
            if(temp == null) {
                throw new NullReferenceException(new String("Header convert failure."));
            }
            header = temp.Value;
            buffer = _buffer[header_length.._buffer.Length].ToArray();
        }
    }
}



