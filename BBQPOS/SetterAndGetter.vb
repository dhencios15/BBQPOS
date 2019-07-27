Module SetterAndGetter
    Private ProductName, ProductDescription, ProductCategory, userLogin As String
    Private ProductPrice, ProductTotal, PaymentInput, PaymentTotal As Double
    Private ProductQuantity, ProductTotalQuantity, ProductID As Integer


    Property Product_ID() As Integer
        Set(ByVal ID As Integer)
            ProductID = ID
        End Set
        Get
            Return ProductID
        End Get
    End Property

    Property Payment_Input() As Double
        Set(ByVal pay As Double)
            PaymentInput = pay
        End Set
        Get
            Return PaymentInput
        End Get
    End Property

    Property Payment_Total() As Double
        Set(ByVal total As Double)
            PaymentTotal = total
        End Set
        Get
            Return PaymentTotal
        End Get
    End Property

    Property Product_Name() As String
        Set(ByVal Name As String)
            ProductName = Name
        End Set
        Get
            Return ProductName
        End Get
    End Property

    Property Product_Description() As String
        Set(ByVal Description As String)
            ProductDescription = Description
        End Set
        Get
            Return ProductDescription
        End Get
    End Property

    Property Product_Category() As String
        Set(ByVal Category As String)
            ProductCategory = Category
        End Set
        Get
            Return ProductCategory
        End Get
    End Property

    Property Product_Price() As Double
        Set(ByVal Price As Double)
            ProductPrice = Price
        End Set
        Get
            Return ProductPrice
        End Get
    End Property

    Property ProductTotal_Quantity() As Integer
        Set(ByVal Quantity As Integer)
            ProductTotalQuantity = Quantity
        End Set
        Get
            Return ProductTotalQuantity
        End Get
    End Property

    Property Product_Quantity() As Integer
        Set(ByVal Quantity As Integer)
            ProductQuantity = Quantity
        End Set
        Get
            Return ProductQuantity
        End Get
    End Property

    Property Product_Total() As Double
        Set(ByVal Total As Double)
            ProductTotal = Total
        End Set
        Get
            Return ProductTotal
        End Get
    End Property

    Property User_Login() As String
        Set(ByVal Total As String)
            userLogin = Total
        End Set
        Get
            Return userLogin
        End Get
    End Property


End Module
