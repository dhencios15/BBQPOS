Public Class Payment
    Private Sub Payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPayment.Text = Product_Total
    End Sub
    Private Sub txtCategory_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPayment.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Payment_Input = 0
        Payment_Total = CDbl(lblPayment.Text)
        txtPayment.Text = ""
        lblChange.Text = 0
        Me.Close()
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If txtPayment.Text = "" Then
            MsgBox("Invalid Payment")
        ElseIf CDbl(txtPayment.Text) < CDbl(lblPayment.Text) Then
            MsgBox("Invalid Payment")
        ElseIf CDbl(txtPayment.Text) >= CDbl(lblPayment.Text) Then
            Payment_Total = CDbl(lblPayment.Text)
            Payment_Input = CDbl(txtPayment.Text)
            MsgBox("Payment Success")
            Me.Close()
        End If

        txtPayment.Text = ""
        lblChange.Text = 0
    End Sub

    Private Sub TxtPayment_TextChanged(sender As Object, e As EventArgs) Handles txtPayment.TextChanged
        Try
            lblChange.Text = paymentPrice(lblPayment.Text, txtPayment.Text, lblChange.Text)
        Catch ex As Exception

        End Try
    End Sub
End Class