using System;
using System.Drawing;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	public abstract class OperationContainerShape : TypeShape
	{
		static MembersDialog membersDialog = new MembersDialog();
		static StringFormat accessFormat = new StringFormat(StringFormat.GenericTypographic);
		static SolidBrush memberBrush = new SolidBrush(Color.Black);

		static OperationContainerShape()
		{
			accessFormat.Alignment = StringAlignment.Center;
		}

		private static Font StaticFont
		{
			get { return Style.CurrentStyle.StaticMemberFont; }
		}

		private static Font AbstractFont
		{
			get { return Style.CurrentStyle.AbstractMemberFont; }
		}

		protected override void EditItems()
		{
			if (Entity is OperationContainer) {
				membersDialog.ShowDialog((OperationContainer) Entity);
				if (membersDialog.Changed)
					OnContentsChanged(EventArgs.Empty);
				Invalidate();
			}
		}

		private static string GetAccessString(Member member)
		{
			if (member == null)
				return string.Empty;

			switch (member.Access) {
				case AccessModifier.Public:
					return "+";

				case AccessModifier.Internal:
					return "~";

				case AccessModifier.ProtectedInternal:
				case AccessModifier.Protected:
					return "#";

				case AccessModifier.Private:
				default:
					return "-";
			}
		}
		
		private static string GetMemberString(Member member)
		{
			if (member == null)
				return string.Empty;

			return member.GetCaption(
				Settings.CurrentSettings.ShowType,
				Settings.CurrentSettings.ShowParameters,
				Settings.CurrentSettings.ShowParameterNames,
				Settings.CurrentSettings.ShowInitialValue);
		}

		private static bool IsVisibleMember(Member member)
		{
			if (member == null)
				return false;

			switch (member.Access) {
				case AccessModifier.Public:
					return Settings.CurrentSettings.IsPublicVisible;
				case AccessModifier.ProtectedInternal:
					return Settings.CurrentSettings.IsProtintVisible;
				case AccessModifier.Internal:
					return Settings.CurrentSettings.IsInternalVisible;
				case AccessModifier.Protected:
					return Settings.CurrentSettings.IsProtectedVisible;
				case AccessModifier.Private:
				default:
					return Settings.CurrentSettings.IsPrivateVisible;
			}
		}

		private void DrawMember(Graphics g, float height, Member member)
		{
			if (member == null)
				return;

			int marginSize = Style.CurrentStyle.MarginSize;
			Font memberFont;

			if (member.IsStatic) {
				memberFont = StaticFont;
			}
			else if (member is Operation &&
					((Operation) member).Modifier == OperationModifier.Abstract) {
				memberFont = AbstractFont;
			}
			else {
				memberFont = Font;
			}

			if (member is Field)
				memberBrush.Color = Style.CurrentStyle.AttributeColor;
			else
				memberBrush.Color = Style.CurrentStyle.OperationColor;

			if (Style.CurrentStyle.UseIcons) {
				float fontHeight = memberFont.GetHeight(g);
				float iconHeight = Icons.IconSize.Height;
				float recordHeight = Math.Max(fontHeight, iconHeight);

				if (fontHeight > iconHeight) {
					g.DrawImage(Icons.GetImage(member),
						new PointF(marginSize, height + (int) ((fontHeight - iconHeight) / 2)));
				}
				else {
					g.DrawImage(Icons.GetImage(member), new PointF(marginSize, height));
				}

				g.DrawString(GetMemberString(member), memberFont, memberBrush,
					new PointF(marginSize + Icons.IconSize.Width + IconSpacing,
					height + (float) Math.Ceiling((recordHeight - fontHeight) / 2)));
			}
			else {
				SizeF fontSize = g.MeasureString("+", Font, PointF.Empty, accessFormat);
				float leftMargin = fontSize.Width;

				g.DrawString(GetAccessString(member), Font, memberBrush,
					new PointF(marginSize + leftMargin / 2, height), accessFormat);

				g.DrawString(GetMemberString(member), memberFont, memberBrush,
					new PointF(marginSize + leftMargin, height));
			}
		}

		protected override void DrawContent(Graphics g)
		{
			float height = HeaderHeight + Style.CurrentStyle.MarginSize;
			float fontHeight = Font.GetHeight(g) + 1;

			if (Style.CurrentStyle.UseIcons)
				fontHeight = Math.Max(fontHeight, Icons.IconSize.Height + 1);

			if (Entity is IFieldAllower) {
				int fieldCount = 0;

				foreach (Field field in ((IFieldAllower) Entity).Fields) {
					if (IsVisibleMember(field)) {
						DrawMember(g, height, field);
						fieldCount++;
						height += fontHeight;
					}
				}
				if (fieldCount > 0)
					height += Style.CurrentStyle.MarginSize;
				DrawLine(g, (int) height);
				height += Style.CurrentStyle.MarginSize;
			}

			if (Entity is IOperationAllower) {
				foreach (Operation operation in ((IOperationAllower) Entity).Operations) {
					if (IsVisibleMember(operation)) {
						DrawMember(g, height, operation);
						height += fontHeight;
					}
				}
			}

			MinHeight = (int) height + Style.CurrentStyle.MarginSize;
		}
	}
}
