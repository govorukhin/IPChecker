using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using TypeExtensions;

namespace TypeAddons
{
    public static class IPAddressOperations
    {        
        public static IPAddress CreateRandomIP(Random random, IPAddress minValue, IPAddress maxValue)
        {
            if(minValue.AddressFamily == maxValue.AddressFamily)
            {
                BigInteger from = IPToBigInteger(minValue);
                BigInteger to = IPToBigInteger(maxValue);
                BigInteger randomBigInt = random.Next(from, to);
                bool isIPV4 = minValue.AddressFamily == AddressFamily.InterNetwork;
                return BigIntegerToIP(randomBigInt, isIPV4);
            }
            else
                throw new ArgumentOutOfRangeException("", "Ip должны быть одинаковой версии");            
        }

        public static IPAddress[] CreateDiapasonIP(IPAddress minValue, IPAddress maxValue)
        {
            if (minValue.AddressFamily == maxValue.AddressFamily)
            {
                BigInteger from = IPToBigInteger(minValue);
                BigInteger to = IPToBigInteger(maxValue);
                bool isIPV4 = minValue.AddressFamily == AddressFamily.InterNetwork;

                List<IPAddress> result = new List<IPAddress>();
                for (BigInteger i = from; i <= to; i++)
                {
                    result.Add(BigIntegerToIP(i, isIPV4));                    
                }
                return result.ToArray();
            }
            else
                throw new ArgumentOutOfRangeException("", "Ip должны быть одинаковой версии");
        }


  


        // если IsIPV4 == false, будет делать для IPV6
        public static IPAddress BigIntegerToIP(BigInteger bigInt, bool IsIPV4)
        {
            if (IsIPV4)
                if (bigInt.ToByteArray().Count() > 4)
                    throw new OverflowException();
                else
                if (bigInt.ToByteArray().Count() > 16)
                    throw new OverflowException();

            byte[] clearedBytes = CopyArrayWithoutZeroBytesFromRight(bigInt.ToByteArray()); // Удаляем ноли справа
            byte[] bigEndianBytes = clearedBytes.Reverse().ToArray(); // Переводим в сетевой порядок разрядов

            // переписываем
            byte[] result = (IsIPV4) ? new byte[4] : new byte[16];
            int shift = result.Count() - bigEndianBytes.Count();
            for (int i = bigEndianBytes.Count() - 1; i >= 0; i--)
                result[i + shift] = bigEndianBytes[i];
            
            return new IPAddress(result);
        }


        public static BigInteger IPToBigInteger(IPAddress ip)
        {
            byte[] bytes = ip.GetAddressBytes();            
            BigInteger result = new BigInteger(bytes.Reverse().ToArray());

            return result;
        }



        // Переписывает массив байт без нолей справа.
        // Если в массиве байт все ноли, то вернёт массив из нулевого элемента исходного массива.
        public static byte[] CopyArrayWithoutZeroBytesFromRight(byte[] bytes)
        {
            // ищем первый байт !=0, или останавливаемся на байте с индеском 0
            int rightEgde = bytes.Count() - 1;
            while (!(rightEgde == 0 || bytes[rightEgde] != 0))
            {
                rightEgde--;
            }

            // Переписываем
            byte[] newBytes = new byte[rightEgde + 1];
            for (int i = 0; i <= rightEgde; i++)
                newBytes[i] = bytes[i];

            return newBytes.ToArray();
        }
    }
}
