using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication2
{
    public class CoffHeader
    {
        private readonly Dictionary<ushort, string> platformCodes = new Dictionary<ushort, string>()
        {
            {332, "x86"},
            {34404, "x64"}
        };

        public byte[] TargetPlatform { get; }
        public byte[] NumberOfSections { get; }
        public byte[] TimeDateStamp { get; }
        public byte[] PointerToSymbolTable { get; }
        public byte[] NumberOfSymbolTable { get; }
        public byte[] SizeOfOptionalHeader { get; }
        public byte[] Characteristics { get; }

        public ushort TargetPlatformAsUInt16 => BitConverter.ToUInt16(TargetPlatform, 0);
        public ushort NumberOfSectionsAsUInt16 => BitConverter.ToUInt16(NumberOfSections, 0);
        public int TimeDateStampAsInt32 => BitConverter.ToInt32(TimeDateStamp, 0);
        public DateTime TimeDateStampAsDateTime => DateTimeOffset.FromUnixTimeSeconds(TimeDateStampAsInt32).DateTime;
        public int PointerToSymbolTableAsInt32 => BitConverter.ToInt32(PointerToSymbolTable, 0);
        public int NumberOfSymbolTableAsInt32 => BitConverter.ToInt32(NumberOfSymbolTable, 0);
        public ushort SizeOfOptionalHeaderAsUInt16 => BitConverter.ToUInt16(SizeOfOptionalHeader, 0);
        public ushort CharacteristicsAsUInt16 => BitConverter.ToUInt16(Characteristics, 0);

        public CoffHeader(byte[] targetPlatform, byte[] numberOfSections, byte[] timeDateStamp, byte[] pointerToSymbolTable,
            byte[] numberOfSymbolTable, byte[] sizeOfOptionalHeader, byte[] characteristics)
        {
            TargetPlatform = targetPlatform;
            NumberOfSections = numberOfSections;
            TimeDateStamp = timeDateStamp;
            PointerToSymbolTable = pointerToSymbolTable;
            NumberOfSymbolTable = numberOfSymbolTable;
            SizeOfOptionalHeader = sizeOfOptionalHeader;
            Characteristics = characteristics;
        }

        public override string ToString()
        {
            return new StringBuilder()
                .Append($"Target platform: {TargetPlatformAsUInt16}")
                .Append(Environment.NewLine)
                .Append($"Number of sections: {NumberOfSectionsAsUInt16}")
                .Append(Environment.NewLine)
                .Append($"TimeDateStamp: {TimeDateStampAsInt32} {TimeDateStampAsDateTime}")
                .Append(Environment.NewLine)
                .Append($"Pointer to symbol table (deprecated): {PointerToSymbolTableAsInt32}")
                .Append(Environment.NewLine)
                .Append($"Number of symbol table (deprecated): {NumberOfSymbolTableAsInt32}")
                .Append(Environment.NewLine)
                .Append($"Size of optional header: {SizeOfOptionalHeaderAsUInt16}")
                .Append(Environment.NewLine)
                .Append($"Characteristics: {CharacteristicsAsUInt16}")
                .ToString();
        }
    }
}