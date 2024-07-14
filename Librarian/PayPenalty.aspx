<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="PayPenalty.aspx.cs" Inherits="Penalty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1 {
            width: 747px;
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
        .style16 {
            text-align: right;
            color: Green;
            width: 153px;
        }
        .auto-style1 {
            text-align: right;
            color: Green;
            width: 201px;
        }
        .auto-style2 {
            width: 897px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">PAY PENALTY</td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style1">
                            Roll No.:
                            <asp:TextBox ID="txtRoll" runat="server" CssClass="txt"></asp:TextBox>
                            <asp:Button ID="btnFetchIssueBook" runat="server" CssClass="btn" Text="Fetch Book" OnClick="btnFetchIssueBook_Click" Width="100px" />                            
                        </td>
                        <td class="style1">
                            Book No.:
                            <asp:DropDownList ID="drpbook" runat="server" CssClass="txt" AutoPostBack="false"></asp:DropDownList>
                            <asp:Button ID="btnSelectBook" runat="server" CssClass="btn" Text="Select Book" OnClick="btnSelectBook_Click" ValidationGroup="bookValidation" Width="100px" />                            
                        </td>
                    </tr>
                    <tr>
                        <td class="style1"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRoll" ErrorMessage="Roll number is required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                        <td class="style1"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpbook" ErrorMessage="Book should be selected" ForeColor="Red" SetFocusOnError="True" ValidationGroup="bookValidation"></asp:RequiredFieldValidator></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View2" runat="server">
                        <table class="tbl">
                            <tr>
                                <td class="tblhead">View Book Detail </td>
                            </tr>
                            <tr>
                                <td>
                                    <table class="style4">
                                        <tr>
                                            <td class="style5">
                                                Book No. : <asp:Label ID="lblBookNo" runat="server"></asp:Label>
                                            </td>
                                            <td class="style5">
                                                Book Name : <asp:Label ID="lblBookName" runat="server"></asp:Label>
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
                                                        <td class="auto-style1" style="font-size: medium">Author :</td>
                                                        <td><asp:Label ID="lblauthor" runat="server"></asp:Label></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style1" style="font-size: medium">Publication :</td>
                                                        <td><asp:Label ID="lblpub" runat="server"></asp:Label></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style1" style="font-size: medium">Price :</td>
                                                        <td><asp:Label ID="lblprice" runat="server"></asp:Label></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style1" style="font-size: medium">Roll No. :</td>
                                                        <td><asp:Label ID="lblRoll" runat="server"></asp:Label></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style1" style="font-size: medium">Student Name:</td>
                                                        <td><asp:Label ID="lblstudent" runat="server"></asp:Label></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style1" style="font-size: medium">Days :</td>
                                                        <td><asp:Label ID="lbldays" runat="server"></asp:Label></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style1" style="font-size: medium">Issue Date :</td>
                                                        <td><asp:Label ID="lblidate" runat="server"></asp:Label></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style1" style="font-size: medium">Penalty Status :</td>
                                                        <td><asp:Label ID="lblpanalty" runat="server"></asp:Label></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style1" style="font-size: medium">Penalty Amount :</td>
                                                        <td><asp:TextBox ID="txtpenalty" runat="server" CssClass="txt" Width="80px"></asp:TextBox></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style1" style="font-size: medium">Reason :</td>
                                                        <td><asp:TextBox ID="txtdetail" runat="server" CssClass="txt" Height="40px" 
                                                            TextMode="MultiLine" Width="200px"></asp:TextBox></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style1" style="font-size: medium">&nbsp;</td>
                                                        <td>
                                                            <asp:Button ID="btnpaypenalty" runat="server" CssClass="btn" 
                                                                onclick="btnpaypenalty_Click" Text="Pay Now" Width="90px" />
                                                            <asp:Label ID="lblpay" runat="server" Font-Size="10pt"></asp:Label>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
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
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
