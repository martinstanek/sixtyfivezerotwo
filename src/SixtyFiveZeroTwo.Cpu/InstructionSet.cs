using System.Collections.Generic;
using System.Linq;
using SixtyFiveZeroTwo.Cpu.Instructions;

namespace SixtyFiveZeroTwo.Cpu
{
    public class InstructionSet
    {
        private readonly List<Instruction> _instructionSet = new List<Instruction>()
        {
            new Nop(),
            new Inx(),
            new Iny(),
            new Txa(),
            new Txs(),
            new Tya(),
            new Sec(),
            new LdxImmediate(),
            new AndImmediate()
        };

        public Instruction DecodeInstruction(byte opc)
        {
            return _instructionSet.Single(i => i.Opc.Equals(opc));
        }
    }
}