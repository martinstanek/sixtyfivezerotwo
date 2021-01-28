using System;

namespace SixtyFiveZeroTwo.Cpu.Events
{
    public class RegisterValueChangedEventArgs : EventArgs
    {
        public RegisterValueChangedEventArgs(Registers.CpuRegisters register, ushort oldValue, ushort newValue)
        {
            Register = register;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public Registers.CpuRegisters Register { get; }

        public ushort OldValue { get; }

        public ushort NewValue { get; }
    }
}
