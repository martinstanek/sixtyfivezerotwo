namespace SixtyFiveZeroTwo.Cpu.Instructions
{
    /// <summary>
    /// Increment Y
    /// </summary>
    public class Iny : Instruction
    {
        public Iny() : base(0xC8, "INY", 1) { }

        protected override void PerformExecute(Memory memory, Registers registers)
        {
            if (registers.Y == byte.MaxValue)
            {
                registers.Y++;
                registers.SetFlags(f => f.V = true);
            }
            else
            {
                registers.Y++;
            }

            if (registers.Y == 0x00)
            {
                registers.SetFlags(f => f.Z = true);
            }
        }
    }
}
