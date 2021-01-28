namespace SixtyFiveZeroTwo.Cpu.Instructions
{
    public class Nop : Instruction
    {
        public Nop() : base(0xEA, "NOP", 1) { }
    }
}