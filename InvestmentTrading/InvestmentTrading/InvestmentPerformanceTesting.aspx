<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvestmentPerformanceTesting.aspx.cs" Inherits="InvestmentTrading.InvestmentPerformanceTesting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1">
                <tr><td><asp:Label ID="lblUserID" runat="server" Text="Investor ID:"></asp:Label></td><td>
                    <asp:TextBox ID="txtInvestorID" runat="server"></asp:TextBox>
                    </td></tr>
                 <tr><td><asp:Label ID="Label1" runat="server" Text="Investment ID:"></asp:Label></td><td>
                     <asp:TextBox ID="txtInvestmentID" runat="server"></asp:TextBox>
                     </td></tr>
                 <tr><td>&nbsp;</td><td>
                     <asp:Button ID="btnGetInvestment" runat="server" OnClick="btnGetInvestment_Click" Text="Get Investment" />
                     </td></tr>
            </table>
        </div>
    </form>
</body>
</html>
