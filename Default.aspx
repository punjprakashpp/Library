<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>UDCA Automated Library</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <center>
    <div class="bg">
        <div id="head">
            <img src="img/logo/logo-head-lib.png" />
        </div>
        <div id="title">
            <h1>
                Welcome to Automated Library of UDCA</h1>
        </div>
        <div id="main">
            <div id="img">
                <img src="img/logo/logo-lib-back.png" />
            </div>
            <div id="login">
                <table class="tbl">
                    <tr>
                        <td class="tblhead" colspan="2">
                            Login Area
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:RadioButton ID="rdolibrary" runat="server" Checked="True" ForeColor="Green"
                                GroupName="a" Text="Librarian" />
                            &nbsp;<asp:RadioButton ID="rdosudent" runat="server" ForeColor="Green" GroupName="a"
                                Text="Student" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl">
                            Username :
                        </td>
                        <td>
                            <asp:TextBox ID="txtuname" runat="server" CssClass="txt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtuname"
                                ErrorMessage="!!!" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl">
                            Password : </td>
                        <td>
                            <asp:TextBox ID="txtupass" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtupass"
                                ErrorMessage="!!!" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnLogin" runat="server" CssClass="btn" Text="Login" Width="80px"
                                Font-Size="10pt" OnClick="btnLogin_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl" runat="server" Font-Size="11px" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
            </center>
    </form>
</body>
</html>
