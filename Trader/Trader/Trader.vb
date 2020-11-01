Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data


Module Trader

    Sub Main()
        Dim traderService As TraderServiceRef.TraderServiceClient = New TraderServiceRef.TraderServiceClient("BasicHttpBinding_ITraderService")

        Dim currentPrice As Decimal = Nothing
        Dim dsInvestments As DataSet = Nothing
        Dim userid As Int32 = "54321"

        Try
            dsInvestments = traderService.GetInvestmentList(userid)

            For i As Int16 = 0 To dsInvestments.Tables(0).Rows.Count - 1

                Console.WriteLine("Investment Id: " + dsInvestments.Tables(0).Rows(i)(0).ToString)
                Console.WriteLine("Investment: " + dsInvestments.Tables(0).Rows(i)(1).ToString)

            Next

            With traderService

                Console.WriteLine("Cost Basis/Share: " + .GetCostBasisPerShare(userid).ToString)
                currentPrice = traderService.GetCurrentValue("54321")
                Console.WriteLine("Current Value: " + .GetCurrentValue(userid).ToString)
                Console.WriteLine("Current Price: " + .GetCurrentPrice(userid).ToString)
                Console.WriteLine("Term: " + .GetInvestmentTerm(userid).ToString)
                Console.WriteLine("GainLoss: " + .GetGainLoss(userid).ToString)

                Console.WriteLine("Press any key to end.")

                Console.ReadKey()

            End With

        Catch ex As Exception
            '          logInstance = LogEvent(ex.InnerException.Message)

        End Try

    End Sub

End Module
