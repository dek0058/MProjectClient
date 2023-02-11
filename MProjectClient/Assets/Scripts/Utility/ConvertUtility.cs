/*****************************************************************//**
 * \file   ConvertUtility.cs
 * \brief  타입 변환 유틸리티
 * 
 * \author dek0058
 * \date   2023-02-11
*********************************************************************/
using System;
using System.Runtime.InteropServices;

namespace mproject.utility {

    public static class ConvertUtility {

        public static T? ToObject<T>(byte[] _buffer, GCHandleType _type = GCHandleType.Pinned) where T : struct {
            GCHandle gc = GCHandle.Alloc(_buffer, _type);
            Object result = Marshal.PtrToStructure(gc.AddrOfPinnedObject(), typeof(T));
            gc.Free();
            return result != null ? (T)result : null;
        }

        public static byte[] ToBytes<T>(T _object, GCHandleType _type = GCHandleType.Pinned) where T : struct {
            int size = Marshal.SizeOf(_object);
            byte[] buffer = new byte[size];
            GCHandle gc = GCHandle.Alloc(buffer, _type);
            Marshal.StructureToPtr(_object, gc.AddrOfPinnedObject(), false);
            gc.Free();
            return buffer;
        }
        
    }

}


