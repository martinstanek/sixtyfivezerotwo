using System;
using System.Text;
using SixtyFiveZeroTwo.Cpu;

namespace SixtyFiveZeroTwo.Demo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("MOS 6502");

            var machineCode = new byte[]
            {
                0xEA,       // NOP
                0xA2, 0x41, // LDX 0x41
                0xE8,       // INX
                0xE8,       // INX
                0xE8,       // INX
                0xE8,       // INX
                0xEA,       // NOP
            };

            var processor = new Processor();

            processor.Registers.ValueChanged += (s, e) =>
            {
                if (e.Register == Registers.CpuRegisters.X)
                {
                    Console.WriteLine(Encoding.ASCII.GetString(new[] { (byte) e.NewValue }));
                }
            };

            processor.Execute(machineCode);

            Console.ReadLine();
        }
    }
}
