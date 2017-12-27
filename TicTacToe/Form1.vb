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
    Dim Xw As Integer = 0 'La valeur des gagnes de X
    Dim Ow As Integer = 0 'La valeur des gagnes de O
    Dim PlayCho As Integer 'La valeur de quel piece player 1 joue avec
    Dim LB As Integer 'Un switch pour la pointage
    Dim ORD As Integer 'un switch pour si l'ordinateur joue
    Dim ordCho As Integer 'un switch pour ORD
    Dim ordPlay As Integer 'la variable de la choix de l'ordinateur
    Dim ordToPlay As Integer = 0 'la variable de la choix prochain de l'ordinateur
    Dim ordTurn As Integer = 1 'un switch pour Si c'est la tour de l'ordinateur
    Dim Pick As Integer
    Dim Player As Integer
    Dim Computer As Integer
    Dim Draw As Integer = 0
    Dim games As Integer = 0
    Dim gamesC As Integer = 0
    Dim XwP As Double 'La valeur des gagnes de X en %
    Dim OwP As Double 'La valeur des gagnes de O en %
    Dim DrawP As Double
    Dim Pointage As Boolean
    Dim gb2S As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("fr-CA")
        PlayCho = MsgBox("Est-ce que Joueur 1 veut être X?", 4, "")
        selPlayer()
        ordCho = MsgBox("Est-ce que tu veux jouer contre l'ordinateur?", 4, "")
        If ordCho = 6 Then
            RadioButton2.PerformClick()
        ElseIf ordCho = 7 Then
            RadioButton1.PerformClick()
        End If
        GroupBox1.Hide()
        RadioButton4.PerformClick()
        GroupBox2.Hide()
        Button1.Text = "Nouveau Jeu: " & games
        'Button2.Hide()
    End Sub 'La Selection de soit X ou O

    Private Sub checkTurn()
        Turn = TurnC Mod 2
        If Turn = 1 Then
            Label1.Text = "C'est le tour de X"
        ElseIf Turn = 0 Then
            Label1.Text = "C'est le tour de O"
        End If

    End Sub 'Verifie le tour
    Private Sub turnCount()
        TurnC = TurnC + 1
    End Sub 'Count le tour

    Private Sub checkWin()
        If ((P1 = 1) And P1 = P2 And P1 = P3) Then
            PictureBox5.BackColor = Color.PaleGreen
            PictureBox6.BackColor = Color.PaleGreen
            PictureBox7.BackColor = Color.PaleGreen
            freezeGame()
            Label1.Text = "X Gagne"
        ElseIf ((P1 = 1) And P1 = P4 And P1 = P7) Then
            PictureBox5.BackColor = Color.PaleGreen
            PictureBox8.BackColor = Color.PaleGreen
            PictureBox11.BackColor = Color.PaleGreen
            freezeGame()
            Label1.Text = "X Gagne"
        ElseIf ((P1 = 1) And P1 = P5 And P1 = P9) Then
            PictureBox5.BackColor = Color.PaleGreen
            PictureBox9.BackColor = Color.PaleGreen
            PictureBox13.BackColor = Color.PaleGreen
            freezeGame()
            Label1.Text = "X Gagne"
        ElseIf ((P2 = 1) And P2 = P5 And P2 = P8) Then
            PictureBox6.BackColor = Color.PaleGreen
            PictureBox9.BackColor = Color.PaleGreen
            PictureBox12.BackColor = Color.PaleGreen
            freezeGame()
            Label1.Text = "X Gagne"
        ElseIf ((P3 = 1) And P3 = P6 And P3 = P9) Then
            PictureBox7.BackColor = Color.PaleGreen
            PictureBox10.BackColor = Color.PaleGreen
            PictureBox13.BackColor = Color.PaleGreen
            freezeGame()
            Label1.Text = "X Gagne"
        ElseIf ((P3 = 1) And P3 = P5 And P3 = P7) Then
            PictureBox7.BackColor = Color.PaleGreen
            PictureBox9.BackColor = Color.PaleGreen
            PictureBox11.BackColor = Color.PaleGreen
            freezeGame()
            Label1.Text = "X Gagne"
        ElseIf ((P4 = 1) And P4 = P5 And P4 = P6) Then
            PictureBox8.BackColor = Color.PaleGreen
            PictureBox9.BackColor = Color.PaleGreen
            PictureBox10.BackColor = Color.PaleGreen
            freezeGame()
            Label1.Text = "X Gagne"
        ElseIf ((P7 = 1) And P7 = P8 And P7 = P9) Then
            PictureBox11.BackColor = Color.PaleGreen
            PictureBox12.BackColor = Color.PaleGreen
            PictureBox13.BackColor = Color.PaleGreen
            freezeGame()
            Label1.Text = "X Gagne"
        ElseIf ((P1 = 2) And P1 = P2 And P1 = P3) Then
            PictureBox5.BackColor = Color.PaleGreen
            PictureBox6.BackColor = Color.PaleGreen
            PictureBox7.BackColor = Color.PaleGreen
            freezeGame()
            Label1.Text = "O Gagne"
        ElseIf ((P1 = 2) And P1 = P4 And P1 = P7) Then
            PictureBox5.BackColor = Color.PaleGreen
            PictureBox8.BackColor = Color.PaleGreen
            PictureBox11.BackColor = Color.PaleGreen
            freezeGame()
            Label1.Text = "O Gagne"
        ElseIf ((P1 = 2) And P1 = P5 And P1 = P9) Then
            PictureBox5.BackColor = Color.PaleGreen
            PictureBox9.BackColor = Color.PaleGreen
            PictureBox13.BackColor = Color.PaleGreen
            freezeGame()
            Label1.Text = "O Gagne"
        ElseIf ((P2 = 2) And P2 = P5 And P2 = P8) Then
            PictureBox6.BackColor = Color.PaleGreen
            PictureBox9.BackColor = Color.PaleGreen
            PictureBox12.BackColor = Color.PaleGreen
            freezeGame()
            Label1.Text = "O Gagne"
        ElseIf ((P3 = 2) And P3 = P6 And P3 = P9) Then
            PictureBox7.BackColor = Color.PaleGreen
            PictureBox10.BackColor = Color.PaleGreen
            PictureBox13.BackColor = Color.PaleGreen
            freezeGame()
            Label1.Text = "O Gagne"
        ElseIf ((P3 = 2) And P3 = P5 And P3 = P7) Then
            PictureBox7.BackColor = Color.PaleGreen
            PictureBox9.BackColor = Color.PaleGreen
            PictureBox11.BackColor = Color.PaleGreen
            freezeGame()
            Label1.Text = "O Gagne"
        ElseIf ((P4 = 2) And P4 = P5 And P4 = P6) Then
            PictureBox8.BackColor = Color.PaleGreen
            PictureBox9.BackColor = Color.PaleGreen
            PictureBox10.BackColor = Color.PaleGreen
            freezeGame()
            Label1.Text = "O Gagne"
        ElseIf ((P7 = 2) And P7 = P8 And P7 = P9) Then
            PictureBox11.BackColor = Color.PaleGreen
            PictureBox12.BackColor = Color.PaleGreen
            PictureBox13.BackColor = Color.PaleGreen
            freezeGame()
            Label1.Text = "O Gagne"
        ElseIf (P1 <> 0 And P2 <> 0 And P3 <> 0 And P4 <> 0 And P5 <> 0 And P6 <> 0 And P7 <> 0 And P8 <> 0 And P9 <> 0) Then
            Label1.Text = "Match Nul"
            ordTurn = 1
        End If
        checkWinner()
        percentWin()
        If Pointage = True Then
            Label4.Text = XwP & "%"
            Label5.Text = OwP & "%"
            Label6.Text = DrawP & "%"
        Else
            Label4.Text = Xw
            Label5.Text = Ow
            Label6.Text = Draw
        End If
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
                gamesC = gamesC + 1
            ElseIf (Label1.Text = "O Gagne") Then
                Ow = Ow + 1
                LB = 1
                gamesC = gamesC + 1
            ElseIf (Label1.Text = "Match Nul") Then
                Draw = Draw + 1
                LB = 1
                gamesC = gamesC + 1
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
        If PlayCho = 6 Then
            Label1.Text = "C'est le tour de X"
            Player = 1
            Computer = 2
        ElseIf PlayCho = 7 Then
            turnCount()
            checkTurn()
            Label1.Text = "C'est le tour de O"
            Player = 2
            Computer = 1
        End If
    End Sub 'La Selection de soit X ou O
    Private Sub newGame()
        games = games + 1
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
        Button1.Text = "Nouveau Jeu: " & games
        checkTurn()
        selPlayer()
    End Sub 'Nouveau jeu
    Private Sub rndPick()
        'Random number generator variable 
        Dim gen As New Random
        'Use the random number generator 
        ordPlay = gen.Next(1, 10)
    End Sub 'Choisir un nombre au hazard pour l'ordinateur
    Private Sub comp()
1:
        'horizontal
        'Top
        If ((P1 = Computer) And P1 = P2 And P3 = 0) Then
            ordPlay = 3
            GoTo 2
        ElseIf ((P1 = Computer) And P1 = P3 And P2 = 0) Then
            ordPlay = 2
            GoTo 2
        ElseIf ((P2 = Computer) And P2 = P1 And P3 = 0) Then
            ordPlay = 3
            GoTo 2
        ElseIf ((P2 = Computer) And P2 = P3 And P1 = 0) Then
            ordPlay = 1
            GoTo 2
        ElseIf ((P3 = Computer) And P3 = P1 And P2 = 0) Then
            ordPlay = 2
            GoTo 2
        ElseIf ((P3 = Computer) And P3 = P2 And P1 = 0) Then
            ordPlay = 1
            GoTo 2
            'Middle	
        ElseIf ((P4 = Computer) And P4 = P5 And P6 = 0) Then
            ordPlay = 6
            GoTo 2
        ElseIf ((P4 = Computer) And P4 = P6 And P5 = 0) Then
            ordPlay = 5
            GoTo 2
        ElseIf ((P5 = Computer) And P5 = P6 And P4 = 0) Then
            ordPlay = 4
            GoTo 2
        ElseIf ((P5 = Computer) And P5 = P4 And P6 = 0) Then
            ordPlay = 6
            GoTo 2
        ElseIf ((P6 = Computer) And P6 = P5 And P4 = 0) Then
            ordPlay = 4
            GoTo 2
        ElseIf ((P6 = Computer) And P6 = P4 And P5 = 0) Then
            ordPlay = 5
            GoTo 2
            'Bottom
        ElseIf ((P7 = Computer) And P7 = P8 And P9 = 0) Then
            ordPlay = 9
            GoTo 2
        ElseIf ((P7 = Computer) And P7 = P9 And P8 = 0) Then
            ordPlay = 8
            GoTo 2
        ElseIf ((P8 = Computer) And P8 = P7 And P9 = 0) Then
            ordPlay = 9
            GoTo 2
        ElseIf ((P8 = Computer) And P8 = P9 And P7 = 0) Then
            ordPlay = 7
            GoTo 2
        ElseIf ((P9 = Computer) And P9 = P8 And P7 = 0) Then
            ordPlay = 7
            GoTo 2
        ElseIf ((P9 = Computer) And P9 = P7 And P8 = 0) Then
            ordPlay = 8
            GoTo 2
            'Vertical
            'left
        ElseIf ((P1 = Computer) And P1 = P7 And P4 = 0) Then
            ordPlay = 4
            GoTo 2
        ElseIf ((P1 = Computer) And P1 = P4 And P7 = 0) Then
            ordPlay = 7
            GoTo 2
        ElseIf ((P4 = Computer) And P4 = P7 And P1 = 0) Then
            ordPlay = 1
            GoTo 2
        ElseIf ((P4 = Computer) And P4 = P1 And P7 = 0) Then
            ordPlay = 7
            GoTo 2
        ElseIf ((P7 = Computer) And P7 = P1 And P4 = 0) Then
            ordPlay = 4
            GoTo 2
        ElseIf ((P7 = Computer) And P7 = P4 And P1 = 0) Then
            ordPlay = 1
            GoTo 2
            'middle
        ElseIf ((P2 = Computer) And P2 = P8 And P5 = 0) Then
            ordPlay = 5
            GoTo 2
        ElseIf ((P2 = Computer) And P2 = P5 And P8 = 0) Then
            ordPlay = 8
            GoTo 2
        ElseIf ((P5 = Computer) And P5 = P8 And P2 = 0) Then
            ordPlay = 2
            GoTo 2
        ElseIf ((P5 = Computer) And P5 = P2 And P8 = 0) Then
            ordPlay = 8
            GoTo 2
        ElseIf ((P8 = Computer) And P8 = P2 And P5 = 0) Then
            ordPlay = 5
            GoTo 2
        ElseIf ((P8 = Computer) And P8 = P5 And P2 = 0) Then
            ordPlay = 2
            GoTo 2
            'right	
        ElseIf ((P3 = Computer) And P3 = P9 And P6 = 0) Then
            ordPlay = 6
            GoTo 2
        ElseIf ((P3 = Computer) And P3 = P6 And P9 = 0) Then
            ordPlay = 9
            GoTo 2
        ElseIf ((P6 = Computer) And P6 = P9 And P3 = 0) Then
            ordPlay = 3
            GoTo 2
        ElseIf ((P6 = Computer) And P6 = P3 And P9 = 0) Then
            ordPlay = 9
            GoTo 2
        ElseIf ((P9 = Computer) And P9 = P6 And P3 = 0) Then
            ordPlay = 3
            GoTo 2
        ElseIf ((P9 = Computer) And P9 = P3 And P6 = 0) Then
            ordPlay = 6
            GoTo 2
            'diagonal
            'backslash
        ElseIf ((P1 = Computer) And P1 = P5 And P9 = 0) Then
            ordPlay = 9
            GoTo 2
        ElseIf ((P1 = Computer) And P1 = P9 And P5 = 0) Then
            ordPlay = 5
            GoTo 2
        ElseIf ((P5 = Computer) And P5 = P1 And P9 = 0) Then
            ordPlay = 9
            GoTo 2
        ElseIf ((P5 = Computer) And P5 = P9 And P1 = 0) Then
            ordPlay = 1
            GoTo 2
        ElseIf ((P9 = Computer) And P9 = P5 And P1 = 0) Then
            ordPlay = 1
            GoTo 2
        ElseIf ((P9 = Computer) And P9 = P1 And P5 = 0) Then
            ordPlay = 5
            GoTo 2
            'forwardslash
        ElseIf ((P3 = Computer) And P3 = P7 And P5 = 0) Then
            ordPlay = 5
            GoTo 2
        ElseIf ((P3 = Computer) And P3 = P5 And P7 = 0) Then
            ordPlay = 7
            GoTo 2
        ElseIf ((P5 = Computer) And P5 = P7 And P3 = 0) Then
            ordPlay = 3
            GoTo 2
        ElseIf ((P5 = Computer) And P5 = P3 And P7 = 0) Then
            ordPlay = 7
            GoTo 2
        ElseIf ((P7 = Computer) And P7 = P3 And P5 = 0) Then
            ordPlay = 5
            GoTo 2
        ElseIf ((P7 = Computer) And P7 = P5 And P3 = 0) Then
            ordPlay = 3
            GoTo 2

            'horizontal
            'Top
        ElseIf ((P1 = Player) And P1 = P2 And P3 = 0) Then
            ordPlay = 3
            GoTo 2
        ElseIf ((P1 = Player) And P1 = P3 And P2 = 0) Then
            ordPlay = 2
            GoTo 2
        ElseIf ((P2 = Player) And P2 = P1 And P3 = 0) Then
            ordPlay = 3
            GoTo 2
        ElseIf ((P2 = Player) And P2 = P3 And P1 = 0) Then
            ordPlay = 1
            GoTo 2
        ElseIf ((P3 = Player) And P3 = P1 And P2 = 0) Then
            ordPlay = 2
            GoTo 2
        ElseIf ((P3 = Player) And P3 = P2 And P1 = 0) Then
            ordPlay = 1
            GoTo 2
            'Middle	
        ElseIf ((P4 = Player) And P4 = P5 And P6 = 0) Then
            ordPlay = 6
            GoTo 2
        ElseIf ((P4 = Player) And P4 = P6 And P5 = 0) Then
            ordPlay = 5
            GoTo 2
        ElseIf ((P5 = Player) And P5 = P6 And P4 = 0) Then
            ordPlay = 4
            GoTo 2
        ElseIf ((P5 = Player) And P5 = P4 And P6 = 0) Then
            ordPlay = 6
            GoTo 2
        ElseIf ((P6 = Player) And P6 = P5 And P4 = 0) Then
            ordPlay = 4
            GoTo 2
        ElseIf ((P6 = Player) And P6 = P4 And P5 = 0) Then
            ordPlay = 5
            GoTo 2
            'Bottom
        ElseIf ((P7 = Player) And P7 = P8 And P9 = 0) Then
            ordPlay = 9
            GoTo 2
        ElseIf ((P7 = Player) And P7 = P9 And P8 = 0) Then
            ordPlay = 8
            GoTo 2
        ElseIf ((P8 = Player) And P8 = P7 And P9 = 0) Then
            ordPlay = 9
            GoTo 2
        ElseIf ((P8 = Player) And P8 = P9 And P7 = 0) Then
            ordPlay = 7
            GoTo 2
        ElseIf ((P9 = Player) And P9 = P8 And P7 = 0) Then
            ordPlay = 7
            GoTo 2
        ElseIf ((P9 = Player) And P9 = P7 And P8 = 0) Then
            ordPlay = 8
            GoTo 2
            'Vertical
            'left
        ElseIf ((P1 = Player) And P1 = P7 And P4 = 0) Then
            ordPlay = 4
            GoTo 2
        ElseIf ((P1 = Player) And P1 = P4 And P7 = 0) Then
            ordPlay = 7
            GoTo 2
        ElseIf ((P4 = Player) And P4 = P7 And P1 = 0) Then
            ordPlay = 1
            GoTo 2
        ElseIf ((P4 = Player) And P4 = P1 And P7 = 0) Then
            ordPlay = 7
            GoTo 2
        ElseIf ((P7 = Player) And P7 = P1 And P4 = 0) Then
            ordPlay = 4
            GoTo 2
        ElseIf ((P7 = Player) And P7 = P4 And P1 = 0) Then
            ordPlay = 1
            GoTo 2
            'middle
        ElseIf ((P2 = Player) And P2 = P8 And P5 = 0) Then
            ordPlay = 5
            GoTo 2
        ElseIf ((P2 = Player) And P2 = P5 And P8 = 0) Then
            ordPlay = 8
            GoTo 2
        ElseIf ((P5 = Player) And P5 = P8 And P2 = 0) Then
            ordPlay = 2
            GoTo 2
        ElseIf ((P5 = Player) And P5 = P2 And P8 = 0) Then
            ordPlay = 8
            GoTo 2
        ElseIf ((P8 = Player) And P8 = P2 And P5 = 0) Then
            ordPlay = 5
            GoTo 2
        ElseIf ((P8 = Player) And P8 = P5 And P2 = 0) Then
            ordPlay = 2
            GoTo 2
            'right	
        ElseIf ((P3 = Player) And P3 = P9 And P6 = 0) Then
            ordPlay = 6
            GoTo 2
        ElseIf ((P3 = Player) And P3 = P6 And P9 = 0) Then
            ordPlay = 9
            GoTo 2
        ElseIf ((P6 = Player) And P6 = P9 And P3 = 0) Then
            ordPlay = 3
            GoTo 2
        ElseIf ((P6 = Player) And P6 = P3 And P9 = 0) Then
            ordPlay = 9
            GoTo 2
        ElseIf ((P9 = Player) And P9 = P6 And P3 = 0) Then
            ordPlay = 3
            GoTo 2
        ElseIf ((P9 = Player) And P9 = P3 And P6 = 0) Then
            ordPlay = 6
            GoTo 2
            'diagonal
            'backslash
        ElseIf ((P1 = Player) And P1 = P5 And P9 = 0) Then
            ordPlay = 9
            GoTo 2
        ElseIf ((P1 = Player) And P1 = P9 And P5 = 0) Then
            ordPlay = 5
            GoTo 2
        ElseIf ((P5 = Player) And P5 = P1 And P9 = 0) Then
            ordPlay = 9
            GoTo 2
        ElseIf ((P5 = Player) And P5 = P9 And P1 = 0) Then
            ordPlay = 1
            GoTo 2
        ElseIf ((P9 = Player) And P9 = P5 And P1 = 0) Then
            ordPlay = 1
            GoTo 2
        ElseIf ((P9 = Player) And P9 = P1 And P5 = 0) Then
            ordPlay = 5
            GoTo 2
            'forwardslash
        ElseIf ((P3 = Player) And P3 = P7 And P5 = 0) Then
            ordPlay = 5
            GoTo 2
        ElseIf ((P3 = Player) And P3 = P5 And P7 = 0) Then
            ordPlay = 7
            GoTo 2
        ElseIf ((P5 = Player) And P5 = P7 And P3 = 0) Then
            ordPlay = 3
            GoTo 2
        ElseIf ((P5 = Player) And P5 = P3 And P7 = 0) Then
            ordPlay = 7
            GoTo 2
        ElseIf ((P7 = Player) And P7 = P3 And P5 = 0) Then
            ordPlay = 5
            GoTo 2
        ElseIf ((P7 = Player) And P7 = P5 And P3 = 0) Then
            ordPlay = 3
            GoTo 2

        Else
            If (ordToPlay <> 0) Then
                ordPlay = ordToPlay
                ordToPlay = 0
                GoTo 2
            ElseIf ((P1 = Computer) And (P1 = P3) And (P9 = 0)) Then
                ordPlay = 9
                GoTo 2
            ElseIf ((P1 = Computer) And (P1 = P3) And (P7 = 0)) Then
                ordPlay = 7
                GoTo 2
            ElseIf ((P3 = Computer) And (P3 = P9) And (P7 = 0)) Then
                ordPlay = 7
                GoTo 2
            ElseIf ((P3 = Computer) And (P3 = P9) And (P1 = 0)) Then
                ordPlay = 1
                GoTo 2
            ElseIf ((P9 = Computer) And (P9 = P7) And (P1 = 0)) Then
                ordPlay = 1
                GoTo 2
            ElseIf ((P9 = Computer) And (P9 = P7) And (P3 = 0)) Then
                ordPlay = 3
                GoTo 2
            ElseIf ((P1 = Computer) And (P1 = P7) And (P3 = 0)) Then
                ordPlay = 3
                GoTo 2
            ElseIf ((P1 = Computer) And (P1 = P7) And (P9 = 0)) Then
                ordPlay = 9
                GoTo 2
            ElseIf ((P1 = Computer) And (P1 = P9) And (P3 = 0)) Then
                ordPlay = 3
                GoTo 2
            ElseIf ((P1 = Computer) And (P1 = P9) And (P7 = 0)) Then
                ordPlay = 7
                GoTo 2
            ElseIf ((P3 = Computer) And (P3 = P7) And (P1 = 0)) Then
                ordPlay = 1
                GoTo 2
            ElseIf ((P3 = Computer) And (P3 = P7) And (P9 = 0)) Then
                ordPlay = 9
                GoTo 2
            ElseIf (P1 = Player) And (P2 = 0) And (P2 = P3 = P4 = P5 = P6 = P7 = P8 = P9) Then
                ordPlay = 5
                GoTo 2
            ElseIf (P3 = Player) And (P2 = 0) And (P2 = P1 = P4 = P5 = P6 = P7 = P8 = P9) Then
                ordPlay = 5
                GoTo 2
            ElseIf (P7 = Player) And (P2 = 0) And (P2 = P3 = P4 = P5 = P6 = P1 = P8 = P9) Then
                ordPlay = 5
                GoTo 2
            ElseIf (P9 = Player) And (P2 = 0) And (P2 = P3 = P4 = P5 = P6 = P7 = P8 = P1) Then
                ordPlay = 5
                GoTo 2
            ElseIf (P2 = Player) And (P3 = 0) Then
                ordPlay = 3
                ordToPlay = 5
                GoTo 2
            ElseIf (P6 = Player) And (P9 = 0) Then
                ordPlay = 9
                ordToPlay = 5
                GoTo 2
            ElseIf (P8 = Player) And (P7 = 0) Then
                ordPlay = 7
                ordToPlay = 5
                GoTo 2
            ElseIf (P4 = Player) And (P1 = 0) Then
                ordPlay = 1
                ordToPlay = 5
                GoTo 2
            ElseIf ((P1 = Player) And (P1 = P9) And (P5 = Computer)) Then
                ordPlay = 8
                GoTo 2
            ElseIf ((P3 = Player) And (P3 = P7) And (P5 = Computer)) Then
                ordPlay = 2
                GoTo 2
            ElseIf (P2 = Player) And (P2 = P4) And (P1 = 0) Then
                ordPlay = 1
                GoTo 2
            ElseIf (P2 = Player) And (P2 = P6) And (P3 = 0) Then
                ordPlay = 3
                GoTo 2
            ElseIf (P4 = Player) And (P4 = P8) And (P7 = 0) Then
                ordPlay = 7
                GoTo 2
            ElseIf (P6 = Player) And (P6 = P8) And (P9 = 0) Then
                ordPlay = 9
                GoTo 2
            ElseIf (P2 = Player) And (P2 = P4) And (P5 = 0) Then
                ordPlay = 5
                GoTo 2
            ElseIf (P2 = Player) And (P2 = P6) And (P5 = 0) Then
                ordPlay = 5
                GoTo 2
            ElseIf (P4 = Player) And (P4 = P8) And (P5 = 0) Then
                ordPlay = 5
                GoTo 2
            ElseIf (P6 = Player) And (P6 = P8) And (P5 = 0) Then
                ordPlay = 5
                GoTo 2
            Else
3:
                Dim gen As New Random
                Pick = gen.Next(1, 6)
                If (Pick = 1 And P1 = 0) Then
                    ordPlay = 1
                    GoTo 2
                ElseIf (Pick = 2 And P3 = 0) Then
                    ordPlay = 3
                    GoTo 2
                ElseIf (Pick = 3 And P5 = 0) Then
                    ordPlay = 5
                    GoTo 2
                ElseIf (Pick = 4 And P7 = 0) Then
                    ordPlay = 7
                    GoTo 2
                ElseIf (Pick = 5 And P9 = 0) Then
                    ordPlay = 9
                    GoTo 2
                ElseIf Pick <> 1 And Pick <> 2 And Pick <> 3 And Pick <> 4 And Pick <> 5 Then
                    GoTo 3
                Else
                    rndPick()
                End If
            End If
        End If
2:
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
    End Sub 'Comment l'ordinateur choisir où jouer

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
    End Sub 'Selection de Jouer Contre
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

    End Sub 'RadioButton vide

    Private Sub percentWin()
        XwP = (Xw / gamesC) * 100
        OwP = (Ow / gamesC) * 100
        DrawP = (Draw / gamesC) * 100

        XwP = Math.Round(XwP, 2, MidpointRounding.AwayFromZero)
        OwP = Math.Round(OwP, 2, MidpointRounding.AwayFromZero)
        DrawP = Math.Round(DrawP, 2, MidpointRounding.AwayFromZero)
    End Sub 'calcul la pourcentage des victoires
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If gb2S = False Then
            GroupBox2.Show()
            gb2S = True
        ElseIf gb2S = True Then
            GroupBox2.Hide()
            gb2S = False
        End If
    End Sub 'la button d'option
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        Pointage = False
        percentWin()
        If Pointage = True Then
            Label4.Text = XwP & "%"
            Label5.Text = OwP & "%"
            Label6.Text = DrawP & "%"
        Else
            Label4.Text = Xw
            Label5.Text = Ow
            Label6.Text = Draw
        End If
        'GroupBox2.Hide()
    End Sub 'pointage
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Pointage = True
        percentWin()
        If Pointage = True Then
            Label4.Text = XwP & "%"
            Label5.Text = OwP & "%"
            Label6.Text = DrawP & "%"
        Else
            Label4.Text = Xw
            Label5.Text = Ow
            Label6.Text = Draw
        End If
        'GroupBox2.Hide()
    End Sub 'pourcentage
End Class