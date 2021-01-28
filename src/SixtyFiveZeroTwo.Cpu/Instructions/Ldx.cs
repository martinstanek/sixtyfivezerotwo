namespace SixtyFiveZeroTwo.Cpu.Instructions
{
    /// <summary>
    /// Load memory to X
    /// </summary>
    public class Ldx : Instruction
    {
        public Ldx() : base("LDX")
        {
            AddFlawor(0xA2, 2);
        }
        
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