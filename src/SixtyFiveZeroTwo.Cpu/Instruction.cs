using System;

namespace SixtyFiveZeroTwo.Cpu
{
    public class Instruction
    {
        public Instruction(byte opc, string name, byte length)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Opc = opc;
            Name = name;
            Length = length;
        }

        public virtual void Execute(Memory memory, Registers registers)
        {
            _ = registers ?? throw new ArgumentNullException(nameof(registers));
            _ = memory ?? throw new ArgumentNullException(nameof(memory));

            if (Operands.Length != Length - 1)
            {
                throw new InvalidOperationException();
            }

            BeginInstructionExecuted?.Invoke(this, this);
        }

        public void Load(params byte[] operands)
        {
            Operands = operands ?? throw new ArgumentNullException(nameof(operands));
        }

        public byte Opc { get; }

        public string Name { get; }

        public byte Length { get; }

        public byte[] Operands { get; private set; } = new byte[] { };

        public event EventHandler<Instruction> BeginInstructionExecuted = delegate {};
    }
}
