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
            new LdxImmediate()
        };

        public Instruction DecodeInstruction(byte opc)
        {
            return _instructionSet.Single(i => i.Opc.Equals(opc));
        }
    }
}