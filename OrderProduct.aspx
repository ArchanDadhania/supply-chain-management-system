<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OrderProduct.aspx.cs" Inherits="OrderProduct" StyleSheetTheme="SkinFile" %>

<asp:Content ID="c2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <center>
        <div id="div1" runat="server">
            <center><br />
                <asp:Label ID="lblPagehead" runat="server" Text="Order Product" 
                    CssClass="title2" ></asp:Label>
                
                <div>
                <hr style="background-color: #855890; color: #855890;" />
                   </div>
                                <div >
                <table id="Table1" runat="server" cellpadding="2" width ="100%">
                    <tr>
                        <td align="left" class="style3">
                            &nbsp;</td>
                        <td align="left" class="style3">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left" class="style2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            &nbsp;</td>
                        <td align="left" class="style3">
                            <asp:Label ID="Label1" runat="server" Text="Order ID:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtOrderID" runat="server" MaxLength="50" 
                                AutoPostBack="True"  Width="190px" Enabled="False" 
                                ></asp:TextBox>
                        </td>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left" class="style2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            &nbsp;</td>
                        <td align="left" class="style3">
                            <asp:Label ID="Label2" runat="server" Text="Product:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DdlProduct" runat="server" Height="20px" Width="189px" 
                                AutoPostBack="True" onselectedindexchanged="DdlProduct_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                            <td align="left">
                                &nbsp;</td>
                        <td align="left" class="style2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            &nbsp;</td>
                        <td align="left" class="style3">
                            Product Details:</td>
                        <td align="left" colspan="3">
                            <span id="sp_product" runat ="server" ></span>
                            
                            </td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            &nbsp;</td>
                        <td align="left" class="style3">
                            To
                            Warehouse:</td>
                        <td align="left" colspan="3">
                            <asp:DropDownList ID="DdlWarehouse" runat="server" Height="20px" Width="189px" 
                                AutoPostBack="True" 
                                onselectedindexchanged="DdlWarehouse_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            &nbsp;</td>
                        <td align="left" class="style3">
                            Warehouse Details:</td>
                        <td align="left" colspan="3">
                            <span id="sp_warehouse" runat ="server" ></span>
                            
                            </td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            &nbsp;</td>
                        <td align="left" class="style3">
                            Quantity:</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="TxtQuantity" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="BtnAddProduct" runat="server" Text="Add Product" 
                             TabIndex="11"  Font-Bold="False" 
                                Font-Size="8pt" onclick="BtnAddProduct_Click"/>
                        </td>
                    </tr>
                    <tr> 
                     <td align="center">
                         &nbsp;</td>
                     <td align="center" colspan="4">
                     <asp:Label ID="lblmsg" runat="server" CssClass="MsgLabel"></asp:Label>
                    </td>
                    </tr>
                    <tr> 
                     <td align="center" colspan="5">
                            <asp:GridView ID="grv1" runat="server" BackColor="White"
                                BorderColor="#FFCC66" BorderStyle="Solid" BorderWidth="1px" 
                                CellPadding="3" Font-Names="Arial"
                                Font-Size="10pt" GridLines="Vertical" Width="98%" 
                                EnableTheming="True" onpageindexchanging="grv1_PageIndexChanging" 
                                onrowdatabound="grv1_RowDataBound">
                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <RowStyle BackColor="White" ForeColor="Black" />
                                <PagerStyle BackColor="White" ForeColor="#339933" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#109502" />
                                <AlternatingRowStyle BackColor="#FFFFCC" />
                            </asp:GridView>
                         
                         
                         
                         
                         </td>
                    </tr>
                    <tr> 
                     <td align="center" colspan="5">
                     <asp:Button ID="btnsubmit" runat="server" Text="Save Order" onclick="btnsubmit_Click" 
                             TabIndex="11" />
                         &nbsp;<asp:Button ID="btnDelete" runat="server" Text="Delete Order" 
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
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style2
        {
            width: 93px;
        }
        .style3
        {
            width: 115px;
        }
    </style>

</asp:Content>
