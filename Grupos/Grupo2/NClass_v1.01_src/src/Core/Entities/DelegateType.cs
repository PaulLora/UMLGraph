using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace NClass.Core
{
	public sealed class DelegateType : TypeBase
	{
		const string DefaultType = "void";

		ParameterCollection parameterList;
		string type;

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		internal DelegateType(string name) : base(name)
		{
			parameterList = new CSharpParameterCollection();
			Type = DefaultType;
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="value"/> does not fit to the syntax.
		/// </exception>
		public string Type
		{
			get { return type; }
			set { type = value; }
		}

		public IEnumerable<Parameter> Parameters
		{
			get
			{
				for (int i = 0; i < ParameterList.Count; i++)
					yield return ParameterList[i];
			}
		}

		private ParameterCollection ParameterList
		{
			get { return parameterList; }
		}
		
		public override string Signature
		{
			get
			{
				return SyntaxHelper.GetAccessModifier(
					Access, Language.CSharp, false) + " Delegate";
			}
		}

		public override string Stereotype
		{
			get { return "«delegate»"; }
		}

		public override Language Language
		{
			get { return Language.CSharp; }
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		internal override void Serialize(XmlNode node)
		{
			XmlElement child;

			base.Serialize(node);

			for (int i = 0; i < ParameterList.Count; i++) {
				child = node.OwnerDocument.CreateElement("Param");
				child.InnerText = ParameterList[i].ToString();
				node.AppendChild(child);
			}
		}

		/// <exception cref="BadSyntaxException">
		/// An error occured in building the class.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		internal override void Deserialize(XmlNode node)
		{
			base.Deserialize(node);

			XmlElement child = node["Param"];
			while (child != null) {
				if (child.Name == "Param") {
					try {
						ParameterList.Add(child.InnerText);
					}
					catch (BadSyntaxException) {
						// Skips incorrect node
					}
				}
				child = child.NextSibling as XmlElement;
			}
		}

		/// <exception cref="BadSyntaxException">
		/// The name does not fit to the syntax.
		/// </exception>
		/// <exception cref="ReservedNameException">
		/// The parameter name is already exists.
		/// </exception>
		public Parameter AddParameter(string declaration)
		{
			return ParameterList.Add(declaration);
		}

		/// <exception cref="BadSyntaxException">
		/// The name does not fit to the syntax.
		/// </exception>
		/// <exception cref="ReservedNameException">
		/// The parameter name is already exists.
		/// </exception>
		public Parameter ModifyParameter(Parameter parameter, string declaration)
		{
			return ParameterList.ModifyParameter(parameter, declaration);
		}

		public void RemoveParameter(Parameter parameter)
		{
			ParameterList.Remove(parameter);
		}

		public override void MoveUpItem(object item)
		{
			if (item is Parameter)
				TypeHelper.MoveUpItem(ParameterList, (Parameter) item);
		}

		public override void MoveDownItem(object item)
		{
			if (item is Parameter)
				TypeHelper.MoveDownItem(ParameterList, (Parameter) item);
		}
	}
}
