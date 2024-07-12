<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true"
    CodeFile="AddStudent.aspx.cs" Inherits="AddStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            // Datepicker initialization
            $("#<%= txtBirthDate.ClientID %>").datepicker({
                dateFormat: 'dd-mm-yy'
            });
        });
    </script>
    <style type="text/css">
        .style1 {
            width: 471px;
            height: 415px;
        }
        .style2
        {
            text-align: right;
            color: #007bff;
            width: 159px;
            padding-right: 5px;
            vertical-align: top;
        }
        .style3
        {
            width: 159px;
        }
        .txt 
        {
            width:200px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">ADD NEW STUDENT</td>
        </tr>
        <tr>
            <td><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Library/Librarian/UploadStudentData.aspx">Click here to upload student data using excel file</asp:HyperLink></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table align="center" class="style1">
                    <tr>
                        <td class="style2">Session :</td>
                        <td>
                            <asp:DropDownList ID="ddlSession" runat="server" CssClass="txt"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSession"
                                ErrorMessage="Please select a session" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">Roll No. :</td>
                        <td>
                            <asp:TextBox ID="txtRoll" runat="server" CssClass="txt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRoll"
                                ErrorMessage="Roll number is required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">Name :</td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" CssClass="txt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                ErrorMessage="Name is required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">Gender :</td>
                        <td>
                            <asp:RadioButton ID="rdomale" runat="server" Checked="True" Text="MALE" GroupName="Gender" />
                            <asp:RadioButton ID="rdofemale" runat="server" Text="FEMALE" GroupName="Gender" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">Date of Birth :</td>
                        <td>
                            <asp:TextBox ID="txtBirthDate" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">Mobile :</td>
                        <td>
                            <asp:TextBox ID="txtmobile" runat="server" CssClass="txt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtmobile"
                                ErrorMessage="Mobile number is required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtmobile"
                                ErrorMessage="Please enter a valid mobile number" ForeColor="Red" MaximumValue="9999999999"
                                MinimumValue="1000000000" SetFocusOnError="True" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">Email :</td>
                        <td>
                            <asp:TextBox ID="txtemail" runat="server" CssClass="txt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtemail"
                                ErrorMessage="Email is required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail"
                                ErrorMessage="Invalid email format" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">Address :</td>
                        <td>
                            <asp:TextBox ID="txtaddress" runat="server" CssClass="txt" TextMode="MultiLine" Height="64px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">City :</td>
                        <td>
                            <asp:TextBox ID="txtcity" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">Pincode :</td>
                        <td>
                            <asp:TextBox ID="txtpincode" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">Photo :</td>
                        <td>
                            <asp:FileUpload ID="fileUpload" runat="server" />
                            <asp:Label ID="lblFileTypeError" runat="server" ForeColor="Red" Visible="false">Invalid file type. Only .jpg, .jpeg, .png files are allowed.</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">&nbsp;</td>
                        <td>
                            <asp:Button ID="btnaddStudent" runat="server" CssClass="btn" OnClick="btnadd_Click"
                                Text="ADD Student" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">&nbsp;</td>
                        <td>
                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
