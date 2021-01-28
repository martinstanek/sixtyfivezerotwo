namespace SixtyFiveZeroTwo.Cpu
{
    public class Memory
    {

        public void Load(byte[] memoryContent)
        {
            Content = memoryContent;
        }

        public byte[] Content { get; private set; } = new byte[] { };
    }
}
