using System;
using System.Text;

namespace NClass.Core
{
	public abstract class Method : Operation
	{
		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parent"/> is null.
		/// </exception>
		protected Method(string name, OperationContainer parent) : base(name, parent)
		{
		}

		public override string GetCaption(bool getType, bool getParameters,
			bool getParameterNames, bool getInitValue)
		{
			StringBuilder builder = new StringBuilder(100);

			builder.AppendFormat("{0}(", Name);

			if (getParameters) {
				for (int i = 0; i < ParameterList.Count; i++) {
					builder.Append(ParameterList[i].GetCaption(getParameterNames));
					if (i < ParameterList.Count - 1)
						builder.Append(", ");
				}
			}

			if (getType && Type != null)
				builder.AppendFormat(") : {0}", Type);
			else
				builder.Append(")");

			return builder.ToString();
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder(100);

			if (AccessModifier != AccessModifier.Default) {
				builder.Append(SyntaxHelper.GetAccessModifier(AccessModifier, Language));
				builder.Append(" ");
			}
			if (Modifier != OperationModifier.None) {
				builder.Append(SyntaxHelper.GetOperationModifier(Modifier, Language));
				builder.Append(" ");
			}
			if (IsStatic) {
				builder.Append("static ");
			}

			if (string.IsNullOrEmpty(Type))
				builder.AppendFormat("{0}(", Name);
			else
				builder.AppendFormat("{0} {1}(", Type, Name);

			for (int i = 0; i < ParameterList.Count; i++) {
				builder.Append(ParameterList[i]);
				if (i < ParameterList.Count - 1)
					builder.Append(", ");
			}
			builder.Append(")");

			return builder.ToString();
		}
	}
}
