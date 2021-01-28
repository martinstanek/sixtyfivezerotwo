using System;
using System.Collections.Generic;
using System.Linq;

namespace SixtyFiveZeroTwo.Cpu
{
    public abstract class Instruction
    {
        private readonly List<InstructionFlawor> _flawors = new List<InstructionFlawor>();

        public Instruction(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
        }

        public void Execute(Memory memory, Registers registers)
        {
            _ = registers ?? throw new ArgumentNullException(nameof(registers));
            _ = memory ?? throw new ArgumentNullException(nameof(memory));
            
            if (Operands.Length != Flawors.Single(s => s.Opc == Opc).Length - 1)
            {
                throw new InvalidOperationException();
            }

            PerformExecute(memory, registers);

            BeginInstructionExecuted?.Invoke(this, this);
        }

        public void Load(byte opc, params byte[] operands)
        {
            Operands = operands ?? throw new ArgumentNullException(nameof(operands));

            if (!CanExecute(opc))
            {
                throw new InvalidOperationException();
            }

            Opc = opc;
        }

        public byte GetLength(byte opc)
        {
            return Flawors.Single(s => s.Opc == opc).Length;
        }

        public bool CanExecute(byte opc)
        {
            return Flawors.Any(s => s.Opc == opc);
        }

        protected abstract void PerformExecute(Memory memory, Registers registers);

        protected void AddFlawor(byte opc, byte length)
        {
            _flawors.Add(new InstructionFlawor(opc, length));
        }

        public byte Opc { get; private set; }

        public string Name { get; }

        public byte[] Operands { get; private set; } = new byte[] { };

        public IReadOnlyCollection<InstructionFlawor> Flawors => _flawors;

        public event EventHandler<Instruction> BeginInstructionExecuted = delegate { };
    }
}
