Public Class Main
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        homeSelected()
    End Sub

    Private Sub BtnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        settingSelected()
    End Sub

    Private Sub BtnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        reportSelected()
    End Sub

    ' -------------------------------  HOME PHASE CODES  ------------------------------
    Sub homeSelected()
        homePanel.Visible = True
        settingsPanel.Visible = False
        reportsPanel.Visible = False

        btnHome.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer))
        btnSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        btnReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
    End Sub
    ' -------------------------------  SETTINGS PHASE CODES  ------------------------------
    Sub settingSelected()
        homePanel.Visible = False
        settingsPanel.Visible = True
        reportsPanel.Visible = False

        btnHome.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        btnSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer))
        btnReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
    End Sub
    ' -------------------------------  REPORTS PHASE CODES  ------------------------------
    Sub reportSelected()
        homePanel.Visible = False
        settingsPanel.Visible = False
        reportsPanel.Visible = True

        btnHome.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        btnSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        btnReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer))
    End Sub
End Class