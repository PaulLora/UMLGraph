using System;
using System.Runtime.Serialization;

namespace NClass.Core
{
	public class ReservedNameException : BadSyntaxException
	{
		string name;

		public ReservedNameException() : base("error_reserved_name")
		{
			name = null;
		}

		public ReservedNameException(string name)
			: base("error_reserved_name")
		{
			this.name = name;
		}

		public ReservedNameException(string name, Exception innerException)
			: base("error_reserved_name")
		{
			this.name = name;
		}

		public string ReservedName
		{
			get { return name; }
		}
	}
}
