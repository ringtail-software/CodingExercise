<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NuixTradeWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="jumbotron">
        <h1>NuixTrade</h1>
        <p class="lead">The world's leading Discovery system is now better than ever.</p>
        <p><label id="userName" runat="server"/>, Welcome to the Nuix Trading Platform</p>
    </div>

    <div id="errorContainer">
        <label id="errorLabel" class="errorMessage" runat="server"></label>
    </div>

    <div id="portfolioContainer" class="float-container" runat="server">
        <div class="float-child">
            <asp:GridView ID="PortfolioGridView" runat="server" AutoGenerateColumns="true" OnRowDataBound="PortfolioGridView_RowDataBound" CellPadding="20">
            </asp:GridView>
        </div>

        <div id="investmentDetailContainer" class="dTable float-child">
            <div class="dTableRow">
                <div class="dTableCell">Investment</div>
                <div class="dTableCell">
                    <label id="investmentName" runat="server" />
                </div>
            </div>
            <div class="dTableRow">
                <div class="dTableCell">Shares</div>
                <div class="dTableCell">
                    <label id="numShares" runat="server" />
                </div>
            </div>
            <div class="dTableRow">
                <div class="dTableCell">Cost Basis/Share</div>
                <div class="dTableCell">
                    <label id="costBasisPerShare" runat="server" />
                </div>
            </div>
            <div class="dTableRow">
                <div class="dTableCell">Current Value</div>
                <div class="dTableCell">
                    <label id="currentValue" runat="server" />
                </div>
            </div>
            <div class="dTableRow">
                <div class="dTableCell">Current Price</div>
                <div class="dTableCell">
                    <label id="currentPrice" runat="server" />
                </div>
            </div>
            <div class="dTableRow">
                <div class="dTableCell">Term</div>
                <div class="dTableCell">
                    <label id="term" runat="server" />
                </div>
            </div>
            <div class="dTableRow">
                <div class="dTableCell">Total Gain/Loss</div>
                <div class="dTableCell">
                    <label id="totalGainLoss" runat="server" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
