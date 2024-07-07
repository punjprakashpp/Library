<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/MasterPage.master" AutoEventWireup="true" CodeFile="RemoveStudent.aspx.cs" Inherits="Librarian_RemoveStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
            text-align: right;
            color: Green;
            width: 249px;
            height: 29px;
        }
        .auto-style2 {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">
                REMOVE STUDENT
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
                            Select an entire Session to Remove : 
                            <asp:DropDownList ID="ddlSession" runat="server" CssClass="txt" AutoPostBack="false"></asp:DropDownList>
                            <asp:Button ID="btnRemSem" runat="server" CssClass="btn" OnClick="btnRemSem_Click" ValidationGroup="SessionValidation"
                                Text="Delete Session" />
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSession"
                                ErrorMessage="Please select a session" ForeColor="Red" ValidationGroup="SessionValidation" SetFocusOnError="True"></asp:RequiredFieldValidator>                                                  
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Search a Student to Remove :
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl">
                            <asp:RadioButton ID="rdRoll" runat="server" Text="Roll No. :" GroupName="SearchCriteria"
                                AutoPostBack="True" />
                            <asp:RadioButton ID="rdName" runat="server" Text="Student Name :" GroupName="SearchCriteria"
                                AutoPostBack="True" />
                            <asp:TextBox ID="txtsearch" runat="server" CssClass="txt"></asp:TextBox>
                            <asp:Button ID="btnsearch" runat="server" CssClass="btn" OnClick="btnsearch_Click"
                                Text="Search" />
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
                                            <asp:TemplateField HeaderText="Remove">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkRem" runat="server" CommandName="Remove" CommandArgument='<%# Eval("sid") %>'
                                                        CssClass="lnk" Text="Remove"></asp:LinkButton>
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

