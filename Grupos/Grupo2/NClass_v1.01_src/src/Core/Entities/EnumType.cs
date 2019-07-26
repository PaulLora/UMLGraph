using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace NClass.Core
{
	public abstract class EnumType : TypeBase
	{
		List<EnumItem> valueList;

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		protected EnumType(string name) : base(name)
		{
			valueList = new List<EnumItem>();
		}

		public IEnumerable<EnumItem> Values
		{
			get
			{
				for (int i = 0; i < ValueList.Count; i++)
					yield return ValueList[i];
			}
		}

		protected List<EnumItem> ValueList
		{
			get { return valueList; }
		}

		public override string Stereotype
		{
			get { return "«enumeration»"; }
		}

		/// <exception cref="BadSyntaxException">
		/// The name does not fit to the syntax.
		/// </exception>
		/// <exception cref="ReservedNameException">
		/// The name is a reserved name.
		/// </exception>
		public EnumItem AddValue(string declaration)
		{
			EnumItem value = EnumItem.LoadFromString(declaration);

			for (int i = 0; i < ValueList.Count; i++) {
				if (ValueList[i].Name == value.Name)
					throw new ReservedNameException(value.Name);
			}

			ValueList.Add(value);
			return value;
		}

		/// <exception cref="BadSyntaxException">
		/// The name does not fit to the syntax.
		/// </exception>
		/// <exception cref="ReservedNameException">
		/// The name is a reserved name.
		/// </exception>
		public EnumItem ModifyValue(EnumItem value, string declaration)
		{
			int index = ValueList.IndexOf(value);

			if (index >= 0) {
				EnumItem newValue = EnumItem.LoadFromString(declaration);

				for (int i = 0; i < ValueList.Count; i++) {
					if (i != index && ValueList[i].Name == newValue.Name)
						throw new ReservedNameException(newValue.Name);
				}

				ValueList[index] = newValue;
				return newValue;
			}
			else {
				return value;
			}
		}
		
		public void RemoveValue(EnumItem value)
		{
			ValueList.Remove(value);
		}

		public override void MoveUpItem(object item)
		{
			if (item is EnumItem)
				TypeHelper.MoveUpItem(ValueList, (EnumItem) item);
		}

		public override void MoveDownItem(object item)
		{
			if (item is EnumItem)
				TypeHelper.MoveDownItem(ValueList, (EnumItem) item);
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		internal override void Serialize(XmlNode node)
		{
			XmlElement child;

			base.Serialize(node);

			for (int i = 0; i < ValueList.Count; i++) {
				child = node.OwnerDocument.CreateElement("Value");
				child.SetAttribute("initValue", ValueList[i].InitValue.ToString());
				child.InnerText = ValueList[i].Name;
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

			XmlElement child = node["Value"];
			while (child != null) {
				if (child.Name == "Value")
					AddValue(child.InnerText);

				child = child.NextSibling as XmlElement;
			}
		}
	}
}
