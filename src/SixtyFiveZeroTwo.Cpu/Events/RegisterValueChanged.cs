using System;

namespace SixtyFiveZeroTwo.Cpu.Events
{
    public class RegisterValueChangedEventArgs : EventArgs
    {
        public RegisterValueChangedEventArgs(Registers.CpuRegisters register, ushort oldValue, ushort newValue, Flags flags)
        {
            Flags = flags ?? throw new ArgumentNullException(nameof(flags));
            Register = register;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public Registers.CpuRegisters Register { get; }

        public Flags Flags { get; }

        public ushort OldValue { get; }

        public ushort NewValue { get; }
    }
}
