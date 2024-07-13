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
            width: 600px;
            height: 415px;
        }

        .style2 {
            text-align: right;
            color: #007bff;
            width: 159px;
            padding-right: 5px;
            vertical-align: top;
        }

        .style3 {
            width: 159px;
        }

        .txt {
            width: 200px;
        }

        .auto-style1 {
            width: 341px;
        }

        .auto-style2 {
            text-align: right;
            color: #007bff;
            width: 240px;
            padding-right: 5px;
            vertical-align: top;
        }

        .auto-style3 {
            width: 240px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">ADD NEW STUDENT</td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="UploadStudentData.aspx">Click here to upload student data using excel file</asp:HyperLink></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table align="center" class="style1">
                    <tr>
                        <td class="auto-style2">Session :</td>
                        <td>
                            <asp:DropDownList ID="ddlSession" runat="server" CssClass="txt"></asp:DropDownList>

                        </td>
                        <td class="auto-style1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSession"
                                ErrorMessage="Please select a session" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Roll No. :</td>
                        <td>
                            <asp:TextBox ID="txtRoll" runat="server" CssClass="txt"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRoll" runat="server" ControlToValidate="txtRoll"
                                ErrorMessage="Roll number must be numeric" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                        </td>
                        <td class="auto-style1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRoll"
                                ErrorMessage="Roll number is required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Name :</td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" CssClass="txt"></asp:TextBox>

                        </td>
                        <td class="auto-style1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                ErrorMessage="Name is required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Gender :</td>
                        <td>
                            <asp:RadioButton ID="rdomale" runat="server" Checked="True" Text="MALE" GroupName="Gender" />
                            <asp:RadioButton ID="rdofemale" runat="server" Text="FEMALE" GroupName="Gender" />
                        </td>
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Date of Birth :</td>
                        <td>
                            <asp:TextBox ID="txtBirthDate" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                        <td class="auto-style1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBirthDate"
                                ErrorMessage="Date of Birth is required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Mobile :</td>
                        <td>
                            <asp:TextBox ID="txtmobile" runat="server" CssClass="txt"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorMobile" runat="server" ControlToValidate="txtmobile"
                                ErrorMessage="It must be numeric and 10 digits" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
                        </td>
                        <td class="auto-style1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtmobile"
                                ErrorMessage="Mobile number is required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Email :</td>
                        <td>
                            <asp:TextBox ID="txtemail" runat="server" CssClass="txt"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail"
                                ErrorMessage="Invalid Email format" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                        <td class="auto-style1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtemail"
                                ErrorMessage="Email is required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Address :</td>
                        <td>
                            <asp:TextBox ID="txtaddress" runat="server" CssClass="txt" TextMode="MultiLine" Height="64px"></asp:TextBox>
                        </td>
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">City :</td>
                        <td>
                            <asp:TextBox ID="txtcity" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Pincode :</td>
                        <td>
                            <asp:TextBox ID="txtpincode" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                        <td class="auto-style1">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPincode" runat="server" ControlToValidate="txtpincode"
                                ErrorMessage="Pincode must be numeric and 6 digits" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^\d{6}$"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Photo :</td>
                        <td>
                            <asp:FileUpload ID="fileUpload" runat="server" />
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="lblFileTypeError" runat="server" ForeColor="Red" Visible="false">Invalid file type. Only .jpg, .jpeg, .png files are allowed.</asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style3">&nbsp;</td>
                        <td>
                            <asp:Button ID="btnaddStudent" runat="server" CssClass="btn" OnClick="btnadd_Click"
                                Text="ADD Student" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">&nbsp;</td>
                        <td>
                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
