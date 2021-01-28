namespace SixtyFiveZeroTwo.Cpu.Instructions
{
    /// <summary>
    /// Increment X
    /// </summary>
    public class Inx : Instruction
    {
        public Inx() : base("INX")
        {
            AddFlawor(0xE8, 1);
        }

        protected override void PerformExecute(Memory memory, Registers registers)
        {
            if (registers.X == byte.MaxValue)
            {
                registers.X++;
                registers.SetFlags(f => f.V = true);
            }
            else
            {
                registers.X++;
            }

            if (registers.X == 0x00)
            {
                registers.SetFlags(f => f.Z = true);
            }
        }
    }
}
