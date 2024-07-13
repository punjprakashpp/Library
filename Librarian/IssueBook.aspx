<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="IssueBook.aspx.cs" Inherits="BookIssue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            // Datepicker initialization
            $("#<%= txtIssueDate.ClientID %>").datepicker({
                dateFormat: 'dd-mm-yy'
            });

            $("#<%= txtReturnDate.ClientID %>").datepicker({
                dateFormat: 'dd-mm-yy'
            });
        });
    </script>
    <style type="text/css">
        .style1 { width: 746px; }
        .style4 { width: 717px; height: 276px; }
        .style5 { font-weight: 700; }
        .style6 { width: 216px; }
        .style8 { height: 183px; }
        .style7 { width: 452px; }
        .style9 { height: 48px; }
        .style13 { height: 27px; color: #000066; font-size: small; }
        .style14 { text-align: right; color: Green; width: 136px; }
        .style15 { height: 49px; }
        .auto-style2 {
            height: 34px;
        }
        .auto-style3 {
            text-align: right;
            color: #007bff;
            font-size: 12px;
            height: 29px;
            padding-right: 5px;
        }
        .auto-style4 {
            height: 29px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">ISSUE BOOK</td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="lbl">Roll No:</td>
                        <td><asp:TextBox ID="txtRollNo" runat="server" CssClass="txt"></asp:TextBox></td>
                        <td><asp:Button ID="btnFetchStudent" runat="server" CssClass="btn" Text="Fetch Student" OnClick="btnFetchStudent_Click" /></td>
                    </tr>
                    <tr>
                        <td class="lbl">Session:</td>
                        <td colspan="2"><asp:TextBox ID="txtSession" runat="server" CssClass="txt" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="lbl">Student Name:</td>
                        <td colspan="2"><asp:TextBox ID="txtStudentName" runat="server" CssClass="txt" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="lbl">Book No:</td>
                        <td class="auto-style2"><asp:TextBox ID="txtBookNo" runat="server" CssClass="txt"></asp:TextBox></td>
                        <td class="auto-style2"><asp:Button ID="btnFetchBook" runat="server" CssClass="btn" Text="Fetch Book Detail" OnClick="btnFetchBook_Click" /></td>
                    </tr>
                    <tr>
                        <td class="lbl">Book Name:</td>
                            <td colspan="2"><asp:TextBox ID="txtBookName" runat="server" CssClass="txt" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="lbl">Author:</td>
                            <td colspan="2" class="auto-style4"><asp:TextBox ID="txtAuthor" runat="server" CssClass="txt" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="lbl">Publication:</td>
                            <td colspan="2"><asp:TextBox ID="txtPublication" runat="server" CssClass="txt" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="lbl">Issue Date:</td>
                        <td colspan="2"><asp:TextBox ID="txtIssueDate" runat="server" CssClass="txt"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="lbl">Return Date:</td>
                        <td class="auto-style2"><asp:TextBox ID="txtReturnDate" runat="server" CssClass="txt"></asp:TextBox></td>
                        <td class="auto-style2"><asp:Button ID="btnIssueBook" runat="server" CssClass="btn" Text="Issue Book" OnClick="btnIssueBook_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="3"><asp:Label ID="lblMessage" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
