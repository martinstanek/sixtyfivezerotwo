using System;

namespace SixtyFiveZeroTwo.Cpu
{
    public class Flags
    {
        public Flags() { }

        public Flags(byte statusRegister)
        {
            bool[] result = new bool[8];

            for (var i = 0; i < 8; i++)
            {
                result[i] = (statusRegister & (1 << i)) != 0;
            }
             
            Array.Reverse(result);

            N = result[0];
            V = result[1];
            B = result[3];
            D = result[4];
            I = result[5];
            Z = result[6];
            C = result[7];
        }

        /// <summary>
        /// Negative
        /// </summary>
        public bool N { get; set; }

        /// <summary>
        /// Overflow
        /// </summary>
        public bool V { get; set; }

        /// <summary>
        /// Break
        /// </summary>
        public bool B { get; set; }

        /// <summary>
        /// Decimal
        /// </summary>
        public bool D { get; set; }

        /// <summary>
        /// Interrupt
        /// </summary>
        public bool I { get; set; }

        /// <summary>
        /// Zero
        /// </summary>
        public bool Z { get; set; }

        /// <summary>
        /// Carry
        /// </summary>
        public bool C { get; set; }

        public byte AsStatusRegister()
        {
            byte result = 0;
            var index = 0;

            foreach (var b in new bool[] { N, V, true, B, D, I, Z, C })
            {
                if (b)
                {
                    result |= (byte)(1 << (7 - index));
                }

                index++;
            }

            return result;
        }
    }
}
