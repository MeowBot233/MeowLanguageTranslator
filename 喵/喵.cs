using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 喵语翻译器
{
    public static class 喵
    {
        public static async Task<string> 喵喵EncodeAsync(string cat, bool zipcat = true) => await new Task<string>(() => { return 喵喵Encode(cat, zipcat); });
        public static async Task<string> 喵喵DecodeAsync(string cat) => await new Task<string>(() => { return 喵喵Decode(cat); });
        public static string 喵喵Encode(string cat, bool zipcat = true)
        {

            var 喵喵们 = Encoding.Unicode.GetBytes(cat);
            bool 压缩喵喵 = (喵喵们.Length > 50) && zipcat;
            if (压缩喵喵)
                喵喵们 = 喵变小(喵喵们);

            string 喵 = "";
            foreach (byte 一只喵 in 喵喵们)
            {
                System.Diagnostics.Debug.WriteLine(Convert.ToString(一只喵, 2).PadLeft(8, '0'));
                喵 += Convert.ToString(一只喵, 2).PadLeft(8, '0');
            }
            string 喵喵 = 变成喵(喵.TrimStart('0'));

            if (压缩喵喵)
                return 喵喵 + "Σ(っ°Д°;)っ";
            else return 喵喵 + "_(:з」∠)_";
        }
        public static string 喵喵Decode(string cat)
        {
            // 替换nia为nya 兼容旧版本
            cat = cat.Replace("nia", "nya");
            string 喵 = "", 小喵 = "";
            if (!(cat.EndsWith("_(:з」∠)_") || cat.EndsWith("Σ(っ°Д°;)っ")))
                throw new Exception();
            bool 压缩喵喵 = cat.EndsWith("Σ(っ°Д°;)っ");
            foreach(char 一只喵 in cat)
            {
                小喵 += 一只喵;
                if (一只喵 == '！'|| 一只喵 == '？'|| 一只喵 == '～'|| 一只喵=='。' || 一只喵 == '!' || 一只喵 == '?' || 一只喵 == '~' || 一只喵 == '.') { 喵 += 喵喵表.Forward[小喵]; 小喵 = ""; }
            }
            return 喵喵喵(喵, 压缩喵喵);
        }
        internal static string 喵喵喵(string cat,bool 压缩喵喵)
        {
            cat = cat.TrimStart('0');
            cat = cat.PadLeft(8 * (int)Math.Ceiling((double)cat.Length / 8), '0');

            List<byte> 所有的喵喵 = new List<byte>();
            for (int 喵喵的位置=0; 喵喵的位置<cat.Length; 喵喵的位置 += 8)
            {
                所有的喵喵.Add(Convert.ToByte(cat.Substring(喵喵的位置, 8), 2));
            }
            byte[] 最后的喵;
            if (压缩喵喵)
                最后的喵 = 喵变大(所有的喵喵.ToArray());
            else 最后的喵 = 所有的喵喵.ToArray();

            return Encoding.Unicode.GetString(最后的喵);
        }
        internal static string 变成喵(string cat)
        {
            cat = cat.PadLeft(喵喵的长度 * (int)Math.Ceiling((double)cat.Length / 喵喵的长度), '0');
            System.Diagnostics.Debug.WriteLine(cat);
            string 喵 = "";
            for (int 喵喵的位置 = 0; 喵喵的位置 < cat.Length; 喵喵的位置 += 喵喵的长度)
            {
                喵 += 喵喵表.Reverse[cat.Substring(喵喵的位置, 喵喵的长度)];
                
            }
            return 喵;
            
        }
        public static byte[] 喵变小(byte[] cat)
        {
            try
            {
                MemoryStream 喵喵流 = new MemoryStream();
                GZipStream 喵 = new GZipStream(喵喵流, CompressionMode.Compress, true);
                喵.Write(cat, 0, cat.Length);
                喵.Close();
                byte[] 喵喵 = new byte[喵喵流.Length];
                喵喵流.Position = 0;
                喵喵流.Read(喵喵, 0, 喵喵.Length);
                喵喵流.Close();
                return 喵喵;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static byte[] 喵变大(byte[] cat)
        {
            try
            {
                MemoryStream 喵 = new MemoryStream(cat);
                GZipStream 压缩喵喵 = new GZipStream(喵, CompressionMode.Decompress, true);
                MemoryStream 喵喵流 = new MemoryStream();
                byte[] 喵喵 = new byte[0x1000];
                while (true)
                {
                    int reader = 压缩喵喵.Read(喵喵, 0, 喵喵.Length);
                    if (reader <= 0)
                    {
                        break;
                    }
                    喵喵流.Write(喵喵, 0, reader);
                }
                压缩喵喵.Close();
                喵.Close();
                喵喵流.Position = 0;
                喵喵 = 喵喵流.ToArray();
                喵喵流.Close();
                return 喵喵;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private const int 喵喵的长度 = 5;
        internal static Map<string, string> 喵喵表 = new Map<string, string>()
        {
            {"!","00000" },
            {"?","00001" },
            {"~","00010" },
            {".","00011" },
            {"nya?","00100" },
            {"nya~","00101" },
            {"nya!","00110" },
            {"nya.","00111" },
            {"！","01000" },
            {"？","01001" },
            {"～","01010" },
            {"。","01011" },
            {"nya？","01100" },
            {"nya～","01101" },
            {"nya！","01110" },
            {"nya。","01111" },
            {"喵!","10000" },
            {"喵?","10001" },
            {"喵~","10010" },
            {"喵.","10011" },
            {"喵呜?","10100" },
            {"喵呜~","10101" },
            {"喵呜!","10110" },
            {"喵呜.","10111" },
            {"喵！","11000" },
            {"喵？","11001" },
            {"喵～","11010" },
            {"喵。","11011" },
            {"喵呜？","11100" },
            {"喵呜～","11101" },
            {"喵呜！","11110" },
            {"喵呜。","11111" },
        };
        
    }

}
