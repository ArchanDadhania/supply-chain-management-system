<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" StylesheetTheme="SkinFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eSCMS - Login</title>
        <meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
    <link rel="stylesheet" href="mykb.css" />
    <style type="text/css">
        #table64
        {
            height: 16px;
        }
        .style1
        {
            font-size: medium;
        }
        #table66
        {
            height: 16px;
            width: 257px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" width="100%" id="table2" style="height: 72px;" cellspacing="0" cellpadding="0">
        <tr>
            <td class="topbg" valign="top" style="height: 72px">
                <table border="0" width="100%" id="table3" cellspacing="0"
                    cellpadding="0">
                    <tr>
                        <td >
                            <img src ="images/logo1.gif" />
                        
                        </td>
                        <td >
                            
                                                        &nbsp;<p align="right" />

                        &nbsp;&nbsp;&nbsp;
                            
                            </td>
                    </tr>
                    <tr>
                    <td class="top2" colspan ="2">
                    &nbsp;
                    </td>
                    
                    </tr>
                </table>
                
            </td>
        </tr>
    </table>
    <div align="center">
        <table border="0" width="100%" id="table4" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <table border="0" width="100%" id="table13" cellpadding="0" cellspacing="0" height="394">
                        <tr>
                            <td width="10%" valign="top" class="tdmenu">
                                <table border="0" width="100%" id="table63" cellspacing="1">
                                    <tr>
                                        <td>
                                            <table border="0" width="100%" id="table64" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="29%" class="text2">
                                                        &nbsp;</td>
                                                    <td width="64%" align="left" >
                                                        <b> </font>
                                                        </b>
                                                     
                                                     
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table border="0" width="200" id="table65" cellspacing="0" cellpadding="0" height="315">
                                                <tr>
                                                <td style="height:100%;">
                                                    &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top" style="width: 68%">
        <div id="div2" runat="server">
            <center>
                <div>
                    <br />
                    &nbsp;<table border="0" id="table66" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="29%" class="text2">
                                                        &nbsp;<strong><img border="0" src="images/login.gif" width="58" height="58" alt="" /></strong></td>
                                                    <td width="64%" align="left" >
                                                        <b> </font>
                                                        <strong><span class="style1">Login to eSCMS</span></strong></b></td>
                                                </tr>
                                            </table>
                                            <br />
                </div>
                                <div style="width: 500px;">
                <table id="Table1" runat="server">
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblloginname" runat="server" Text="User Name:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtusername" runat="server" Width="200px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblpassword" runat="server" Text="Password:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Use SCMS as a:</td>
                        <td align="left">
                            <asp:RadioButton ID="RdCompany" runat="server" Text="Company" GroupName="L1" 
                                Checked="True" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left">
                            <asp:RadioButton ID="RdStockist" runat="server" Text="Stock Department" 
                                GroupName="L1" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left">
                            <asp:RadioButton ID="RdDistributor" runat="server" Text="Distributor" 
                                GroupName="L1" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                         <asp:Button ID="btnlogin" runat="server" Text="Login" onclick="btnlogin_Click"  />
                        &nbsp;
                         <asp:Button ID="btnregister" runat="server" Text="Register" 
                                onclick="btnregister_Click"  />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                        <asp:Label ID="lblmsg" runat="server" CssClass="MsgLabel"></asp:Label>
                    </td>
                    </tr>
                </table>
                </div>
                <div>
                    &nbsp;</div>
            </center>
        </div>

                            </td>
                            <td width="45%" valign="top">
                                <br />
                                <br />
                                <br />
                                <br />
                                
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            </table>
    </div>
    <table border="0" width="100%" id="table12" cellspacing="0" cellpadding="0" height="45">
        <tr>
            <td class="topbg" valign="top" style="background-image: url('images/bot_bg.gif'); height: 45px; text-align: center;"
                width="100%">
                &nbsp;
                       
                <br />
                Developed by <strong>Student Name</strong></td>
            </td>
        </tr>
    </table>
    
    </form>
</body>
</html>
