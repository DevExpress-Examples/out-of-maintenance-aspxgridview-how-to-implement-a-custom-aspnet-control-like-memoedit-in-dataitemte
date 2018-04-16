Imports DevExpress.Web
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class Default3
    Inherits System.Web.UI.Page

    Protected Sub ASPxGridView1_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
        TryCast((TryCast(sender, ASPxGridView)).Columns("Description"), GridViewDataColumn).DataItemTemplate = New MyDropDownEdit()
    End Sub
    Private Class MyDropDownEdit
        Implements ITemplate

        Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
            Dim gridContainer As GridViewDataItemTemplateContainer = CType(container, GridViewDataItemTemplateContainer)
            Dim dde As New ASPxDropDownEdit()
            dde.ID = "dde_" & gridContainer.VisibleIndex
            container.Controls.Add(dde)

            dde.Width = New Unit(100, UnitType.Pixel)
            dde.PopupHorizontalAlign = PopupHorizontalAlign.RightSides
            dde.DropDownWindowWidth = 250
            dde.DropDownWindowHeight = New Unit(100, UnitType.Percentage)
            dde.AutoResizeWithContainer = True
            dde.AutoPostBack = False
            dde.ReadOnly = True

            dde.DropDownWindowTemplate = New MyMemoEdit(container)

            dde.BackgroundImage.ImageUrl = "Images/image.png"
            dde.BackgroundImage.HorizontalPosition = "center"
            dde.BackgroundImage.VerticalPosition = "center"
            dde.BackgroundImage.Repeat = BackgroundImageRepeat.NoRepeat

            dde.Value = gridContainer.Text
            dde.CssClass += If(String.IsNullOrEmpty(CStr(dde.Value)), "", " visibility")

            dde.ClientInstanceName = "dde_" & gridContainer.VisibleIndex
            dde.ClientSideEvents.DropDown = "OnDropDown"
            dde.JSProperties("cpIndex") = gridContainer.VisibleIndex
        End Sub
    End Class
    Private Class MyMemoEdit
        Implements ITemplate

        Private outerContainer As Control
        Public Sub New(ByVal container As Control)
            outerContainer = container
        End Sub
        Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
            Dim ddeContainer As TemplateContainerBase = TryCast(container, TemplateContainerBase)
            Dim gridContainer As GridViewDataItemTemplateContainer = CType(outerContainer, GridViewDataItemTemplateContainer)

            Dim memo As New ASPxMemo()
            memo.ID = "memo_" & gridContainer.VisibleIndex.ToString()
            memo.EnableTheming = True
            ddeContainer.Controls.Add(memo)

            memo.CssClass &= "memo"
            memo.Width = New Unit(100, UnitType.Percentage)
            memo.Height = 200
            memo.AutoResizeWithContainer = True
            memo.AutoPostBack = False

            memo.ClientInstanceName = "memo_" & gridContainer.VisibleIndex

            Dim saveButton As New ASPxButton()
            saveButton.ID = "saveButton_" & gridContainer.VisibleIndex
            ddeContainer.Controls.Add(saveButton)
            saveButton.Text = "Save"
            saveButton.ClientSideEvents.Click = "OnSaveClick"
            saveButton.AutoPostBack = False

            Dim cancelButton As New ASPxButton()
            cancelButton.ID = "cancelButton_" & gridContainer.VisibleIndex
            ddeContainer.Controls.Add(cancelButton)
            cancelButton.Text = "Cancel"
            cancelButton.ClientSideEvents.Click = "OnCancelClick"
            cancelButton.AutoPostBack = False
        End Sub
    End Class
End Class