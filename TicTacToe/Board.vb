Public Class GameBoard
    Public Const Playable As Byte = 0
    Public Const PlayedX As Byte = 1
    Public Const PlayedO As Byte = 2
    Public Const Frozen As Byte = 3

    Public Game() As Byte =
        {0, 0, 0,
         0, 0, 0,
         0, 0, 0}
    Public Sub New()
        For i = LBound(Game) To UBound(Game)
            Game(i) = Playable
        Next
    End Sub
    Public Function GameToString()
        Dim msg As String = ""
        For Each i As Byte In Game
            msg += i & ", "
        Next
        Return msg
    End Function

    Public ReadOnly Property TopRow As Byte()
        Get
            Return {TopLeft, TopMiddle, TopRight}
        End Get
    End Property
    Public ReadOnly Property MiddleRow As Byte()
        Get
            Return {CenterLeft, CenterMiddle, CenterRight}
        End Get
    End Property
    Public ReadOnly Property BottomRow As Byte()
        Get
            Return {BottomLeft, BottomMiddle, BottomRight}
        End Get
    End Property
    Public ReadOnly Property LeftColumn As Byte()
        Get
            Return {TopLeft, CenterLeft, BottomLeft}
        End Get
    End Property
    Public ReadOnly Property MiddleColumn As Byte()
        Get
            Return {TopMiddle, CenterMiddle, BottomMiddle}
        End Get
    End Property
    Public ReadOnly Property RightColumn As Byte()
        Get
            Return {TopRight, CenterRight, BottomRight}
        End Get
    End Property
    Public ReadOnly Property ForwardDiagonal As Byte()
        Get
            Return {TopLeft, CenterMiddle, BottomRight}
        End Get
    End Property
    Public ReadOnly Property BackwardDiagonal As Byte()
        Get
            Return {TopRight, CenterMiddle, BottomLeft}
        End Get
    End Property


    Public Property TopLeft As Byte
        Get
            Return Game(0)
        End Get
        Set(value As Byte)
            Game(0) = value
        End Set
    End Property
    Public Property TopMiddle As Byte
        Get
            Return Game(1)
        End Get
        Set(value As Byte)
            Game(1) = value
        End Set
    End Property
    Public Property TopRight As Byte
        Get
            Return Game(2)
        End Get
        Set(value As Byte)
            Game(2) = value
        End Set
    End Property
    Public Property CenterLeft As Byte
        Get
            Return Game(3)
        End Get
        Set(value As Byte)
            Game(3) = value
        End Set
    End Property
    Public Property CenterMiddle As Byte
        Get
            Return Game(4)
        End Get
        Set(value As Byte)
            Game(4) = value
        End Set
    End Property
    Public Property CenterRight As Byte
        Get
            Return Game(5)
        End Get
        Set(value As Byte)
            Game(5) = value
        End Set
    End Property
    Public Property BottomLeft As Byte
        Get
            Return Game(6)
        End Get
        Set(value As Byte)
            Game(6) = value
        End Set
    End Property
    Public Property BottomMiddle As Byte
        Get
            Return Game(7)
        End Get
        Set(value As Byte)
            Game(7) = value
        End Set
    End Property
    Public Property BottomRight As Byte
        Get
            Return Game(8)
        End Get
        Set(value As Byte)
            Game(8) = value
        End Set
    End Property
End Class
Public Class ScoreBoard
    Public Scores(3) As Byte
    Public Sub New()
        For i = LBound(Scores) To UBound(Scores)
            Scores(i) = 0
        Next
    End Sub

    Public Property pointsX As Byte
        Get
            Return Scores(0)
        End Get
        Set(value As Byte)
            Scores(0) = value
        End Set
    End Property
    Public Property pointsO As Byte
        Get
            Return Scores(1)
        End Get
        Set(value As Byte)
            Scores(1) = value
        End Set
    End Property
    Public Property pointsDraw As Byte
        Get
            Return Scores(2)
        End Get
        Set(value As Byte)
            Scores(2) = value
        End Set
    End Property
    Public Property totalGames As Byte
        Get
            Return Scores(3)
        End Get
        Set(value As Byte)
            Scores(3) = value
        End Set
    End Property
End Class