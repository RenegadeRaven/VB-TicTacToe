Module GameLogic
    Public player1Piece As Byte = 1
    Public player2Piece As Byte = 1 + (player1Piece Mod 2)
    Public turnCount As Byte = 0
    Public Game As New GameBoard
    Public Score As New ScoreBoard
    Public highlightColor As Color = Color.PaleGreen

    Public Sub turnText()
        Select Case checkTurn()
            Case 0
                Main.Label1.Text = Main.LangData("X turn")
            Case 1
                Main.Label1.Text = Main.LangData("O turn")
        End Select
    End Sub 'Verifie le tour
    Public Function checkTurn()
        Return turnCount Mod 2
    End Function
    Public Sub turnIncrement()
        turnCount += 1
        turnText()
    End Sub 'Count le tour
    Private Function checkBoard(boardRow As Byte())
        Dim allSame As Boolean = True
        For Each i As Byte In boardRow
            If (i <> boardRow(0)) Or (i = GameBoard.Playable) Then allSame = False
        Next
        Return allSame
    End Function
    Private Sub whoWon(Spot As Byte)
        Select Case Spot
            Case GameBoard.PlayedX
                Main.Label1.Text = Main.LangData("X wins")
                Score.pointsX += 1
            Case GameBoard.PlayedO
                Main.Label1.Text = Main.LangData("O wins")
                Score.pointsO += 1
        End Select
        Main.playSFX(My.Resources.point)
        Score.totalGames += 1
        Main.updateScore()
    End Sub
    Public Sub checkWin()
        If checkBoard(Game.TopRow) Then
            Main.pb_TopLeft.BackColor = highlightColor
            Main.pb_TopMiddle.BackColor = highlightColor
            Main.pb_TopRight.BackColor = highlightColor
            freezeGame()
            whoWon(Game.TopLeft)
        ElseIf checkBoard(Game.MiddleRow) Then
            Main.pb_CenterLeft.BackColor = highlightColor
            Main.pb_CenterMiddle.BackColor = highlightColor
            Main.pb_CenterRight.BackColor = highlightColor
            freezeGame()
            whoWon(Game.CenterLeft)
        ElseIf checkBoard(Game.BottomRow) Then
            Main.pb_BottomLeft.BackColor = highlightColor
            Main.pb_BottomMiddle.BackColor = highlightColor
            Main.pb_BottomRight.BackColor = highlightColor
            freezeGame()
            whoWon(Game.BottomLeft)
        ElseIf checkBoard(Game.LeftColumn) Then
            Main.pb_TopLeft.BackColor = highlightColor
            Main.pb_CenterLeft.BackColor = highlightColor
            Main.pb_BottomLeft.BackColor = highlightColor
            freezeGame()
            whoWon(Game.BottomLeft)
        ElseIf checkBoard(Game.MiddleColumn) Then
            Main.pb_TopMiddle.BackColor = highlightColor
            Main.pb_BottomMiddle.BackColor = highlightColor
            Main.pb_CenterMiddle.BackColor = highlightColor
            freezeGame()
            whoWon(Game.CenterMiddle)
        ElseIf checkBoard(Game.RightColumn) Then
            Main.pb_TopRight.BackColor = highlightColor
            Main.pb_CenterRight.BackColor = highlightColor
            Main.pb_BottomRight.BackColor = highlightColor
            freezeGame()
            whoWon(Game.BottomRight)
        ElseIf checkBoard(Game.ForwardDiagonal) Then
            Main.pb_TopLeft.BackColor = highlightColor
            Main.pb_BottomRight.BackColor = highlightColor
            Main.pb_CenterMiddle.BackColor = highlightColor
            freezeGame()
            whoWon(Game.CenterMiddle)
        ElseIf checkBoard(Game.BackwardDiagonal) Then
            Main.pb_TopRight.BackColor = highlightColor
            Main.pb_BottomLeft.BackColor = highlightColor
            Main.pb_CenterMiddle.BackColor = highlightColor
            freezeGame()
            whoWon(Game.CenterMiddle)
        ElseIf checkDraw() Then
            Main.Label1.Text = Main.LangData("Draw Text")
            Score.pointsDraw += 1
            Score.totalGames += 1
            freezeGame()
            Main.updateScore()
        End If
        If ordTurn = True And ordPlay = True Then selectPC()
    End Sub
    Private Function checkDraw()
        Dim isDraw = True
        For i = LBound(Game.Game) To UBound(Game.Game)
            If Game.Game(i) = GameBoard.Playable Then isDraw = False
        Next
        Return isDraw
    End Function
    Private Sub freezeGame()
        For i = LBound(Game.Game) To UBound(Game.Game)
            If Game.Game(i) = GameBoard.Playable Then Game.Game(i) = GameBoard.Frozen
        Next
        ordTurn = False
    End Sub 'Arrete le jeu quand quelqu'un gagne
    Public Sub newGame()
        turnCount = 1 - (player1Piece Mod 2)
        Game = New GameBoard
        ordTurn = False
        Main.pb_TopLeft.BackgroundImage = Nothing
        Main.pb_TopMiddle.BackgroundImage = Nothing
        Main.pb_TopRight.BackgroundImage = Nothing
        Main.pb_CenterLeft.BackgroundImage = Nothing
        Main.pb_CenterMiddle.BackgroundImage = Nothing
        Main.pb_CenterRight.BackgroundImage = Nothing
        Main.pb_BottomLeft.BackgroundImage = Nothing
        Main.pb_BottomMiddle.BackgroundImage = Nothing
        Main.pb_BottomRight.BackgroundImage = Nothing

        Main.invertColor()
        Main.bt_NewGame.Text = Main.LangData("NewGame").ToString() & (Score.totalGames + 1)
        turnText()
    End Sub 'Nouveau jeu
    Public Sub selPlayer()
        Select Case MsgBox(Main.LangData("PlayerPiece").ToString(), 2, "X", "O",, Main.LangData("head1").ToString())
            Case 6
                player1Piece = GameBoard.PlayedX
                player2Piece = GameBoard.PlayedO
            Case 7
                turnIncrement()
                player1Piece = GameBoard.PlayedO
                player2Piece = GameBoard.PlayedX
        End Select
    End Sub 'La Selection de soit X ou O
    Public Sub selOpponent()
        Select Case MsgBox(Main.LangData("PC").ToString(), 2, Main.LangData("The Computer").ToString(), Main.LangData("Another Player").ToString(),, Main.LangData("head2").ToString())
            Case 6
                ordPlay = True
            Case 7
                ordPlay = False
        End Select
    End Sub
End Module
