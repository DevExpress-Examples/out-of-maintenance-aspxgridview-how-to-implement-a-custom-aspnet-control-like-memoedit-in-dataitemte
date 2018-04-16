<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<style>
		.visibility input[type="text"]{
			display:none;
		}
		.memo textarea {
			padding: 0px !important;
			resize: both;
			margin: 0px !important;
		}

		.memo td {
			padding: 0px !important;
		}
	</style>
	<script type="text/javascript">
		var dropDownEdit;
		var memo;

		function OnDropDown(s, e) {
			SetGlobalVariables(s);

			memo.SetText(dropDownEdit.GetValue());
		}
		function OnCancelClick(s, e) {
			dropDownEdit.HideDropDown();
		}
		function OnSaveClick(s, e) {
			dropDownEdit.SetValue(memo.GetValue());

			SetInputDisplayFormat(dropDownEdit);

			dropDownEdit.HideDropDown();
		}	
		function SetInputDisplayFormat(dde) {
			var input = dde.GetInputElement();
			input.style.display = (input.value != "") ? "none" : "block";
		}
		function SetGlobalVariables(dde) {
			dropDownEdit = dde;
			memo = ASPxClientControl.GetControlCollection().GetByName("memo_" + dde.cpIndex);
		}
	</script>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="SqlDataSource1">
				<Columns>
					<dx:GridViewDataColumn FieldName="CategoryID" VisibleIndex="0">
					</dx:GridViewDataColumn>
					<dx:GridViewDataColumn FieldName="CategoryName" VisibleIndex="1">
					</dx:GridViewDataColumn>
					<dx:GridViewDataColumn FieldName="Description" VisibleIndex="2">
						<DataItemTemplate>
							<dx:ASPxDropDownEdit ID="ASPxDropDownEdit1" runat="server" ReadOnly="true" Width="100" Height="100%"
								ClientInstanceName="dde" ClientVisible="true" OnLoad="ASPxDropDownEdit1_Load" PopupHorizontalAlign="RightSides">
								<BackgroundImage ImageUrl="~/Images/image.png" Repeat="NoRepeat" HorizontalPosition="center" VerticalPosition="center" />
								<ClientSideEvents DropDown="OnDropDown" />								
								<DropDownWindowTemplate>
									<dx:ASPxMemo ID="ASPxMemo1" ClientInstanceName="memo" runat="server" Height="200px" Width="250px" 
										OnLoad="ASPxMemo1_Load" CssClass="memo"></dx:ASPxMemo>
									<dx:ASPxButton ID="ASPxButton1" runat="server" Text="Save" AutoPostBack="false">
										<ClientSideEvents Click="OnSaveClick" />
									</dx:ASPxButton>
									<dx:ASPxButton ID="ASPxButton2" runat="server" Text="Cancel" AutoPostBack="false">
										<ClientSideEvents Click="OnCancelClick" />
									</dx:ASPxButton>
								</DropDownWindowTemplate>
							</dx:ASPxDropDownEdit>
						</DataItemTemplate>
					</dx:GridViewDataColumn>
				</Columns>
			</dx:ASPxGridView>
			<asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT * FROM Categories"
				ConnectionString="<%$ ConnectionStrings: NorthwindConnectionString %>">
			</asp:SqlDataSource>
		</div>
	</form>
</body>
</html>
