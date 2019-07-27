Public Class Category
    Private Sub BtnAddCategory_Click(sender As Object, e As EventArgs) Handles btnAddCategory.Click
        Try
            SQLProcess("INSERT INTO category VALUES(NULL,'" & txtCategory.Text & "')")

        Catch ex As Exception
            MessageBox.Show("Message Error: Add Category" & ex.Message)
        End Try

        MsgBox("Add Category Success!")
        Me.Close()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class