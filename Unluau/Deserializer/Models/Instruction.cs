using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unluau
{
    public class Instruction
    {
        private uint _value;

        public OpProperties GetProperties()
        {
            OpCode code = (OpCode)(Value & 0xFF);
            OpProperties properties;

            if (OpProperties.Map.TryGetValue(code, out properties))
                return properties;

            throw new DecompilerException(Stage.Deserializer, $"unhandled operation code ({code})");
        }

        public uint Value { 
            get { return _value; } 
            private set { _value = value; } 
        }

        public byte A
            => (byte)((_value >> 8) & 0xFF);

        public byte B
            => (byte)((_value >> 16) & 0xFF);

        public byte C
            => (byte)((_value >> 24) & 0xFF);

        public int D
            => (int)_value >> 16;

        public int E
            => (int)_value >> 8;

        public Instruction(uint value)
            => Value = value;
    }
}
