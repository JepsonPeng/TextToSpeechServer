<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextToSpeechPage.aspx.cs" Inherits="TextToSpeechServer.TextToSpeechPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>文字转语音</title>
</head>
<body background="文字转语音.png" style="background-size:100%,100%;background-repeat:no-repeat;background-attachment:fixed">
    <form id="form1" runat="server">
    <table style="width:100%">
        <tr style="height:100px">
            <th>
                <label style="font-size:50px;color:white;">文字语音转换器</label>
            </th>
        </tr>
        <tr style="height:600px">
            <th>
                <%--<textarea style="width:800px;height:500px;margin:100px,100px,100px,100px;font-size:20px"></textarea>--%>
                <asp:TextBox ID="ConvertTextBox" runat="server" Height="500px" Width="800px" Font-Size="20px" TextMode="MultiLine"></asp:TextBox>
            </th>
        </tr>
        <tr style="height:100px">
            <th>
                <%--<button style="font-size:20px;width:150px;height:50px">开始转换</button>--%>
                <asp:Button ID="ConvertButton" runat="server" OnClick="ConvertButton_Click" Text="开始转换" style="font-size:20px;width:150px;height:50px"/>
            </th>
        </tr>
    </table>
    </form>
</body>
</html>
