using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unluau
{
    public class NumberLiteral : Expression, IComparable<double>
    {
        public double Value { get; protected set; }

        public NumberLiteral(double value)
            => Value = value;

        public override void Write(Output output)
        {
            output.Write(Value.ToString());
        }

        public int CompareTo(double other)
        {
            return Value.CompareTo(other);
        }
    }
}
