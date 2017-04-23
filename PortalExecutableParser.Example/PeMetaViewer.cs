using System.ComponentModel.Design;
using System.Linq;

namespace ConsoleApplication2
{
    public class PeMetaViewer
    {
        public static PeMeta GetPeMeta(byte[] peContent)
        {
            var dosHeader = GetDosHeader(peContent);
            var dosStub = GetDosStub(peContent, dosHeader);
            var peHeader = GetPeHeader(peContent, dosHeader);
            var coffHeader = GetCoffHeader(peContent, dosHeader);
            return new PeMeta(dosHeader, dosStub, peHeader, coffHeader);
        }

        private static DosHeader GetDosHeader(byte[] peContent)
        {
            var dosSignature = peContent.Take(2).ToArray();
            var peHeaderOffset = peContent.Skip(0x3C).Take(4).ToArray();
            return new DosHeader(dosSignature, peHeaderOffset);
        }

        private static DosStub GetDosStub(byte[] peContent, DosHeader dosHeader)
        {
            return new DosStub(peContent.Skip(0x3C).Take(dosHeader.PeHeaderOffsetAsInt - 0x40).ToArray());
        }

        private static PeHeader GetPeHeader(byte[] peContent, DosHeader dosHeader)
        {
            var peSignature = peContent.Skip(dosHeader.PeHeaderOffsetAsInt).Take(4).ToArray();
            return new PeHeader(peSignature);
        }

        private static CoffHeader GetCoffHeader(byte[] peContent, DosHeader dosHeader)
        {
            var coffHeaderBytes = peContent.Skip(dosHeader.PeHeaderOffsetAsInt).Skip(4).Take(20).ToArray();
            var targetPlatform = coffHeaderBytes.Take(2).ToArray();
            var numberOfSections = coffHeaderBytes.Skip(2).Take(2).ToArray();
            var timeDateStamp = coffHeaderBytes.Skip(4).Take(4).ToArray();
            var pointerToSymbolTable = coffHeaderBytes.Skip(8).Take(4).ToArray();
            var numberOfSymbolTable = coffHeaderBytes.Skip(12).Take(4).ToArray();
            var sizeOfOptionalHeader = coffHeaderBytes.Skip(16).Take(2).ToArray();
            var characteristics = coffHeaderBytes.Skip(18).Take(2).ToArray();
            return new CoffHeader(targetPlatform, numberOfSections, timeDateStamp, pointerToSymbolTable,
                numberOfSymbolTable, sizeOfOptionalHeader, characteristics);
        }
    }
}