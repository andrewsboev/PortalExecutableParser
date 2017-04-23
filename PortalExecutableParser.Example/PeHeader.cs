using System.Text;

namespace ConsoleApplication2
{
    public class PeHeader
    {
        public byte[] PeSignature { get; }
        public string PeSignatureAsString => Encoding.ASCII.GetString(PeSignature);

        public PeHeader(byte[] bytes)
        {
            PeSignature = bytes;
        }

        public override string ToString()
        {
            return PeSignatureAsString;
        }
    }
}