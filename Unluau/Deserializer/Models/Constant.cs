using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unluau
{
	public enum ConstantType
	{
		Nil,
		Bool,
		Number,
		String,
		Import,
		Table,
		Closure
	}

	public abstract class Constant
	{
		public ConstantType Type { get; protected set; }
		public override abstract string ToString();
	}

	public class Constant<T> : Constant
	{
		public T Value { get; private set; }

		protected Constant(ConstantType type, T value)
		{
			Type = type;
			Value = value;
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}

	public class NilConstant : Constant<object>
	{
		public NilConstant()
			: base(ConstantType.Nil, null)
		{ }

		public override string ToString()
		{
			return "nil";
		}
	}

	public class BoolConstant : Constant<bool>
	{
		public BoolConstant(bool value)
			: base(ConstantType.Bool, value)
		{ }

		public override string ToString()
		{
			return Value ? "true" : "false";
		}
	}

	public class NumberConstant : Constant<double>
	{
		public NumberConstant(double value)
			: base(ConstantType.Number, value)
		{ }

        public override string ToString()
        {
			return Value.ToString();
        }
    }

	public class StringConstant : Constant<string>
	{
		public StringConstant(string value)
			: base(ConstantType.String, value)
		{ }
	}

	public class ImportConstant : Constant<IList<StringConstant>>
	{
		public ImportConstant(IList<StringConstant> names)
			: base(ConstantType.Import, names)
		{ }
	}

	public class TableConstant : Constant<IList<Constant>>
	{
		public TableConstant(IList<Constant> keys)
			: base(ConstantType.Table, keys)
		{ }
	}

	public class ClosureConstant : Constant<int>
	{
		public ClosureConstant(int index)
			: base(ConstantType.Closure, index)
		{ }
	}
}
