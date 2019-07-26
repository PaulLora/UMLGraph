using System;
using System.Collections;

namespace NClass.Core
{
    public abstract class ParameterCollection : CollectionBase, ICloneable
    {
        protected ParameterCollection()
        {
        }

        /// <exception cref="ArgumentNullException">
        /// <paramref name="collection"/> is null.
        /// </exception>
        protected ParameterCollection(ParameterCollection collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");

            Capacity = collection.Capacity;
            for (int i = 0; i < collection.InnerList.Count; i++)
                InnerList.Add(collection.InnerList[i]);
        }

        public Parameter this[int index]
        {
            get { return InnerList[index] as Parameter; }
        }

        public static ParameterCollection GetCollection(Language language)
        {
            return new CSharpParameterCollection();
        }

        public void Remove(Parameter parameter)
        {
            if (!InnerList.IsReadOnly && !InnerList.IsFixedSize)
                InnerList.Remove(parameter);
        }

        protected bool ReservedName(string name)
        {
            return ReservedName(name, -1);
        }

        protected bool ReservedName(string name, int index)
        {
            for (int i = 0; i < Count; i++)
            {
                if (((Parameter)InnerList[i]).Name == name && i != index)
                    return true;
            }
            return false;
        }

        /// <exception cref="BadSyntaxException">
        /// The <paramref name="declaration"/> does not fit to the syntax.
        /// </exception>
        /// <exception cref="ReservedNameException">
        /// The parameter name is already exists.
        /// </exception>
        public abstract Parameter Add(string declaration);

        /// <exception cref="BadSyntaxException">
        /// The <paramref name="declaration"/> does not fit to the syntax.
        /// </exception>
        /// <exception cref="ReservedNameException">
        /// The parameter name is already exists.
        /// </exception>
        public abstract Parameter ModifyParameter(Parameter parmeter, string declaration);

        /// <exception cref="BadSyntaxException">
        /// The <paramref name="declaration"/> does not fit to the syntax.
        /// </exception>
        public abstract void InitFromString(string declaration);

        public abstract object Clone();
    }
}
