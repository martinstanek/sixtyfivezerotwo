using System;

namespace SixtyFiveZeroTwo.Cpu
{
    public class Dissassembler
    {
        private readonly InstructionSet _instructionSet;
        private readonly Registers _registers;
        private readonly Memory _memory;

        public Dissassembler(InstructionSet instructionSet, Registers registers, Memory memory)
        {
            _instructionSet = instructionSet ?? throw new ArgumentNullException(nameof(instructionSet));
            _registers = registers ?? throw new ArgumentNullException(nameof(registers));
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
        }

        public void SetPointer()
        {
            _registers.Pc = 0;
        }

        public Instruction? GetNextInstruction()
        {
            if (_registers.Pc >= _memory.Content.Length)
            {
                return null;
            }

            var opc = _memory.Content[_registers.Pc];
            var instruction = _instructionSet.DecodeInstruction(opc);
            var length = instruction.GetLength(opc);
            var operands = new byte[length - 1];

            if (length > 1)
            {
                Array.Copy(_memory.Content, _registers.Pc + 1, operands, 0, operands.Length);
            }

            instruction.Load(opc, operands);

            _registers.Pc += length;

            return instruction;
        }
    }
}