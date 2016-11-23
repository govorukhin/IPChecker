using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TypeExtensions
{
    public static class RandomExtensions
    {
        /// <summary>
        /// Возвращает случайный BigInteger от minValue(включительно) до maxValue(включительно).
        /// minValue и maxValue должны быть положительными.
        /// </summary>
        /// <param name="random"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static BigInteger Next(this Random random, BigInteger minValue, BigInteger maxValue)
        {
            if (minValue > maxValue)
                throw new ArgumentOutOfRangeException("minValue", "Значение minValue больше значения maxValue");

            BigInteger n = maxValue - minValue;            
            BigInteger random_0n = Next(random, n);
            BigInteger result = random_0n + minValue;

            return result;
        }


        /// <summary>
        /// Возвращает случайный BigInteger от 0 до maxValue(включительно).
        /// maxValue должен быть положительным.
        /// </summary>
        /// <param name="random"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static BigInteger Next(this Random random, BigInteger maxValue)
        {
            if (maxValue < 0)
                throw new ArgumentOutOfRangeException("maxValue", "Значение параметра maxValue меньше 0");

            BigInteger result = new BigInteger(RandomBigint_LittleEndianBytes(random, maxValue.ToByteArray()));
            return result;
        }



        // О порядке байтов 
        // Тут https://ru.wikipedia.org/wiki/Порядок_байтов сказано, что порядок байтов может быть разным у разных процессоров.
        // Однако про BigInteger https://msdn.microsoft.com/en-us/library/system.numerics.biginteger.tobytearray(v=vs.110).aspx 
        //                       https://msdn.microsoft.com/en-us/library/dd268207(v=vs.110).aspx
        // сказано что работает в прямом порядке. Значит с таким порядком и будем работать.
        //
        private static byte[] RandomBigint_LittleEndianBytes(this Random random, byte[] bytes)
        {                        
            byte valueSignificantByte = bytes.Last(); // значение старшего разряда
            byte valueRandom = Convert.ToByte(random.Next(valueSignificantByte + 1)); // от 0 до valueSignificantByte(включительно)
            byte[] otherBytes = new byte[0];

            if (bytes.Count() == 1)
            {
                return new byte[] { valueRandom };
            }
            else if (valueRandom == valueSignificantByte)
            {
                otherBytes = RandomBigint_LittleEndianBytes(random, bytes.Take(bytes.Count() - 1).ToArray());
            }
            else //if(valueRandom < valueSignificantByte)
            {               
                // Если случайное значение получилось меньше, чем у аргумента этой функции в текущем старшем разряде,
                // то значения остальных разрядов можно ослучайнивать не задумываясь. Например 100 > 099
                otherBytes = new byte[bytes.Count() - 1];
                random.NextBytes(otherBytes);
            }

            List<byte> result = new List<byte>();
            result.AddRange(otherBytes);
            result.Add(valueRandom);

            return result.ToArray();
        }
    }
}
