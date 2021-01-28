namespace SixtyFiveZeroTwo.Cpu.Instructions
{
    /// <summary>
    /// AND memory with accumulator (immediate)
    /// </summary>
    public class AndImmediate : Instruction
    {
        public AndImmediate() : base(0x29, "AND", 2) { }

        protected override void PerformExecute(Memory memory, Registers registers)
        {
            if ((registers.Ac & Operands[0]) > byte.MaxValue)
            {
                registers.SetFlags(f => f.V = true);
            }

            if ((registers.Ac & Operands[0]) == 0x00)
            {
                registers.SetFlags(f => f.Z = true);
            }

            registers.Ac &= Operands[0];
        }
    }
}
