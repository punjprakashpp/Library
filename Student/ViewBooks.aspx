<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ViewBooks.aspx.cs" Inherits="bookreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1 { width: 100%; }
        .style2 { text-align: left; color: Green; }
        .style4 { width: 717px; }
        .style5 { font-weight: 700; }
        .style6 { width: 216px; }
        .style7 { width: 452px; }
        .style8 { height: 183px; }
        .style9 { height: 45px; }
        .style11 { text-align: right; color: Green; width: 177px; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">VIEW BOOK</td>
        </tr>
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="Search for Book via:-"></asp:Label></td>

        </tr>
        <tr>
            <td>
                <table class="style1" align="center">
                    <tr>
                        <td class="style2">
                            <asp:RadioButton ID="rdBookNo" runat="server" Text="Book No :" GroupName="ViewOption" />
                            <asp:RadioButton ID="rdBookName" runat="server" Text="Book Name :" GroupName="ViewOption" />
                            <asp:RadioButton ID="rdAuthor" runat="server" Text="Author :" GroupName="ViewOption" />
                            <asp:RadioButton ID="rdPublication" runat="server" Text="Publication :" GroupName="ViewOption" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="txt"></asp:TextBox>
                            <asp:Button ID="btnView" runat="server" CssClass="btn" Text="View" OnClick="btnView_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblmsg" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table class="tbl">
                            <tr>
                                <td class="tblhead"><asp:Label ID="lblmsg0" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="748px" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" OnRowCommand="GridView1_RowCommand" style="text-align: center">
                                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                        <Columns>
                                            <asp:BoundField DataField="BookNo" HeaderText="Book No" />
                                            <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                                            <asp:BoundField DataField="Author" HeaderText="Author" />
                                            <asp:BoundField DataField="Publication" HeaderText="Publication" />
                                            <asp:BoundField DataField="Price" HeaderText="Price" />
                                            <asp:TemplateField HeaderText="View">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkview" Text="View" CommandName="View" CommandArgument='<%#Eval("BID") %>' CssClass="lnk"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                            <tr><td>&nbsp;</td></tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table class="tbl">
                            <tr>
                                <td class="tblhead">View Book Detail</td>
                            </tr>
                            <tr>
                                <td>
                                    <table class="style4">
                                        <tr>
                                            <td class="style6">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style6" rowspan="2">
                                                <asp:Image ID="Image2" runat="server" Height="228px" Width="207px" />
                                            </td>
                                            <td class="style8" valign="top">
                                                <table class="style7">
                                                    <tr>
                                                        <td class="style11" style="font-size: medium">Book No. :</td>
                                                        <td><asp:Label ID="lblBookNo" runat="server"></asp:Label></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style11" style="font-size: medium">Book Name :</td>
                                                        <td><asp:Label ID="lblBookName" runat="server"></asp:Label></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style11" style="font-size: medium">Author :</td>
                                                        <td><asp:Label ID="lblauthor" runat="server"></asp:Label></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style11" style="font-size: medium">Publication :</td>
                                                        <td><asp:Label ID="lblpub" runat="server"></asp:Label></td>
                                                        <td>&nbsp;</td>
                                                    </tr>                                                  
                                                    <tr>
                                                        <td class="style11" style="font-size: medium">Detail :</td>
                                                        <td><asp:Label ID="lbldetail" runat="server"></asp:Label></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style11" style="font-size: medium">Price :</td>
                                                        <td><asp:Label ID="lblprice" runat="server"></asp:Label></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style9" valign="top">
                                                <asp:Button ID="Button11" runat="server" CssClass="btn" OnClick="Button11_Click" Text="Back" Width="80px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>
