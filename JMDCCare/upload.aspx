﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                                             <asp:FileUpload ID="FileUpload1" runat="server"   />
<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick = "Upload"  />
                                   
        </div>
    </form>
</body>
</html>