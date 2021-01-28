namespace SixtyFiveZeroTwo.Cpu.Instructions
{
    /// <summary>
    /// Do nothing
    /// </summary>
    public class Nop : Instruction
    {
        public Nop() : base(0xEA, "NOP", 1) { }

        protected override void PerformExecute(Memory memory, Registers registers) { }
    }
}