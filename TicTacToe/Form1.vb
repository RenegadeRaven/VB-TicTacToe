Public Class Form1
#Region "Variables"
    Dim TurnC As Integer 'La count des tours
    Dim Turn As Integer 'A qui la tour
    Public Pos(8) As Integer '= {P1, P2, P3, P4, P5, P6, P7, P8, P9}
    'P1 = haut-gauche carree, P2 = haut-centre carree, P3 = haut-droite carree, P4 = gauche-centre carree, P5 = centre carree, P6 = droite-centre carree, P7 = bas-gauche carree, P8 = bas-centre carree, P9 = bas-droite carree
    Dim Points(2) As Integer '= {X, O, Draw}
    Dim Percent(2) As Integer '= {X%, O%, Draw%}
    Dim PlayCho As Integer 'La valeur de quel piece player 1 joue avec
    Dim LB As Integer 'Un switch pour la pointage
    Public ORD As Integer 'un switch pour si l'ordinateur joue
    Public ordCho As Integer 'un switch pour ORD
    Public ordPlay As Integer 'la variable de la choix de l'ordinateur
    Public ordToPlay As Integer = 0 'la variable de la choix prochain de l'ordinateur
    Dim ordTurn As Integer = 1 'un switch pour Si c'est la tour de l'ordinateur
    Public Pick As Integer 'le chois d'ordis au hazard
    Public Player As Integer 'la pièce de joueur
    Public Computer As Integer 'la pièce de l'ordis
    Dim games As Integer = 0 'la montant de jeu commencé
    Dim gamesC As Integer = 0 'la montant de jeu fini
    Dim Pointage As Boolean 'Un switch pour quelle pointage est affiché
    Dim gb2S As Boolean 'Un switch pour si le groupbox2 est affiché
    Public ErrorCount As Integer 'un counteur des errors
    Dim invcol As Boolean 'un switch pour si les couleurs sont renverser
    Dim OptPage As Integer = 0 'index de page d'option
    Dim sfx As Boolean = True 'un switch pour si les sons sont couper
    Dim restr As Integer
    Dim clos As Integer
    Dim savClose As Integer
    Dim pathexe As String = My.Application.Info.DirectoryPath
    Dim path As String = pathexe & "\TicTacToe"
    Dim config(3) As String '= {"Lang", "color", "mute", "points"}
    Dim settings As String
    Dim time As String
    Dim log As String
    Dim mang As Boolean
    Dim manglog As Boolean
    'Language stuff
    Dim Yes As String = "Oui"
    Dim No As String = "Non"
    Dim head1 As String = "Sélection du Pièce"
    Dim head2 As String = "Jouer Contre?"
    Dim head3 As String = "Paramètres?"
    Dim PlayPiece As String = "Quel pièce est-ce que Joueur 1 veut être?"
    Dim PC As String = "Qui est-ce que tu veux jouer contre?"
    Dim NG As String = "Nouveau Jeu: "
    Dim Xt As String = "C'est le tour de X"
    Dim Ot As String = "C'est le tour de O"
    Dim winX As String = "X Gagne"
    Dim winO As String = "O Gagne"
    Dim DrawT As String = "Match Nul"
    Dim restrMsg As String = "Est-ce que tu est assuré que tu veux redémarrer le jeu? Tu va perdre tous tes points."
    Dim restrMsgHead As String = "Est-ce que tu est assuré?"
    Dim closeMsg As String = "Est-ce que tu est assuré que tu veux fermer le jeu?"
    Dim save As String = "Est-ce que tu veux sauvegarder tes paramètres?"
    Dim ONs As String = "Allumé"
    Dim OFF As String = "Éteint"
#End Region

#Region "System Menu"
    Public Const WM_SYSCOMMAND As Int32 = &H112
    Public Const MF_BYPOSITION As Int32 = &H400
    Public Const MYMENU1 As Int32 = 1000
    Public Const MYMENU2 As Int32 = 1001

    Dim hSysMenu As Integer


    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal bRevert As Integer) As Integer
    Public Declare Function InsertMenu Lib "user32" Alias "InsertMenuA" _
       (ByVal hMenu As IntPtr, ByVal nPosition As Integer, ByVal wFlags As Integer, ByVal wIDNewItem As Integer, ByVal lpNewItem As String) As Boolean

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        MyBase.WndProc(m)
        If (m.Msg = WM_SYSCOMMAND) Then
            Select Case m.WParam.ToInt32
                Case MYMENU1
                    Dim about As New LangMessageBox("Continue", "Exit")
                    about.ShowDialog()
                    LangSet()
                    Me.Refresh()
                Case MYMENU2
                    Dim options As New UpdateCheck
                    'options.ShowDialog()
            End Select
        End If
    End Sub


#End Region

#Region "Form Functions"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mang = False
        checkUpdate()
        My.Computer.FileSystem.CreateDirectory(pathexe & "\TicTacToe")
        My.Computer.FileSystem.CreateDirectory(path & "\logs")
        If My.Settings.Settings = True Then
            manglog = False
            If My.Settings.Color = "Yes" Then
                CheckBox1.Checked = True
            End If
            If My.Settings.Mute = "Yes" Then
                CheckBox2.Checked = True
            End If
            If My.Settings.Points = "Point" Then
                RadioButton4.PerformClick()
            ElseIf My.Settings.Points = "Percent" Then
                RadioButton3.PerformClick()
            End If
            manglog = True
            Button9.Enabled = False
            GroupBox4.Text = "Configuration = " & ONs
            log = log & "Start | From Settings | Lang: " & My.Settings.Lang & ", InvertColors: " & My.Settings.Color & ", Mute: " & My.Settings.Mute & ", Score: " & My.Settings.Points & " | "
            LangSet()
        Else
            My.Settings.Color = "No"
            My.Settings.Mute = "No"
            Button10.Enabled = False
            GroupBox4.Text = "Configuration = " & OFF
            RadioButton4.PerformClick()
            LangSet()
            log = log & "Start | " & My.Settings.Lang & " | "
        End If
        If My.Settings.Settings = True Then
            GroupBox4.Text = "Configuration = " & ONs
        Else
            GroupBox4.Text = "Configuration = " & OFF
        End If
        PlayCho = MsgB(PlayPiece, 2, "X", "O", "", head1)
        selPlayer()
        ordCho = MsgB(PC, 2, RadioButton2.Text, RadioButton1.Text, "", head2)
        If ordCho = 6 Then
            log = log & "Against PC 

"
            RadioButton2.PerformClick()
        ElseIf ordCho = 7 Then
            log = log & "Against Player 2 

"
            RadioButton1.PerformClick()
        End If
        mang = True
        GroupBox1.Hide()
        GroupBox2.Hide()
        GroupBox3.Hide()
        GroupBox4.Hide()
        Language.Hide()
        Button1.Text = NG & games

        hSysMenu = GetSystemMenu(Me.Handle, False)
        InsertMenu(hSysMenu, 6, MF_BYPOSITION, MYMENU1, "Language...")
        If My.Computer.Network.IsAvailable Then
            InsertMenu(hSysMenu, 7, MF_BYPOSITION, MYMENU2, "Check for Updates...")
        End If
    End Sub 'La Selection de soit X ou O
    Private Sub Form1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        clos = MsgB(closeMsg, 2, Yes, No, "", restrMsgHead)
        If clos = 6 Then

        ElseIf clos = 7 Then
            e.Cancel = True
        End If
        logger()
    End Sub 'Form1_Closing
    Private Sub logger()
        time = System.DateTime.Now.ToString("dd-MM-yyy HH;mm;ss")
        System.IO.File.WriteAllText(path & "\logs\" & time & ".txt", log)
    End Sub
    Public Sub checkUpdate()
        Dim ver As String = My.Application.Info.Version.ToString
#If DEBUG Then
        System.IO.File.WriteAllText(pathexe & "\version.txt", ver)
#Else
        If My.Computer.Network.IsAvailable Then
            Dim msgU As New UpdateCheck
        End If
#End If
    End Sub 'automatiquement faire une mise à jour
    Private Function MsgB(ByVal mes As String, ByVal numB As Integer, ByVal But1 As String, ByVal But2 As String, ByVal But3 As String, ByVal head As String)
        Dim msg As New CustomMessageBox(mes, numB, But1, But2, But3, head)
        Dim result = msg.ShowDialog()
        Dim Ans As Integer
        If result = Windows.Forms.DialogResult.Yes Then
            'user clicked "B1"
            Ans = 6
        ElseIf result = Windows.Forms.DialogResult.No Then
            'user clicked "B2"
            Ans = 7
        ElseIf result = Windows.Forms.DialogResult.Cancel Then
            'user clicked "B3"
            Ans = 8
        Else
            'user closed the window without clicking a button
            Ans = -1
            Close()
        End If
        Return Ans
    End Function 'custom MsgBox
    Public Sub LangSet()
        Dim LangT As String = "?"
        If My.Settings.Settings = True Then
            If My.Settings.Lang = "English" Then
                LangT = "English"
            ElseIf My.Settings.Lang = "Français" Then
                LangT = "Français"
            End If
        Else
            Dim msgL As New LangMessageBox("Continue", "Cancel")
            Dim resultL = msgL.ShowDialog()
            If resultL = Windows.Forms.DialogResult.Yes Then
                'user clicked "Oui"
            ElseIf resultL = Windows.Forms.DialogResult.No Then
                'user clicked "Non"
            Else
                'user closed the window without clicking a button
                Close()
            End If
            LangT = My.Settings.Lang
        End If

        If LangT = "Français" Then
            Yes = "Oui"
            No = "Non"
            ONs = "Allumé"
            OFF = "Éteint"
            head1 = "Sélection du Pièce"
            head2 = "Jouer Contre?"
            PlayPiece = "Quel pièce est-ce que Joueur 1 veut être?"
            PC = "Qui est-ce que tu veux jouer contre?" '"Est-ce que tu veux jouer contre l'ordinateur?"
            NG = "Nouveau Jeu: "
            Xt = "C'est le tour de X"
            Ot = "C'est le tour de O"
            winX = "X Gagne"
            winO = "O Gagne"
            DrawT = "Match Nul"
            CheckBox1.Text = "Renverser 
les Couleurs"
            CheckBox1.Location = New Point(36, 13)
            CheckBox2.Text = "Couper le son"
            GroupBox1.Text = "Jouer Contre"
            GroupBox2.Text = "Pointage"
            GroupBox3.Text = "Autres"
            RadioButton1.Text = "Un autre joueur"
            RadioButton2.Text = "L'ordinateur"
            RadioButton3.Text = "En Pourcentage"
            RadioButton4.Text = "En Points"
            Button5.Text = "Redémarrer"
            Button9.Text = ONs
            Button10.Text = OFF
            Button11.Text = "Fermer"
            restrMsg = "Est-ce que tu est assuré que tu veux redémarrer le jeu? Tu va perdre tous tes points."
            closeMsg = "Est-ce que tu est assuré que tu veux fermer le jeu? Tu va perdre tous tes points."
            restrMsgHead = "Est-ce que tu est assuré?"
            config(0) = LangT
            save = "Est-ce que tu veux sauvegarder tes paramètres?"
            head3 = "Paramètres?"
        ElseIf LangT = "English" Then
            Yes = "Yes"
            No = "No"
            ONs = "ON"
            OFF = "OFF"
            head1 = "Piece Selection"
            head2 = "Play Against?"
            PlayPiece = "Which piece does Player 1 want to play as?"
            PC = "Who do you want to play against?" '"Do you want to play against the computer?"
            NG = "New Game: "
            Xt = "It's X's Turn"
            Ot = "It's O's Turn"
            winX = "X Wins"
            winO = "O Wins"
            DrawT = "Draw"
            CheckBox1.Text = "Invert Colors"
            CheckBox1.Location = New Point(36, 20)
            CheckBox2.Text = "Mute"
            GroupBox1.Text = "Play Against"
            GroupBox2.Text = "Leaderboard"
            GroupBox3.Text = "Others"
            RadioButton1.Text = "Another Player"
            RadioButton2.Text = "The Computer"
            RadioButton3.Text = "In Percentage"
            RadioButton4.Text = "In Points"
            Button5.Text = "Restart"
            Button9.Text = ONs
            Button10.Text = OFF
            Button11.Text = "Close"
            restrMsg = "Are you sure you want to restart the game? You will lose all your points."
            closeMsg = "Are you sure you want to close the game? You will lose all your points."
            restrMsgHead = "Are you sure?"
            config(0) = LangT
            save = "Do you want to save your settings?"
            head3 = "Settings?"
        End If
        Label7.Text = DrawT & "s"
    End Sub 'selection du language
#End Region

#Region "Game Functions"
    Private Sub checkTurn()
        Turn = TurnC Mod 2
        If Turn = 1 Then
            Label1.Text = Xt
        ElseIf Turn = 0 Then
            Label1.Text = Ot
        End If

    End Sub 'Verifie le tour
    Private Sub turnCount()
        TurnC = TurnC + 1
    End Sub 'Count le tour
    Private Sub selPlayer()
        If PlayCho = 6 Then
            Label1.Text = Xt
            Player = 1
            Computer = 2
            If games = 0 Then
                log = log & "Player 1 = X | "
            End If
        ElseIf PlayCho = 7 Then
            turnCount()
            checkTurn()
            Label1.Text = Ot
            Player = 2
            Computer = 1
            If games = 0 Then
                log = log & "Player 1 = O | "
            End If
        End If
    End Sub 'La Selection de soit X ou O
    Private Sub checkWin()
        If ((Pos(0) = 1) And Pos(0) = Pos(1) And Pos(0) = Pos(2)) Then
            If invcol = True Then
                PictureBox5.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox6.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox7.BackColor = Color.FromArgb(64, 64, 64)
            ElseIf invcol = False Then
                PictureBox5.BackColor = Color.PaleGreen
                PictureBox6.BackColor = Color.PaleGreen
                PictureBox7.BackColor = Color.PaleGreen
            End If
            freezeGame()
            Label1.Text = winX
        ElseIf ((Pos(0) = 1) And Pos(0) = Pos(3) And Pos(0) = Pos(6)) Then
            If invcol = True Then
                PictureBox5.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox8.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox11.BackColor = Color.FromArgb(64, 64, 64)
            ElseIf invcol = False Then
                PictureBox5.BackColor = Color.PaleGreen
                PictureBox8.BackColor = Color.PaleGreen
                PictureBox11.BackColor = Color.PaleGreen
            End If
            freezeGame()
            Label1.Text = winX
        ElseIf ((Pos(0) = 1) And Pos(0) = Pos(4) And Pos(0) = Pos(8)) Then
            If invcol = True Then
                PictureBox5.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox9.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox13.BackColor = Color.FromArgb(64, 64, 64)
            ElseIf invcol = False Then
                PictureBox5.BackColor = Color.PaleGreen
                PictureBox9.BackColor = Color.PaleGreen
                PictureBox13.BackColor = Color.PaleGreen
            End If
            freezeGame()
            Label1.Text = winX
        ElseIf ((Pos(1) = 1) And Pos(1) = Pos(4) And Pos(1) = Pos(7)) Then
            If invcol = True Then
                PictureBox6.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox9.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox12.BackColor = Color.FromArgb(64, 64, 64)
            ElseIf invcol = False Then
                PictureBox6.BackColor = Color.PaleGreen
                PictureBox9.BackColor = Color.PaleGreen
                PictureBox12.BackColor = Color.PaleGreen
            End If
            freezeGame()
            Label1.Text = winX
        ElseIf ((Pos(2) = 1) And Pos(2) = Pos(5) And Pos(2) = Pos(8)) Then
            If invcol = True Then
                PictureBox7.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox10.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox13.BackColor = Color.FromArgb(64, 64, 64)
            ElseIf invcol = False Then
                PictureBox7.BackColor = Color.PaleGreen
                PictureBox10.BackColor = Color.PaleGreen
                PictureBox13.BackColor = Color.PaleGreen
            End If
            freezeGame()
            Label1.Text = winX
        ElseIf ((Pos(2) = 1) And Pos(2) = Pos(4) And Pos(2) = Pos(6)) Then
            If invcol = True Then
                PictureBox7.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox9.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox11.BackColor = Color.FromArgb(64, 64, 64)
            ElseIf invcol = False Then
                PictureBox7.BackColor = Color.PaleGreen
                PictureBox9.BackColor = Color.PaleGreen
                PictureBox11.BackColor = Color.PaleGreen
            End If
            freezeGame()
            Label1.Text = winX
        ElseIf ((Pos(3) = 1) And Pos(3) = Pos(4) And Pos(3) = Pos(5)) Then
            If invcol = True Then
                PictureBox8.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox9.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox10.BackColor = Color.FromArgb(64, 64, 64)
            ElseIf invcol = False Then
                PictureBox8.BackColor = Color.PaleGreen
                PictureBox9.BackColor = Color.PaleGreen
                PictureBox10.BackColor = Color.PaleGreen
            End If
            freezeGame()
            Label1.Text = winX
        ElseIf ((Pos(6) = 1) And Pos(6) = Pos(7) And Pos(6) = Pos(8)) Then
            If invcol = True Then
                PictureBox11.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox12.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox13.BackColor = Color.FromArgb(64, 64, 64)
            ElseIf invcol = False Then
                PictureBox11.BackColor = Color.PaleGreen
                PictureBox12.BackColor = Color.PaleGreen
                PictureBox13.BackColor = Color.PaleGreen
            End If
            freezeGame()
            Label1.Text = winX
        ElseIf ((Pos(0) = 2) And Pos(0) = Pos(1) And Pos(0) = Pos(2)) Then
            If invcol = True Then
                PictureBox5.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox6.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox7.BackColor = Color.FromArgb(64, 64, 64)
            ElseIf invcol = False Then
                PictureBox5.BackColor = Color.PaleGreen
                PictureBox6.BackColor = Color.PaleGreen
                PictureBox7.BackColor = Color.PaleGreen
            End If
            freezeGame()
            Label1.Text = winO
        ElseIf ((Pos(0) = 2) And Pos(0) = Pos(3) And Pos(0) = Pos(6)) Then
            If invcol = True Then
                PictureBox5.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox8.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox11.BackColor = Color.FromArgb(64, 64, 64)
            ElseIf invcol = False Then
                PictureBox5.BackColor = Color.PaleGreen
                PictureBox8.BackColor = Color.PaleGreen
                PictureBox11.BackColor = Color.PaleGreen
            End If
            freezeGame()
            Label1.Text = winO
        ElseIf ((Pos(0) = 2) And Pos(0) = Pos(4) And Pos(0) = Pos(8)) Then
            If invcol = True Then
                PictureBox5.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox9.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox13.BackColor = Color.FromArgb(64, 64, 64)
            ElseIf invcol = False Then
                PictureBox5.BackColor = Color.PaleGreen
                PictureBox9.BackColor = Color.PaleGreen
                PictureBox13.BackColor = Color.PaleGreen
            End If
            freezeGame()
            Label1.Text = winO
        ElseIf ((Pos(1) = 2) And Pos(1) = Pos(4) And Pos(1) = Pos(7)) Then
            If invcol = True Then
                PictureBox6.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox9.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox12.BackColor = Color.FromArgb(64, 64, 64)
            ElseIf invcol = False Then
                PictureBox6.BackColor = Color.PaleGreen
                PictureBox9.BackColor = Color.PaleGreen
                PictureBox12.BackColor = Color.PaleGreen
            End If
            freezeGame()
            Label1.Text = winO
        ElseIf ((Pos(2) = 2) And Pos(2) = Pos(5) And Pos(2) = Pos(8)) Then
            If invcol = True Then
                PictureBox7.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox10.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox13.BackColor = Color.FromArgb(64, 64, 64)
            ElseIf invcol = False Then
                PictureBox7.BackColor = Color.PaleGreen
                PictureBox10.BackColor = Color.PaleGreen
                PictureBox13.BackColor = Color.PaleGreen
            End If
            freezeGame()
            Label1.Text = winO
        ElseIf ((Pos(2) = 2) And Pos(2) = Pos(4) And Pos(2) = Pos(6)) Then
            If invcol = True Then
                PictureBox7.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox9.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox11.BackColor = Color.FromArgb(64, 64, 64)
            ElseIf invcol = False Then
                PictureBox7.BackColor = Color.PaleGreen
                PictureBox9.BackColor = Color.PaleGreen
                PictureBox11.BackColor = Color.PaleGreen
            End If
            freezeGame()
            Label1.Text = winO
        ElseIf ((Pos(3) = 2) And Pos(3) = Pos(4) And Pos(3) = Pos(5)) Then
            If invcol = True Then
                PictureBox8.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox9.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox10.BackColor = Color.FromArgb(64, 64, 64)
            ElseIf invcol = False Then
                PictureBox8.BackColor = Color.PaleGreen
                PictureBox9.BackColor = Color.PaleGreen
                PictureBox10.BackColor = Color.PaleGreen
            End If
            freezeGame()
            Label1.Text = winO
        ElseIf ((Pos(6) = 2) And Pos(6) = Pos(7) And Pos(6) = Pos(8)) Then
            If invcol = True Then
                PictureBox11.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox12.BackColor = Color.FromArgb(64, 64, 64)
                PictureBox13.BackColor = Color.FromArgb(64, 64, 64)
            ElseIf invcol = False Then
                PictureBox11.BackColor = Color.PaleGreen
                PictureBox12.BackColor = Color.PaleGreen
                PictureBox13.BackColor = Color.PaleGreen
            End If
            freezeGame()
            Label1.Text = winO
        ElseIf (Pos(0) <> 0 And Pos(1) <> 0 And Pos(2) <> 0 And Pos(3) <> 0 And Pos(4) <> 0 And Pos(5) <> 0 And Pos(6) <> 0 And Pos(7) <> 0 And Pos(8) <> 0) Then
            Label1.Text = DrawT
            ordTurn = 1
        End If
        checkWinner()
        percentWin()
        If Pointage = True Then
            Label4.Text = Percent(0) & "%"
            Label5.Text = Percent(1) & "%"
            Label6.Text = Percent(2) & "%"
        Else
            Label4.Text = Points(0)
            Label5.Text = Points(1)
            Label6.Text = Points(2)
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
            If (Label1.Text = winX) Then
                If sfx = True Then
                    My.Computer.Audio.Play(My.Resources.point, AudioPlayMode.Background)
                End If
                Points(0) = Points(0) + 1
                LB = 1
                gamesC = gamesC + 1
                log = log & "

X wins
"
            ElseIf (Label1.Text = winO) Then
                If sfx = True Then
                    My.Computer.Audio.Play(My.Resources.point, AudioPlayMode.Background)
                End If
                Points(1) = Points(1) + 1
                LB = 1
                gamesC = gamesC + 1
                log = log & "

O wins
"
            ElseIf (Label1.Text = DrawT) Then
                If sfx = True Then
                    My.Computer.Audio.Play(My.Resources.point, AudioPlayMode.Background)
                End If
                Points(2) = Points(2) + 1
                LB = 1
                gamesC = gamesC + 1
                log = log & "

Draw
"
            End If
        End If
    End Sub 'Verifie qui a gagné
    Private Sub freezeGame()
        If Pos(0) = 0 Then
            Pos(0) = 3
        End If
        If Pos(1) = 0 Then
            Pos(1) = 3
        End If
        If Pos(2) = 0 Then
            Pos(2) = 3
        End If
        If Pos(3) = 0 Then
            Pos(3) = 3
        End If
        If Pos(4) = 0 Then
            Pos(4) = 3
        End If
        If Pos(5) = 0 Then
            Pos(5) = 3
        End If
        If Pos(6) = 0 Then
            Pos(6) = 3
        End If
        If Pos(7) = 0 Then
            Pos(7) = 3
        End If
        If Pos(8) = 0 Then
            Pos(8) = 3
        End If
        ordTurn = 1
    End Sub 'Arrete le jeu quand quelqu'un gagne
    Private Sub newGame()
        games = games + 1
        TurnC = 0
        Turn = 0
        Pos(0) = 0
        Pos(1) = 0
        Pos(2) = 0
        Pos(3) = 0
        Pos(4) = 0
        Pos(5) = 0
        Pos(6) = 0
        Pos(7) = 0
        Pos(8) = 0
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
        'PictureBox5.BackColor = SystemColors.Control
        'PictureBox6.BackColor = SystemColors.Control
        'PictureBox7.BackColor = SystemColors.Control
        'PictureBox8.BackColor = SystemColors.Control
        'PictureBox9.BackColor = SystemColors.Control
        'PictureBox10.BackColor = SystemColors.Control
        'PictureBox11.BackColor = SystemColors.Control
        'PictureBox12.BackColor = SystemColors.Control
        'PictureBox13.BackColor = SystemColors.Control
        log = log & "


----New game----

"
        invertColor()
        Button1.Text = NG & games
        checkTurn()
        selPlayer()
    End Sub 'Nouveau jeu

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        newGame()
    End Sub 'La button pour commencer un nouveau jeu
#End Region



#Region "PicBoxes"
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        If sfx = True Then
            My.Computer.Audio.Play(My.Resources.drop, AudioPlayMode.Background)
        End If
        If Pos(0) = 0 Then
            checkTurn()
            If Turn = 1 Then
                PictureBox5.BackgroundImage = My.Resources.O
                Pos(0) = 2
                turnCount()

            ElseIf Turn = 0 Then
                PictureBox5.BackgroundImage = My.Resources.X
                Pos(0) = 1
                turnCount()

            End If
            log = log & "Player - P1
"
            ordTurn = 0
        Else
        End If
        checkWin()
    End Sub 'Quoi arrive quand tu clicke PicBox5
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        If sfx = True Then
            My.Computer.Audio.Play(My.Resources.drop, AudioPlayMode.Background)
        End If
        If Pos(1) = 0 Then
            checkTurn()
            If Turn = 1 Then
                PictureBox6.BackgroundImage = My.Resources.O
                turnCount()
                Pos(1) = 2
            ElseIf Turn = 0 Then
                PictureBox6.BackgroundImage = My.Resources.X
                turnCount()
                Pos(1) = 1
            End If
            log = log & "Player - P2
"
            ordTurn = 0
        Else
        End If
        checkWin()
    End Sub 'Quoi arrive quand tu clicke PicBox6
    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        If sfx = True Then
            My.Computer.Audio.Play(My.Resources.drop, AudioPlayMode.Background)
        End If
        If Pos(2) = 0 Then
            checkTurn()
            If Turn = 1 Then
                PictureBox7.BackgroundImage = My.Resources.O
                turnCount()
                Pos(2) = 2
            ElseIf Turn = 0 Then
                PictureBox7.BackgroundImage = My.Resources.X
                turnCount()
                Pos(2) = 1
            End If
            log = log & "Player - P3
"
            ordTurn = 0
        Else
        End If
        checkWin()
    End Sub 'Quoi arrive quand tu clicke PicBox7
    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        If sfx = True Then
            My.Computer.Audio.Play(My.Resources.drop, AudioPlayMode.Background)
        End If
        If Pos(3) = 0 Then
            checkTurn()
            If Turn = 1 Then
                PictureBox8.BackgroundImage = My.Resources.O
                turnCount()
                Pos(3) = 2
            ElseIf Turn = 0 Then
                PictureBox8.BackgroundImage = My.Resources.X
                turnCount()
                Pos(3) = 1
            End If
            log = log & "Player - P4
"
            ordTurn = 0
        Else

        End If
        checkWin()
    End Sub 'Quoi arrive quand tu clicke PicBox8
    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        If sfx = True Then
            My.Computer.Audio.Play(My.Resources.drop, AudioPlayMode.Background)
        End If
        If Pos(4) = 0 Then
            checkTurn()
            If Turn = 1 Then
                PictureBox9.BackgroundImage = My.Resources.O
                turnCount()
                Pos(4) = 2
            ElseIf Turn = 0 Then
                PictureBox9.BackgroundImage = My.Resources.X
                turnCount()
                Pos(4) = 1
            End If
            log = log & "Player - P5
"
            ordTurn = 0
        Else
        End If
        checkWin()
    End Sub 'Quoi arrive quand tu clicke PicBox9
    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        If sfx = True Then
            My.Computer.Audio.Play(My.Resources.drop, AudioPlayMode.Background)
        End If
        If Pos(5) = 0 Then
            checkTurn()
            If Turn = 1 Then
                PictureBox10.BackgroundImage = My.Resources.O
                turnCount()
                Pos(5) = 2
            ElseIf Turn = 0 Then
                PictureBox10.BackgroundImage = My.Resources.X
                turnCount()
                Pos(5) = 1
            End If
            log = log & "Player - P6
"
            ordTurn = 0
        Else
        End If
        checkWin()
    End Sub 'Quoi arrive quand tu clicke PicBox10
    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        If sfx = True Then
            My.Computer.Audio.Play(My.Resources.drop, AudioPlayMode.Background)
        End If
        If Pos(6) = 0 Then
            checkTurn()
            If Turn = 1 Then
                PictureBox11.BackgroundImage = My.Resources.O
                turnCount()
                Pos(6) = 2
            ElseIf Turn = 0 Then
                PictureBox11.BackgroundImage = My.Resources.X
                turnCount()
                Pos(6) = 1
            End If
            log = log & "Player - P7
"
            ordTurn = 0
        Else
        End If
        checkWin()
    End Sub 'Quoi arrive quand tu clicke PicBox11
    Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click
        If sfx = True Then
            My.Computer.Audio.Play(My.Resources.drop, AudioPlayMode.Background)
        End If
        If Pos(7) = 0 Then
            checkTurn()
            If Turn = 1 Then
                PictureBox12.BackgroundImage = My.Resources.O
                turnCount()
                Pos(7) = 2
            ElseIf Turn = 0 Then
                PictureBox12.BackgroundImage = My.Resources.X
                turnCount()
                Pos(7) = 1
            End If
            log = log & "Player - P8
"
            ordTurn = 0
        Else
        End If
        checkWin()
    End Sub 'Quoi arrive quand tu clicke PicBox12
    Private Sub PictureBox13_Click(sender As Object, e As EventArgs) Handles PictureBox13.Click
        If sfx = True Then
            My.Computer.Audio.Play(My.Resources.drop, AudioPlayMode.Background)
        End If
        If Pos(8) = 0 Then
            checkTurn()
            If Turn = 1 Then
                PictureBox13.BackgroundImage = My.Resources.O
                turnCount()
                Pos(8) = 2
            ElseIf Turn = 0 Then
                PictureBox13.BackgroundImage = My.Resources.X
                turnCount()
                Pos(8) = 1
            End If
            log = log & "Player - P9
"
            ordTurn = 0
        Else
        End If
        checkWin()
    End Sub 'Quoi arrive quand tu clicke PicBox13
#End Region

#Region "Button Panel"
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        log = log & "                        > Close
"
        Close()
    End Sub 'close
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        restr = MsgB(restrMsg, 2, Yes, No, "", restrMsgHead)
        If restr = 6 Then
            Application.Restart()
        End If
        log = log & "                        > Restart
"
        logger()
    End Sub 'Restart Button

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If OptPage = 0 Then
            If gb2S = False Then
                GroupBox2.Show()
                gb2S = True
            ElseIf gb2S = True Then
                GroupBox2.Hide()
                gb2S = False
            End If
        ElseIf OptPage = 1 Then
            If gb2S = False Then
                GroupBox3.Show()
                gb2S = True
            ElseIf gb2S = True Then
                GroupBox3.Hide()
                gb2S = False
            End If
        ElseIf OptPage = 2 Then
            If gb2S = False Then
                GroupBox4.Show()
                gb2S = True
            ElseIf gb2S = True Then
                GroupBox4.Hide()
                gb2S = False
            End If
        End If
        log = log & "                        > Option
"
    End Sub 'la button d'option
#Region "Page Buttons"
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GroupBox2.Hide()
        GroupBox3.Show()
        OptPage = 1
        log = log & "                        > Option: Page 1 to Page 2
"
    End Sub 'à page 2 de les options
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GroupBox2.Show()
        GroupBox3.Hide()
        OptPage = 0
        log = log & "                        > Option: Page 2 to Page 1
"
    End Sub 'à page 1 de les options
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        GroupBox4.Show()
        GroupBox3.Hide()
        OptPage = 2
        log = log & "                        > Option: Page 2 to Page 3
"
    End Sub 'à page 3 de les options
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        GroupBox3.Show()
        GroupBox4.Hide()
        OptPage = 1
        log = log & "                        > Option: Page 3 to Page 2
"
    End Sub 'à page 2 de les options
#End Region
#Region "Options"
    Private Sub percentWin()
        If gamesC = Nothing Then
            GoTo 1
        End If
        Percent(0) = (Points(0) / gamesC) * 100
        Percent(1) = (Points(1) / gamesC) * 100
        Percent(2) = (Points(2) / gamesC) * 100

        Percent(0) = Math.Round(Percent(0), 2, MidpointRounding.AwayFromZero)
        Percent(1) = Math.Round(Percent(1), 2, MidpointRounding.AwayFromZero)
        Percent(2) = Math.Round(Percent(2), 2, MidpointRounding.AwayFromZero)
1:
    End Sub 'calcul la pourcentage des victoires
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        Pointage = False
        percentWin()
        If Pointage = True Then
            Label4.Text = Percent(0) & "%"
            Label5.Text = Percent(1) & "%"
            Label6.Text = Percent(2) & "%"
            My.Settings.Points = "Percent"
        Else
            Label4.Text = Points(0)
            Label5.Text = Points(1)
            Label6.Text = Points(2)
            My.Settings.Points = "Point"
        End If
        If manglog = True Then
            log = log & "                        > Point
"
        End If
        'GroupBox2.Hide()
    End Sub 'pointage
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Pointage = True
        percentWin()
        If Pointage = True Then
            Label4.Text = Percent(0) & "%"
            Label5.Text = Percent(1) & "%"
            Label6.Text = Percent(2) & "%"
            My.Settings.Points = "Percent"
        Else
            Label4.Text = Points(0)
            Label5.Text = Points(1)
            Label6.Text = Points(2)
            My.Settings.Points = "Point"
        End If
        'GroupBox2.Hide()
        If manglog = True Then
            log = log & "                        > Percent
"
        End If
    End Sub 'pourcentage

    Private Sub invertColor()
        If invcol = True Then
            Me.BackColor = SystemColors.ControlText
            PictureBox1.BackColor = SystemColors.Control
            PictureBox2.BackColor = SystemColors.Control
            PictureBox3.BackColor = SystemColors.Control
            PictureBox4.BackColor = SystemColors.Control
            Label1.ForeColor = SystemColors.Control
            Label2.ForeColor = SystemColors.Control
            Label3.ForeColor = SystemColors.Control
            Label4.ForeColor = SystemColors.Control
            Label5.ForeColor = SystemColors.Control
            Label6.ForeColor = SystemColors.Control
            Label7.ForeColor = SystemColors.Control
            PictureBox5.BackColor = SystemColors.ControlText
            PictureBox6.BackColor = SystemColors.ControlText
            PictureBox7.BackColor = SystemColors.ControlText
            PictureBox8.BackColor = SystemColors.ControlText
            PictureBox9.BackColor = SystemColors.ControlText
            PictureBox10.BackColor = SystemColors.ControlText
            PictureBox11.BackColor = SystemColors.ControlText
            PictureBox12.BackColor = SystemColors.ControlText
            PictureBox13.BackColor = SystemColors.ControlText
            Button1.BackColor = SystemColors.ControlText
            Button1.ForeColor = SystemColors.Control
            Button2.BackColor = SystemColors.ControlText
            Button2.ForeColor = SystemColors.Control
            Button3.BackColor = SystemColors.ControlText
            Button3.ForeColor = SystemColors.Control
            Button4.BackColor = SystemColors.ControlText
            Button4.ForeColor = SystemColors.Control
            Button5.BackColor = SystemColors.ControlText
            Button5.ForeColor = SystemColors.Control
            Button6.BackColor = SystemColors.ControlText
            Button6.ForeColor = SystemColors.Control
            Button7.BackColor = SystemColors.ControlText
            Button7.ForeColor = SystemColors.Control
            Button8.BackColor = SystemColors.ControlText
            Button8.ForeColor = SystemColors.Control
            Button9.BackColor = SystemColors.ControlText
            Button9.ForeColor = SystemColors.Control
            Button10.BackColor = SystemColors.ControlText
            Button10.ForeColor = SystemColors.Control
            Button11.BackColor = SystemColors.ControlText
            Button11.ForeColor = SystemColors.Control
            GroupBox2.ForeColor = SystemColors.Control
            GroupBox3.ForeColor = SystemColors.Control
            GroupBox4.ForeColor = SystemColors.Control
            RadioButton3.ForeColor = SystemColors.Control
            RadioButton4.ForeColor = SystemColors.Control
            CheckBox1.ForeColor = SystemColors.Control
            CheckBox2.ForeColor = SystemColors.Control
        ElseIf invcol = False Then
            Me.BackColor = SystemColors.Control
            PictureBox1.BackColor = SystemColors.ControlText
            PictureBox2.BackColor = SystemColors.ControlText
            PictureBox3.BackColor = SystemColors.ControlText
            PictureBox4.BackColor = SystemColors.ControlText
            Label1.ForeColor = SystemColors.ControlText
            Label2.ForeColor = SystemColors.ControlText
            Label3.ForeColor = SystemColors.ControlText
            Label4.ForeColor = SystemColors.ControlText
            Label5.ForeColor = SystemColors.ControlText
            Label6.ForeColor = SystemColors.ControlText
            Label7.ForeColor = SystemColors.ControlText
            PictureBox5.BackColor = SystemColors.Control
            PictureBox6.BackColor = SystemColors.Control
            PictureBox7.BackColor = SystemColors.Control
            PictureBox8.BackColor = SystemColors.Control
            PictureBox9.BackColor = SystemColors.Control
            PictureBox10.BackColor = SystemColors.Control
            PictureBox11.BackColor = SystemColors.Control
            PictureBox12.BackColor = SystemColors.Control
            PictureBox13.BackColor = SystemColors.Control
            Button1.BackColor = SystemColors.Control
            Button1.ForeColor = SystemColors.ControlText
            Button2.BackColor = SystemColors.Control
            Button2.ForeColor = SystemColors.ControlText
            Button3.BackColor = SystemColors.Control
            Button3.ForeColor = SystemColors.ControlText
            Button4.BackColor = SystemColors.Control
            Button4.ForeColor = SystemColors.ControlText
            Button5.BackColor = SystemColors.Control
            Button5.ForeColor = SystemColors.ControlText
            Button6.BackColor = SystemColors.Control
            Button6.ForeColor = SystemColors.ControlText
            Button7.BackColor = SystemColors.Control
            Button7.ForeColor = SystemColors.ControlText
            Button8.BackColor = SystemColors.Control
            Button8.ForeColor = SystemColors.ControlText
            Button9.BackColor = SystemColors.Control
            Button9.ForeColor = SystemColors.ControlText
            Button10.BackColor = SystemColors.Control
            Button10.ForeColor = SystemColors.ControlText
            Button11.BackColor = SystemColors.Control
            Button11.ForeColor = SystemColors.ControlText
            GroupBox2.ForeColor = SystemColors.ControlText
            GroupBox3.ForeColor = SystemColors.ControlText
            GroupBox4.ForeColor = SystemColors.ControlText
            RadioButton3.ForeColor = SystemColors.ControlText
            RadioButton4.ForeColor = SystemColors.ControlText
            CheckBox1.ForeColor = SystemColors.ControlText
            CheckBox2.ForeColor = SystemColors.ControlText
        End If
    End Sub 'renverser les couleurs
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            invcol = True
            invertColor()
            My.Settings.Color = "Yes"
            If manglog = True Then
                log = log & "                        > Invert Colors ON
"
            End If
        Else
            invcol = False
            invertColor()
            My.Settings.Color = "No"
            If manglog = True Then
                log = log & "                        > Invert Colors OFF
"
            End If
        End If
        checkWin()
    End Sub 'l'option de renverser les couleurs
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            sfx = False
            My.Settings.Mute = "Yes"
            If manglog = True Then
                log = log & "                        > Mute ON
"
            End If
        Else
            sfx = True
            My.Settings.Mute = "No"
            If manglog = True Then
                log = log & "                        > Mute OFF
"
            End If
        End If
    End Sub 'couper le son

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        My.Settings.Settings = True
        Button9.Enabled = False
        Button10.Enabled = True
        GroupBox4.Text = "Configuration = " & ONs
        log = log & "                        > Config ON
"
    End Sub 'Saves config
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If My.Settings.Settings = True Then
            My.Settings.Settings = False
            Button9.Enabled = True
            Button10.Enabled = False
            GroupBox4.Text = "Configuration = " & OFF
        Else
            Button10.Enabled = False
            GroupBox4.Text = "Configuration = " & OFF
        End If
        log = log & "                        > Config OFF
"
    End Sub 'delete config
#End Region
#End Region

End Class