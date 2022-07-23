Imports System.IO
Imports System.Threading
Imports Newtonsoft.Json.Linq
Public Class Main
    Public Shared ReadOnly apppath As String = My.Application.Info.DirectoryPath 'Path to .exe directory
    Public Shared ReadOnly res As String = Path.GetFullPath(Application.StartupPath & "\..\..\Resources\") 'Path to Project Resources
    Public Shared ReadOnly TempPath As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp" 'Path to Temp
    Public Shared ReadOnly Local As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Regnum\TicTacToe"
    Public LangData As JObject

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckLocal()
        tscb_Languages.Text = My.Settings.Language
        CheckLang()
        UpdateCheck()
        updateLang()
        selPlayer()
        selOpponent()
    End Sub
    Private Sub Main_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If My.Settings.DarkMode = True Then tsmi_InvertColours.Checked = True
        If My.Settings.Mute = True Then tsmi_Mute.Checked = True
        If My.Settings.Score = "Point" Then
            tsmi_Points.Checked = True
        ElseIf My.Settings.Score = "Percent" Then
            tsmi_Percentage.Checked = True
        End If
        turnText()
    End Sub
    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        WriteSettings()
    End Sub

#Region "Essentials"
    'Checks For Update
    Private Sub UpdateCheck()
        If File.Exists(TempPath & "\vsn.txt") Then File.Delete(TempPath & "\vsn.txt")
        If File.Exists(TempPath & "\dt.txt") Then File.Delete(TempPath & "\dt.txt")
#If DEBUG Then
        File.WriteAllText(apppath & "..\..\..\version.txt", My.Application.Info.Version.ToString)
        File.WriteAllText(apppath & "..\..\..\version.json", "{
" & ControlChars.Quote & "version" & ControlChars.Quote & ": " & ControlChars.Quote & My.Application.Info.Version.ToString & ControlChars.Quote & "
}")
        If My.Computer.Network.IsAvailable Then
            My.Computer.Network.DownloadFile("https://raw.githubusercontent.com/PlasticJustice/VB-TicTacToe/master/TicTacToe/version.txt", TempPath & "\vsn.txt")
            Dim Reader As New IO.StreamReader(TempPath & "\vsn.txt")
            Dim v As String = Reader.ReadToEnd
            Reader.Close()
            File.Delete(TempPath & "\vsn.txt")
            If Application.ProductVersion <> v Then File.WriteAllText(res & "/date.txt", (System.DateTime.Today.Year & "/" & System.DateTime.Today.Month & "/" & System.DateTime.Today.Day))
        End If
        lklb_Update.Hide()
#Else
        File.WriteAllText(TempPath & "\date.txt", My.Resources._date)
        Dim dat As String = File.ReadAllText(TempPath & "\date.txt")
        Me.Text = "TicTacToe (" & dat & ")"
        If My.Computer.Network.IsAvailable Then
            Try
                My.Computer.Network.DownloadFile("https://raw.githubusercontent.com/PlasticJustice/VB-TicTacToe/master/TicTacToe/Resources/date.txt", TempPath & "\dt.txt")
            Catch
                File.WriteAllText(TempPath & "\dt.txt", " ")
            End Try
            Dim Reader As New IO.StreamReader(TempPath & "\dt.txt")
            Dim dtt As String = Reader.ReadToEnd
            Reader.Close()
            File.Delete(TempPath & "\dt.txt")
            If dat <> dtt Then
                lklb_Update.Text = "New Update Available! " & dtt
                lklb_Update.Show()
            Else
                lklb_Update.Hide()
            End If
        Else
            lklb_Update.Hide()
        End If
        File.Delete(TempPath & "\date.txt")
#End If
    End Sub

    'Link to Update version
    Private Sub Lklb_Update_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lklb_Update.LinkClicked
        If My.Computer.Network.IsAvailable Then
            Process.Start("https://github.com/PlasticJustice/VB-TicTacToe/releases/latest")
        Else
            MsgBox("No Internet connection!
You can not update at the moment.", vbOKOnly, "Error 404")
        End If
    End Sub

    'Link the Author's, yours truly, Github Page
    Private Sub Lklb_Author_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lklb_Author.LinkClicked
        If My.Computer.Network.IsAvailable Then
            Process.Start("https://github.com/PlasticJustice")
        Else
            MsgBox("No Internet connection!
You can look me up later.", vbOKOnly, "Error 404")
        End If
    End Sub

    'PayPal Donate Button
    Private Sub Pb_Donate_Click(sender As Object, e As EventArgs) Handles pb_Donate.Click, tsmi_Donate.Click
        Thread.Sleep(200)
        If My.Computer.Network.IsAvailable Then
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=UGSCC5VGSGN3E")
        Else
            MsgBox("No Internet connection!
        I appreciate the gesture.", vbOKOnly, "Error 404")
        End If
    End Sub
    Private Sub Pb_Donate_MouseDown(sender As Object, e As MouseEventArgs) Handles pb_Donate.MouseDown
        pb_Donate.Image = My.Resources.ppdbs
    End Sub
    Private Sub Pb_Donate_MouseUp(sender As Object, e As MouseEventArgs) Handles pb_Donate.MouseUp
        pb_Donate.Image = Nothing
    End Sub
#End Region
#Region "Startup"
    'Creates Local Files and Folders
    Private Sub CreateFolders(ByVal dirs As String())
        Try
            For i = 0 To UBound(dirs) Step 1
                If dirs(i).Contains(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)) Then
                Else
                    dirs(i) = Local & dirs(i)
                End If
                Do While Not Directory.Exists(dirs(i))
                    If Not Directory.Exists(dirs(i)) Then Directory.CreateDirectory(dirs(i))
                Loop
            Next i
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub CreateFiles(ByVal files(,))
        Try
            For i = 0 To UBound(files) Step 1
                If files(i, 0).Contains(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)) Then
                Else
                    files(i, 0) = Local & files(i, 0)
                End If
                If File.Exists(files(i, 0)) And (File.ReadAllText(files(i, 0)) <> files(i, 1)) Then
                    File.Delete(files(i, 0))
                End If
                Do While Not File.Exists(files(i, 0))
                    If Not File.Exists(files(i, 0)) Then
                        If TypeOf files(i, 1) Is String Then
                            File.WriteAllText(files(i, 0), files(i, 1))
                        Else
                            File.WriteAllBytes(files(i, 0), files(i, 1))
                        End If
                    End If
                Loop
            Next i
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Checks Local Folders
    Private Sub CheckLocal()
        Dim locals As String() = {Local, Local & "\Languages"}
        CreateFolders(locals)
        CreateFiles({{Local & "\Languages\English.json", My.Resources.English}, {Local & "\Languages\Français.json", My.Resources.Français}})

        If Not File.Exists(Local & "\settings.json") Then
            'File.WriteAllText(Local & "\settings.json", "")
            WriteSettings()
        End If
        ReadSettings()
    End Sub

#End Region

#Region "Language"
    Private Sub updateLang()
        If My.Application.Info.Version.ToString() <> LangData("Version").ToString() Then
            File.Delete(Local & "/Languages/English.json")
            File.Delete(Local & "/Languages/Français.json")
            Application.Restart()
        End If
    End Sub
    Private Sub CheckLang()
        If (My.Settings.Language <> tscb_Languages.Items.Item(0).ToString()) And (My.Settings.Language <> tscb_Languages.Items.Item(1).ToString()) Then LangBox()
        Dim lang As String = File.ReadAllText(Local & "/Languages/" & My.Settings.Language & ".json")
        LangData = JObject.Parse(lang)

        lklb_Update.Text = LangData("New Update Available! ").ToString()
        lb_By.Text = LangData("by").ToString()
        Select Case My.Settings.Language
            Case "English"
                lklb_Author.Location = New Point(14, 246)
            Case "Français"
                lklb_Author.Location = New Point(18, 246)
        End Select
        lb_BoardDraw.Text = LangData("Draw Text").ToString()
        bt_NewGame.Text = LangData("NewGame").ToString() & (Score.totalGames + 1)
        bt_Restart.Text = LangData("Restart").ToString()
        bt_Close.Text = LangData("Close").ToString()
        tsmi_InvertColours.Text = LangData("Invert Colors").ToString()
        tsmi_Mute.Text = LangData("Mute").ToString()
        tsmi_Language.Text = LangData("Language").ToString()
        tsmi_Score.Text = LangData("Score In...").ToString()
        tsmi_Percentage.Text = LangData("Percentage").ToString()
        tsmi_Points.Text = LangData("Points").ToString()
        turnText()
        Me.Refresh()
    End Sub
    Private Sub ChangeLang() Handles tscb_Languages.TextChanged, tscb_Languages.SelectedIndexChanged, tscb_Languages.TextUpdate
        My.Settings.Language = tscb_Languages.Text
        CheckLang()
    End Sub
#End Region

#Region "PicBoxes"
    Private Sub pb_TopLeft_Click(sender As Object, e As EventArgs) Handles pb_TopLeft.Click
        If Game.TopLeft = GameBoard.Playable Then
            playSFX(My.Resources.drop)
            Select Case checkTurn()
                Case 1
                    pb_TopLeft.BackgroundImage = My.Resources.O
                    Game.TopLeft = GameBoard.PlayedO
                Case 0
                    pb_TopLeft.BackgroundImage = My.Resources.X
                    Game.TopLeft = GameBoard.PlayedX
            End Select
            turnIncrement()
            ordTurn = True
            checkWin()
        End If
    End Sub

    Private Sub pb_TopMiddle_Click(sender As Object, e As EventArgs) Handles pb_TopMiddle.Click
        If Game.TopMiddle = GameBoard.Playable Then
            playSFX(My.Resources.drop)
            Select Case checkTurn()
                Case 1
                    pb_TopMiddle.BackgroundImage = My.Resources.O
                    Game.TopMiddle = GameBoard.PlayedO
                Case 0
                    pb_TopMiddle.BackgroundImage = My.Resources.X
                    Game.TopMiddle = GameBoard.PlayedX
            End Select
            turnIncrement()
            ordTurn = True
            checkWin()
        End If
    End Sub

    Private Sub pb_TopRight_Click(sender As Object, e As EventArgs) Handles pb_TopRight.Click
        If Game.TopRight = GameBoard.Playable Then
            playSFX(My.Resources.drop)
            Select Case checkTurn()
                Case 1
                    pb_TopRight.BackgroundImage = My.Resources.O
                    Game.TopRight = GameBoard.PlayedO
                Case 0
                    pb_TopRight.BackgroundImage = My.Resources.X
                    Game.TopRight = GameBoard.PlayedX
            End Select
            turnIncrement()
            ordTurn = True
            checkWin()
        End If
    End Sub

    Private Sub pb_CenterLeft_Click(sender As Object, e As EventArgs) Handles pb_CenterLeft.Click
        If Game.CenterLeft = GameBoard.Playable Then
            playSFX(My.Resources.drop)
            Select Case checkTurn()
                Case 1
                    pb_CenterLeft.BackgroundImage = My.Resources.O
                    Game.CenterLeft = GameBoard.PlayedO
                Case 0
                    pb_CenterLeft.BackgroundImage = My.Resources.X
                    Game.CenterLeft = GameBoard.PlayedX
            End Select
            turnIncrement()
            ordTurn = True
            checkWin()
        End If
    End Sub

    Private Sub pb_CenterMiddle_Click(sender As Object, e As EventArgs) Handles pb_CenterMiddle.Click
        If Game.CenterMiddle = GameBoard.Playable Then
            playSFX(My.Resources.drop)
            Select Case checkTurn()
                Case 1
                    pb_CenterMiddle.BackgroundImage = My.Resources.O
                    Game.CenterMiddle = GameBoard.PlayedO
                Case 0
                    pb_CenterMiddle.BackgroundImage = My.Resources.X
                    Game.CenterMiddle = GameBoard.PlayedX
            End Select
            turnIncrement()
            ordTurn = True
            checkWin()
        End If
    End Sub

    Private Sub pb_CenterRight_Click(sender As Object, e As EventArgs) Handles pb_CenterRight.Click
        If Game.CenterRight = GameBoard.Playable Then
            playSFX(My.Resources.drop)
            Select Case checkTurn()
                Case 1
                    pb_CenterRight.BackgroundImage = My.Resources.O
                    Game.CenterRight = GameBoard.PlayedO
                Case 0
                    pb_CenterRight.BackgroundImage = My.Resources.X
                    Game.CenterRight = GameBoard.PlayedX
            End Select
            turnIncrement()
            ordTurn = True
            checkWin()
        End If
    End Sub

    Private Sub pb_BottomLeft_Click(sender As Object, e As EventArgs) Handles pb_BottomLeft.Click
        If Game.BottomLeft = GameBoard.Playable Then
            playSFX(My.Resources.drop)
            Select Case checkTurn()
                Case 1
                    pb_BottomLeft.BackgroundImage = My.Resources.O
                    Game.BottomLeft = GameBoard.PlayedO
                Case 0
                    pb_BottomLeft.BackgroundImage = My.Resources.X
                    Game.BottomLeft = GameBoard.PlayedX
            End Select
            turnIncrement()
            ordTurn = True
            checkWin()
        End If
    End Sub

    Private Sub pb_BottomMiddle_Click(sender As Object, e As EventArgs) Handles pb_BottomMiddle.Click
        If Game.BottomMiddle = GameBoard.Playable Then
            playSFX(My.Resources.drop)
            Select Case checkTurn()
                Case 1
                    pb_BottomMiddle.BackgroundImage = My.Resources.O
                    Game.BottomMiddle = GameBoard.PlayedO
                Case 0
                    pb_BottomMiddle.BackgroundImage = My.Resources.X
                    Game.BottomMiddle = GameBoard.PlayedX
            End Select
            turnIncrement()
            ordTurn = True
            checkWin()
        End If
    End Sub

    Private Sub pb_BottomRight_Click(sender As Object, e As EventArgs) Handles pb_BottomRight.Click
        If Game.BottomRight = GameBoard.Playable Then
            playSFX(My.Resources.drop)
            Select Case checkTurn()
                Case 1
                    pb_BottomRight.BackgroundImage = My.Resources.O
                    Game.BottomRight = GameBoard.PlayedO
                Case 0
                    pb_BottomRight.BackgroundImage = My.Resources.X
                    Game.BottomRight = GameBoard.PlayedX
            End Select
            turnIncrement()
            ordTurn = True
            checkWin()
        End If
    End Sub
#End Region

    Private Sub bt_NewGame_Click(sender As Object, e As EventArgs) Handles bt_NewGame.Click
        newGame()
    End Sub

    Private Sub bt_Close_Click(sender As Object, e As EventArgs) Handles bt_Close.Click
        Me.Close()
    End Sub

    Private Sub bt_Restart_Click(sender As Object, e As EventArgs) Handles bt_Restart.Click
        Application.Restart()
    End Sub

    Private Sub tsmi_Points_Click(sender As Object, e As EventArgs) Handles tsmi_Points.Click
        tsmi_Percentage.Checked = False
        My.Settings.Score = "Point"
        updateScore()
    End Sub

    Private Sub tsmi_Percentage_Click(sender As Object, e As EventArgs) Handles tsmi_Percentage.Click
        tsmi_Points.Checked = False
        My.Settings.Score = "Percent"
        updateScore()
    End Sub
    Public Sub updateScore()
        If tsmi_Points.Checked = True Then
            lb_ScoreX.Text = Score.pointsX
            lb_ScoreO.Text = Score.pointsO
            lb_ScoreDraw.Text = Score.pointsDraw
        ElseIf tsmi_Percentage.Checked = True Then
            lb_ScoreX.Text = Math.Round(((Score.pointsX / If(Score.totalGames = 0, 1, Score.totalGames)) * 100), 2, MidpointRounding.AwayFromZero) & "%"
            lb_ScoreO.Text = Math.Round(((Score.pointsO / If(Score.totalGames = 0, 1, Score.totalGames)) * 100), 2, MidpointRounding.AwayFromZero) & "%"
            lb_ScoreDraw.Text = Math.Round(((Score.pointsDraw / If(Score.totalGames = 0, 1, Score.totalGames)) * 100), 2, MidpointRounding.AwayFromZero) & "%"
        End If
    End Sub

    Private Sub tsmi_Mute_Click(sender As Object, e As EventArgs) Handles tsmi_Mute.Click
        My.Settings.Mute = tsmi_Mute.Checked
    End Sub
    Public Sub playSFX(sfx)
        If tsmi_Mute.Checked <> True Then My.Computer.Audio.Play(sfx, AudioPlayMode.Background)
    End Sub

    Private Sub tsmi_InvertColours_Click(sender As Object, e As EventArgs) Handles tsmi_InvertColours.Click
        My.Settings.DarkMode = tsmi_InvertColours.Checked
        invertColor()
    End Sub
    Public Sub invertColor()
        Select Case tsmi_InvertColours.Checked
            Case True
                Me.BackColor = SystemColors.ControlText
                pb_lvBar.BackColor = SystemColors.Control
                pb_rvBar.BackColor = SystemColors.Control
                pb_thBar.BackColor = SystemColors.Control
                pb_bhBar.BackColor = SystemColors.Control
                Label1.ForeColor = SystemColors.Control
                lb_BoardX.ForeColor = SystemColors.Control
                lb_BoardO.ForeColor = SystemColors.Control
                lb_BoardDraw.ForeColor = SystemColors.Control
                lb_ScoreX.ForeColor = SystemColors.Control
                lb_ScoreO.ForeColor = SystemColors.Control
                lb_ScoreDraw.ForeColor = SystemColors.Control
                pb_TopLeft.BackColor = SystemColors.ControlText
                pb_TopMiddle.BackColor = SystemColors.ControlText
                pb_TopRight.BackColor = SystemColors.ControlText
                pb_CenterLeft.BackColor = SystemColors.ControlText
                pb_CenterMiddle.BackColor = SystemColors.ControlText
                pb_CenterRight.BackColor = SystemColors.ControlText
                pb_BottomLeft.BackColor = SystemColors.ControlText
                pb_BottomMiddle.BackColor = SystemColors.ControlText
                pb_BottomRight.BackColor = SystemColors.ControlText
                bt_NewGame.BackColor = SystemColors.ControlText
                bt_NewGame.ForeColor = SystemColors.Control
                bt_Restart.BackColor = SystemColors.ControlText
                bt_Restart.ForeColor = SystemColors.Control
                bt_Close.BackColor = SystemColors.ControlText
                bt_Close.ForeColor = SystemColors.Control
                lb_By.ForeColor = SystemColors.Control
                pb_Donate.BackColor = SystemColors.ControlText
                tsmi_Options.ForeColor = SystemColors.Control
                highlightColor = Color.FromArgb(64, 64, 64)
            Case False
                Me.BackColor = SystemColors.Control
                pb_lvBar.BackColor = SystemColors.ControlText
                pb_rvBar.BackColor = SystemColors.ControlText
                pb_thBar.BackColor = SystemColors.ControlText
                pb_bhBar.BackColor = SystemColors.ControlText
                Label1.ForeColor = SystemColors.ControlText
                lb_BoardX.ForeColor = SystemColors.ControlText
                lb_BoardO.ForeColor = SystemColors.ControlText
                lb_BoardDraw.ForeColor = SystemColors.ControlText
                lb_ScoreX.ForeColor = SystemColors.ControlText
                lb_ScoreO.ForeColor = SystemColors.ControlText
                lb_ScoreDraw.ForeColor = SystemColors.ControlText
                pb_TopLeft.BackColor = SystemColors.Control
                pb_TopMiddle.BackColor = SystemColors.Control
                pb_TopRight.BackColor = SystemColors.Control
                pb_CenterLeft.BackColor = SystemColors.Control
                pb_CenterMiddle.BackColor = SystemColors.Control
                pb_CenterRight.BackColor = SystemColors.Control
                pb_BottomLeft.BackColor = SystemColors.Control
                pb_BottomMiddle.BackColor = SystemColors.Control
                pb_BottomRight.BackColor = SystemColors.Control
                bt_NewGame.BackColor = SystemColors.Control
                bt_NewGame.ForeColor = SystemColors.ControlText
                bt_Restart.BackColor = SystemColors.Control
                bt_Restart.ForeColor = SystemColors.ControlText
                bt_Close.BackColor = SystemColors.Control
                bt_Close.ForeColor = SystemColors.ControlText
                lb_By.ForeColor = SystemColors.ControlText
                pb_Donate.BackColor = SystemColors.Control
                tsmi_Options.ForeColor = SystemColors.ControlText
                highlightColor = Color.PaleGreen
        End Select
    End Sub 'renverser les couleurs
End Class