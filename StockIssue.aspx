<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StockIssue.aspx.cs" Inherits="StockIssue" StyleSheetTheme="SkinFile" %>

<asp:Content ID="c2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <center>
        <div id="div1" runat="server">
            <center><br />
                <asp:Label ID="lblPagehead" runat="server" Text="Issue Stock" 
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
                            <asp:Label ID="Label1" runat="server" Text="Product ID:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DdlProduct" runat="server" Height="20px" Width="189px" 
                                AutoPostBack="True" onselectedindexchanged="DdlProduct_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left">
                            Product Details:</td>
                        <td align="left">
                            <span id="sp_product" runat ="server" ></span>
                            
                            </td>
                            <td align="left">
                                &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label2" runat="server" Text="Available Quantity"></asp:Label>
                        </td>
                        <td align="left">
                            
                     <asp:Label ID="lblmsg3" runat="server" CssClass="MsgLabel"></asp:Label>
                            </span>
                            </td>
                            <td align="left">
                                &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left">
                            Issue Quanity:</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="TxtQty" runat="server" MaxLength="100" TabIndex="2" 
                                Width="190px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Issue To:</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="TxtTo" runat="server" MaxLength="100" TabIndex="2" 
                                Width="190px"></asp:TextBox>
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