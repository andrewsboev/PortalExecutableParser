using System;
using System.Text;

namespace ConsoleApplication2
{
    public class DosHeader
    {
        public byte[] DosSignature { get; }
        public byte[] PeHeaderOffset { get; }

        public string DosSignatureAsString => Encoding.ASCII.GetString(DosSignature);
        public int PeHeaderOffsetAsInt => BitConverter.ToInt32(PeHeaderOffset, 0);

        public DosHeader(byte[] dosSignature, byte[] peHeaderOffset)
        {
            DosSignature = dosSignature;
            PeHeaderOffset = peHeaderOffset;
        }

        public override string ToString()
        {
            return new StringBuilder()
                .Append($"DOS Signature: {DosSignatureAsString}")
                .Append(Environment.NewLine)
                .Append($"PE Header Offset: {PeHeaderOffsetAsInt}")
                .ToString();
        }
    }
}