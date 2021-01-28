using Shouldly;
using SixtyFiveZeroTwo.Cpu;
using Xunit;

namespace SixtyFiveZeroTwo.Tests
{
    public class FlagsTests
    {
        [Fact]
        public void Flags_RegisterIsZero_AllFlagsFalse()
        {
            var flags = new Flags(0);

            flags.B.ShouldBeFalse();
            flags.C.ShouldBeFalse();
            flags.D.ShouldBeFalse();
            flags.I.ShouldBeFalse();
            flags.N.ShouldBeFalse();
            flags.V.ShouldBeFalse();
            flags.Z.ShouldBeFalse();
        }

        [Fact]
        public void Flags_RegisterIsMaxValue_AllFlagsTrue()
        {
            var flags = new Flags(byte.MaxValue);

            flags.B.ShouldBeTrue();
            flags.C.ShouldBeTrue();
            flags.D.ShouldBeTrue();
            flags.I.ShouldBeTrue();
            flags.N.ShouldBeTrue();
            flags.V.ShouldBeTrue();
            flags.Z.ShouldBeTrue();
        }

        [Fact]
        public void AsStatusRegister_ValuesAreConverted()
        {
            var flags = new Flags
            {
                Z = true,
                I = true,
                N = true
            };

            var register = flags.AsStatusRegister();

            var newFlags = new Flags(register);

            newFlags.B.ShouldBeFalse();
            newFlags.C.ShouldBeFalse();
            newFlags.D.ShouldBeFalse();
            newFlags.V.ShouldBeFalse();

            newFlags.I.ShouldBeTrue();
            newFlags.N.ShouldBeTrue();
            newFlags.Z.ShouldBeTrue();
        }
    }
}
