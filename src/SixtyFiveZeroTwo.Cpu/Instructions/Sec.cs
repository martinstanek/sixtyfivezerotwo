namespace SixtyFiveZeroTwo.Cpu.Instructions
{
    /// <summary>
    /// Set carry flag
    /// </summary>
    public class Sec : Instruction
    {
        public Sec() : base(0x38, "SEC", 1) { }

        protected override void PerformExecute(Memory memory, Registers registers)
        {
            registers.SetFlags(s => s.C = true);
        }
    }
}
