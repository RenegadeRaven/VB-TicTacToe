﻿Imports System.IO
Imports System.Threading
Public Class Main
    Public Shared ReadOnly exeDirectory As String = My.Application.Info.DirectoryPath 'Path to .exe directory
    Public Shared ReadOnly projResources As String = Path.GetFullPath(Application.StartupPath & "\..\..\Resources\") 'Path to Project Resources
    Public Shared ReadOnly sysTemp As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp" 'Path to Temp
    Public Shared ReadOnly userLocal As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\RenegadeRaven\TicTacToe" 'Path to App folder in user Local
    Public Shared ReadOnly repoUpdateURL As String = "https://raw.githubusercontent.com/RenegadeRaven/VB-TicTacToe/master/TicTacToe/"
    Public Shared localizationLanguage As Resources.ResourceManager

    'Application Startup Sequence
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Generate and Verify Local App Folder
        checkLocal()

        'Pull desired language from settings and apply it
        tscb_Languages.Text = My.Settings.Language
        checkLang()

        'Check for Updates
        updateCheck()

        'Let user pick their piece and opponent
        selPlayer()
        selOpponent()
    End Sub

    'Form Startup
    Private Sub Main_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'Apply cosmetic settings
        'Dark Mode
        If My.Settings.DarkMode = True Then tsmi_InvertColours.Checked = True

        'Mute
        If My.Settings.Mute = True Then tsmi_Mute.Checked = True

        'Score Format
        If My.Settings.Score = "Point" Then
            tsmi_Points.Checked = True
        ElseIf My.Settings.Score = "Percent" Then
            tsmi_Percentage.Checked = True
        End If

        'Sets Turn text
        turnText()
    End Sub

    'Application Close Sequence
    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Write Settings File
        writeSettings()
    End Sub

#Region "Internet"
    'Check for Internet connection by ping
    Private Function PingCheck()
        Try
            Return My.Computer.Network.Ping("8.8.8.8")
        Catch
            Return False
        End Try
    End Function

    'Check For Update
    Private Sub UpdateCheck()
        Dim versionFile As String = "\TicTacToe-Version.txt"
        Dim versionDateFile As String = "\TicTacToe-VersionDate.txt"

        If File.Exists(sysTemp & versionFile) Then File.Delete(sysTemp & versionFile)
        If File.Exists(sysTemp & versionDateFile) Then File.Delete(sysTemp & versionFile)
#If DEBUG Then
        File.WriteAllText(exeDirectory & "..\..\..\version.txt", My.Application.Info.Version.ToString)
        '        File.WriteAllText(exeDirectory & "..\..\..\version.json", "{
        '" & ControlChars.Quote & "version" & ControlChars.Quote & ": " & ControlChars.Quote & My.Application.Info.Version.ToString & ControlChars.Quote & "
        '}")
        If My.Computer.Network.IsAvailable And PingCheck() Then
            My.Computer.Network.DownloadFile(repoUpdateURL & "version.txt", sysTemp & versionFile)
            If File.Exists(sysTemp & versionFile) Then
                Dim fileReader As New IO.StreamReader(sysTemp & versionFile)
                Dim version As String = fileReader.ReadToEnd
                fileReader.Close()
                File.Delete(sysTemp & versionFile)
                If Application.ProductVersion <> version Then
                    File.WriteAllText(projResources & "/date.txt", (System.DateTime.Today.Year & "/" & System.DateTime.Today.Month & "/" & System.DateTime.Today.Day))
                End If
            End If
        End If
        lklb_Update.Hide()
#Else
        Me.Text = "TicTacToe (" & My.Resources._date & ")"
        If My.Computer.Network.IsAvailable And PingCheck() Then
            Try
                My.Computer.Network.DownloadFile(repoUpdateURL & "Resources/date.txt", sysTemp & versionDateFile)
                If File.Exists(sysTemp & versionDateFile) Then
                    Dim fileReader As New IO.StreamReader(sysTemp & versionDateFile)
                    Dim versionDate As String = fileReader.ReadToEnd
                    fileReader.Close()
                    File.Delete(sysTemp & versionDateFile)
                    If My.Resources._date <> versionDate Then
                        lklb_Update.Text = "New Update Available! " & versionDate
                        lklb_Update.Show()
                    Else
                        lklb_Update.Hide()
                    End If
                End If
            Catch
                File.WriteAllText(sysTemp & versionDateFile, " ")
            End Try
        Else
            lklb_Update.Hide()
        End If
        File.Delete(sysTemp & "\date.txt")
#End If
    End Sub

    'Link to Update version
    Private Sub lklb_Update_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lklb_Update.LinkClicked
        If My.Computer.Network.IsAvailable And PingCheck() Then
            Process.Start("https://github.com/RenegadeRaven/VB-TicTacToe/releases/latest")
        Else
            MsgBox(localizationLanguage.GetString("No Internet connection") & "
" & localizationLanguage.GetString("NoUpdate"), 1,,,, localizationLanguage.GetString("Error") & " 404")
        End If
    End Sub

    'Link the Author's, yours truly, Github Page
    Private Sub lklb_Author_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lklb_Author.LinkClicked
        If My.Computer.Network.IsAvailable And PingCheck() Then
            Process.Start("https://github.com/RenegadeRaven")
        Else
            MsgBox(localizationLanguage.GetString("No Internet connection") & "
" & localizationLanguage.GetString("LookMeUp"), 1,,,, localizationLanguage.GetString("Error") & " 404")
        End If
    End Sub

    'PayPal Donate Button
    Private Sub pb_Donate_Click(sender As Object, e As EventArgs) Handles pb_Donate.Click, tsmi_Donate.Click
        'Thread.Sleep(200)
        If My.Computer.Network.IsAvailable And PingCheck() Then
            Process.Start("https://www.paypal.com/donate/?hosted_button_id=V3U6Q93MJ9MZC")
        Else
            MsgBox(localizationLanguage.GetString("No Internet connection") & "
" & localizationLanguage.GetString("Gesture"), 1,,,, localizationLanguage.GetString("Error") & " 404")
        End If
    End Sub
    Private Sub pb_Donate_MouseDown(sender As Object, e As MouseEventArgs) Handles pb_Donate.MouseDown
        pb_Donate.Image = My.Resources.ppdbs
    End Sub
    Private Sub pb_Donate_MouseUp(sender As Object, e As MouseEventArgs) Handles pb_Donate.MouseUp
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
                    dirs(i) = userLocal & dirs(i)
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
                    files(i, 0) = userLocal & files(i, 0)
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
        Dim locals As String() = {userLocal}
        CreateFolders(locals)

        If Not File.Exists(userLocal & "\settings.xml") Then writeSettings()
        readSettings()
    End Sub

#End Region

#Region "Language"
    Private Sub CheckLang()
        If (My.Settings.Language <> tscb_Languages.Items.Item(0).ToString()) And (My.Settings.Language <> tscb_Languages.Items.Item(1).ToString()) Then LangBox()
        My.Settings.Language = tscb_Languages.Text
        Select Case tscb_Languages.Text
            Case "English"
                localizationLanguage = New Resources.ResourceManager("TicTacToe.English", Reflection.Assembly.GetExecutingAssembly())
                lklb_Author.Location = New Point(14, 246)
            Case "Français"
                localizationLanguage = New Resources.ResourceManager("TicTacToe.Français", Reflection.Assembly.GetExecutingAssembly())
                lklb_Author.Location = New Point(18, 246)
        End Select

        lklb_Update.Text = localizationLanguage.GetString("Update")
        lb_By.Text = localizationLanguage.GetString("By")

        lb_BoardDraw.Text = localizationLanguage.GetString("Draw Text")
        bt_NewGame.Text = localizationLanguage.GetString("NewGame") & ": " & (Score.totalGames + 1)
        bt_Restart.Text = localizationLanguage.GetString("Restart")
        bt_Close.Text = localizationLanguage.GetString("Close")
        tsmi_InvertColours.Text = localizationLanguage.GetString("InvertColors")
        tsmi_Mute.Text = localizationLanguage.GetString("Mute")
        tsmi_Language.Text = localizationLanguage.GetString("Language")
        tsmi_Score.Text = localizationLanguage.GetString("Score")
        tsmi_Percentage.Text = localizationLanguage.GetString("Percent")
        tsmi_Points.Text = localizationLanguage.GetString("Points")
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
    Public Sub UpdateScore()
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
    Public Sub PlaySFX(sfx)
        If tsmi_Mute.Checked <> True Then My.Computer.Audio.Play(sfx, AudioPlayMode.Background)
    End Sub

    Private Sub tsmi_InvertColours_Click(sender As Object, e As EventArgs) Handles tsmi_InvertColours.Click
        My.Settings.DarkMode = tsmi_InvertColours.Checked
        invertColor()
    End Sub
    Public Sub InvertColor()
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