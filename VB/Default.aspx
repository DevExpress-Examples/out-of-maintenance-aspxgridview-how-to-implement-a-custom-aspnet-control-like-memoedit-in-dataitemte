<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.20.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br/><br/><br/>
            <dx:ASPxHyperLink runat="server" ID="hyper1" NavigateUrl="Default2.aspx" Text="A Markup Way"></dx:ASPxHyperLink>            
            <br/><br/><br/>
            <dx:ASPxHyperLink runat="server" ID="hyper2" NavigateUrl="Default3.aspx" Text="A Code-Behind Way"></dx:ASPxHyperLink>
        </div>
    </form>
</body>
</html>