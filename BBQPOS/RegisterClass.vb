Public Class RegisterClass

    Private name As String
    Private userName As String
    Private password As String
    Private gender As Integer
    Private contact As String

    Dim strQuery = ""
    Public Sub Register(ByVal name As String, ByVal gender As Integer, ByVal contact As String, ByVal userName As String, ByVal password As String)

        dbConnection.dbConnection()
        strQuery = "INSERT INTO employee VALUES(NULL,'" & name & "', " & gender & ",'" & contact & "', '" & userName & "','" & password & "')"
        SQLProcess(strQuery)

    End Sub

End Class
