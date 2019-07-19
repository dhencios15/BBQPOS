Imports System.Data.SQLite
Module dbConnection
    Dim dbName As String = "bbqpos.db"
    Dim stringConnection As String = "Data Source={0};Version=3;"
    Private dbConn As SQLiteConnection
    Private sqlCommand As SQLiteCommand
    Private da As SQLiteDataAdapter
    Private dr As SQLiteDataReader
    Private dt As DataTable

    Public Sub dbConnection()
        stringConnection = String.Format(stringConnection, dbName)
        Try
            dbConn = New SQLiteConnection(stringConnection)
            dbConn.Open()
        Catch ex As Exception
            MessageBox.Show("Error 101: dbConnection " & ex.Message)
        Finally
            dbConn.Close()
        End Try
    End Sub

    Public Sub SQLProcess(ByVal SQL As String)
        Try
            dbConn.Open()
            sqlCommand = New SQLiteCommand(SQL, dbConn)
            With sqlCommand
                '.CommandText = SQL
                .CommandType = CommandType.Text
                '.Connection = dbConn
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            errorMessage("Error 103: SQL Process" & ex.Message)
        Finally
            dbConn.Close()
        End Try
    End Sub

    Public Sub displayRecords(ByVal SQL As String, ByVal DG As DataGridView)
        Try
            dbConn.Open()
            da = New SQLiteDataAdapter(SQL, dbConn)
            dt = New DataTable
            da.Fill(dt) ' da.Fill(DG.DataSource)
            DG.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error 102: displayRecords" & ex.Message)
        Finally
            dbConn.Close()
        End Try
    End Sub

    Sub errorMessage(ByVal msg)
        MessageBox.Show(msg)
    End Sub
End Module
