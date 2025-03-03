﻿<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ReturnBook.aspx.cs" Inherits="BookReturn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1 {
            width: 746px;
        }

        .style4 {
            width: 717px;
            height: 276px;
        }

        .style5 {
            font-weight: 700;
        }

        .style6 {
            width: 216px;
        }

        .style8 {
            height: 183px;
        }

        .style7 {
            width: 452px;
            height: 222px;
        }

        .style14 {
            text-align: right;
            color: Green;
            width: 136px;
        }

        .style15 {
            text-align: right;
            color: Green;
            width: 158px;
        }

        .lbl {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">RETURN BOOK</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style1">Roll No. :
                            <asp:TextBox ID="txtRoll" runat="server" CssClass="txt"></asp:TextBox>
                            <asp:Button ID="btnFetchIssueBook" runat="server" CssClass="btn" Text="Fetch Book" OnClick="btnFetchIssueBook_Click" Width="100px" />
                        </td>
                        <td class="style1">Book No. :
                            <asp:DropDownList ID="drpbook" runat="server" CssClass="txt" AutoPostBack="false"></asp:DropDownList>
                            <asp:Button ID="btnSelectBook" runat="server" CssClass="btn" Text="Select Book" OnClick="btnSelectBook_Click" ValidationGroup="bookValidation" Width="100px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRoll"
                                ErrorMessage="Roll number is required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                        <td class="style1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpbook"
                                ErrorMessage="Book should be selected" ForeColor="Red" SetFocusOnError="True" ValidationGroup="bookValidation"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                        </td>

                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View2" runat="server">
                        <table class="tbl">
                            <tr>
                                <td class="tblhead">View Book Detail
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table class="style4">
                                        <tr>
                                            <td class="style5" colspan="2">Book Name :
                                                <asp:Label ID="lblbname" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style6">
                                                <asp:Image ID="Image2" runat="server" Height="211px" Width="207px"
                                                    BorderColor="#009933" BorderStyle="Dotted" BorderWidth="1px" />
                                            </td>
                                            <td class="style8" valign="top">
                                                <table class="style7">
                                                    <tr>
                                                        <td class="style15" style="font-size: medium">Author :</td>
                                                        <td>
                                                            <asp:Label ID="lblauthor" runat="server"></asp:Label>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style15" style="font-size: medium">Publication :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblpub" runat="server"></asp:Label>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style15" style="font-size: medium">Price :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblprice" runat="server"></asp:Label>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style15" style="font-size: medium">Student Name:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblstudent" runat="server"></asp:Label>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style15" style="font-size: medium">Days :</td>
                                                        <td>
                                                            <asp:Label ID="lbldays" runat="server"></asp:Label>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style15" style="font-size: medium">Issue Date :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblidate" runat="server"></asp:Label>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style15" style="font-size: medium">Penalty Status :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblpanalty" runat="server"></asp:Label>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style6">&nbsp;</td>
                                            <td valign="top">
                                                <asp:Button ID="btnreturnbook" runat="server" CssClass="btn" Text="Return Book" OnClick="btnreturnbook_Click" Width="120px" />
                                                &nbsp;<asp:Label ID="lblbook" runat="server" Font-Size="10pt"></asp:Label>
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
    </table>
</asp:Content>
