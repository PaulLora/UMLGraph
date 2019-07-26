using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace NClass.Core
{
    internal static class TypeHelper
    {
        /// <exception cref="ArgumentException">
        /// There is no such <paramref name="type"/> of <see cref="Member"/>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="parent"/> is null.
        /// </exception>
        /// <exception cref="BadSyntaxException">
        /// The <paramref name="memberName"/> does not fit to the syntax.
        /// </exception>
        private static Member GetMemberFromName(string type, string memberName,
            OperationContainer parent)
        {
            switch (type)
            {
                case "CSharpField":
                    return new CSharpField(memberName, parent);
                case "CSharpMethod":
                    return new CSharpMethod(memberName, parent);
                case "CSharpConstructor":
                    return new CSharpConstructor(parent);
                case "Destructor":
                    return new Destructor(parent);
                case "Property":
                    return new Property(memberName, parent);
                case "Event":
                    return new Event(memberName, parent);
                default:
                    throw new ArgumentException(
                        "error_member_type_does_not_exist");
            }
        }

        /// <exception cref="BadSyntaxException">
        /// The <paramref name="name"/> does not fit to the syntax.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// There is no such <paramref name="type"/> of <see cref="Entity"/>.
        /// </exception>
        internal static Entity GetEntityFromType(string type, string name)
        {
            switch (type)
            {
                case "CSharpClass":
                    return new CSharpClass(name);
                case "CSharpInterface":
                    return new CSharpInterface(name);
                case "CSharpEnum":
                    return new CSharpEnum(name);
                case "StructType":
                    return new StructType(name);
                case "DelegateType":
                    return new DelegateType(name);
                case "Comment":
                    return new Comment();
                default:
                    throw new ArgumentException(
                       "error_type_does_not_exist");
            }
        }

        /// <exception cref="ArgumentException">
        /// There is no such <paramref name="value"/> of <see cref="RelationType"/>.
        /// </exception>
        internal static RelationType ParseRelationType(string value)
        {
            try
            {
                return (RelationType)Enum.Parse(typeof(RelationType), value, true);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(
                    "error_relation_does_not_exist" + ex.Message);
            }
        }

        /// <exception cref="ArgumentException">
        /// <paramref name="memberType"/> is empty string.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="list"/> is null.-or-
        /// <paramref name="memberType"/> is null.-or-
        /// <paramref name="node"/> is null.-or-
        /// <paramref name="parent"/> is null.
        /// </exception>
        internal static void LoadMembers<T>(IList<T> list, string memberType, XmlNode node,
            OperationContainer parent) where T : Member
        {
            if (list == null)
                throw new ArgumentNullException("list");
            if (memberType == null)
                throw new ArgumentNullException("memberType");
            if (node == null)
                throw new ArgumentNullException("node");
            if (parent == null)
                throw new ArgumentNullException("parent");

            if (memberType == "")
            {
                throw new ArgumentException(
                    "error_empty_string", "memberType");
            }

            XmlElement child = node[memberType];
            while (child != null)
            {
                if (child.Name == memberType)
                {
                    string name = child.GetAttribute("name");
                    string type = child.GetAttribute("type");
                    try
                    {
                        Member member = GetMemberFromName(type, name, parent);
                        member.InitFromString(child.InnerText);
                        list.Add((T)member);
                    }
                    catch
                    {
                        // Skips incorrect node 
                    }
                }
                child = child.NextSibling as XmlElement;
            }
        }

        /// <exception cref="ArgumentException">
        /// <paramref name="memberType"/> is empty string.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="list"/> is null.-or-
        /// <paramref name="memberType"/> is null.-or-
        /// <paramref name="node"/> is null.
        /// </exception>
        internal static void SaveMembers<T>(IList<T> list, string memberType, XmlNode node)
            where T : Member
        {
            XmlElement child;

            if (list == null)
                throw new ArgumentNullException("list");
            if (memberType == null)
                throw new ArgumentNullException("memberType");
            if (node == null)
                throw new ArgumentNullException("node");

            if (memberType == "")
            {
                throw new ArgumentException(
                    "error_empty_string", "memberType");
            }

            for (int i = 0; i < list.Count; i++)
            {
                child = node.OwnerDocument.CreateElement(memberType);
                child.SetAttribute("name", list[i].Name);
                child.SetAttribute("type", list[i].GetType().Name);
                child.InnerText = list[i].ToString();
                node.AppendChild(child);
            }
        }

        internal static int MemberComparisonByName(Member mem1, Member member2)
        {
            return mem1.Name.CompareTo(member2.Name);
        }

        internal static int MemberComparisonByAccess(Member member1, Member member2)
        {
            int access1 = (int)member1.Access;
            int access2 = (int)member2.Access;

            if (access1 == access2)
                return MemberComparisonByKind(member1, member2);
            else
                return access1 - access2;
        }

        internal static int MemberComparisonByKind(Member member1, Member member2)
        {
            int ret = GetMemberOrdinal(member1) - GetMemberOrdinal(member2);

            if (ret == 0)
                return MemberComparisonByName(member1, member2);

            return ret;
        }

        private static int GetMemberOrdinal(Member member)
        {
            if (member is IConst && ((IConst)member).IsConst)
                return 0;
            if (member is Field)
                return 1;
            if (member is Property && ((Property)member).IsReadonly)
                return 2;
            if (member is Property && ((Property)member).IsWriteonly)
                return 3;
            if (member is Property)
                return 4;
            if (member is Constructor)
                return 5;
            if (member is IOperator && ((IOperator)member).IsOperator)
                return 6;
            if (member is Destructor)
                return 8; // (!)
            if (member is Method)
                return 7;
            if (member is Event)
                return 9;

            // Unreachable case
            return 10;
        }

        internal static void MoveUpItem(IList list, object item)
        {
            if (item == null)
                return;

            int index = list.IndexOf(item);
            if (index > 0)
            {
                object temp = list[index - 1];
                list[index - 1] = list[index];
                list[index] = temp;
            }
        }

        internal static void MoveDownItem(IList list, object item)
        {
            if (item == null)
                return;

            int index = list.IndexOf(item);
            if (index >= 0 && index < list.Count - 1)
            {
                object temp = list[index + 1];
                list[index + 1] = list[index];
                list[index] = temp;
            }
        }
    }
}
