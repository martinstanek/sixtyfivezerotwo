namespace SixtyFiveZeroTwo.Cpu.Instructions
{
    /// <summary>
    /// Do nothing
    /// </summary>
    public class Nop : Instruction
    {
        public Nop() : base("NOP")
        {
            AddFlawor(0xEA, 1);
        }

        protected override void PerformExecute(Memory memory, Registers registers) { }
    }
}