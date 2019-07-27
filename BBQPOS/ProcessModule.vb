Module ProcessModule
    Public Function totalPrice(ByVal price As Double, ByVal quantity As Integer, ByVal total As Double)
        total = (price * quantity)
        Return total
    End Function

    Public Function paymentPrice(ByVal price As Double, ByVal payment As Double, ByVal total As Double)
        total = payment - price
        Return total
    End Function

    Public Function isPaymentSuccess(ByVal price As Double, ByVal payment As Double)
        If payment >= price Then
            Return True
        Else
            Return False
        End If
    End Function

End Module
