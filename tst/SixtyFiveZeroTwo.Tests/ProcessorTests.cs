using System.Collections.Generic;
using SixtyFiveZeroTwo.Cpu;
using Xunit;

namespace SixtyFiveZeroTwo.Tests
{
    public class ProcessorTests
    {
        [Fact]
        public void Execute_WholeInstructionSet_Processed()
        {
            var machineCode = new List<byte>();
            var instructionSet = new InstructionSet();
            var processor = new Processor();

            foreach (var instruction in instructionSet.LegalInstructions)
            {
                foreach (var flawor in instruction.Flawors)
                {
                    machineCode.Add(flawor.Opc);

                    for (var i = 0; i < flawor.Length - 1; i++)
                    {
                        machineCode.Add(0xAA);
                    }
                }
            }

            processor.Execute(machineCode.ToArray());
        }
    }
}
