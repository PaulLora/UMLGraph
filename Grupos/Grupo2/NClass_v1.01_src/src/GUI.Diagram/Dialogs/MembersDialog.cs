using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	public partial class MembersDialog : Form
	{
		OperationContainer parent = null;
		Member member = null;
		bool locked = false;
		int attributeCount = 0;
		AccessModifier[] accessOrder = null;
		OperationModifier[] modifierOrder = null;
		bool changed = false;

		#region Enum orders

		static AccessModifier[] csharpAccessOrder = {
			AccessModifier.Public,
			AccessModifier.ProtectedInternal,
			AccessModifier.Internal,
			AccessModifier.Protected,
			AccessModifier.Private,
			AccessModifier.Default
		};

		static AccessModifier[] javaAccessOrder = {
			AccessModifier.Public,
			AccessModifier.Protected,
			AccessModifier.Private,
			AccessModifier.Default
		};

		static OperationModifier[] csharpModifierOrder = {
			OperationModifier.None,
			OperationModifier.Virtual,
			OperationModifier.Abstract,
			OperationModifier.Override,
			OperationModifier.Sealed
		};

		static OperationModifier[] javaModifierOrder = {
			OperationModifier.None,
			OperationModifier.Abstract,
			OperationModifier.Sealed
		};

		#endregion

		public MembersDialog()
		{
			InitializeComponent();
			lstMembers.SmallImageList = Icons.IconList;
		}

		public bool Changed
		{
			get { return changed; }
			private set { changed = value; }
		}

		private void UpdateTexts()
		{
			lblSyntax.Text = "syntax";
			lblName.Text = "name";
			lblType.Text = "type";
			lblAccess.Text = "access";
			lblModifier.Text = "modifier";
			lblInitValue.Text = "initial value";
			grpOtherModifiers.Text = "other modifiers";
			toolNewField.Text = "new field";
			toolNewMethod.Text = "new method";
			toolDelete.Text = "delete";
			lstMembers.Columns[1].Text = "name";
			lstMembers.Columns[2].Text = "type";
			lstMembers.Columns[3].Text = "access";
			lstMembers.Columns[4].Text = "modifier";
			btnClose.Text = "close";
		}

		public void ShowDialog(OperationContainer parent)
		{
			if (parent == null)
				return;

			this.parent = parent;
			this.Text = parent.Name;
			Changed = false;

			FillCollections(parent.Language);
			FillMembersList();
			if (lstMembers.Items.Count > 0) {
				lstMembers.Items[0].Focused = true;
				lstMembers.Items[0].Selected = true;
			}

			toolNewField.Visible = (parent is IFieldAllower);

			if (parent.Language == Language.CSharp) {
				accessOrder = csharpAccessOrder;
				modifierOrder = csharpModifierOrder;
			}
			else {
				accessOrder = javaAccessOrder;
				modifierOrder = javaModifierOrder;
			}

			errorProvider.SetError(txtSyntax, null);
			errorProvider.SetError(txtName, null);
			errorProvider.SetError(cboType, null);

			base.ShowDialog();
		}

		private void FillCollections(Language language)
		{
            cboType.Items.Clear();
            cboAccess.Items.Clear();
			cboModifier.Items.Clear();

			if (language == Language.CSharp) {
				cboAccess.Items.Add("Public");
				cboAccess.Items.Add("Protected Internal");
				cboAccess.Items.Add("Internal");
				cboAccess.Items.Add("Protected");
				cboAccess.Items.Add("Private");
				cboAccess.Items.Add("Default");

				cboModifier.Items.Add("None");
				cboModifier.Items.Add("Virtual");
				cboModifier.Items.Add("Abstract");
				cboModifier.Items.Add("Override");
				cboModifier.Items.Add("Sealed");
			}
			else {
				cboAccess.Items.Add("Public");
				cboAccess.Items.Add("Protected");
				cboAccess.Items.Add("Private");
				cboAccess.Items.Add("Default");

				cboModifier.Items.Add("None");
				cboModifier.Items.Add("Abstract");
				cboModifier.Items.Add("Final");
			}
            cboType.Items.Add("int");
            cboType.Items.Add("long");
            cboType.Items.Add("string");
            cboType.Items.Add("char");
            cboType.Items.Add("decimal");
            cboType.Items.Add("double");
            cboType.Items.Add("float");
            cboType.Items.Add("bool");
            cboType.Items.Add("byte");
        }

		private void FillMembersList()
		{
			lstMembers.Items.Clear();
			attributeCount = 0;

			if (parent is IFieldAllower) {
				foreach (Field field in ((IFieldAllower) parent).Fields)
					AddFieldToList(field);
			}

			foreach (Operation operation in parent.Operations)
				AddOperationToList(operation);

			DisableFields();
		}

		private ListViewItem AddFieldToList(Field field)
		{
			ListViewItem item = lstMembers.Items.Insert(attributeCount, "");

			item.Tag = field;
			item.ImageIndex = Icons.GetImageIndex(field);
			item.SubItems.Add(field.Name);
			item.SubItems.Add(field.Type);
			item.SubItems.Add(SyntaxHelper.GetAccessModifier(
				field.AccessModifier, parent.Language, false));
			item.SubItems.Add("");
			attributeCount++;

			return item;
		}

		private ListViewItem AddOperationToList(Operation operation)
		{
			ListViewItem item = lstMembers.Items.Add("");

			item.Tag = operation;
			item.ImageIndex = Icons.GetImageIndex(operation);
			item.SubItems.Add(operation.Name);
			item.SubItems.Add(operation.Type);
			item.SubItems.Add(SyntaxHelper.GetAccessModifier(
				operation.AccessModifier, parent.Language, false));
			item.SubItems.Add(SyntaxHelper.GetOperationModifier(
				operation.Modifier, parent.Language, false));

			return item;
		}

		private void ShowNewMember(Member actualMember)
		{
			if (locked || actualMember == null)
				return;
			else
				member = actualMember;

			RefreshValues();
		}

		private void RefreshValues()
		{
			if (member == null)
				return;

			locked = true;
			
			txtSyntax.Enabled = true;
			txtName.Enabled = true;
			txtSyntax.ReadOnly = (member is Destructor);
			txtName.ReadOnly = (member == null || member.IsNameReadonly);
			cboType.Enabled = (member != null && !member.IsTypeReadonly);
			cboAccess.Enabled = (member != null && member.CanSetAccess);
			cboModifier.Enabled = (member is Operation && ((Operation) member).CanSetModifier);
			txtInitialValue.Enabled = (member is Field);
			chkStatic.Enabled = (member != null && member.CanSetStatic);
			chkReadonly.Enabled = (member is Field);
			chkConst.Enabled = (member is IConst && ((IConst) member).CanSetConst);
			txtSyntax.Text = member.ToString();
			txtName.Text = member.Name;
			cboType.Text = member.Type;

            //// Type selection
            //for (int i = 0; i < accessOrder.Length; i++)
            //{
            //    if (accessOrder[i] == member.AccessModifier)
            //    {
            //        cboType.SelectedIndex = i;
            //        break;
            //    }
            //}

            // Access selection
            for (int i = 0; i < accessOrder.Length; i++) {
				if (accessOrder[i] == member.AccessModifier) {
					cboAccess.SelectedIndex = i;
					break;
				}
			}

			// Modifier selection
			if (member is Operation) {
				for (int i = 0; i < modifierOrder.Length; i++) {
					if (modifierOrder[i] == ((Operation) member).Modifier) {
						cboModifier.SelectedIndex = i;
						break;
					}
				}
			}
			else {
				cboModifier.Text = null;
			}

			chkStatic.Checked = member.IsStatic;
			if (member is Field) {
				chkReadonly.Checked = ((Field) member).IsReadonly;
				txtInitialValue.Text = ((Field) member).InitialValue;
			}
			else {
				chkReadonly.Checked = false;
				txtInitialValue.Text = null;
			}

			// Contant verifying
			if (member is IConst)
				chkConst.Checked = ((IConst) member).IsConst;
			else
				chkConst.Checked = false;

			RefreshMembersList();
			
			locked = false;

			errorProvider.SetError(txtSyntax, null);
			errorProvider.SetError(txtName, null);
			errorProvider.SetError(cboType, null);
		}

		private void RefreshMembersList()
		{
			ListViewItem item = null;

			if (lstMembers.FocusedItem != null)
				item = lstMembers.FocusedItem;
			else if (lstMembers.SelectedItems.Count > 0)
				item = lstMembers.SelectedItems[0];

			if (item != null && member != null) {
				item.ImageIndex = Icons.GetImageIndex(member);
				item.SubItems[1].Text = txtName.Text;
				item.SubItems[2].Text = cboType.Text;
				item.SubItems[3].Text = cboAccess.Text;
				item.SubItems[4].Text = cboModifier.Text;
			}
		}

		private void DisableFields()
		{
			member = null;

			locked = true;

			txtSyntax.Text = null;
			txtName.Text = null;
			cboType.Text = null;
			cboAccess.Text = null;
			cboModifier.Text = null;
			txtInitialValue.Text = null;
			chkStatic.Checked = false;
			chkReadonly.Checked = false;
			chkConst.Checked = false;

			txtSyntax.Enabled = false;
			txtName.Enabled = false;
			cboType.Enabled = false;
			cboAccess.Enabled = false;
			cboModifier.Enabled = false;
			txtInitialValue.Enabled = false;
			chkStatic.Enabled = false;
			chkReadonly.Enabled = false;
			chkConst.Enabled = false;
			toolDelete.Enabled = false;

			locked = false;
		}

		private void SwapListItems(ListViewItem item1, ListViewItem item2)
		{
			int image = item1.ImageIndex;
			item1.ImageIndex = item2.ImageIndex;
			item2.ImageIndex = image;

			object tag = item1.Tag;
			item1.Tag = item2.Tag;
			item2.Tag = tag;

			for (int i = 0; i < item1.SubItems.Count; i++) {
				string text = item1.SubItems[i].Text;
				item1.SubItems[i].Text = item2.SubItems[i].Text;
				item2.SubItems[i].Text = text;
			}
			Changed = true;
		}

		private void DeleteSelectedMember()
		{
			if (lstMembers.SelectedItems.Count > 0) {
				ListViewItem item = lstMembers.SelectedItems[0];
				int index = item.Index;

				if (item.Tag is Field)
					attributeCount--;
				parent.RemoveMember(item.Tag as Member);
				lstMembers.Items.Remove(item);
				Changed = true;

				int count = lstMembers.Items.Count;
				if (count > 0) {
					if (index >= count)
						index = count - 1;
					lstMembers.Items[index].Selected = true;
				}
				else {
					DisableFields();
				}
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			UpdateTexts();
		}

		private void PropertiesDialog_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				RefreshValues();
			else if (e.KeyCode == Keys.Enter)
				lstMembers.Focus();
		}

		private void txtSyntax_Validating(object sender, CancelEventArgs e)
		{
			if (!locked && member != null) {
				try {
					member.InitFromString(txtSyntax.Text);
					errorProvider.SetError(txtSyntax, null);
					RefreshValues();
				}
				catch (BadSyntaxException ex) {
					e.Cancel = true;
					errorProvider.SetError(txtSyntax, ex.Message);
				}
			}
		}

		private void txtName_Validating(object sender, CancelEventArgs e)
		{
			if (!locked && member != null) {
				try {
					member.Name = txtName.Text;
					errorProvider.SetError(txtName, null);
					RefreshValues();
				}
				catch (BadSyntaxException ex) {
					e.Cancel = true;
					errorProvider.SetError(txtName, ex.Message);
				}
			}
		}

		private void cboType_Validating(object sender, CancelEventArgs e)
		{
			if (!locked && member != null) {
				try {
					member.Type = cboType.Text;
					if (!cboType.Items.Contains(cboType.Text))
						cboType.Items.Add(cboType.Text);
					errorProvider.SetError(cboType, null);
					cboType.Select(0, 0);
					RefreshValues();
				}
				catch (BadSyntaxException ex) {
					e.Cancel = true;
					errorProvider.SetError(cboType, ex.Message);
				}
			}
		}

		private void cboAccess_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = cboAccess.SelectedIndex;

			if (!locked && member != null) {
				try {
					member.AccessModifier = accessOrder[index];
					RefreshValues();
					Changed = true;
				}
				catch {
					// Skips
				}
			}
		}
        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            member.Type = cboType.SelectedItem.ToString();
            RefreshValues();
            Changed = true;
        }
        private void cboModifier_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = cboModifier.SelectedIndex;

			if (!locked && member is Operation) {
				try {
					if (modifierOrder[index] == OperationModifier.Abstract &&
						((ClassType) parent).Modifier != InheritanceModifier.Abstract)
					{
						DialogResult result = MessageBox.Show(
							"abstract_changing", "confirmation",
							MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

						if (result == DialogResult.No) {
							RefreshValues();
							return;
						}
					}

					((Operation) member).Modifier = modifierOrder[index];
					RefreshValues();
					Changed = true;
				}
				catch {
					// Skips
				}
			}
		}

		private void txtInitialValue_Validating(object sender, CancelEventArgs e)
		{
			if (!locked && member is Field) {
				if (txtInitialValue.Text != "" && txtInitialValue.Text[0] == '"' &&
					!txtInitialValue.Text.EndsWith("\""))
				{
					txtInitialValue.Text += '"';
				}
				((Field) member).InitialValue = txtInitialValue.Text;
				RefreshValues();
			}
		}

		private void MemberChanged(object sender, EventArgs e)
		{
			if (!locked)
				Changed = true;
		}

		private void chkStatic_CheckedChanged(object sender, EventArgs e)
		{
			if (!locked && member != null) {
				try {
					member.IsStatic = chkStatic.Checked;
					RefreshValues();
					Changed = true;
				}
				catch  {
					// Skips
				}
			}
		}

		private void chkReadonly_CheckedChanged(object sender, EventArgs e)
		{
			if (!locked && member is Field) {
				try {
					((Field) member).IsReadonly = chkReadonly.Checked;
					RefreshValues();
					Changed = true;
				}
				catch {
					// Skips
				}
			}
		}

		private void chkConst_CheckedChanged(object sender, EventArgs e)
		{
			if (!locked && member is IConst) {
				try {
					((IConst) member).IsConst = chkConst.Checked;
					if (!chkConst.Checked && member is Field) {
						member.IsStatic = false;
						((Field) member).IsReadonly = false;
					}
					RefreshValues();
					Changed = true;
				}
				catch {
					// Skips
				}
			}
		}

		private void lstMembers_ItemSelectionChanged(object sender,
			ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected && e.Item.Tag is Member) {
				ShowNewMember((Member) e.Item.Tag);

				toolDelete.Enabled = true;
			}
			else {
				toolDelete.Enabled = false;
			}
		}

		private void lstMembers_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
				DeleteSelectedMember();
		}

		private void toolNewField_Click(object sender, EventArgs e)
		{
			if (parent is IFieldAllower) {
				Field field = ((IFieldAllower) parent).AddField("NewField");
				ListViewItem item = AddFieldToList(field);

				Changed = true;
				item.Focused = true;
				item.Selected = true;
				txtName.SelectAll();
				txtName.Focus();
			}
		}

		private void toolNewMethod_Click(object sender, EventArgs e)
		{
			Method method = parent.AddMethod("NewMethod");
			ListViewItem item = AddOperationToList(method);

			Changed = true;
			item.Focused = true;
			item.Selected = true;
			txtName.SelectAll();
			txtName.Focus();
		}

		private void toolDelete_Click(object sender, EventArgs e)
		{
			DeleteSelectedMember();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
    }
}