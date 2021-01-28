namespace SixtyFiveZeroTwo.Cpu.Instructions
{
    /// <summary>
    /// AND memory with accumulator
    /// </summary>
    public class And : Instruction
    {
        public And() : base("AND")
        {
            AddFlawor(0x29, 2);
        }

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
