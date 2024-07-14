<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true"
    CodeFile="StudentReport.aspx.cs" Inherits="Studenteport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 739px;
        }
        .style2
        {
            width: 202px;
        }
        .style3
        {
            text-align: right;
            color: Green;
            width: 157px;
        }
        .style4
        {
            width: 561px;
        }
        .style5
        {
            text-align: right;
            color: Green;
            width: 249px;
        }
        .lbl {
            text-align: center;
        }
        .auto-style1 {
            text-align: left;
            color: Green;
            width: 249px;
            height: 29px;
        }
        .auto-style2 {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">
                STUDENT REPORT
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="lbl">
                            <asp:Label ID="Label1" runat="server" Text="Search for Student via:-"></asp:Label>
                            <asp:RadioButton ID="rdRoll" runat="server" Text="Roll No. :" GroupName="SearchCriteria"
                                AutoPostBack="True" />
                            <asp:RadioButton ID="rdName" runat="server" Text="Student Name :" GroupName="SearchCriteria"
                                AutoPostBack="True" />
                            <asp:TextBox ID="txtsearch" runat="server" CssClass="txt"></asp:TextBox>
                            <asp:Button ID="btnseach" runat="server" CssClass="btn" OnClick="btnseach_Click"
                                Text="View" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table class="tbl">
                            <tr>
                                <td class="tblhead">
                                    <asp:Label ID="lbl" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                                        BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None"
                                        OnRowCommand="GridView1_RowCommand" Style="text-align: center" Width="748px">
                                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                        <Columns>
                                            <asp:BoundField DataField="Roll" HeaderText="Roll No" />
                                            <asp:BoundField DataField="Name" HeaderText="StudentName" />
                                            <asp:BoundField DataField="Session" HeaderText="Session" />
                                            <asp:TemplateField HeaderText="View">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkview" runat="server" CommandName="View" CommandArgument='<%# Eval("sid") %>'
                                                        CssClass="lnk" Text="View"></asp:LinkButton>
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
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table class="tbl">
                            <tr>
                                <td class="tblhead">
                                    Student Detail
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table align="center" class="style4">
                                        <tr>
                                            <td class="style5">
                                                Session :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblsem" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                Roll No :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRoll" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                Student Name:
                                            </td>
                                            <td>
                                                <asp:Label ID="lblname" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                BirthDate :
                                            </td>
                                            <td>
                                                <asp:Label ID="lbldob" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                Gender :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGen" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                Mobile :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblmobile" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                Address:
                                            </td>
                                            <td>
                                                <asp:Label ID="lbladdress" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                City :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblcity" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                Pincode :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblpin" runat="server"></asp:Label>
                                            </td>
                                        </tr>                                        
                                        <tr>
                                            <td class="style5">
                                                Email :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblemai" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                Password :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblpass" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lbl">
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:Button ID="Button12" runat="server" CssClass="btn" OnClick="Button12_Click"
                                                    Text="BACK" Width="80px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
