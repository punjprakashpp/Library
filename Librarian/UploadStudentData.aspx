<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="UploadStudentData.aspx.cs" Inherits="Library_Librarian_UploadStudentData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Upload Student Data</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">UPLOAD STUDENT DATA</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table align="center" class="style1">
                    <tr>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="txt" />
                            <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" CssClass="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                     <tr>
                        <td><asp:Label ID="lblmsg" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

