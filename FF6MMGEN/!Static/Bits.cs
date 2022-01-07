// This class is based on some code by giangurgolo
// ZONE DOCTOR - Final Fantasy 6 Editor
// Version: 3.18.4
// Date: August 26, 2013
// Available here: http://www.ff6hacking.com/wiki/doku.php?id=ff3:ff3us:util:start#source_code

namespace FF6MMGEN
{
    public static class Bits
    {
        public static byte[] SetShort(byte[] data, int offset, ushort set)
        {
            data[offset] = (byte) (set & 0xFF);
            data[offset + 1] = (byte) (set >> 8);
            return data;
        }

        public static ushort GetShort(byte[] data, int offset)
        {
            ushort ret = (ushort)(data[offset + 1] << 8);
            ret += (ushort)(data[offset]);

            return ret;
        }

        public static ushort[] GetShorts(byte[] data, int offset, int size)
        {
            ushort[] toGet = new ushort[size];

            for (int i = 0; i < size; i++)
            {
                toGet[i] = (ushort)(data[offset + 1 + (i * 2)] << 16);
                toGet[i] += data[offset + (i * 2)];
            }

            return toGet;
        }

        public static void SetInt24(byte[] data, int offset, int value)
        {
            data[offset++] = (byte)(value & 0xFF);
            data[offset++] = (byte)((value >> 8) & 0xFF);
            data[offset] = (byte)((value >> 16) & 0xFF);
        }

        public static int GetInt24(byte[] data, int offset)
        {
            int ret = 0;
            ret += (int)(data[offset + 2] << 16);
            ret += (int)(data[offset + 1] << 8);
            ret += (int)data[offset];

            return ret;
        }

        public static byte[] GetBytes(byte[] data, int offset, int size)
        {
            byte[] toGet = new byte[size];

            for (int i = 0; i < size; i++)
            {
                toGet[i] = data[offset + i];
            }

            return toGet;
        }

        public static void SetBytes(byte[] data, int offset, byte[] src)
        {
            for (int i = 0; i < src.Length && i < data.Length; i++)
            {
                data[offset + i] = src[i];
            }
        }
    }
}
