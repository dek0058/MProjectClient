using System;
using System.Text;

namespace MProject.Utility {
    public class UniversalToolkit {

        static public string Digest2Hex(byte[] _data) {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in _data) {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

    }
}
