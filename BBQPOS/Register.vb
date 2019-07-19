Public Class Register
    Dim register As New RegisterClass()

    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadToComboBox("SELECT * FROM gender", cmbGender)
    End Sub


    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Try
            If txtUsername.Text = "" Or txtName.Text = "" Or txtContact.Text = "" Or txtPassword.Text = "" Then
                MsgBox("Please Fill Up the following")
            ElseIf isFound("SELECT * FROM employee", txtUsername.Text) Then
                MsgBox(txtUsername.Text & " Already Taken")
                txtPassword.Text = ""
                txtPassword2.Text = ""
            Else
                If txtPassword.Text = txtPassword2.Text Then
                    register.Register(txtName.Text, cmbGender.SelectedValue, txtContact.Text, txtUsername.Text, txtPassword.Text)
                    txtUsername.Text = ""
                    txtName.Text = ""
                    txtContact.Text = ""
                    txtPassword.Text = ""
                    txtPassword2.Text = ""
                    MsgBox("Register Success")

                    Me.Hide()
                    Form1.Show()
                Else
                    MsgBox("Password not match")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


End Class