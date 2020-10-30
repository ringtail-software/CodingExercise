<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="InvestmentPerformanceWebAPITest.aspx.cs" Inherits="InvestmentPerformanceWebAPI.InvestmentPerformanceWebAPITest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0">
                <tr><td colspan="2"><asp:Label ID="Label3" runat="server" Text="Investment Performance Web API" Font-Bold="True" Font-Size="Larger" ForeColor="Teal"></asp:Label></td></tr>
                <tr><td><asp:Label ID="Label1" runat="server" Text="Inverstor ID:"></asp:Label></td>
                    <td><asp:TextBox ID="txtInvestorID" runat="server"></asp:TextBox> </td></tr>
                <tr><td><asp:Label ID="Label2" runat="server" Text="Investment ID:"></asp:Label></td>
                    <td><asp:TextBox ID="txtInvestmentID" runat="server"></asp:TextBox></td>
                </tr>
                 <tr><td></td>
                    <td><asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
                </tr>
                <tr><td colspan="2"><asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtXML" runat="server" BorderStyle="None" Height="410px" TextMode="MultiLine" Width="553px"></asp:TextBox></td></tr>
            </table>
        </div>
    </form>
</body>
</html>
