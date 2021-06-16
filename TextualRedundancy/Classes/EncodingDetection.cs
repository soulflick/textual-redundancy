using System;
using System.IO;
using System.Linq;
using System.Text;

namespace TextualRedundancy.Classes
{
    public class EncodingDetection
    {
        public static Encoding Detect(string filename)
        {
            byte[] bytes;

            try
            {
                bytes = File.ReadAllBytes(filename);
            }
            catch
            {
                return Encoding.Default;
            }

            string text = null;
            Encoding encoding = null;
            UTF8Encoding encUtf8Bom = new UTF8Encoding(true, true);

            bool couldBeUtf8 = true;
            byte[] preamble = encUtf8Bom.GetPreamble();
            int prLen = preamble.Length;

            if (bytes.Length >= prLen && preamble.SequenceEqual(bytes.Take(prLen)))
            {
                try
                {
                    text = encUtf8Bom.GetString(bytes, prLen, bytes.Length - prLen);
                    encoding = new UTF8Encoding(true, false);
                    return encoding;
                }
                catch (ArgumentException)
                {
                    couldBeUtf8 = false;
                }
            }
            if (couldBeUtf8 && encoding == null)
            {
                UTF8Encoding encUtf8NoBom = new UTF8Encoding(false, true);
                try
                {
                    encoding = encUtf8NoBom;
                    text = encUtf8NoBom.GetString(bytes, prLen, bytes.Length - prLen);
                    encoding = new UTF8Encoding(false, false);
                    return encoding;
                }
                catch (ArgumentException)
                {
                    encoding = null;
                }
            }
            if (encoding == null)
            {
                encoding = Encoding.GetEncoding(1252);
                try
                {
                    text = encoding.GetString(bytes);
                    return encoding;
                }
                catch
                {
                    "false".ToString();
                }
            }

            return Encoding.Default;
        }
    }
}
