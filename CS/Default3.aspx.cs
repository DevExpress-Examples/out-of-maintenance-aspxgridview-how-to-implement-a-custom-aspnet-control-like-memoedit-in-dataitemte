using DevExpress.Web;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default3 : System.Web.UI.Page {
	protected void ASPxGridView1_DataBinding(object sender, EventArgs e) {
		((sender as ASPxGridView).Columns["Description"] as GridViewDataColumn).DataItemTemplate = new MyDropDownEdit();
	}
	class MyDropDownEdit : ITemplate {
		public void InstantiateIn(Control container) {
			GridViewDataItemTemplateContainer gridContainer = (GridViewDataItemTemplateContainer)container;
			ASPxDropDownEdit dde = new ASPxDropDownEdit();
			dde.ID = "dde_" + gridContainer.VisibleIndex;
			container.Controls.Add(dde);

			dde.Width = new Unit(100, UnitType.Pixel);
			dde.PopupHorizontalAlign = PopupHorizontalAlign.RightSides;
			dde.DropDownWindowWidth = 250;
			dde.DropDownWindowHeight = new Unit(100, UnitType.Percentage);
			dde.AutoResizeWithContainer = true;
			dde.AutoPostBack = false;
			dde.ReadOnly = true;

			dde.DropDownWindowTemplate = new MyMemoEdit(container);

			dde.BackgroundImage.ImageUrl = "Images/image.png";
			dde.BackgroundImage.HorizontalPosition = "center";
			dde.BackgroundImage.VerticalPosition = "center";
			dde.BackgroundImage.Repeat = BackgroundImageRepeat.NoRepeat;

			dde.Value = gridContainer.Text;
			dde.CssClass += (string.IsNullOrEmpty((string)dde.Value)) ? "" : " visibility";

			dde.ClientInstanceName = "dde_" + gridContainer.VisibleIndex;
			dde.ClientSideEvents.DropDown = "OnDropDown";
			dde.JSProperties["cpIndex"] = gridContainer.VisibleIndex;
		}
	}
	class MyMemoEdit : ITemplate {
		Control outerContainer;
		public MyMemoEdit(Control container) {
			outerContainer = container;
		}
		public void InstantiateIn(Control container) {
			TemplateContainerBase ddeContainer = container as TemplateContainerBase;
			GridViewDataItemTemplateContainer gridContainer = (GridViewDataItemTemplateContainer)outerContainer;

			ASPxMemo memo = new ASPxMemo();
			memo.ID = "memo_" + gridContainer.VisibleIndex.ToString();
			memo.EnableTheming = true;
			ddeContainer.Controls.Add(memo);

			memo.CssClass += "memo";			
			memo.Width = new Unit(100, UnitType.Percentage);
			memo.Height = 200;
			memo.AutoResizeWithContainer = true;
			memo.AutoPostBack = false;

			memo.ClientInstanceName = "memo_" + gridContainer.VisibleIndex;

			ASPxButton saveButton = new ASPxButton();
			saveButton.ID = "saveButton_" + gridContainer.VisibleIndex;
			ddeContainer.Controls.Add(saveButton);
			saveButton.Text = "Save";
			saveButton.ClientSideEvents.Click = "OnSaveClick";
			saveButton.AutoPostBack = false;

			ASPxButton cancelButton = new ASPxButton();
			cancelButton.ID = "cancelButton_" + gridContainer.VisibleIndex;
			ddeContainer.Controls.Add(cancelButton);
			cancelButton.Text = "Cancel";
			cancelButton.ClientSideEvents.Click = "OnCancelClick";
			cancelButton.AutoPostBack = false;
		}
	}
}