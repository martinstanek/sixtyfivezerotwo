namespace SixtyFiveZeroTwo.Cpu.Instructions
{
    /// <summary>
    /// Transfer X to Stack register
    /// </summary>
    public class Txs : Instruction
    {
        public Txs() : base(0x9A, "TXS", 1) { }

        protected override void PerformExecute(Memory memory, Registers registers)
        {
            registers.Sp = registers.X;
        }
    }
}
