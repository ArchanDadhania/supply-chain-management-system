﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewOrder.aspx.cs" Inherits="ViewOrder" StyleSheetTheme="SkinFile" %>

<asp:Content ID="c2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <center>
        <div id="div1" runat="server">
            <center>
                 
                <br />
      <asp:Label ID="lblPagehead" runat="server" Text="View Order" 
                    CssClass="title2" ></asp:Label>
                <div>
                    &nbsp;</div>
                                <div style="font-family:Verdana; font-size: 9pt;">
                <table id="Table1" runat="server" width="100%">
                    <tr>
                        <td align="left" style="height: 24px">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 24px">
                            <asp:GridView ID="grv1" runat="server" AllowPaging="True" BackColor="White"
                                BorderColor="#FFCC66" BorderStyle="Solid" BorderWidth="1px" 
                                CellPadding="3" Font-Names="Arial"
                                Font-Size="10pt" GridLines="Vertical" 
                                PageSize="7" Width="95%" 
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
                     <td align="center" class="style1">
                     <asp:Label ID="lblmsg" runat="server" CssClass="MsgLabel"></asp:Label>
                    </td>
                    </tr>
                    <tr> 
                     <td align="center">
                     <asp:Button ID="btnsubmit" runat="server" Text="Add new order" 
                             TabIndex="11" OnClick="btnsubmit_Click" />
                         &nbsp;<asp:Button ID="btnreset" runat="server" Text="Reset" 
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
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style1
        {
            height: 18px;
        }
    </style>

</asp:Content>
