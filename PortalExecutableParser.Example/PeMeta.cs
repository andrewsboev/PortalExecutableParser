using System;

namespace ConsoleApplication2
{
    public class PeMeta
    {
        public DosHeader DosHeader { get; }
        public DosStub DosStub { get; }
        public PeHeader PeHeader { get; }
        public CoffHeader CoffHeader { get; }

        public PeMeta(DosHeader dosHeader, DosStub dosStub, PeHeader peHeader, CoffHeader coffHeader)
        {
            DosHeader = dosHeader;
            DosStub = dosStub;
            PeHeader = peHeader;
            CoffHeader = coffHeader;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, DosHeader, DosStub, PeHeader, CoffHeader);
        }
    }
}