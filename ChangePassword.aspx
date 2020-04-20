<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword"
    MasterPageFile="~/MasterPage.master" StylesheetTheme="SkinFile" %>

<asp:Content ID="c3" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <center>
        <div id="div1" runat="server">
            <br />
            <asp:Label ID="lblPagehead" runat="server" Text="Change Password" CssClass="title2" ></asp:Label>
        <div>
                <hr style="background-color: #855890; color: #855890;" />
                   </div>
                
            <div style="width: 500px; font-family:Verdana; font-size: 9pt;">
            <table id="Table1" runat="server">
                <tr>
                    <td align="left">
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="l1" runat="server" Text="Email ID:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TxtEmailID" runat="server" ReadOnly="true" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="Label2" runat="server" Text="Old Password:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtoldpassword" runat="server" TextMode="Password" 
                            Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="Label3" runat="server" Text="New Password:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtnewpassword" runat="server" TextMode="Password" 
                            Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="Label4" runat="server" Text="Confirm Password:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtconfirmpassword" runat="server" TextMode="Password" 
                            Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Label ID="lblmsg" runat="server" CssClass="MsgLabel"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnchange" runat="server" Text="Change" OnClick="btnchange_Click" />
                        &nbsp;<asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                    </td>
                </tr>
            </table>
            </div>
            <div>
                &nbsp;</div>

    </div> </center>
</asp:Content>
