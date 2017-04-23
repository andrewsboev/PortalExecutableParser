using System.Text;

namespace ConsoleApplication2
{
    public class DosStub
    {
        public byte[] Content { get; }
        public string ContentAsString => Encoding.ASCII.GetString(Content);

        public DosStub(byte[] content)
        {
            Content = content;
        }

        public override string ToString()
        {
            return ContentAsString;
        }
    }
}