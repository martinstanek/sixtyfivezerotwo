namespace SixtyFiveZeroTwo.Cpu.Instructions
{
    /// <summary>
    /// Transfer Y to accumulator
    /// </summary>
    public class Tya : Instruction
    {
        public Tya() : base("TYA")
        {
            AddFlawor(0x98, 1);
        }

        protected override void PerformExecute(Memory memory, Registers registers)
        {
            registers.Ac = registers.Y;
        }
    }
}
