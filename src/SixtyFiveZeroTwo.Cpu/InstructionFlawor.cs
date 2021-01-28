using System;

namespace SixtyFiveZeroTwo.Cpu
{
    public class InstructionFlawor
    {
        public InstructionFlawor(byte opc, byte length)
        {
            if (length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            Opc = opc;
            Length = length;
        }

        public byte Opc { get; }

        public byte Length { get; }
    }
}
