Module Computer
    Public ordPlay As Boolean
    Dim ordMove As Byte = 0
    Dim ordNextMove As Byte = 0
    Public ordTurn As Boolean = True

    Private Function rndNum(maxVal As Byte)
        Return New Random().Next(1, (maxVal + 1)) 'random number generator
    End Function 'Choisir un nombre au hazard

    Public Sub selectPC()
        ordMove = 0
#Region "Computer"
#Region "Horizontal"
#Region "Top"
        If ((Game.TopLeft = player2Piece) And Game.TopLeft = Game.TopMiddle And Game.TopRight = GameBoard.Playable) Then
            ordMove = 3
        ElseIf ((Game.TopLeft = player2Piece) And Game.TopLeft = Game.TopRight And Game.TopMiddle = GameBoard.Playable) Then
            ordMove = 2
        ElseIf ((Game.TopMiddle = player2Piece) And Game.TopMiddle = Game.TopLeft And Game.TopRight = GameBoard.Playable) Then
            ordMove = 3
        ElseIf ((Game.TopMiddle = player2Piece) And Game.TopMiddle = Game.TopRight And Game.TopLeft = GameBoard.Playable) Then
            ordMove = 1
        ElseIf ((Game.TopRight = player2Piece) And Game.TopRight = Game.TopLeft And Game.TopMiddle = GameBoard.Playable) Then
            ordMove = 2
        ElseIf ((Game.TopRight = player2Piece) And Game.TopRight = Game.TopMiddle And Game.TopLeft = GameBoard.Playable) Then
            ordMove = 1
#End Region
#Region "Center"
        ElseIf ((Game.CenterLeft = player2Piece) And Game.CenterLeft = Game.CenterMiddle And Game.CenterRight = GameBoard.Playable) Then
            ordMove = 6
        ElseIf ((Game.CenterLeft = player2Piece) And Game.CenterLeft = Game.CenterRight And Game.CenterMiddle = GameBoard.Playable) Then
            ordMove = 5
        ElseIf ((Game.CenterMiddle = player2Piece) And Game.CenterMiddle = Game.CenterRight And Game.CenterLeft = GameBoard.Playable) Then
            ordMove = 4
        ElseIf ((Game.CenterMiddle = player2Piece) And Game.CenterMiddle = Game.CenterLeft And Game.CenterRight = GameBoard.Playable) Then
            ordMove = 6
        ElseIf ((Game.CenterRight = player2Piece) And Game.CenterRight = Game.CenterMiddle And Game.CenterLeft = GameBoard.Playable) Then
            ordMove = 4
        ElseIf ((Game.CenterRight = player2Piece) And Game.CenterRight = Game.CenterLeft And Game.CenterMiddle = GameBoard.Playable) Then
            ordMove = 5
#End Region
#Region "Bottom"
        ElseIf ((Game.BottomLeft = player2Piece) And Game.BottomLeft = Game.BottomMiddle And Game.BottomRight = GameBoard.Playable) Then
            ordMove = 9
        ElseIf ((Game.BottomLeft = player2Piece) And Game.BottomLeft = Game.BottomRight And Game.BottomMiddle = GameBoard.Playable) Then
            ordMove = 8
        ElseIf ((Game.BottomMiddle = player2Piece) And Game.BottomMiddle = Game.BottomLeft And Game.BottomRight = GameBoard.Playable) Then
            ordMove = 9
        ElseIf ((Game.BottomMiddle = player2Piece) And Game.BottomMiddle = Game.BottomRight And Game.BottomLeft = GameBoard.Playable) Then
            ordMove = 7
        ElseIf ((Game.BottomRight = player2Piece) And Game.BottomRight = Game.BottomMiddle And Game.BottomLeft = GameBoard.Playable) Then
            ordMove = 7
        ElseIf ((Game.BottomRight = player2Piece) And Game.BottomRight = Game.BottomLeft And Game.BottomMiddle = GameBoard.Playable) Then
            ordMove = 8
#End Region
#End Region
#Region "Vertical"
#Region "Left"
        ElseIf ((Game.TopLeft = player2Piece) And Game.TopLeft = Game.BottomLeft And Game.CenterLeft = GameBoard.Playable) Then
            ordMove = 4
        ElseIf ((Game.TopLeft = player2Piece) And Game.TopLeft = Game.CenterLeft And Game.BottomLeft = GameBoard.Playable) Then
            ordMove = 7
        ElseIf ((Game.CenterLeft = player2Piece) And Game.CenterLeft = Game.BottomLeft And Game.TopLeft = GameBoard.Playable) Then
            ordMove = 1
        ElseIf ((Game.CenterLeft = player2Piece) And Game.CenterLeft = Game.TopLeft And Game.BottomLeft = GameBoard.Playable) Then
            ordMove = 7
        ElseIf ((Game.BottomLeft = player2Piece) And Game.BottomLeft = Game.TopLeft And Game.CenterLeft = GameBoard.Playable) Then
            ordMove = 4
        ElseIf ((Game.BottomLeft = player2Piece) And Game.BottomLeft = Game.CenterLeft And Game.TopLeft = GameBoard.Playable) Then
            ordMove = 1
#End Region
#Region "Middle"
        ElseIf ((Game.TopMiddle = player2Piece) And Game.TopMiddle = Game.BottomMiddle And Game.CenterMiddle = GameBoard.Playable) Then
            ordMove = 5
        ElseIf ((Game.TopMiddle = player2Piece) And Game.TopMiddle = Game.CenterMiddle And Game.BottomMiddle = GameBoard.Playable) Then
            ordMove = 8
        ElseIf ((Game.CenterMiddle = player2Piece) And Game.CenterMiddle = Game.BottomMiddle And Game.TopMiddle = GameBoard.Playable) Then
            ordMove = 2
        ElseIf ((Game.CenterMiddle = player2Piece) And Game.CenterMiddle = Game.TopMiddle And Game.BottomMiddle = GameBoard.Playable) Then
            ordMove = 8
        ElseIf ((Game.BottomMiddle = player2Piece) And Game.BottomMiddle = Game.TopMiddle And Game.CenterMiddle = GameBoard.Playable) Then
            ordMove = 5
        ElseIf ((Game.BottomMiddle = player2Piece) And Game.BottomMiddle = Game.CenterMiddle And Game.TopMiddle = GameBoard.Playable) Then
            ordMove = 2
#End Region
#Region "Right"
        ElseIf ((Game.TopRight = player2Piece) And Game.TopRight = Game.BottomRight And Game.CenterRight = GameBoard.Playable) Then
            ordMove = 6
        ElseIf ((Game.TopRight = player2Piece) And Game.TopRight = Game.CenterRight And Game.BottomRight = GameBoard.Playable) Then
            ordMove = 9
        ElseIf ((Game.CenterRight = player2Piece) And Game.CenterRight = Game.BottomRight And Game.TopRight = GameBoard.Playable) Then
            ordMove = 3
        ElseIf ((Game.CenterRight = player2Piece) And Game.CenterRight = Game.TopRight And Game.BottomRight = GameBoard.Playable) Then
            ordMove = 9
        ElseIf ((Game.BottomRight = player2Piece) And Game.BottomRight = Game.CenterRight And Game.TopRight = GameBoard.Playable) Then
            ordMove = 3
        ElseIf ((Game.BottomRight = player2Piece) And Game.BottomRight = Game.TopRight And Game.CenterRight = GameBoard.Playable) Then
            ordMove = 6
#End Region
#End Region
#Region "Diagonal"
#Region "Backslash"
        ElseIf ((Game.TopLeft = player2Piece) And Game.TopLeft = Game.CenterMiddle And Game.BottomRight = GameBoard.Playable) Then
            ordMove = 9
        ElseIf ((Game.TopLeft = player2Piece) And Game.TopLeft = Game.BottomRight And Game.CenterMiddle = GameBoard.Playable) Then
            ordMove = 5
        ElseIf ((Game.CenterMiddle = player2Piece) And Game.CenterMiddle = Game.TopLeft And Game.BottomRight = GameBoard.Playable) Then
            ordMove = 9
        ElseIf ((Game.CenterMiddle = player2Piece) And Game.CenterMiddle = Game.BottomRight And Game.TopLeft = GameBoard.Playable) Then
            ordMove = 1
        ElseIf ((Game.BottomRight = player2Piece) And Game.BottomRight = Game.CenterMiddle And Game.TopLeft = GameBoard.Playable) Then
            ordMove = 1
        ElseIf ((Game.BottomRight = player2Piece) And Game.BottomRight = Game.TopLeft And Game.CenterMiddle = GameBoard.Playable) Then
            ordMove = 5
#End Region
#Region "Forwardslash"
        ElseIf ((Game.TopRight = player2Piece) And Game.TopRight = Game.BottomLeft And Game.CenterMiddle = GameBoard.Playable) Then
            ordMove = 5
        ElseIf ((Game.TopRight = player2Piece) And Game.TopRight = Game.CenterMiddle And Game.BottomLeft = GameBoard.Playable) Then
            ordMove = 7
        ElseIf ((Game.CenterMiddle = player2Piece) And Game.CenterMiddle = Game.BottomLeft And Game.TopRight = GameBoard.Playable) Then
            ordMove = 3
        ElseIf ((Game.CenterMiddle = player2Piece) And Game.CenterMiddle = Game.TopRight And Game.BottomLeft = GameBoard.Playable) Then
            ordMove = 7
        ElseIf ((Game.BottomLeft = player2Piece) And Game.BottomLeft = Game.TopRight And Game.CenterMiddle = GameBoard.Playable) Then
            ordMove = 5
        ElseIf ((Game.BottomLeft = player2Piece) And Game.BottomLeft = Game.CenterMiddle And Game.TopRight = GameBoard.Playable) Then
            ordMove = 3
#End Region
#End Region
#End Region 'Verifie si l'ordis peut gagner

#Region "Player"
#Region "Horizontal"
            'Top
        ElseIf ((Game.TopLeft = player1Piece) And Game.TopLeft = Game.TopMiddle And Game.TopRight = GameBoard.Playable) Then
            ordMove = 3
        ElseIf ((Game.TopLeft = player1Piece) And Game.TopLeft = Game.TopRight And Game.TopMiddle = GameBoard.Playable) Then
            ordMove = 2
        ElseIf ((Game.TopMiddle = player1Piece) And Game.TopMiddle = Game.TopLeft And Game.TopRight = GameBoard.Playable) Then
            ordMove = 3
        ElseIf ((Game.TopMiddle = player1Piece) And Game.TopMiddle = Game.TopRight And Game.TopLeft = GameBoard.Playable) Then
            ordMove = 1
        ElseIf ((Game.TopRight = player1Piece) And Game.TopRight = Game.TopLeft And Game.TopMiddle = GameBoard.Playable) Then
            ordMove = 2
        ElseIf ((Game.TopRight = player1Piece) And Game.TopRight = Game.TopMiddle And Game.TopLeft = GameBoard.Playable) Then
            ordMove = 1
            'Middle	
        ElseIf ((Game.CenterLeft = player1Piece) And Game.CenterLeft = Game.CenterMiddle And Game.CenterRight = GameBoard.Playable) Then
            ordMove = 6
        ElseIf ((Game.CenterLeft = player1Piece) And Game.CenterLeft = Game.CenterRight And Game.CenterMiddle = GameBoard.Playable) Then
            ordMove = 5
        ElseIf ((Game.CenterMiddle = player1Piece) And Game.CenterMiddle = Game.CenterRight And Game.CenterLeft = GameBoard.Playable) Then
            ordMove = 4
        ElseIf ((Game.CenterMiddle = player1Piece) And Game.CenterMiddle = Game.CenterLeft And Game.CenterRight = GameBoard.Playable) Then
            ordMove = 6
        ElseIf ((Game.CenterRight = player1Piece) And Game.CenterRight = Game.CenterMiddle And Game.CenterLeft = GameBoard.Playable) Then
            ordMove = 4
        ElseIf ((Game.CenterRight = player1Piece) And Game.CenterRight = Game.CenterLeft And Game.CenterMiddle = GameBoard.Playable) Then
            ordMove = 5
            'Bottom
        ElseIf ((Game.BottomLeft = player1Piece) And Game.BottomLeft = Game.BottomMiddle And Game.BottomRight = GameBoard.Playable) Then
            ordMove = 9
        ElseIf ((Game.BottomLeft = player1Piece) And Game.BottomLeft = Game.BottomRight And Game.BottomMiddle = GameBoard.Playable) Then
            ordMove = 8
        ElseIf ((Game.BottomMiddle = player1Piece) And Game.BottomMiddle = Game.BottomLeft And Game.BottomRight = GameBoard.Playable) Then
            ordMove = 9
        ElseIf ((Game.BottomMiddle = player1Piece) And Game.BottomMiddle = Game.BottomRight And Game.BottomLeft = GameBoard.Playable) Then
            ordMove = 7
        ElseIf ((Game.BottomRight = player1Piece) And Game.BottomRight = Game.BottomMiddle And Game.BottomLeft = GameBoard.Playable) Then
            ordMove = 7
        ElseIf ((Game.BottomRight = player1Piece) And Game.BottomRight = Game.BottomLeft And Game.BottomMiddle = GameBoard.Playable) Then
            ordMove = 8
#End Region
#Region "Vertical"
            'left
        ElseIf ((Game.TopLeft = player1Piece) And Game.TopLeft = Game.BottomLeft And Game.CenterLeft = GameBoard.Playable) Then
            ordMove = 4
        ElseIf ((Game.TopLeft = player1Piece) And Game.TopLeft = Game.CenterLeft And Game.BottomLeft = GameBoard.Playable) Then
            ordMove = 7
        ElseIf ((Game.CenterLeft = player1Piece) And Game.CenterLeft = Game.BottomLeft And Game.TopLeft = GameBoard.Playable) Then
            ordMove = 1
        ElseIf ((Game.CenterLeft = player1Piece) And Game.CenterLeft = Game.TopLeft And Game.BottomLeft = GameBoard.Playable) Then
            ordMove = 7
        ElseIf ((Game.BottomLeft = player1Piece) And Game.BottomLeft = Game.TopLeft And Game.CenterLeft = GameBoard.Playable) Then
            ordMove = 4
        ElseIf ((Game.BottomLeft = player1Piece) And Game.BottomLeft = Game.CenterLeft And Game.TopLeft = GameBoard.Playable) Then
            ordMove = 1
            'middle
        ElseIf ((Game.TopMiddle = player1Piece) And Game.TopMiddle = Game.BottomMiddle And Game.CenterMiddle = GameBoard.Playable) Then
            ordMove = 5
        ElseIf ((Game.TopMiddle = player1Piece) And Game.TopMiddle = Game.CenterMiddle And Game.BottomMiddle = GameBoard.Playable) Then
            ordMove = 8
        ElseIf ((Game.CenterMiddle = player1Piece) And Game.CenterMiddle = Game.BottomMiddle And Game.TopMiddle = GameBoard.Playable) Then
            ordMove = 2
        ElseIf ((Game.CenterMiddle = player1Piece) And Game.CenterMiddle = Game.TopMiddle And Game.BottomMiddle = GameBoard.Playable) Then
            ordMove = 8
        ElseIf ((Game.BottomMiddle = player1Piece) And Game.BottomMiddle = Game.TopMiddle And Game.CenterMiddle = GameBoard.Playable) Then
            ordMove = 5
        ElseIf ((Game.BottomMiddle = player1Piece) And Game.BottomMiddle = Game.CenterMiddle And Game.TopMiddle = GameBoard.Playable) Then
            ordMove = 2
            'right	
        ElseIf ((Game.TopRight = player1Piece) And Game.TopRight = Game.BottomRight And Game.CenterRight = GameBoard.Playable) Then
            ordMove = 6
        ElseIf ((Game.TopRight = player1Piece) And Game.TopRight = Game.CenterRight And Game.BottomRight = GameBoard.Playable) Then
            ordMove = 9
        ElseIf ((Game.CenterRight = player1Piece) And Game.CenterRight = Game.BottomRight And Game.TopRight = GameBoard.Playable) Then
            ordMove = 3
        ElseIf ((Game.CenterRight = player1Piece) And Game.CenterRight = Game.TopRight And Game.BottomRight = GameBoard.Playable) Then
            ordMove = 9
        ElseIf ((Game.BottomRight = player1Piece) And Game.BottomRight = Game.CenterRight And Game.TopRight = GameBoard.Playable) Then
            ordMove = 3
        ElseIf ((Game.BottomRight = player1Piece) And Game.BottomRight = Game.TopRight And Game.CenterRight = GameBoard.Playable) Then
            ordMove = 6
#End Region
#Region "Diagonal"
            'backslash
        ElseIf ((Game.TopLeft = player1Piece) And Game.TopLeft = Game.CenterMiddle And Game.BottomRight = GameBoard.Playable) Then
            ordMove = 9
        ElseIf ((Game.TopLeft = player1Piece) And Game.TopLeft = Game.BottomRight And Game.CenterMiddle = GameBoard.Playable) Then
            ordMove = 5
        ElseIf ((Game.CenterMiddle = player1Piece) And Game.CenterMiddle = Game.TopLeft And Game.BottomRight = GameBoard.Playable) Then
            ordMove = 9
        ElseIf ((Game.CenterMiddle = player1Piece) And Game.CenterMiddle = Game.BottomRight And Game.TopLeft = GameBoard.Playable) Then
            ordMove = 1
        ElseIf ((Game.BottomRight = player1Piece) And Game.BottomRight = Game.CenterMiddle And Game.TopLeft = GameBoard.Playable) Then
            ordMove = 1
        ElseIf ((Game.BottomRight = player1Piece) And Game.BottomRight = Game.TopLeft And Game.CenterMiddle = GameBoard.Playable) Then
            ordMove = 5
            'forwardslash
        ElseIf ((Game.TopRight = player1Piece) And Game.TopRight = Game.BottomLeft And Game.CenterMiddle = GameBoard.Playable) Then
            ordMove = 5
        ElseIf ((Game.TopRight = player1Piece) And Game.TopRight = Game.CenterMiddle And Game.BottomLeft = GameBoard.Playable) Then
            ordMove = 7
        ElseIf ((Game.CenterMiddle = player1Piece) And Game.CenterMiddle = Game.BottomLeft And Game.TopRight = GameBoard.Playable) Then
            ordMove = 3
        ElseIf ((Game.CenterMiddle = player1Piece) And Game.CenterMiddle = Game.TopRight And Game.BottomLeft = GameBoard.Playable) Then
            ordMove = 7
        ElseIf ((Game.BottomLeft = player1Piece) And Game.BottomLeft = Game.TopRight And Game.CenterMiddle = GameBoard.Playable) Then
            ordMove = 5
        ElseIf ((Game.BottomLeft = player1Piece) And Game.BottomLeft = Game.CenterMiddle And Game.TopRight = GameBoard.Playable) Then
            ordMove = 3
#End Region
#End Region 'Empêcher le joueur
        Else
#Region "Strategies"
            If (ordNextMove <> 0) Then
                ordMove = ordNextMove
                ordNextMove = 0
            ElseIf ((Game.TopLeft = player2Piece) And (Game.TopLeft = Game.TopRight) And (Game.BottomRight = GameBoard.Playable)) Then
                ordMove = 9
            ElseIf ((Game.TopLeft = player2Piece) And (Game.TopLeft = Game.TopRight) And (Game.BottomLeft = GameBoard.Playable)) Then
                ordMove = 7
            ElseIf ((Game.TopRight = player2Piece) And (Game.TopRight = Game.BottomRight) And (Game.BottomLeft = GameBoard.Playable)) Then
                ordMove = 7
            ElseIf ((Game.TopRight = player2Piece) And (Game.TopRight = Game.BottomRight) And (Game.TopLeft = GameBoard.Playable)) Then
                ordMove = 1
            ElseIf ((Game.BottomRight = player2Piece) And (Game.BottomRight = Game.BottomLeft) And (Game.TopLeft = GameBoard.Playable)) Then
                ordMove = 1
            ElseIf ((Game.BottomRight = player2Piece) And (Game.BottomRight = Game.BottomLeft) And (Game.TopRight = GameBoard.Playable)) Then
                ordMove = 3
            ElseIf ((Game.TopLeft = player2Piece) And (Game.TopLeft = Game.BottomLeft) And (Game.TopRight = GameBoard.Playable)) Then
                ordMove = 3
            ElseIf ((Game.TopLeft = player2Piece) And (Game.TopLeft = Game.BottomLeft) And (Game.BottomRight = GameBoard.Playable)) Then
                ordMove = 9
            ElseIf ((Game.TopLeft = player2Piece) And (Game.TopLeft = Game.BottomRight) And (Game.TopRight = GameBoard.Playable)) Then
                ordMove = 3
            ElseIf ((Game.TopLeft = player2Piece) And (Game.TopLeft = Game.BottomRight) And (Game.BottomLeft = GameBoard.Playable)) Then
                ordMove = 7
            ElseIf ((Game.TopRight = player2Piece) And (Game.TopRight = Game.BottomLeft) And (Game.TopLeft = GameBoard.Playable)) Then
                ordMove = 1
            ElseIf ((Game.TopRight = player2Piece) And (Game.TopRight = Game.BottomLeft) And (Game.BottomRight = GameBoard.Playable)) Then
                ordMove = 9
            ElseIf (Game.TopLeft = player1Piece) And (Game.TopMiddle = GameBoard.Playable) And (Game.TopMiddle = Game.CenterMiddle) Then
                ordMove = 5
            ElseIf (Game.TopRight = player1Piece) And (Game.TopMiddle = GameBoard.Playable) And (Game.TopMiddle = Game.CenterMiddle) Then
                ordMove = 5
            ElseIf (Game.BottomLeft = player1Piece) And (Game.TopMiddle = GameBoard.Playable) And (Game.TopMiddle = Game.CenterMiddle) Then
                ordMove = 5
            ElseIf (Game.BottomRight = player1Piece) And (Game.TopMiddle = GameBoard.Playable) And (Game.TopMiddle = Game.CenterMiddle) Then
                ordMove = 5
            ElseIf (Game.TopMiddle = player1Piece) And (Game.TopRight = GameBoard.Playable) Then
                ordMove = 3
                ordNextMove = If(Game.CenterMiddle = GameBoard.Playable, 5, 0)
            ElseIf (Game.CenterRight = player1Piece) And (Game.BottomRight = GameBoard.Playable) Then
                ordMove = 9
                ordNextMove = If(Game.CenterMiddle = GameBoard.Playable, 5, 0)
            ElseIf (Game.BottomMiddle = player1Piece) And (Game.BottomLeft = GameBoard.Playable) Then
                ordMove = 7
                ordNextMove = If(Game.CenterMiddle = GameBoard.Playable, 5, 0)
            ElseIf (Game.CenterLeft = player1Piece) And (Game.TopLeft = GameBoard.Playable) Then
                ordMove = 1
                ordNextMove = If(Game.CenterMiddle = GameBoard.Playable, 5, 0)
            ElseIf ((Game.TopLeft = player1Piece) And (Game.TopLeft = Game.BottomRight) And (Game.CenterMiddle = player2Piece)) Then
                ordMove = 8
            ElseIf ((Game.TopRight = player1Piece) And (Game.TopRight = Game.BottomLeft) And (Game.CenterMiddle = player2Piece)) Then
                ordMove = 2
            ElseIf (Game.TopMiddle = player1Piece) And (Game.TopMiddle = Game.CenterLeft) And (Game.TopLeft = GameBoard.Playable) Then
                ordMove = 1
            ElseIf (Game.TopMiddle = player1Piece) And (Game.TopMiddle = Game.CenterRight) And (Game.TopRight = GameBoard.Playable) Then
                ordMove = 3
            ElseIf (Game.CenterLeft = player1Piece) And (Game.CenterLeft = Game.BottomMiddle) And (Game.BottomLeft = GameBoard.Playable) Then
                ordMove = 7
            ElseIf (Game.CenterRight = player1Piece) And (Game.CenterRight = Game.BottomMiddle) And (Game.BottomRight = GameBoard.Playable) Then
                ordMove = 9
            ElseIf (Game.TopMiddle = player1Piece) And (Game.TopMiddle = Game.CenterLeft) And (Game.CenterMiddle = GameBoard.Playable) Then
                ordMove = 5
            ElseIf (Game.TopMiddle = player1Piece) And (Game.TopMiddle = Game.CenterRight) And (Game.CenterMiddle = GameBoard.Playable) Then
                ordMove = 5
            ElseIf (Game.CenterLeft = player1Piece) And (Game.CenterLeft = Game.BottomMiddle) And (Game.CenterMiddle = GameBoard.Playable) Then
                ordMove = 5
            ElseIf (Game.CenterRight = player1Piece) And (Game.CenterRight = Game.BottomMiddle) And (Game.CenterMiddle = GameBoard.Playable) Then
                ordMove = 5
#End Region
            Else
#Region "Random"
                Select Case rndNum(5)
                    Case 1
                        ordMove = 1
                    Case 2
                        ordMove = 3
                    Case 3
                        ordMove = 5
                    Case 4
                        ordMove = 7
                    Case 5
                        ordMove = 9
                    Case Else
                        ordMove = rndNum(9)
                End Select
#End Region
            End If
        End If
        If ordMove <> 0 Then playPC()
    End Sub
    Private Sub playPC()
        Main.Refresh()
        Threading.Thread.Sleep(675)

        Select Case ordMove
            Case 1
                If Game.TopLeft = GameBoard.Playable Then
                    Select Case checkTurn()
                        Case 1
                            Main.pb_TopLeft.BackgroundImage = My.Resources.O
                            Game.TopLeft = GameBoard.PlayedO
                        Case 0
                            Main.pb_TopLeft.BackgroundImage = My.Resources.X
                            Game.TopLeft = GameBoard.PlayedX
                    End Select
                    placePC()
                Else
                    selectPC()
                End If
            Case 2
                If Game.TopMiddle = GameBoard.Playable Then
                    Select Case checkTurn()
                        Case 1
                            Main.pb_TopMiddle.BackgroundImage = My.Resources.O
                            Game.TopMiddle = GameBoard.PlayedO
                        Case 0
                            Main.pb_TopMiddle.BackgroundImage = My.Resources.X
                            Game.TopMiddle = GameBoard.PlayedX
                    End Select
                    placePC()
                Else
                    selectPC()
                End If
            Case 3
                If Game.TopRight = GameBoard.Playable Then
                    Select Case checkTurn()
                        Case 1
                            Main.pb_TopRight.BackgroundImage = My.Resources.O
                            Game.TopRight = GameBoard.PlayedO
                        Case 0
                            Main.pb_TopRight.BackgroundImage = My.Resources.X
                            Game.TopRight = GameBoard.PlayedX
                    End Select
                    placePC()
                Else
                    selectPC()
                End If
            Case 4
                If Game.CenterLeft = GameBoard.Playable Then
                    Select Case checkTurn()
                        Case 1
                            Main.pb_CenterLeft.BackgroundImage = My.Resources.O
                            Game.CenterLeft = GameBoard.PlayedO
                        Case 0
                            Main.pb_CenterLeft.BackgroundImage = My.Resources.X
                            Game.CenterLeft = GameBoard.PlayedX
                    End Select
                    placePC()
                Else
                    selectPC()
                End If
            Case 5
                If Game.CenterMiddle = GameBoard.Playable Then
                    Select Case checkTurn()
                        Case 1
                            Main.pb_CenterMiddle.BackgroundImage = My.Resources.O
                            Game.CenterMiddle = GameBoard.PlayedO
                        Case 0
                            Main.pb_CenterMiddle.BackgroundImage = My.Resources.X
                            Game.CenterMiddle = GameBoard.PlayedX
                    End Select
                    placePC()
                Else
                    selectPC()
                End If
            Case 6
                If Game.CenterRight = GameBoard.Playable Then
                    Select Case checkTurn()
                        Case 1
                            Main.pb_CenterRight.BackgroundImage = My.Resources.O
                            Game.CenterRight = GameBoard.PlayedO
                        Case 0
                            Main.pb_CenterRight.BackgroundImage = My.Resources.X
                            Game.CenterRight = GameBoard.PlayedX
                    End Select
                    placePC()
                Else
                    selectPC()
                End If
            Case 7
                If Game.BottomLeft = GameBoard.Playable Then
                    Select Case checkTurn()
                        Case 1
                            Main.pb_BottomLeft.BackgroundImage = My.Resources.O
                            Game.BottomLeft = GameBoard.PlayedO
                        Case 0
                            Main.pb_BottomLeft.BackgroundImage = My.Resources.X
                            Game.BottomLeft = GameBoard.PlayedX
                    End Select
                    placePC()
                Else
                    selectPC()
                End If
            Case 8
                If Game.BottomMiddle = GameBoard.Playable Then
                    Select Case checkTurn()
                        Case 1
                            Main.pb_BottomMiddle.BackgroundImage = My.Resources.O
                            Game.BottomMiddle = GameBoard.PlayedO
                        Case 0
                            Main.pb_BottomMiddle.BackgroundImage = My.Resources.X
                            Game.BottomMiddle = GameBoard.PlayedX
                    End Select
                    placePC()
                Else
                    selectPC()
                End If
            Case 9
                If Game.BottomRight = GameBoard.Playable Then
                    Select Case checkTurn()
                        Case 1
                            Main.pb_BottomRight.BackgroundImage = My.Resources.O
                            Game.BottomRight = GameBoard.PlayedO
                        Case 0
                            Main.pb_BottomRight.BackgroundImage = My.Resources.X
                            Game.BottomRight = GameBoard.PlayedX
                    End Select
                    placePC()
                Else
                    selectPC()
                End If
        End Select
    End Sub
    Private Sub placePC()
        Main.playSFX(My.Resources.drop)
        ordTurn = False
        checkWin()
        turnIncrement()
    End Sub
End Module
