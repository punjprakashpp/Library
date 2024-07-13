<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Addbook.aspx.cs" Inherits="Addbook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            // Datepicker initialization
            $("#<%= txtPubDate.ClientID %>").datepicker({
                dateFormat: 'dd-mm-yy'
            });
        });
    </script>
    <style type="text/css">
        .style1 {
            width: 437px;
            height: 355px;
        }
        .style4
        {
            text-align: right;
            color: #007bff;
            width: 148px;
            padding-right: 5px;
            vertical-align:top;
        }
        .style5
        {
            width: 148px;
        }
        .txt 
        {
            width:200px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">ADD NEW BOOK</td>
        </tr>
        <tr>
            <td><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="UploadBookData.aspx">Click here to upload book data using excel file</asp:HyperLink></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table align="center" class="style1">
                    <tr>
                        <td class="style4">Book No. :</td>
                        <td>
                            <asp:TextBox ID="txtBookNo" runat="server" CssClass="txt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtBookNo" ErrorMessage="Book No. is required" ForeColor="Red" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">Book Name :</td>
                        <td>
                            <asp:TextBox ID="txtBookName" runat="server" CssClass="txt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtBookName" ErrorMessage="Book Name is required" ForeColor="Red" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">Book Detail :</td>
                        <td>
                            <asp:TextBox ID="txtdetail" runat="server" CssClass="txt" TextMode="MultiLine" 
                                Height="50px" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtdetail" ErrorMessage="Detail is required" ForeColor="Red" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">Author :</td>
                        <td>
                            <asp:TextBox ID="txtauthor" runat="server" CssClass="txt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtauthor" ErrorMessage="Author is required" ForeColor="Red" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">Publication :</td>
                        <td>
                            <asp:TextBox ID="txtPublication" runat="server" CssClass="txt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtPublication" ErrorMessage="Publication is required" ForeColor="Red" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">Publication Date:</td>
                        <td>
                            <asp:TextBox ID="txtPubDate" runat="server" CssClass="txt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="txtPubDate" ErrorMessage="Publication Date is required" ForeColor="Red" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">Price :</td>
                        <td>
                            <asp:TextBox ID="txtprice" runat="server" CssClass="txt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                ControlToValidate="txtprice" ErrorMessage="Price is required" ForeColor="Red" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" 
                                ControlToValidate="txtprice" ErrorMessage="Price must be between 0 and 9999999999" ForeColor="Red" 
                                MaximumValue="9999999999" MinimumValue="0" SetFocusOnError="True" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">Book Photo :</td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="txt" />
                            <asp:Label ID="lblFileTypeError" runat="server" ForeColor="Red" Visible="false">Invalid file type. Only .jpg, .jpeg, .png files are allowed.</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">&nbsp;</td>
                        <td>
                            <asp:Button ID="btnadd" runat="server" CssClass="btn" Text="ADD Book" 
                                OnClick="btnadd_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">&nbsp;</td>
                        <td>
                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
