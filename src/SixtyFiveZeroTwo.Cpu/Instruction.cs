using System;

namespace SixtyFiveZeroTwo.Cpu
{
    public abstract class Instruction
    {
        public Instruction(byte opc, string name, byte length)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (length == 0)
            {
                throw new ArgumentException(nameof(length));
            }

            Opc = opc;
            Name = name;
            Length = length;
        }

        public void Execute(Memory memory, Registers registers)
        {
            _ = registers ?? throw new ArgumentNullException(nameof(registers));
            _ = memory ?? throw new ArgumentNullException(nameof(memory));

            if (Operands.Length != Length - 1)
            {
                throw new InvalidOperationException();
            }

            PerformExecute(memory, registers);

            BeginInstructionExecuted?.Invoke(this, this);
        }

        public void Load(params byte[] operands)
        {
            Operands = operands ?? throw new ArgumentNullException(nameof(operands));
        }

        protected abstract void PerformExecute(Memory memory, Registers registers);
        
        public byte Opc { get; }

        public string Name { get; }

        public byte Length { get; }

        public byte[] Operands { get; private set; } = new byte[] { };

        public event EventHandler<Instruction> BeginInstructionExecuted = delegate { };
    }
}
