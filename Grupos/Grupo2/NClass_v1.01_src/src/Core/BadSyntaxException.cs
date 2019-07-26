using System;
using System.Runtime.Serialization;

namespace NClass.Core
{
	public class BadSyntaxException : Exception
	{
		public BadSyntaxException()
		{
		}

		public BadSyntaxException(string message) : base(message)
		{
		}

		public BadSyntaxException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected BadSyntaxException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public override string Message
		{
			get
			{
				if (InnerException != null)
					return InnerException.Message;
				else
					return base.Message;
			}
		}
	}
}
