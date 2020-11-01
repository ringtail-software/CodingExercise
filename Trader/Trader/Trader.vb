Module Trader

    Sub Main()
        Dim traderService As TraderServiceRef.TraderServiceClient = New TraderServiceRef.TraderServiceClient("BasicHttpBinding_ITraderService")

        Dim currentPrice As Decimal = Nothing
        Try
            currentPrice = traderService.GetCurrentValue("54321")
            Console.WriteLine("Current Price: " + currentPrice.ToString)

        Catch ex As Exception
            '          logInstance = LogEvent(ex.InnerException.Message)

        End Try

    End Sub

End Module
