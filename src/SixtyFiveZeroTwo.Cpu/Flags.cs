namespace SixtyFiveZeroTwo.Cpu
{
    public class Flags
    {
        public Flags() { }

        public Flags(byte statusRegister) { }

        /// <summary>
        /// Negative
        /// </summary>
        public bool N { get; set; }

        /// <summary>
        /// Overflow
        /// </summary>
        public bool V { get; set; }

        /// <summary>
        /// Break
        /// </summary>
        public bool B { get; set; }

        /// <summary>
        /// Decimal
        /// </summary>
        public bool D { get; set; }

        /// <summary>
        /// Interrupt
        /// </summary>
        public bool I { get; set; }

        /// <summary>
        /// Zero
        /// </summary>
        public bool Z { get; set; }

        /// <summary>
        /// Carry
        /// </summary>
        public bool C { get; set; }

        public byte AsStatusRegister()
        {
            return 0;
        }
    }
}
