<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewRequestbyEmp.aspx.cs" Inherits="ViewRequestbyEmp" MasterPageFile="~/MasterPage.master" StylesheetTheme="SkinFile" %>

<asp:Content ID ="c9" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <center>
        <div id="div1" runat="server">
            <asp:Label ID="lblPagehead" runat="server" Text="View Request" CssClass="title2"></asp:Label>
         <div>
                <hr style="background-color: #855890; color: #855890;" />
                   </div>
                
                <div style=" font-family:Verdana; font-size: 9pt;">
    <table id="Table1" runat="server">
             
                <tr>
                <td align="left">
                        <asp:Label ID="Label3" runat="server" Text="Request Type:"></asp:Label>
                </td>
                <td align="left">
                <asp:DropDownList ID="ddlreqtype" runat="server" Width="156px" ></asp:DropDownList>
                </td>
                <td align="right" colspan="2">
                <asp:Button ID="btnopenshow" runat="server" Text="Open" 
                        onclick="btnopenshow_Click" />
                <asp:Button ID="btnprogress" runat="server" Text="Progress" 
                        onclick="btnprogress_Click" />
                <asp:Button ID="btnclose" runat="server" Text="Close" onclick="btnclose_Click" />
                </td>
                    </tr>
            </table>
            
            <br />
            <asp:GridView ID="grvRequest" runat="server" BackColor="White" BorderColor="SkyBlue"
                            BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        Font-Names="Verdana" Font-Size="10pt"
                            GridLines="Vertical" AllowPaging="True" Width ="100%" 
                        onpageindexchanging="grvRequest_PageIndexChanging" OnRowDataBound="grvRequest_RowDataBound">
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <RowStyle BackColor="White" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="MidnightBlue" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#7E428C" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="#F7F0F8" />
                        </asp:GridView>
            </div>
    </div>
    </center>
</asp:Content>