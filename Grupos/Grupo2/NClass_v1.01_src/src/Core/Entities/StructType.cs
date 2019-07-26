using System;

namespace NClass.Core
{
	public sealed class StructType : FieldContainer
	{
		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		internal StructType(string name) : base(name)
		{
		}

		public override string Signature
		{
			get
			{
				return SyntaxHelper.GetAccessModifier(
					Access, Language.CSharp, false) + " Struct";
			}
		}

		public override string Stereotype
		{
			get { return "«struct»"; }
		}

		public override Language Language
		{
			get { return Language.CSharp; }
		}

		public override Method AddConstructor()
		{
			Constructor constructor = new CSharpConstructor(this);
			
			constructor.AccessModifier = AccessModifier.Public;
			OperationList.Add(constructor);
			return constructor;
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		public override Method AddMethod(string name)
		{
			Method method = new CSharpMethod(name, this);

			method.AccessModifier = AccessModifier.Public;
			OperationList.Add(method);
			return method;
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		public override Field AddField(string name)
		{
			Field field = new CSharpField(name, this);

			field.AccessModifier = AccessModifier.Public;
			FieldList.Add(field);
			return field;
		}

		/// <exception cref="ArgumentException">
		/// The language of <paramref name="interfaceType"/> does not equal.-or-
		/// <paramref name="interfaceType"/> is earlier implemented interface.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="interfaceType"/> is null.
		/// </exception>
		internal override void AddInterface(InterfaceType interfaceType)
		{
			if (!(interfaceType is CSharpInterface)) {
				throw new ArgumentException("error_interface_language");
			}

			base.AddInterface(interfaceType);
		}
	}
}
