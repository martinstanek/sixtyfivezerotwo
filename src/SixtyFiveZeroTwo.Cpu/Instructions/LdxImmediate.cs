namespace SixtyFiveZeroTwo.Cpu.Instructions
{
    /// <summary>
    /// Load memory to X (immediate)
    /// </summary>
    public class LdxImmediate : Instruction
    {
        public LdxImmediate() : base(0xA2, "LDX", 2) { }

        protected override void PerformExecute(Memory memory, Registers registers)
        {
            registers.X = Operands[0];

            if (registers.X == 0x00)
            {
                registers.SetFlags(f => f.Z = true);
            }
        }
    }
}