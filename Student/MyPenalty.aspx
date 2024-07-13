﻿<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="MyPenalty.aspx.cs" Inherits="Student_MyPanalty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: 45pt;
            color: #003300;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tbl">
    <tr>
        <td class="tblhead">
            PENATY REPORT</td>
    </tr>
        <tr>
            <td>
                <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red"></asp:Label></td>
        </tr>
    <tr>
        <td style="text-align: center">
                </td>
    </tr>
    <tr>
        <td align="center">
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                CellPadding="2" ForeColor="Black" GridLines="None" Width="668px">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:BoundField DataField="bookno" HeaderText="Book No" />
                    <asp:BoundField DataField="bookname" HeaderText="Book Name" />
                    <asp:BoundField DataField="price" HeaderText="Book Price" />
                    <asp:BoundField DataField="Amount" HeaderText="Penalty Amount" />
                    <asp:BoundField DataField="detail" HeaderText="Penalty Detail" />
                    <asp:BoundField DataField="entrydate" HeaderText="Penalty Date" />
                </Columns>
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                    HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

