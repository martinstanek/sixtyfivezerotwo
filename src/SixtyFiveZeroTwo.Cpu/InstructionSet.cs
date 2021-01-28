using System.Collections.Generic;
using System.Linq;
using SixtyFiveZeroTwo.Cpu.Instructions;

namespace SixtyFiveZeroTwo.Cpu
{
    public class InstructionSet
    {
        private readonly List<Instruction> _instructions = new List<Instruction>()
        {
            new Nop(),
            new Inx(),
            new Iny(),
            new Txa(),
            new Txs(),
            new Tya(),
            new Sec(),
            new Ldx(),
            new And()
        };

        public Instruction DecodeInstruction(byte opc)
        {
            return _instructions.Single(i => i.CanExecute(opc));
        }

        public IReadOnlyCollection<Instruction> LegalInstructions => _instructions;
    }
}