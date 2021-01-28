namespace SixtyFiveZeroTwo.Cpu.Instructions
{
    /// <summary>
    /// Transfer X to accumulator
    /// </summary>
    public class Txa : Instruction
    {
        public Txa() : base("TXA")
        {
            AddFlawor(0x8A, 1);
        }

        protected override void PerformExecute(Memory memory, Registers registers)
        {
            registers.Ac = registers.X;
        }
    }
}
