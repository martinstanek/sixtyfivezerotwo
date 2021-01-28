using System;
using SixtyFiveZeroTwo.Cpu.Events;

namespace SixtyFiveZeroTwo.Cpu
{
    public class Registers
    {
        private ushort _pc;
        private byte _x;

        public enum CpuRegisters { Pc, Ac, X, Y, Sr, Sp }

        public Registers() { }

        /// <summary>
        /// Program counter
        /// </summary>
        public ushort Pc
        {
            get => _pc;
            set => _pc = SetRegiserValue(CpuRegisters.Pc, _pc, value);
        }

        /// <summary>
        /// Accumulator
        /// </summary>
        public byte Ac { get; set; }

        /// <summary>
        /// X register
        /// </summary>
        public byte X
        {
            get => _x;
            set => _x = (byte) SetRegiserValue(CpuRegisters.X, _x, value);
        }

        /// <summary>
        /// Y register
        /// </summary>
        public byte Y { get; set; }

        /// <summary>
        /// Status register
        /// </summary>
        public byte Sr { get; set; }

        /// <summary>
        /// Stack pointer
        /// </summary>
        public byte Sp { get; set; }

        /// <summary>
        /// Status register as Flags
        /// </summary>
        public Flags Flags
        {
            get => new Flags(Sr);
            set => Sr = value.AsStatusRegister();
        }

        private ushort SetRegiserValue(CpuRegisters register, ushort currentValue, ushort newValue)
        {
            ValueChanged?.Invoke(this, new RegisterValueChangedEventArgs(register, currentValue, newValue));

            return newValue;
        }

        public event EventHandler<RegisterValueChangedEventArgs> ValueChanged = delegate { };
    }
}
