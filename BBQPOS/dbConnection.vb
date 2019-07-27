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

    Public Sub SQLProcess(ByVal SQL As String) ' SQL process for insert, delete, update
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

    Public Sub displayRecords(ByVal SQL As String, ByVal DG As DataGridView) ' Display all values in the datagrid
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

    Public Function isFound(ByVal SQL As String, ByVal name As String) As Boolean ' Check if value found in database
        Dim value = ""
        Dim found = False
        Try
            dbConn.Open()
            da = New SQLiteDataAdapter(SQL, dbConn)
            dt = New DataTable
            da.Fill(dt)

            For Each row As DataRow In dt.Rows
                value = row.Item("username")
                If value = name Then
                    found = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error 106: isFound" & ex.Message)
        Finally
            dbConn.Close()
        End Try
        Return found
    End Function

    Public Function isFound(ByVal SQL As String, ByVal name As String, ByVal password As String) As Boolean ' check username and password

        Dim value = "", add = ""
        Dim found = False
        Try
            dbConn.Open()
            da = New SQLiteDataAdapter(SQL, dbConn)
            dt = New DataTable
            da.Fill(dt)

            For Each row As DataRow In dt.Rows
                value = row.Item("username")
                add = row.Item("password")

                If value = name And add = password Then
                    found = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error 104: isFound" & ex.Message)
        Finally
            dbConn.Close()
        End Try
        Return found
    End Function

    Public Sub loadToComboBox(ByVal SQL As String, ByVal cbo As ComboBox) ' Load all values into combobox
        Try
            dbConn.Open()
            da = New SQLiteDataAdapter(SQL, dbConn)
            dt = New DataTable
            da.Fill(dt)
            cbo.DataSource = dt
            cbo.ValueMember = dt.Columns(0).ToString
            cbo.DisplayMember = dt.Columns(1).ToString

        Catch ex As Exception
            MessageBox.Show("Error 105: Db_ComboxDisplay" & ex.Message)
        Finally
            dbConn.Close()
        End Try
    End Sub

    Public Function isFoundProduct(ByVal SQL As String, ByVal name As String) As Boolean ' find Product
        Dim value = ""
        Dim found = False
        Try
            dbConn.Open()
            da = New SQLiteDataAdapter(SQL, dbConn)
            dt = New DataTable
            da.Fill(dt)

            For Each row As DataRow In dt.Rows
                value = row.Item("food_id")
                If value = name Then
                    found = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error 106: isFound" & ex.Message)
        Finally
            dbConn.Close()
        End Try
        Return found
    End Function

    Public Function checkQuantity(ByVal SQL As String, ByVal password As String) As Boolean ' for freezer

        Dim add = ""
        Dim found = False
        Try
            dbConn.Open()
            da = New SQLiteDataAdapter(SQL, dbConn)
            dt = New DataTable
            da.Fill(dt)

            For Each row As DataRow In dt.Rows

                add = row.Item("quantity")

                If add = password Then
                    found = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error 104: isFound" & ex.Message)
        Finally
            dbConn.Close()
        End Try
        Return found
    End Function

    Public Function isFoundRemaining(ByVal SQL As String, ByVal password As String) As Boolean ' for freezer

        Dim value = "", add = ""
        Dim found = False
        Try
            dbConn.Open()
            da = New SQLiteDataAdapter(SQL, dbConn)
            dt = New DataTable
            da.Fill(dt)

            For Each row As DataRow In dt.Rows
                'value = row.Item("menu_id")
                add = row.Item("food_id")

                If add = password Then
                    found = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error 104: isFound" & ex.Message)
        Finally
            dbConn.Close()
        End Try
        Return found
    End Function

    Public Function isFoundFoodName(ByVal SQL As String, ByVal name As String) As Boolean ' find Food Name
        Dim value = ""
        Dim found = False
        Try
            dbConn.Open()
            da = New SQLiteDataAdapter(SQL, dbConn)
            dt = New DataTable
            da.Fill(dt)

            For Each row As DataRow In dt.Rows
                value = row.Item("food_name")
                If value = name Then
                    found = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error 106: isFound" & ex.Message)
        Finally
            dbConn.Close()
        End Try
        Return found
    End Function

    Public Sub loadToComboBoxMenu(ByVal SQL As String, ByVal cbo As ComboBox) ' Menu combobox only
        Try
            dbConn.Open()
            da = New SQLiteDataAdapter(SQL, dbConn)
            dt = New DataTable
            da.Fill(dt)
            cbo.DataSource = dt
            cbo.ValueMember = dt.Columns(0).ToString
            cbo.DisplayMember = dt.Columns(0).ToString

        Catch ex As Exception
            MessageBox.Show("Error 105: Db_ComboxDisplay" & ex.Message)
        Finally
            dbConn.Close()
        End Try
    End Sub

    Public Function isFoundOrderID(ByVal SQL As String, ByVal name As String) As Boolean 'Order ID
        Dim value = ""
        Dim found = False
        Try
            dbConn.Open()
            da = New SQLiteDataAdapter(SQL, dbConn)
            dt = New DataTable
            da.Fill(dt)

            For Each row As DataRow In dt.Rows
                value = row.Item("order_id")
                If value = name Then
                    found = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error 106: isFound" & ex.Message)
        Finally
            dbConn.Close()
        End Try
        Return found
    End Function

    Public Function generateOrderId()
        Dim rand As New Random()
        Dim randomNumbers As String = "1234567890"
        Dim checkId As Boolean = True
        Dim orderId As String = ""

        While checkId
            orderId = ""
            For i = 0 To 8
                orderId += randomNumbers.Chars(rand.Next(0, randomNumbers.Length - 1))
            Next
            checkId = isFoundOrderID("SELECT * FROM orders", orderId)
        End While
        Return orderId

    End Function

    Sub errorMessage(ByVal msg)
        MessageBox.Show(msg)
    End Sub
End Module
