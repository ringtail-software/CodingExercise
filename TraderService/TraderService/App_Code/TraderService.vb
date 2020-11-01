Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data

' NOTE: You can use the "Rename" command on the context menu to change the class name "Service" in code, svc and config file together.
Public Class TraderService
    Implements ITraderService

    Public Sub New()
    End Sub

    Public Function GetCostBasisPerShare(ByVal userId As Int64) As Decimal Implements ITraderService.GetCostBasisPerShare
        Dim factory As DatabaseProviderFactory = New DatabaseProviderFactory
        Dim db As Database = factory.Create("Investment")
        Dim costBasisPerShare As Decimal = Nothing
        Dim logInstance As String = Nothing

        Dim dbCommand As DbCommand = db.GetStoredProcCommand("dbo.GetCostBasisPerShare")
        db.AddInParameter(dbCommand, "@userId", DbType.Int64, userId)

        Try
            costBasisPerShare = db.ExecuteScalar(dbCommand)

        Catch ex As Exception
            '           logInstance = LogEvent(ex.InnerException.Message)
        End Try

        GetCostBasisPerShare = costBasisPerShare

    End Function

    Public Function GetCurrentValue(ByVal userId As Int64) As Decimal Implements ITraderService.GetCurrentValue
        Dim factory As DatabaseProviderFactory = New DatabaseProviderFactory
        Dim db As Database = factory.Create("Investment")
        Dim currentValue As Decimal = Nothing
        Dim logInstance As String = Nothing

        Dim dbCommand As DbCommand = db.GetStoredProcCommand("dbo.GetCurrentValue")
        db.AddInParameter(dbCommand, "@userId", DbType.Int64, userId)

        Try
            currentValue = db.ExecuteScalar(dbCommand)

        Catch ex As Exception
            '          logInstance = LogEvent(ex.InnerException.Message)
        End Try

        GetCurrentValue = currentValue

    End Function

    Public Function GetCurrentPrice(ByVal userId As Int64) As Decimal Implements ITraderService.GetCurrentPrice
        Dim factory As DatabaseProviderFactory = New DatabaseProviderFactory
        Dim db As Database = factory.Create("Investment")
        Dim currentPrice As Decimal = Nothing
        Dim logInstance As String = Nothing

        Dim dbCommand As DbCommand = db.GetStoredProcCommand("dbo.GetCurrentPrice")
        db.AddInParameter(dbCommand, "@userId", DbType.Int64, userId)

        Try
            currentPrice = db.ExecuteScalar(dbCommand)

        Catch ex As Exception
            '           logInstance = LogEvent(ex.InnerException.Message)
        End Try

        GetCurrentPrice = currentPrice

    End Function

    Public Function GetInvestmentTerm(ByVal userId As Int64) As Int16 Implements ITraderService.GetInvestmentTerm
        Dim factory As DatabaseProviderFactory = New DatabaseProviderFactory
        Dim db As Database = factory.Create("Investment")
        Dim investmentTerm As Int16 = Nothing
        Dim logInstance As String = Nothing

        Dim dbCommand As DbCommand = db.GetStoredProcCommand("dbo.GetInvestmentTerk")
        db.AddInParameter(dbCommand, "@userId", DbType.Int64, userId)

        Try
            investmentTerm = db.ExecuteScalar(dbCommand)

        Catch ex As Exception
            '           logInstance = LogEvent(ex.InnerException.Message)
        End Try

        GetInvestmentTerm = investmentTerm

    End Function

    Public Function GetGainLoss(ByVal userId As Int64) As Decimal Implements ITraderService.GetGainLoss
        Dim factory As DatabaseProviderFactory = New DatabaseProviderFactory
        Dim db As Database = factory.Create("Investment")
        Dim gainLoss As Decimal = Nothing
        Dim logInstance As String = Nothing

        Dim dbCommand As DbCommand = db.GetStoredProcCommand("dbo.GetGainLoss")
        db.AddInParameter(dbCommand, "@userId", DbType.Int64, userId)

        Try
            gainLoss = db.ExecuteScalar(dbCommand)

        Catch ex As Exception
            '           logInstance = LogEvent(ex.InnerException.Message)
        End Try

        GetGainLoss = gainLoss

    End Function

    Private Function GetInvestmentList(ByVal userId As Int64) As DataSet Implements ITraderService.GetInvestmentList
        Dim factory As DatabaseProviderFactory = New DatabaseProviderFactory
        Dim db As Database = factory.Create("Investment")
        Dim ds As DataSet = Nothing
        Dim logInstance As String = Nothing

        Dim dbCommand As DbCommand = db.GetStoredProcCommand("dbo.GetListInvestment")
        db.AddInParameter(dbCommand, "@userId", DbType.Int64, userId)

        Try
            ds = db.ExecuteDataSet(dbCommand)

        Catch ex As Exception
            '            logInstance = LogEvent(ex.InnerException.Message)
        End Try

        Return ds

        GetInvestmentList = ds

    End Function

    Private Sub Logevent(ByVal message As String)
        ' log exceptions and other info to database
    End Sub

End Class
