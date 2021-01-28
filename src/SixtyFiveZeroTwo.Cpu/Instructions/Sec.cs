namespace SixtyFiveZeroTwo.Cpu.Instructions
{
    /// <summary>
    /// Set carry flag
    /// </summary>
    public class Sec : Instruction
    {
        public Sec() : base("SEC")
        {
            AddFlawor(0x38, 1);
        }

        protected override void PerformExecute(Memory memory, Registers registers)
        {
            registers.SetFlags(s => s.C = true);
        }
    }
}
