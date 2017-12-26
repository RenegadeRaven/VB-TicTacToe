Public Class Form1
    Dim TurnC As Integer 'La count des tours
    Dim Turn As Integer 'A qui la tour
    Dim P1 As Integer 'La valeur du top-left carree
    Dim P2 As Integer 'La valeur du top-mid carree
    Dim P3 As Integer 'La valeur du top-right carree
    Dim P4 As Integer 'La valeur du gauche-centre carree
    Dim P5 As Integer 'La valeur du centre carree
    Dim P6 As Integer 'La valeur du droite-centre carree
    Dim P7 As Integer 'La valeur du bottom-left carree
    Dim P8 As Integer 'La valeur du bottom-middle carree
    Dim P9 As Integer 'La valeur du bottom-right carree
    Dim Xw As Integer 'La valeur des gagnes de X
    Dim Ow As Integer 'La valeur des gagnes de O
    Dim Player As Integer 'La valeur de quel piece player 1 joue avec
    Dim LB As Integer
    Dim ORD As Integer
    Dim ordCho As Integer
    Dim ordPlay As Integer
    Dim ordTurn As Integer = 1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Player = MsgBox("Est-ce que Joueur 1 veut être X?", 4, "")
        selPlayer()
        ordCho = MsgBox("Est-ce que tu veux jouer contre l'ordinateur?", 4, "")
        If ordCho = 6 Then
            RadioButton2.PerformClick()
        ElseIf ordCho = 7 Then
            RadioButton1.PerformClick()
        End If
        GroupBox1.Hide()
    End Sub 'La Selection de soit X ou O

    Private Sub checkTurn()
        Turn = TurnC Mod 2
        If Turn = 1 Then
            Label1.Text = "C'est la tour de X"
        ElseIf Turn = 0 Then
            Label1.Text = "C'est la tour de O"
        End If

    End Sub 'Verifie le tour
    Private Sub turnCount()
        TurnC = TurnC + 1
    End Sub 'Count le tour

    Private Sub checkWin()
        If ((P1 = 1) And P1 = P2 And P1 = P3) Then
            PictureBox5.BackColor = Color.Green
            PictureBox6.BackColor = Color.Green
            PictureBox7.BackColor = Color.Green
            freezeGame()
            Label1.Text = "X Gagne"

        ElseIf ((P1 = 1) And P1 = P4 And P1 = P7) Then
            PictureBox5.BackColor = Color.Green
            PictureBox8.BackColor = Color.Green
            PictureBox11.BackColor = Color.Green
            freezeGame()
            Label1.Text = "X Gagne"

        ElseIf ((P1 = 1) And P1 = P5 And P1 = P9) Then
            PictureBox5.BackColor = Color.Green
            PictureBox9.BackColor = Color.Green
            PictureBox13.BackColor = Color.Green
            freezeGame()
            Label1.Text = "X Gagne"

        ElseIf ((P2 = 1) And P2 = P5 And P2 = P8) Then
            PictureBox6.BackColor = Color.Green
            PictureBox9.BackColor = Color.Green
            PictureBox12.BackColor = Color.Green
            freezeGame()
            Label1.Text = "X Gagne"

        ElseIf ((P3 = 1) And P3 = P6 And P3 = P9) Then
            PictureBox7.BackColor = Color.Green
            PictureBox10.BackColor = Color.Green
            PictureBox13.BackColor = Color.Green
            freezeGame()
            Label1.Text = "X Gagne"

        ElseIf ((P3 = 1) And P3 = P5 And P3 = P7) Then
            PictureBox7.BackColor = Color.Green
            PictureBox9.BackColor = Color.Green
            PictureBox11.BackColor = Color.Green
            freezeGame()
            Label1.Text = "X Gagne"

        ElseIf ((P4 = 1) And P4 = P5 And P4 = P6) Then
            PictureBox8.BackColor = Color.Green
            PictureBox9.BackColor = Color.Green
            PictureBox10.BackColor = Color.Green
            freezeGame()
            Label1.Text = "X Gagne"

        ElseIf ((P7 = 1) And P7 = P8 And P7 = P9) Then
            PictureBox11.BackColor = Color.Green
            PictureBox12.BackColor = Color.Green
            PictureBox13.BackColor = Color.Green
            freezeGame()
            Label1.Text = "X Gagne"

        ElseIf ((P1 = 2) And P1 = P2 And P1 = P3) Then
            PictureBox5.BackColor = Color.Green
            PictureBox6.BackColor = Color.Green
            PictureBox7.BackColor = Color.Green
            freezeGame()
            Label1.Text = "O Gagne"

        ElseIf ((P1 = 2) And P1 = P4 And P1 = P7) Then
            PictureBox5.BackColor = Color.Green
            PictureBox8.BackColor = Color.Green
            PictureBox11.BackColor = Color.Green
            freezeGame()
            Label1.Text = "O Gagne"

        ElseIf ((P1 = 2) And P1 = P5 And P1 = P9) Then
            PictureBox5.BackColor = Color.Green
            PictureBox9.BackColor = Color.Green
            PictureBox13.BackColor = Color.Green
            freezeGame()
            Label1.Text = "O Gagne"

        ElseIf ((P2 = 2) And P2 = P5 And P2 = P8) Then
            PictureBox6.BackColor = Color.Green
            PictureBox9.BackColor = Color.Green
            PictureBox12.BackColor = Color.Green
            freezeGame()
            Label1.Text = "O Gagne"

        ElseIf ((P3 = 2) And P3 = P6 And P3 = P9) Then
            PictureBox7.BackColor = Color.Green
            PictureBox10.BackColor = Color.Green
            PictureBox13.BackColor = Color.Green
            freezeGame()
            Label1.Text = "O Gagne"

        ElseIf ((P3 = 2) And P3 = P5 And P3 = P7) Then
            PictureBox7.BackColor = Color.Green
            PictureBox9.BackColor = Color.Green
            PictureBox11.BackColor = Color.Green
            freezeGame()
            Label1.Text = "O Gagne"

        ElseIf ((P4 = 2) And P4 = P5 And P4 = P6) Then
            PictureBox8.BackColor = Color.Green
            PictureBox9.BackColor = Color.Green
            PictureBox10.BackColor = Color.Green
            freezeGame()
            Label1.Text = "O Gagne"

        ElseIf ((P7 = 2) And P7 = P8 And P7 = P9) Then
            PictureBox11.BackColor = Color.Green
            PictureBox12.BackColor = Color.Green
            PictureBox13.BackColor = Color.Green
            freezeGame()
            Label1.Text = "O Gagne"

        ElseIf (P1 <> 0 And P2 <> 0 And P3 <> 0 And P4 <> 0 And P5 <> 0 And P6 <> 0 And P7 <> 0 And P8 <> 0 And P9 <> 0) Then
            Label1.Text = "Match Nul"
            ordTurn = 1
        End If
        checkWinner()
        Label4.Text = Xw
        Label5.Text = Ow
        If ORD = 1 Then
            If ordTurn = 0 Then
                comp()
            End If
        End If
    End Sub 'Verifie si il y a un gagnant
    Private Sub checkWinner()
        If (LB = 1) Then

        ElseIf (LB = 0) Then
            If (Label1.Text = "X Gagne") Then
                Xw = Xw + 1
                LB = 1
            ElseIf (Label1.Text = "O Gagne") Then
                Ow = Ow + 1
                LB = 1
            ElseIf (Label1.Text = "Match Nul") Then

            End If
        End If
    End Sub 'Verifie qui a gagné
    Private Sub freezeGame()
        If P1 = 0 Then
            P1 = 3
        End If
        If P2 = 0 Then
            P2 = 3
        End If
        If P3 = 0 Then
            P3 = 3
        End If
        If P4 = 0 Then
            P4 = 3
        End If
        If P5 = 0 Then
            P5 = 3
        End If
        If P6 = 0 Then
            P6 = 3
        End If
        If P7 = 0 Then
            P7 = 3
        End If
        If P8 = 0 Then
            P8 = 3
        End If
        If P9 = 0 Then
            P9 = 3
        End If
        ordTurn = 1
    End Sub 'Arrete le jeu quand quelqu'un gagne
    Private Sub selPlayer()
        If Player = 6 Then
            Label1.Text = "C'est la tour de X"
        ElseIf Player = 7 Then
            turnCount()
            checkTurn()
            Label1.Text = "C'est la tour de O"
        End If
    End Sub 'La Selection de soit X ou O
    Private Sub newGame()
        TurnC = 0
        Turn = 0
        P1 = 0
        P2 = 0
        P3 = 0
        P4 = 0
        P5 = 0
        P6 = 0
        P7 = 0
        P8 = 0
        P9 = 0
        LB = 0
        PictureBox5.BackgroundImage = Nothing
        PictureBox6.BackgroundImage = Nothing
        PictureBox7.BackgroundImage = Nothing
        PictureBox8.BackgroundImage = Nothing
        PictureBox9.BackgroundImage = Nothing
        PictureBox10.BackgroundImage = Nothing
        PictureBox11.BackgroundImage = Nothing
        PictureBox12.BackgroundImage = Nothing
        PictureBox13.BackgroundImage = Nothing
        PictureBox5.BackColor = SystemColors.Control
        PictureBox6.BackColor = SystemColors.Control
        PictureBox7.BackColor = SystemColors.Control
        PictureBox8.BackColor = SystemColors.Control
        PictureBox9.BackColor = SystemColors.Control
        PictureBox10.BackColor = SystemColors.Control
        PictureBox11.BackColor = SystemColors.Control
        PictureBox12.BackColor = SystemColors.Control
        PictureBox13.BackColor = SystemColors.Control
        checkTurn()
        selPlayer()
    End Sub 'Nouveau jeu
    Private Sub comp()
1:
        'Random number generator variable 
        Dim gen As New Random
        'Use the random number generator 
        ordPlay = gen.Next(1, 10)
        Me.Refresh()
        Threading.Thread.Sleep(750)
        If ordPlay = 1 Then
            If P1 = 0 Then
                checkTurn()
                If Turn = 1 Then
                    PictureBox5.BackgroundImage = My.Resources.O
                    P1 = 2
                    turnCount()

                ElseIf Turn = 0 Then
                    PictureBox5.BackgroundImage = My.Resources.X
                    P1 = 1
                    turnCount()

                End If
                ordTurn = 1
            Else
                GoTo 1
            End If
        ElseIf ordPlay = 2 Then
            If P2 = 0 Then
                checkTurn()
                If Turn = 1 Then
                    PictureBox6.BackgroundImage = My.Resources.O
                    P2 = 2
                    turnCount()

                ElseIf Turn = 0 Then
                    PictureBox6.BackgroundImage = My.Resources.X
                    P2 = 1
                    turnCount()

                End If
                ordTurn = 1
            Else
                GoTo 1
            End If
        ElseIf ordPlay = 3 Then
            If P3 = 0 Then
                checkTurn()
                If Turn = 1 Then
                    PictureBox7.BackgroundImage = My.Resources.O
                    P3 = 2
                    turnCount()

                ElseIf Turn = 0 Then
                    PictureBox7.BackgroundImage = My.Resources.X
                    P3 = 1
                    turnCount()

                End If
                ordTurn = 1
            Else
                GoTo 1
            End If
        ElseIf ordPlay = 4 Then
            If P4 = 0 Then
                checkTurn()
                If Turn = 1 Then
                    PictureBox8.BackgroundImage = My.Resources.O
                    P4 = 2
                    turnCount()

                ElseIf Turn = 0 Then
                    PictureBox8.BackgroundImage = My.Resources.X
                    P4 = 1
                    turnCount()

                End If
                ordTurn = 1
            Else
                GoTo 1
            End If
        ElseIf ordPlay = 5 Then
            If P5 = 0 Then
                checkTurn()
                If Turn = 1 Then
                    PictureBox9.BackgroundImage = My.Resources.O
                    P5 = 2
                    turnCount()

                ElseIf Turn = 0 Then
                    PictureBox9.BackgroundImage = My.Resources.X
                    P5 = 1
                    turnCount()

                End If
                ordTurn = 1
            Else
                GoTo 1
            End If
        ElseIf ordPlay = 6 Then
            If P6 = 0 Then
                checkTurn()
                If Turn = 1 Then
                    PictureBox10.BackgroundImage = My.Resources.O
                    P6 = 2
                    turnCount()

                ElseIf Turn = 0 Then
                    PictureBox10.BackgroundImage = My.Resources.X
                    P6 = 1
                    turnCount()

                End If
                ordTurn = 1
            Else
                GoTo 1
            End If
        ElseIf ordPlay = 7 Then
            If P7 = 0 Then
                checkTurn()
                If Turn = 1 Then
                    PictureBox11.BackgroundImage = My.Resources.O
                    P7 = 2
                    turnCount()

                ElseIf Turn = 0 Then
                    PictureBox11.BackgroundImage = My.Resources.X
                    P7 = 1
                    turnCount()

                End If
                ordTurn = 1
            Else
                GoTo 1
            End If
        ElseIf ordPlay = 8 Then
            If P8 = 0 Then
                checkTurn()
                If Turn = 1 Then
                    PictureBox12.BackgroundImage = My.Resources.O
                    P8 = 2
                    turnCount()

                ElseIf Turn = 0 Then
                    PictureBox12.BackgroundImage = My.Resources.X
                    P8 = 1
                    turnCount()

                End If
                ordTurn = 1
            Else
                GoTo 1
            End If
        ElseIf ordPlay = 9 Then
            If P9 = 0 Then
                checkTurn()
                If Turn = 1 Then
                    PictureBox13.BackgroundImage = My.Resources.O
                    P9 = 2
                    turnCount()

                ElseIf Turn = 0 Then
                    PictureBox13.BackgroundImage = My.Resources.X
                    P9 = 1
                    turnCount()

                End If
                ordTurn = 1
            Else
                GoTo 1
            End If
        Else
                GoTo 1
        End If
        checkWin()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        If P1 = 0 Then
            checkTurn()
            If Turn = 1 Then
                PictureBox5.BackgroundImage = My.Resources.O
                P1 = 2
                turnCount()

            ElseIf Turn = 0 Then
                PictureBox5.BackgroundImage = My.Resources.X
                P1 = 1
                turnCount()

            End If
            ordTurn = 0
        Else

        End If
        checkWin()
    End Sub 'Quoi arrive quand tu clicke PicBox5

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        If P2 = 0 Then
            checkTurn()
            If Turn = 1 Then
                PictureBox6.BackgroundImage = My.Resources.O
                turnCount()
                P2 = 2
            ElseIf Turn = 0 Then
                PictureBox6.BackgroundImage = My.Resources.X
                turnCount()
                P2 = 1
            End If
            ordTurn = 0
        Else
        End If
        checkWin()
    End Sub 'Quoi arrive quand tu clicke PicBox6

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        If P3 = 0 Then
            checkTurn()
            If Turn = 1 Then
                PictureBox7.BackgroundImage = My.Resources.O
                turnCount()
                P3 = 2
            ElseIf Turn = 0 Then
                PictureBox7.BackgroundImage = My.Resources.X
                turnCount()
                P3 = 1
            End If
            ordTurn = 0
        Else
        End If
        checkWin()
    End Sub 'Quoi arrive quand tu clicke PicBox7

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        If P4 = 0 Then
            checkTurn()
            If Turn = 1 Then
                PictureBox8.BackgroundImage = My.Resources.O
                turnCount()
                P4 = 2
            ElseIf Turn = 0 Then
                PictureBox8.BackgroundImage = My.Resources.X
                turnCount()
                P4 = 1
            End If
            ordTurn = 0
        Else

        End If
        checkWin()
    End Sub 'Quoi arrive quand tu clicke PicBox8

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        If P5 = 0 Then
            checkTurn()
            If Turn = 1 Then
                PictureBox9.BackgroundImage = My.Resources.O
                turnCount()
                P5 = 2
            ElseIf Turn = 0 Then
                PictureBox9.BackgroundImage = My.Resources.X
                turnCount()
                P5 = 1
            End If
            ordTurn = 0
        Else
        End If
        checkWin()
    End Sub 'Quoi arrive quand tu clicke PicBox9

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        If P6 = 0 Then
            checkTurn()
            If Turn = 1 Then
                PictureBox10.BackgroundImage = My.Resources.O
                turnCount()
                P6 = 2
            ElseIf Turn = 0 Then
                PictureBox10.BackgroundImage = My.Resources.X
                turnCount()
                P6 = 1
            End If
            ordTurn = 0
        Else
        End If
        checkWin()
    End Sub 'Quoi arrive quand tu clicke PicBox10

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        If P7 = 0 Then
            checkTurn()
            If Turn = 1 Then
                PictureBox11.BackgroundImage = My.Resources.O
                turnCount()
                P7 = 2
            ElseIf Turn = 0 Then
                PictureBox11.BackgroundImage = My.Resources.X
                turnCount()
                P7 = 1
            End If
            ordTurn = 0
        Else
        End If
        checkWin()
    End Sub 'Quoi arrive quand tu clicke PicBox11

    Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click
        If P8 = 0 Then
            checkTurn()
            If Turn = 1 Then
                PictureBox12.BackgroundImage = My.Resources.O
                turnCount()
                P8 = 2
            ElseIf Turn = 0 Then
                PictureBox12.BackgroundImage = My.Resources.X
                turnCount()
                P8 = 1
            End If
            ordTurn = 0
        Else
        End If
        checkWin()
    End Sub 'Quoi arrive quand tu clicke PicBox12

    Private Sub PictureBox13_Click(sender As Object, e As EventArgs) Handles PictureBox13.Click
        If P9 = 0 Then
            checkTurn()
            If Turn = 1 Then
                PictureBox13.BackgroundImage = My.Resources.O
                turnCount()
                P9 = 2
            ElseIf Turn = 0 Then
                PictureBox13.BackgroundImage = My.Resources.X
                turnCount()
                P9 = 1
            End If
            ordTurn = 0
        Else
        End If
        checkWin()
    End Sub 'Quoi arrive quand tu clicke PicBox13

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        newGame()
    End Sub 'La button pour commencer un nouveau jeu

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If (RadioButton2.Checked) Then
            ORD = 1
        Else
            ORD = 0
        End If
        newGame()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

    End Sub

End Class 'B5CS2017