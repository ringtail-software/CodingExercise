using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Nuix {
    public class General {
        private static readonly byte[] _key = {174, 64, 166, 211, 76, 51, 98, 233, 14, 113, 78, 251, 214, 180, 199, 192, 123, 103, 2, 32, 134, 213, 21, 63, 26, 141, 78, 166, 31, 111, 30, 198};
        private static readonly byte[] _vector = {75, 41, 15, 121, 223, 37, 104, 38, 28, 231, 55, 134, 26, 7, 140, 132};
        private static readonly int _bufferSize = 64;

        public static string Encrypt(string value) {
            using(Aes aes = Aes.Create()) {
                if(aes is null) return string.Empty;
                aes.Key = _key;
                aes.IV = _vector;
                aes.Padding = PaddingMode.Zeros;
                using(ICryptoTransform transform = aes.CreateEncryptor())
                using(var ms = new MemoryStream())
                using(var cs = new CryptoStream(ms, transform, CryptoStreamMode.Write)) {
                    byte[] sb = Encoding.Unicode.GetBytes(value);
                    for(int i = 0; i < sb.Length; i++) {
                        cs.WriteByte(sb[i]);
                    }

                    if(!cs.HasFlushedFinalBlock) {
                        cs.FlushFinalBlock();
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string DecryptB64(string value) {
            var b64Value = Convert.FromBase64String(value);
            using(Aes aes = Aes.Create()) {
                aes.Key = _key;
                aes.IV = _vector;
                aes.Padding = PaddingMode.Zeros;
                using(ICryptoTransform transform = aes.CreateDecryptor())
                using(var ins = new MemoryStream(b64Value))
                using(var os = new MemoryStream())
                using(var cs = new CryptoStream(ins, transform, CryptoStreamMode.Read)) {
                    var bResult = new byte[_bufferSize];
                    var read = cs.Read(bResult, 0, _bufferSize);
                    while(read > 0) {
                        os.Write(bResult, 0, read);
                        read = cs.Read(bResult, 0, _bufferSize);
                    }

                    if(!cs.HasFlushedFinalBlock) {
                        cs.FlushFinalBlock();
                    }

                    return Encoding.Unicode.GetString(os.ToArray());
                }
            }
        }
    }
}