namespace NClass.Core
{
	public interface IConst
	{
		/// <exception cref="BadSyntaxException">
		/// <see cref="IsConst"/> is set to true while 
		/// <see cref="Field.InitialValue"/> is empty.
		/// </exception>
		bool IsConst
		{
			get;
			set;
		}

		bool CanSetConst
		{
			get;
		}
	}
}
