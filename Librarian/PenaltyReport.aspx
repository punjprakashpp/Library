<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="PenaltyReport.aspx.cs" Inherits="Student_MyPenalty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1 {
            font-size: 45pt;
            color: #003300;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">PENALTY REPORT</td>
        </tr>
        <tr>
            <td style="text-align: center"></td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                    BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                    CellPadding="2" ForeColor="Black" GridLines="None" Width="720">
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    <Columns>
                        <asp:BoundField HeaderText="Roll No" DataField="Roll" />
                        <asp:BoundField HeaderText="Student Name" DataField="Name" />
                        <asp:BoundField DataField="BookNo" HeaderText="Book No" />
                        <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                        <asp:BoundField DataField="Price" HeaderText="Price">
                            <ItemStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Amount" HeaderText="Penalty Amount">
                            <ItemStyle Width="110px" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="Tan" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                        HorizontalAlign="Center" />
                    <RowStyle HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <SortedAscendingCellStyle BackColor="#FAFAE7" />
                    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                    <SortedDescendingCellStyle BackColor="#E1DB9C" />
                    <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
