Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbConnection.dbConnection()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Register.ShowDialog()
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If isFound("SELECT * FROM employee", txtUsername.Text, txtPassword.Text) Then
            MessageBox.Show("Login successful")
            'User_Login = txtUsername.Text
            Main.Show()
            Me.Hide()
            reset()
        Else
            MessageBox.Show("Login failed")
        End If
    End Sub

    Sub reset()
        txtUsername.Text = ""
        txtPassword.Text = ""
    End Sub
End Class
