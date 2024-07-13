<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="MyBook.aspx.cs" Inherits="Student_MyBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1 {
            width: 629px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">MY BOOK REPORT</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btntaken" runat="server" CssClass="btn" Text="BORROWED BOOK"
                    OnClick="btntaken_Click" />
                &nbsp;<asp:Button ID="btnreturn" runat="server" CssClass="btn" Text="RETURNED BOOK"
                    OnClick="btnreturn_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table align="center" class="style1">
                            <tr>
                                <td>Borrowed Book List -
                                    <asp:Label ID="lblb" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px"
                                        CellPadding="2" ForeColor="Black" GridLines="None" Style="text-align: center"
                                        Width="612px">
                                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                        <Columns>
                                            <asp:BoundField DataField="BookNo" HeaderText="Book No" />
                                            <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                                            <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" />
                                            <asp:BoundField DataField="Days" HeaderText="Remaining Days" />
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
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table align="center" class="style1">
                            <tr>
                                <td>Return Book List -
                                    <asp:Label ID="lblr" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                                        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px"
                                        CellPadding="2" ForeColor="Black" GridLines="None" Style="text-align: center"
                                        Width="630px">
                                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                        <Columns>
                                            <asp:BoundField DataField="BookNo" HeaderText="Book No" />
                                            <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                                            <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" />
                                            <asp:BoundField DataField="ReturnDate" HeaderText="Return Date" />
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
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>
