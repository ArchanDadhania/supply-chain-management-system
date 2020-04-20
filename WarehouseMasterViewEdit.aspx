<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WarehouseMasterViewEdit.aspx.cs" Inherits="WarehouseMasterViewEdit" StyleSheetTheme="SkinFile" %>

<asp:Content ID="c2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <center>
        <div id="div1" runat="server">
            <center><br />
                <asp:Label ID="lblPagehead" runat="server" Text="Warehouse Master" 
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
                            <asp:Label ID="Label1" runat="server" Text="Warehouse ID:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtID" runat="server" MaxLength="50" 
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
                            <asp:Label ID="Label2" runat="server" Text="Warehouse Name:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtName" runat="server" MaxLength="100" TabIndex="2" 
                                Width="190px"></asp:TextBox>
                        </td>
                            <td align="left">
                                &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left">
                            City:</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="TxtCity" runat="server" MaxLength="100" TabIndex="2" 
                                Width="190px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Address:</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="TxtAddress" runat="server" MaxLength="200" TabIndex="2" 
                                Width="190px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left" colspan="3">
                            &nbsp;</td>
                    </tr>
                    <tr> 
                     <td align="center" colspan="4">
                     <asp:Label ID="lblmsg" runat="server" CssClass="MsgLabel"></asp:Label>
                    </td>
                    </tr>
                    <tr> 
                     <td align="center" colspan="4">
                     <asp:Button ID="btnsubmit" runat="server" Text="Save" onclick="btnsubmit_Click" 
                             TabIndex="11" />
                         &nbsp;<asp:Button ID="btnDelete" runat="server" Text="Delete" 
                              TabIndex="12" onclick="btnreset0_Click"   
                              OnClientClick="if ( ! DeleteConfirmation()) return false;" 
                              />
                     &nbsp;<asp:Button ID="btnreset" runat="server" Text="Back" 
                              TabIndex="12" onclick="btnreset_Click" />
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