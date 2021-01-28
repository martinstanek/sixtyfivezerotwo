using System;
using System.Threading;

namespace SixtyFiveZeroTwo.Cpu
{
    public class Processor
    {
        private readonly Dissassembler _dissassembler;
        private readonly Registers _registers;
        private readonly Memory _memory;

        public Processor()
        {
            _memory = new Memory();
            _registers = new Registers();
            _dissassembler = new Dissassembler(new InstructionSet(), _registers, _memory);
        }

        public void Execute(byte[] program) => Execute(program, CancellationToken.None);

        public void Execute(byte[] program, CancellationToken cancellationToken)
        {
            _memory.Load(program);
            _dissassembler.SetPointer();

            while (true)
            {
                var instruction = _dissassembler.GetNextInstruction();

                if (cancellationToken.IsCancellationRequested || instruction == null)
                {
                    break;
                }

                instruction.Execute(_memory, _registers);

                InstructionExecuted?.Invoke(this, instruction);
            }
        }

        public Registers Registers => _registers;

        public event EventHandler<Instruction> InstructionExecuted = delegate { };
    }
}