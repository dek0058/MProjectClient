/*****************************************************************//**
 * \file   IHeader.cs
 * \brief  패킷 헤더 정의
 * 
 * \author dek0058
 * \date   2023-02-11
*********************************************************************/
using System;
using System.Runtime.InteropServices;
using UnityEditor;

namespace mproject.network {
    
    public interface IHeader
    {
        public UInt32 Protocol_ID { get; }
        public UInt32 Protocol { get; }
        public GUID UUID { get; }
    }

    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 4, Size = 20)]
    public struct FHeader : IHeader {
        private static readonly UInt32 ID = 1;
        
        [FieldOffset(0)]
        public UInt32 protocol;

        [FieldOffset(4)]
        public GUID guid;

        public uint Protocol_ID => ref ID;

        public uint Protocol => protocol;

        public GUID UUID => guid;
        
        public FHeader(bool _ = true)
            => (protocol, guid) = (ID, GUID.Generate());
    }
}
