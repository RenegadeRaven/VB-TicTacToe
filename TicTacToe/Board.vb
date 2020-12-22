Public Class Board
    Public Const Playable As Byte = 0
    Public Const PlayedX As Byte = 1
    Public Const PlayedO As Byte = 2
    Public Const Frozen As Byte = 3

    Public Game(8) As Byte

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
