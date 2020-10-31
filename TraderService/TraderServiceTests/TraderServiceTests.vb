Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class TraderServiceTests

#Region "Test Set Up and Tear Down"

    <TestInitialize()>
    Public Sub TestSetup()

    End Sub

    <TestCleanup()>
    Public Sub TestTeardown()

    End Sub
#End Region

#Region "Unit Tests"
    <TestMethod()> Public Sub TestShoudReturnValidResult()

        Dim traderService As New TraderService.TraderServiceClient
        Assert.IsNotNull(traderService.GetCurrentPrice("A123"))

    End Sub

#End Region

End Class