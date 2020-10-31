Imports System.ServiceModel
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data
<ServiceContract()>
Public Interface ITraderService


    <OperationContract()>
    Function GetInvestmentList(ByVal userId As Int64) As DataSet

    <OperationContract()>
    Function GetCostBasisPerShare(ByVal userId As Int64) As Decimal

    <OperationContract()>
    Function GetCurrentValue(ByVal userId As Int64) As Decimal

    <OperationContract()>
    Function GetCurrentPrice(ByVal userId As Int64) As Decimal

    <OperationContract()>
    Function GetInvestmentTerm(ByVal userId As Int64) As Int16

    <OperationContract()>
    Function GetGainLoss(ByVal userId As Int64) As Decimal

    '<DataContract()>
    'Public Class Investment

    'End Class

End Interface
