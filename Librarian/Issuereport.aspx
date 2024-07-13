<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="IssueReport.aspx.cs" Inherits="Issuereport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1 {
            width: 739px;
        }
        .style3 {
            text-align: right;
            color: Green;
            width: 157px;
        }
        .style2 {
            width: 202px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">ISSUED BOOK REPORT</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;<asp:Label ID="Label1" runat="server" Text="Search for Issused Book via:-"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            <asp:RadioButton ID="rdRoll" runat="server" Text="Roll No. :" GroupName="ViewOption" />
                            <asp:RadioButton ID="rdName" runat="server" Text="Student Name :" GroupName="ViewOption" />
                            <asp:RadioButton ID="rdBookNo" runat="server" Text="Book No :" GroupName="ViewOption" />
                            <asp:RadioButton ID="rdBookName" runat="server" Text="Book Name :" GroupName="ViewOption" />
                            <asp:TextBox ID="txtsearch" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                        <td><asp:Button ID="btnsearch" runat="server" CssClass="btn" OnClick="btnsearch_Click" Text="View" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Width="750px">
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    <Columns>
                        <asp:BoundField DataField="Roll" HeaderText="Roll No" />
                        <asp:BoundField DataField="Name" HeaderText="Student Name" />
                        <asp:BoundField DataField="BookNo" HeaderText="Book No" />
                        <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                        <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" />
                        <asp:BoundField DataField="Days" HeaderText="Days" />
                    </Columns>
                    <FooterStyle BackColor="Tan" />
                    <HeaderStyle BackColor="#FF6600" Font-Bold="True" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <SortedAscendingCellStyle BackColor="#FAFAE7" />
                    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                    <SortedDescendingCellStyle BackColor="#E1DB9C" />
                    <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
