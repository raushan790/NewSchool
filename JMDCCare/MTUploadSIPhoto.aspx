<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MTUploadSIPhoto.aspx.cs"
    Inherits="MTUploadSIPhoto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <base target="_self" />
    <title>Upload</title>
    <link href="CSS/MyStyle.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="Scripts/jsValidation.js" type="text/javascript"></script>
    <script language="javascript" src="Scripts/GridScript.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
    </script>
</head>
<body id="bdUploadPhoto" style="background-image: url(Images/M3.jpg)">
    <form id="frmUploadPhoto" runat="server">
    <div id="MainDiv" align="center">
        <asp:TextBox ID="txtRetValue" runat="server" Style="display: none;"></asp:TextBox>
        <asp:Panel ID="pnlUploadPhoto" runat="server" align="center" valign="middle" Width="350px"
            Height="140px" BorderStyle="Solid" BorderWidth="1px">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left" class="MyLabel" colspan="1" style="width: 30px" valign="middle">
                    </td>
                    <td align="left" class="MyLabel" colspan="3" style="height: 10px" valign="middle">
                    </td>
                    <td align="left" class="MyLabel" colspan="1" style="width: 30px" valign="middle">
                    </td>
                </tr>
                <tr>
                    <td align="left" class="MyLabel" colspan="1" style="width: 30px" valign="middle">
                    </td>
                    <td colspan="3" class="MyLabel" align="left" valign="middle">
                        <strong>Upload Photo</strong>
                    </td>
                    <td align="left" class="MyLabel" colspan="1" style="width: 30px" valign="middle">
                    </td>
                </tr>
                <tr>
                    <td colspan="1">
                    </td>
                    <td colspan="2" align="left">
                        <asp:FileUpload ID="UploadPhoto" runat="server" onchange="frmUploadPhoto.submit();"
                            Width="271px" Height="24px" />
                    </td>
                    <td colspan="1" align="left">
                        <asp:Button ID="btnUploadCancel" runat="server" Text="Close" Width="52px" Height="24px"
                            OnClientClick="window.close();" />
                    </td>
                    <td colspan="1">
                    </td>
                </tr>
                <tr>
                    <td align="left" class="MyLabel" colspan="1" style="height: 65px; text-align: justify">
                    </td>
                    <td align="left" class="MyLabel" colspan="3" style="text-align: justify; height: 65px;">
                        You can upload a JPG or GIF file (Maximum size of 20 kb). Do not upload photos containing
                        cartoons, celebrities, nudity, artwork or copyrighted images. Minimum image size
                        is 32x32.
                    </td>
                    <td align="left" class="MyLabel" colspan="1" style="height: 65px; text-align: justify">
                    </td>
                </tr>
                <tr>
                    <td align="left" class="MyLabel" colspan="1">
                    </td>
                    <td align="left" class="MyLabel" colspan="3" style="height: 10px">
                    </td>
                    <td align="left" class="MyLabel" colspan="1">
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
