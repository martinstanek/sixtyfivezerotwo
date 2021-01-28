using System;
using SixtyFiveZeroTwo.Cpu.Events;

namespace SixtyFiveZeroTwo.Cpu
{
    public class Registers
    {
        private ushort _pc;
        private byte _ac;
        private byte _x;
        private byte _y;
        private byte _sr;
        private byte _sp;

        public enum CpuRegisters { Pc, Ac, X, Y, Sr, Sp }

        /// <summary>
        /// Program counter
        /// </summary>
        public ushort Pc
        {
            get => _pc;
            set => SetWideRegisterValue(CpuRegisters.Pc, ref _pc, value);
        }

        /// <summary>
        /// Accumulator
        /// </summary>
        public byte Ac
        {
            get => _ac;
            set => SetRegisterValue(CpuRegisters.Ac, ref _ac, value);
        }

        /// <summary>
        /// X register
        /// </summary>
        public byte X
        {
            get => _x;
            set => SetRegisterValue(CpuRegisters.X, ref _x, value);
        }

        /// <summary>
        /// Y register
        /// </summary>
        public byte Y
        {
            get => _y;
            set => SetRegisterValue(CpuRegisters.Y, ref _y, value);
        }

        /// <summary>
        /// Status register
        /// </summary>
        public byte Sr
        {
            get => _sr;
            set => SetRegisterValue(CpuRegisters.Sr, ref _sr, value);
        }

        /// <summary>
        /// Stack pointer
        /// </summary>
        public byte Sp
        {
            get => _sp;
            set => SetRegisterValue(CpuRegisters.Sp, ref _sp, value);
        }

        /// <summary>
        /// Status register as Flags
        /// </summary>
        public Flags Flags
        {
            get => new Flags(Sr);
            set => Sr = value.AsStatusRegister();
        }

        public void SetFlags(Action<Flags> flags)
        {
            _ = flags ?? throw new ArgumentNullException(nameof(flags));

            var newFlags = new Flags(Sr);

            flags(newFlags);

            Flags = newFlags;
        }

        public void ResetOverflow()
        {
            if (Flags.V)
            {
                SetFlags(f => f.V = false);
            }
        }

        private void SetRegisterValue(CpuRegisters register, ref byte currentValue, byte newValue)
        {
            var oldValue = currentValue;

            currentValue = newValue;

            ValueChanged?.Invoke(this, new RegisterValueChangedEventArgs(register, oldValue, newValue, new Flags(Sr)));
        }
        
        private void SetWideRegisterValue(CpuRegisters register, ref ushort currentValue, ushort newValue)
        {
            var oldValue = currentValue;

            currentValue = newValue;

            ValueChanged?.Invoke(this, new RegisterValueChangedEventArgs(register, oldValue, newValue, new Flags(Sr)));
        }

        public event EventHandler<RegisterValueChangedEventArgs> ValueChanged = delegate { };
    }
}
