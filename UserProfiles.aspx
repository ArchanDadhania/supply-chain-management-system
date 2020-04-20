<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserProfiles.aspx.cs" Inherits="UserProfiles" StyleSheetTheme="SkinFile" %>

<asp:Content ID="c2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <center>
        <div id="div1" runat="server">
            <center><br />
                <asp:Label ID="lblPagehead" runat="server" Text="User Profile" 
                    CssClass="title2" ></asp:Label>
                
                <div>
                <hr style="background-color: #855890; color: #855890;" />
                   </div>
                                <div >
                <table id="Table1" runat="server" cellpadding="2">
                    <tr>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label1" runat="server" Text="Email ID:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtEmailID" runat="server" MaxLength="50" 
                                AutoPostBack="True"  Width="190px" Enabled="False" 
                                ></asp:TextBox>
                        </td>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label2" runat="server" Text="Display Name:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtDisplayName" runat="server" MaxLength="100" TabIndex="2" 
                                Width="190px"></asp:TextBox>
                        </td>
                            <td align="left">
                                &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label6" runat="server" Text="Mobile No:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtMobile" runat="server" MaxLength="50" TabIndex="6" 
                                Width="190px"></asp:TextBox>
                        </td>
                            <td align="left">
                            <asp:Label ID="Label7" runat="server" Text="Office No:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtOfficeNo" runat="server" MaxLength="50" TabIndex="7" 
                                Width="190px"></asp:TextBox>
                          
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label8" runat="server" Text="Web Site:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtWebsite" runat="server" MaxLength="100" TabIndex="8" 
                                Width="190px"></asp:TextBox>
                        </td>
                            <td align="left">
                            <asp:Label ID="Label9" runat="server" Text="Ext No:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtExt" runat="server" MaxLength="50" TabIndex="9" 
                                Width="190px"></asp:TextBox>
                          
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Office Address:</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="TxtAddress" runat="server" MaxLength="250" TabIndex="8" 
                                Width="190px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr> 
                     <td align="center" colspan="4">
                     <asp:Label ID="lblmsg" runat="server" CssClass="MsgLabel"></asp:Label>
                    </td>
                    </tr>
                    <tr> 
                     <td align="center" colspan="4">
                     <asp:Button ID="btnsubmit" runat="server" Text="Submit" onclick="btnsubmit_Click" 
                             TabIndex="11" />
                         &nbsp;<asp:Button ID="btnreset" runat="server" Text="Back" 
                             onclick="btnreset_Click" TabIndex="12" />
                     </td>
                    </tr>
                </table>
                </div>
                <div>
                    &nbsp;</div>
            </center>
        </div>
    </center>
</asp:Content>