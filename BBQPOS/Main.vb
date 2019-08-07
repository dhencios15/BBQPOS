Public Class Main

    Dim strQuery = ""
    Dim foodID, order_id, serve As Integer

    Private Sub Main_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        lblCashier.Text = User_Login
        loadToComboBox("SELECT * FROM category", cmbCategory)
        displayRecords("SELECT * FROM product_display", DGProducts)
        displayRecords("SELECT * FROM freezer_display WHERE quantity > 0 ORDER BY ID", DGFreezer)
        displayRecords("SELECT * FROM report_display", DGReports)
        displayRecords("SELECT * FROM activitylog_display", DGActivityLog)

        addToCart()
        lblTotal.Text = totalOrder()
        lblTotalItem.Text = totalItem()
        lblTotalSales.Text = totalSales()

    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadToComboBoxMenu("SELECT * FROM menuDate ORDER BY menu_id DESC", cmbMenu)
        lblTransNumber.Text = generateOrderId()
        addMenu()
        buttonStyle()



    End Sub

    Private Sub BtnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        homeSelected()
    End Sub

    Private Sub BtnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        DGProducts.ClearSelection()
        DGFreezer.ClearSelection()
        settingSelected()
    End Sub

    Private Sub BtnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        displayRecords("SELECT order_id As Order_ID, item_sold As Total_items, total_price As Total_amount, payment_made As Datetime, issued_by As Issued_by FROM payment ORDER BY payment_made DESC", DGReports)
        reportSelected()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Logout()
    End Sub

    Private Sub BtnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        addMenu()
    End Sub

    Private Sub BtnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        addProducts()
    End Sub

    Private Sub BtnCategory_Click(sender As Object, e As EventArgs) Handles btnCategory.Click
        Category.ShowDialog()
    End Sub

    Private Sub BtnCreateMenu_Click(sender As Object, e As EventArgs) Handles btnCreateMenu.Click
        createMenu()
    End Sub

    Private Sub BtnAddMenu_Click(sender As Object, e As EventArgs) Handles btnAddMenu.Click
        addToMenu()
    End Sub

    Private Sub DGProducts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGProducts.CellClick
        productCellClick(e)
    End Sub

    Private Sub DGFreezer_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGFreezer.CellClick
        freezerCellClick(e)
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Private Sub BtnProduct_Click(sender As Object, e As EventArgs) Handles btnProduct.Click
        btnProduct.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer))
        btnFreezer.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        DGFreezer.ClearSelection()
        DGProducts.ClearSelection()
        btnAddProduct.Text = "ADD"
        btnAddMenu.Text = "ADD (Product)"
        DGFreezer.Visible = False
        DGProducts.Visible = True
        productEnable()
    End Sub

    Private Sub BtnFreezer_Click(sender As Object, e As EventArgs) Handles btnFreezer.Click

        btnFreezer.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer))
        btnProduct.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        DGFreezer.ClearSelection()
        DGProducts.ClearSelection()
        btnAddProduct.Text = "Remove"
        btnAddMenu.Text = "ADD (Freezer)"
        DGProducts.Visible = False
        DGFreezer.Visible = True
        freezerDisable()
    End Sub

    Private Sub BtnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        purchase()
    End Sub

    Private Sub BtnOks_Click(sender As Object, e As EventArgs) Handles btnOks.Click
        lblTotalSales.Text = totalSales()
    End Sub

    Private Sub BtnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        btnOks.Enabled = True
        DGActivityLog.Visible = False
        DGReports.Visible = True
        displayRecords("Select * FROM report_display", DGReports)
        btnActivityLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        btnReports.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer))
    End Sub

    Private Sub BtnActivityLog_Click(sender As Object, e As EventArgs) Handles btnActivityLog.Click

        btnOks.Enabled = False
        DGActivityLog.Visible = True
        DGReports.Visible = False

        btnActivityLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer))
        btnReports.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
    End Sub

    Private Sub DGReports_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGReports.CellDoubleClick
        Dim strQuery = ""

        Try
            Dim i = e.RowIndex
            With DGReports
                ' Reports Fields
                order_id = .Item("Order_ID", i).Value
            End With

            strQuery = "SELECT f.food_id As ID, f.food_name As Name, o.sub_total As Subtotal, o.quantity As Quantity,  " _
                & "m.emp_name As Menu_by FROM orders o INNER JOIN food f ON o.food_id = f.food_id INNER JOIN menu m ON m.menu_id = o.menu_id " _
                & "WHERE o.order_id = " & order_id & " GROUP BY f.food_name"
            displayRecords(strQuery, DGReports)
        Catch ex As Exception
            MsgBox("You cant double click here.")
        End Try


    End Sub

    Private Sub BtnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click

        If btnHome.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer)) Then
            MessageBox.Show("SETTINGS - ADD PRODUCTS TO THE MENU" & vbCrLf & "MENU TABLE - DOUBLE CLICK CELL TO SELECT PRODUCT" & vbCrLf & "ORDER TABLE - DOUBLE CLICK CELL TO CANCEL ORDER")
        ElseIf btnSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer)) Then
            MessageBox.Show("MENU TABLE - DOUBLE CLICK CELL TO CANCEL PRODUCT" & vbCrLf & "FREEZER TABLE - DOUBLE CLICK TO REMOVE PRODUCT")
        ElseIf btnReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer)) Then
            MessageBox.Show("REPORT TABLE - DOUBLE CLICK CELL TO SHOW MORE ORDERS IN THE ORDER_ID")
        End If


    End Sub

    Private Sub DGMenu_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGMenu.CellDoubleClick
        Dim queryformenu = ""
        Dim quantity, id As Integer
        Try
            Dim i = e.RowIndex
            With DGMenu
                id = .Item("ID", i).Value
                Product_Name = .Item("Name", i).Value
                Product_Description = .Item("Description", i).Value
                Product_Price = .Item("Price", i).Value
                quantity = .Item("Quantity", i).Value
                ProductTotal_Quantity = .Item("Quantity", i).Value

            End With

            queryformenu = "update menu set quantity = quantity -  quantity  where menu_id = " & cmbMenu.Text & " And food_id = " & id & ""
            SQLProcess(queryformenu)
            addMenu()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGFreezer_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGFreezer.CellDoubleClick
        Dim queryforFreezer = ""
        Dim id As Integer
        Try
            Dim i = e.RowIndex
            With DGFreezer
                id = .Item("ID", i).Value
            End With

            queryforFreezer = "update freezer set quantity = 0 where food_id = " & id & ""
            SQLProcess(queryforFreezer)
            displayRecords("SELECT * FROM freezer_display WHERE quantity > 0 ORDER BY ID", DGFreezer)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGMainMenu_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGMainMenu.CellDoubleClick
        Try
            Dim i = e.RowIndex
            With DGMainMenu
                Product_ID = .Item("ID", i).Value
                Product_Name = .Item("Name", i).Value
                Product_Description = .Item("Description", i).Value
                Product_Price = .Item("Price", i).Value
                Product_Quantity = .Item("Quantity", i).Value
                ProductTotal_Quantity = .Item("Quantity", i).Value
                DGMainMenu.ClearSelection()
            End With
        Catch ex As Exception
            MessageBox.Show("Double Click Error: Main Menu")
        End Try
        Selected_Product.Show()
    End Sub

    Private Sub DGOrders_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGOrders.CellDoubleClick
        Dim i = e.RowIndex
        With DGOrders
            lblTotal.Text = CDbl(lblTotal.Text) - CDbl(.Item("SubTotal", i).Value)
        End With
        DGOrders.Rows.Remove(DGOrders.Rows(i))
    End Sub

    Private Sub DateTime_Tick(sender As Object, e As EventArgs) Handles DateTime.Tick
        lblTime.Text = Date.Now.ToString("hh:mm:ss")
        lblDate.Text = Date.Now.ToString("dd-MM-yyyy")
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        'displayRecords("SELECT order_id As Order_ID, item_sold As Total_items, total_price As Total_amount, payment_made As Datetime, issued_by As Issued_by FROM payment ORDER BY payment_made DESC", DGReports)
        Try
            strQuery = "Select * FROM report_display WHERE Order_ID LIKE '%" & txtSearch.Text & "%' OR Datetime LIKE '%" & txtSearch.Text & "%'"
            displayRecords(strQuery, DGReports)
            lblTotalSales.Text = totalSales()
        Catch ex As Exception
            MsgBox("ERROR ON TXTSEARCH PRODUCTS")
        End Try
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

    Public Function totalOrder()
        Dim total As Double = 0
        For Each row As DataGridViewRow In DGOrders.Rows
            If Not row.IsNewRow Then
                total += CDbl(row.Cells(4).Value)
            End If
        Next
        Return total
    End Function

    Public Function totalItem()
        Dim total As Double = 0
        For Each row As DataGridViewRow In DGOrders.Rows
            If Not row.IsNewRow Then
                total += CDbl(row.Cells(3).Value)
            End If
        Next
        Return total
    End Function

    Public Function totalSales()
        Dim total As Double = 0
        For Each row As DataGridViewRow In DGReports.Rows
            If Not row.IsNewRow Then
                total += CDbl(row.Cells(2).Value)
            End If
        Next
        Return total
    End Function


    ' -------------------------------  SETTINGS PHASE CODES  ------------------------------

    Sub addProducts()

        If btnAddProduct.Text = "ADD" Then

            If txtName.Text = "" Or txtPrice.Text = "" Or txtDescription.Text = "" Then
                MsgBox("Invalid Adding Products")
            ElseIf isFoundFoodName("SELECT * FROM food", txtName.Text) Then
                MsgBox("Food name already Exist!")
            Else
                strQuery = "INSERT INTO food VALUES(NULL, '" & txtName.Text & "','" & txtDescription.Text & "'," & txtPrice.Text & "," & cmbCategory.SelectedIndex + 1 & ")"
                SQLProcess(strQuery)
                Reset()
                displayRecords("SELECT * FROM product_display", DGProducts)
            End If
        ElseIf btnAddProduct.Text = "UPDATE" Then

            If txtName.Text = "" Or txtPrice.Text = "" Or txtDescription.Text = "" Then
                MsgBox("Invalid Adding Products")
            Else
                strQuery = "UPDATE food SET food_name = '" & txtName.Text & "', description = '" & txtDescription.Text & "', price = " & txtPrice.Text & ", " _
                    & "category_id = " & cmbCategory.SelectedIndex + 1 & " WHERE food_id = " & foodID & ""
                SQLProcess(strQuery)
                Reset()
                displayRecords("SELECT * FROM product_display", DGProducts)
            End If
        ElseIf btnAddProduct.Text = "Remove" Then
            Dim queryforFreezer = ""
            queryforFreezer = "update freezer set quantity = 0 where food_id = " & foodID & ""
            SQLProcess(queryforFreezer)
            displayRecords("SELECT * FROM freezer_display WHERE quantity > 0 ORDER BY ID", DGFreezer)

        End If

    End Sub

    ' -------------------------------  MENU PHASE CODES  ------------------------------

    Sub createMenu()
        Try
            strQuery = "INSERT INTO menuDate VALUES(NULL, date('now') )"
            SQLProcess(strQuery)
            MsgBox("New Menu Created, you can now add product to the new menu")
            loadToComboBoxMenu("SELECT * FROM menuDate ORDER BY menu_id DESC", cmbMenu)
        Catch ex As Exception

        End Try
    End Sub

    Sub addToCart()
        Dim dataSize As Integer = 0
        If DGOrders.Rows.Count = 0 And Product_Name <> "" And Product_Total <> 0 And Product_Quantity <> 0 And Product_Price <> 0 Then
            DGOrders.Rows.Add(Product_ID, Product_Name, Product_Price, Product_Quantity, Product_Total, "X")
            resetValues()
            DGOrders.ClearSelection()
        Else
            For Each row As DataGridViewRow In DGOrders.Rows 'Loop through the DataGridView Contents
                If Not row.IsNewRow Then
                    'MsgBox(row.Cells(0).Value.ToString)
                    'MsgBox(row.Cells(1).Value.ToString)
                    'MsgBox(row.Cells(2).Value.ToString)
                    'MsgBox(row.Cells(3).Value.ToString)

                    If Product_Name <> "" And Product_Total <> 0 And Product_Quantity <> 0 And Product_Price <> 0 Then
                        If Product_Name = row.Cells(1).Value.ToString Then
                            Dim totalQuantity As Integer = Product_Quantity + row.Cells(3).Value
                            If ProductTotal_Quantity < totalQuantity Then
                                row.Cells(3).Value = ProductTotal_Quantity
                            Else
                                row.Cells(3).Value = totalQuantity
                                row.Cells(4).Value = CDbl(row.Cells(4).Value) + Product_Total
                                resetValues()
                                DGOrders.ClearSelection()
                            End If
                            Exit For
                        ElseIf DGOrders.Rows.Count - 1 = dataSize Then
                            DGOrders.Rows.Add(Product_ID, Product_Name, Product_Price, Product_Quantity, Product_Total, "X")
                            resetValues()
                            DGOrders.ClearSelection()
                            Exit For
                        End If
                    End If
                    dataSize += 1
                End If
            Next
        End If

    End Sub

    Private Sub resetValues()
        Product_Name = ""
        Product_Price = 0
        Product_Quantity = 0
        ProductTotal_Quantity = 0
        Product_Description = ""
        Product_Total = 0
    End Sub

    Sub addToMenu()
        Dim queryForRemaining = ""

        If btnAddMenu.Text = "ADD (Product)" Then
            If txtServeMenu.Text = "" Then
                MsgBox("Please input serve")
            Else
                If isFoundProduct("SELECT * FROM menu WHERE menu_id=" & cmbMenu.Text & "", foodID) Then
                    strQuery = "UPDATE menu SET quantity = quantity + " & txtServeMenu.Text & " WHERE food_id =" & foodID & ""
                    SQLProcess(strQuery)
                    MsgBox("Add Quantity Success")
                    addMenu()

                Else
                    strQuery = "INSERT INTO menu VALUES(" & cmbMenu.Text & "," & foodID & "," & txtPrice.Text & "," & txtServeMenu.Text & ",'" & User_Login & "')"
                    SQLProcess(strQuery)
                    MsgBox("Add Menu Success")
                    addMenu()

                End If

            End If
        ElseIf btnAddMenu.Text = "ADD (Freezer)" Then

            If txtServeMenu.Text = "" Then
                MsgBox("Please input serve")
            ElseIf txtServeMenu.Text > serve Then
                MsgBox("Order quantity must not exceed the item's stock quantity!")
                txtServeMenu.Text = serve
            Else
                Dim remainingProduct As Integer = txtServeMenu.Text

                If isFoundProduct("SELECT * FROM menu WHERE menu_id=" & cmbMenu.Text & "", foodID) Then
                    Try
                        strQuery = "UPDATE menu SET quantity = quantity + " & txtServeMenu.Text & " WHERE food_id =" & foodID & ""
                        queryForRemaining = "UPDATE freezer SET quantity = (SELECT quantity FROM freezer WHERE food_id = " & foodID & ") - " & txtServeMenu.Text & " WHERE food_id = " & foodID & ""
                        SQLProcess(strQuery)
                        SQLProcess(queryForRemaining)

                        MsgBox("Add Quantity Success")
                        addMenu()
                        displayRecords("SELECT * FROM freezer_display WHERE quantity > 0 ORDER BY ID", DGFreezer)
                    Catch ex As Exception
                        MsgBox("Add Quantity Failed")
                    End Try

                Else
                    Try
                        strQuery = "UPDATE menu SET quantity = quantity + " & txtServeMenu.Text & " WHERE food_id =" & foodID & ""
                        queryForRemaining = "UPDATE freezer SET quantity = (SELECT quantity FROM freezer WHERE food_id = " & foodID & ") - " & txtServeMenu.Text & " WHERE food_id =" & foodID & ""
                        SQLProcess(strQuery)
                        SQLProcess(queryForRemaining)
                        MsgBox("Add Menu Success")
                        addMenu()
                        displayRecords("SELECT * FROM freezer_display WHERE quantity > 0 ORDER BY ID", DGFreezer)
                    Catch ex As Exception
                        MsgBox("Add Quantity Failed")
                    End Try

                End If

            End If
        End If
    End Sub



    Sub purchase()
        Dim id, quantity, orderid As Integer
        Dim subtotal, total As Double
        Dim datasize As Integer = 0
        Dim queryformenu, queryfororder, queryforpayment As String
        Product_Total = lblTotal.Text
        orderid = lblTransNumber.Text
        total = lblTotal.Text

        If DGOrders.Rows.Count > 0 Then
            Payment.ShowDialog()
            If isPaymentSuccess(Payment_Total, Payment_Input) Then

                For Each row As DataGridViewRow In DGOrders.Rows

                    If Not row.IsNewRow Then
                        Try
                            id = row.Cells(0).Value
                            quantity = row.Cells(3).Value
                            subtotal = row.Cells(4).Value
                            queryformenu = "update menu set quantity = quantity - " & quantity & " where menu_id = " & cmbMenu.Text & " and food_id = " & id & ""
                            queryfororder = "insert into orders values(" & orderid & ", " & cmbMenu.Text & ", " & id & ", " & quantity & ", " & subtotal & ")"
                            SQLProcess(queryformenu)
                            SQLProcess(queryfororder)
                            datasize += 1

                        Catch ex As Exception
                            MessageBox.Show("error on menu and orders " & ex.Message)

                        End Try
                    End If
                Next
                Try
                    queryforpayment = "insert into payment values(null," & orderid & ", ( select sum(quantity) from orders where order_id = " & orderid & "), ( select sum(sub_total) from orders where order_id = " & orderid & "), datetime('now','localtime'),'" & lblCashier.Text & "')"
                    SQLProcess(queryforpayment)
                    lblTransNumber.Text = generateOrderId()
                    DGOrders.Rows.Clear()
                    lblTotal.Text = 0
                    lblTotalItem.Text = 0
                    resetValues()
                    addMenu()
                    displayRecords("SELECT * FROM activitylog_display", DGActivityLog)

                Catch ex As Exception
                    MessageBox.Show("error on payment: " & ex.Message)
                End Try

            Else
                MsgBox("payment failed")
            End If
        Else
            MsgBox("empty cart")
        End If

    End Sub

    ' -------------------------------  Button Change DataGrid for Prodcuts and Freezer Clicks  ------------------------------
    Sub datagridChange()

        If btnProduct.Text = "Products" Then
            btnProduct.Text = "Freezer"



        ElseIf btnProduct.Text = "Freezer" Then
            btnProduct.Text = "Products"



        End If
    End Sub

    Sub freezerDisable()
        txtName.Enabled = False
        txtDescription.Enabled = False
        txtPrice.Enabled = False
        btnAddProduct.Enabled = False
        cmbCategory.Enabled = False
        btnClear.Enabled = False

    End Sub

    Sub productEnable()
        txtName.Enabled = True
        txtDescription.Enabled = True
        txtPrice.Enabled = True
        btnAddProduct.Enabled = True
        cmbCategory.Enabled = True
        btnClear.Enabled = True

    End Sub

    ' -------------------------------  Cell Clicks  ------------------------------

    Sub productCellClick(ByVal e)
        Try
            Dim i = e.RowIndex
            With DGProducts
                ' Products Fields
                foodID = .Item("ID", i).Value
                txtName.Text = .Item("Name", i).Value
                txtPrice.Text = .Item("Price", i).Value
                txtDescription.Text = .Item("Description", i).Value
                cmbCategory.Text = .Item("Category", i).Value

                ' Menu Fields
                txtNameMenu.Text = .Item("Name", i).Value
                txtPriceMenu.Text = .Item("Price", i).Value

            End With

            btnAddProduct.Text = "UPDATE"
            'txtPriceMenu.Enabled = True
            txtServeMenu.Enabled = True
            btnAddMenu.Enabled = True
            btnCategory.Enabled = False

        Catch ex As Exception
            MsgBox("CellClick Error: Product" & ex.Message)
        End Try
    End Sub

    Sub freezerCellClick(ByVal e)
        Try
            Dim i = e.RowIndex
            With DGFreezer
                ' Products Fields
                foodID = .Item("ID", i).Value
                txtName.Text = .Item("Name", i).Value
                txtPrice.Text = .Item("Price", i).Value
                txtDescription.Text = .Item("Description", i).Value
                cmbCategory.Text = .Item("Category", i).Value
                serve = .Item("Quantity", i).Value

                ' Menu Fields
                txtNameMenu.Text = .Item("Name", i).Value
                txtPriceMenu.Text = .Item("Price", i).Value
                txtServeMenu.Text = serve

            End With

            btnAddProduct.Text = "Remove"
            btnAddProduct.Enabled = True
            'txtPriceMenu.Enabled = True
            txtServeMenu.Enabled = True
            btnAddMenu.Enabled = True
            btnCategory.Enabled = False

        Catch ex As Exception
            MsgBox("CellClick Error: Product" & ex.Message)
        End Try
    End Sub

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

    Sub clear()
        txtName.Text = ""
        txtDescription.Text = ""
        txtPrice.Text = ""
        txtNameMenu.Text = ""
        txtPriceMenu.Text = ""
        txtPriceMenu.Enabled = False
        txtServeMenu.Enabled = False

        btnAddProduct.Text = "ADD"
        btnCategory.Enabled = True
        btnAddMenu.Enabled = False
    End Sub

    Private Sub txtServeMenu_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtServeMenu.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtnAddtoCart_Click(sender As Object, e As EventArgs) Handles btnAddtoCart.Click
        If Product_Name = "" And Product_Total = 0 And Product_Quantity = 0 And Product_Price = 0 Then
            MessageBox.Show("Please select product first.")
        Else
            Selected_Product.Show()
            DGMainMenu.ClearSelection()
        End If

    End Sub

    Private Sub DGMainMenu_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGMainMenu.CellClick
        Try
            Dim i = e.RowIndex
            With DGMainMenu
                Product_ID = .Item("ID", i).Value
                Product_Name = .Item("Name", i).Value
                Product_Description = .Item("Description", i).Value
                Product_Price = .Item("Price", i).Value
                Product_Quantity = .Item("Quantity", i).Value
                ProductTotal_Quantity = .Item("Quantity", i).Value

            End With
        Catch ex As Exception
            MessageBox.Show("Double Click Error: Main Menu")
        End Try
    End Sub

    Private Sub DGOrders_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGOrders.CellContentClick
        Dim i = e.RowIndex
        If e.ColumnIndex <> 5 Then
            Exit Sub
        Else
            With DGOrders
                lblTotal.Text = CDbl(lblTotal.Text) - CDbl(.Item("SubTotal", i).Value)
            End With
            DGOrders.Rows.Remove(DGOrders.Rows(i))
        End If
    End Sub

    Sub addMenu()
        strQuery = "SELECT f.food_id As ID, f.food_name As Name, f.description As Description,  m.quantity As Quantity, m.food_price As Price" _
                     & " FROM menu m LEFT JOIN food f ON m.food_id = f.food_id WHERE m.quantity > 0 AND m.menu_id = " & cmbMenu.Text & " ORDER BY f.food_id"
        displayRecords(strQuery, DGMenu)
        displayRecords(strQuery, DGMainMenu)
    End Sub

    Private Sub DGMainMenu_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGMainMenu.CellContentClick

    End Sub

    Sub Logout()
        Dim queryRemaining, queryMenu As String
        Dim dataSize As Integer = 0

        If DGMainMenu.Rows.Count > 0 Then
            Dim result As Integer = MessageBox.Show("Put all the remaining products to freezer?", "LOGOUT", MessageBoxButtons.YesNoCancel)
            Try
                If result = DialogResult.Yes Then
                    Try
                        For Each row As DataGridViewRow In DGMainMenu.Rows
                            Dim foodID As Integer = row.Cells(0).Value
                            Dim menuCode As Integer = cmbMenu.Text
                            Dim quantity As Integer = row.Cells(3).Value

                            If Not row.IsNewRow Then
                                If isFoundRemaining("SELECT * FROM freezer", foodID) Then
                                    queryRemaining = "UPDATE freezer SET quantity = quantity + " & quantity & " WHERE food_id = " & foodID & ""
                                    queryMenu = "update menu set quantity = quantity -  quantity where menu_id = " & cmbMenu.Text & " and food_id = " & foodID & ""
                                    SQLProcess(queryRemaining)
                                    SQLProcess(queryMenu)
                                    dataSize += 1
                                Else
                                    queryRemaining = "INSERT INTO freezer VALUES(" & foodID & ", " & quantity & ")"
                                    queryMenu = "update menu set quantity = quantity -  quantity where menu_id = " & cmbMenu.Text & " and food_id = " & foodID & ""
                                    SQLProcess(queryRemaining)
                                    SQLProcess(queryMenu)
                                    dataSize += 1
                                End If

                            End If
                        Next
                        Product_Total = 0
                        Product_Name = ""
                        Product_Quantity = 0
                        Product_Price = 0
                        Me.Close()
                        Form1.Show()
                    Catch ex As Exception
                    End Try
                ElseIf result = DialogResult.No Then
                    Me.Close()
                    Form1.Show()
                End If
            Catch ex As Exception

            End Try
        Else
            Product_Total = 0
            Product_Name = ""
            Product_Quantity = 0
            Product_Price = 0
            Me.Close()
            Form1.Show()
        End If


    End Sub

    Sub buttonStyle()
        btnCancelOrder.FlatStyle = FlatStyle.Flat

    End Sub


End Class