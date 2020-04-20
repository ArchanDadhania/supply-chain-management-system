<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Allocation.aspx.cs" Inherits="Allocation"
    MasterPageFile="~/MasterPage.master" StylesheetTheme="SkinFile" %>

<asp:Content ID="c2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <center>
        <div id="div1" runat="server">
            <asp:Label ID="lblPagehead" runat="server" Text="Allocation" CssClass="title2"></asp:Label>
        <div>
                <hr style="background-color: #855890; color: #855890;" />
                   </div>
                
            <div style="width: 100%; font-family:Verdana; font-size: 9pt;">
                <table id="Table1" runat="server">
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label2" runat="server" Text="From Date:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtdatefrom" runat="server" ToolTip="Date Format must be dd-mm-yyyy"
                                MaxLength="20" Width="150px"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label1" runat="server" Text="To Date:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txttodate" runat="server" ToolTip="Date Format must be dd-mm-yyyy"
                                MaxLength="20" TabIndex="1" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label3" runat="server" Text="Request Type:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlreqtype" runat="server" TabIndex="2" Width="156px">
                            </asp:DropDownList>
                        </td>
                        <td align="right" colspan="2">
                            <asp:Button ID="btnshow" runat="server" Text="Show" OnClick="btnshow_Click" TabIndex="3" />
                        </td>
                    </tr>
                </table>
                <br />
                <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="grvRequest" runat="server" OnSelectedIndexChanging="grvRequest_SelectedIndexChanging"
                                AllowPaging="True" OnPageIndexChanging="grvRequest_PageIndexChanging" BackColor="White"
                                BorderColor="SkyBlue" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Names="Verdana"
                                Font-Size="10pt" GridLines="Vertical" TabIndex="4" Width="100%" OnRowDataBound="grvRequest_RowDataBound" OnSelectedIndexChanged="grvRequest_SelectedIndexChanged">
                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <RowStyle BackColor="White" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="MidnightBlue" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#7E428C" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="#F7F0F8" />
                                <Columns>
                                    <asp:CommandField HeaderText="Allocate To" SelectText="Allocate" ShowSelectButton="True" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="lblmsg" runat="server" CssClass="MsgLabel"></asp:Label>
                <br />
                <br />
                <table id="tblAllocateto" runat="server" visible="false">
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label4" runat="server" Text="Request ID:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblReqID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label5" runat="server" Text="Allocate To:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlallocateto" runat="server" TabIndex="5" Width="156px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <asp:Button ID="btnallocate" runat="server" Text="Allocate" OnClick="btnallocate_Click"
                                TabIndex="6" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                &nbsp;</div>
        </div>
    </center>
</asp:Content>
