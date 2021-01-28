namespace SixtyFiveZeroTwo.Cpu.Instructions
{
    public class LdxImmediate : Instruction
    {
        public LdxImmediate() : base(0xA2, "LDX", 2) { }

        public override void Execute(Memory memory, Registers registers)
        {
            base.Execute(memory, registers);

            registers.X = Operands[0];
        }
    }
}