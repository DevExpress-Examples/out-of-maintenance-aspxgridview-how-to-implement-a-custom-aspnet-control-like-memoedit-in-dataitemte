using DevExpress.Web;
using System;

public partial class Default2 : System.Web.UI.Page {	
	protected void ASPxDropDownEdit1_Load(object sender, EventArgs e) {
		ASPxDropDownEdit dde = sender as ASPxDropDownEdit;
		var container = dde.NamingContainer as GridViewDataItemTemplateContainer;
		var index = container.VisibleIndex;
		dde.ClientInstanceName = "dde_" + index;
		dde.Value = ASPxGridView1.GetRowValues(index, "Description");		
		dde.CssClass +=(string.IsNullOrEmpty((string)dde.Value)) ? "":" visibility";
		dde.JSProperties["cpIndex"] = index;
	}

	protected void ASPxMemo1_Load(object sender, EventArgs e) {
		ASPxMemo memo = sender as ASPxMemo;
		var container = memo.NamingContainer.NamingContainer.NamingContainer.NamingContainer as GridViewDataItemTemplateContainer;
		var index = container.VisibleIndex;
		memo.ClientInstanceName = "memo_" + index;
	}
}