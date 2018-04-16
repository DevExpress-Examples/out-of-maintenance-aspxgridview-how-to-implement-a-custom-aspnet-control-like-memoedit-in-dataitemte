Imports DevExpress.Web
Imports System

Partial Public Class Default2
    Inherits System.Web.UI.Page

    Protected Sub ASPxDropDownEdit1_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim dde As ASPxDropDownEdit = TryCast(sender, ASPxDropDownEdit)
        Dim container = TryCast(dde.NamingContainer, GridViewDataItemTemplateContainer)
        Dim index = container.VisibleIndex
        dde.ClientInstanceName = "dde_" & index
        dde.Value = ASPxGridView1.GetRowValues(index, "Description")
        dde.CssClass +=If(String.IsNullOrEmpty(CStr(dde.Value)), "", " visibility")
        dde.JSProperties("cpIndex") = index
    End Sub

    Protected Sub ASPxMemo1_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim memo As ASPxMemo = TryCast(sender, ASPxMemo)
        Dim container = TryCast(memo.NamingContainer.NamingContainer.NamingContainer.NamingContainer, GridViewDataItemTemplateContainer)
        Dim index = container.VisibleIndex
        memo.ClientInstanceName = "memo_" & index
    End Sub
End Class