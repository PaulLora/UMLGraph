using System;
using System.Collections.Generic;

namespace NClass.Core
{
	public abstract class InterfaceType : OperationContainer, IInheritable
	{
		List<InterfaceType> baseList;

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		internal InterfaceType(string name) : base(name)
		{
			baseList = new List<InterfaceType>();
		}

		public IEnumerable<InterfaceType> Bases
		{
			get
			{
				for (int i = 0; i < BaseList.Count; i++)
					yield return BaseList[i];
			}
		}

		public bool HasBase
		{
			get { return BaseList.Count > 0; }
		}

		protected List<InterfaceType> BaseList
		{
			get { return baseList; }
		}

		public bool IsAllowedParent
		{
			get { return true; }
		}

		public bool IsAllowedChild
		{
			get { return true; }
		}

		public override string Stereotype
		{
			get { return "«interface»"; }
		}

		private bool IsAncestor(InterfaceType _interface)
		{
			for (int i = 0; i < baseList.Count; i++) {
				if (baseList[i].IsAncestor(_interface))
					return true;
			}
			return (_interface == this);
		}

		/// <exception cref="ArgumentException">
		/// The language of <paramref name="_base"/> does not equal.-or-
		/// <paramref name="_base"/> is earlier added base.-or-
		/// <paramref name="_base"/> is descendant of the interface.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="_base"/> is null.
		/// </exception>
		internal void AddBase(InterfaceType _base)
		{
			if (_base == null)
				throw new ArgumentNullException("_base");

			if (BaseList.Contains(_base)) {
				throw new ArgumentException("error_cannot_add_same_base_interface");
			}
			if (_base.IsAncestor(this)) {
					throw new ArgumentException("interface");
			}

			if (_base.Language != this.Language)
				throw new ArgumentException("error_languages_do_not_equal");

			BaseList.Add(_base);
		}

		internal void RemoveBase(InterfaceType _base)
		{
			bool v = BaseList.Remove(_base);
		}
	}
}
