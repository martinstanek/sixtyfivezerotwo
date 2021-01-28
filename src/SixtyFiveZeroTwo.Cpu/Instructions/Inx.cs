namespace SixtyFiveZeroTwo.Cpu.Instructions
{
    public class Inx : Instruction
    {
        public Inx() : base(0xE8, "INX", 1) { }

        public override void Execute(Memory memory, Registers registers)
        {
            base.Execute(memory, registers);

            if (registers.X == byte.MaxValue)
            {
                registers.X++;
                registers.Flags.V = true; // figure out ie.: registers.SetFlag(f => f.V = true);
            }
            else
            {
                registers.X++;
            }            
        }
    }
}
