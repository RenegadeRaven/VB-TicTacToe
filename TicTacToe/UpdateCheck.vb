Public Class UpdateCheck
    Dim dir As String = My.Application.Info.DirectoryPath
    Dim web As New System.Net.WebClient
    Dim prog As String = dir & "\TicTacToe.exe"
    Private Sub UpdateCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://raw.githubusercontent.com/PlasticJustice/VB-TicTacToe/master/TicTacToe/bin/Debug/version.txt")
        Dim response As System.Net.HttpWebResponse = request.GetResponse()
        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
        Dim newestversion As String = sr.ReadToEnd()
        Dim currentversion As String = Application.ProductVersion
        If newestversion.Contains(currentversion) Then
            'Do nothing
            Close()
        Else
            web.DownloadFileAsync(New Uri("https://github.com/PlasticJustice/VB-TicTacToe/raw/master/TicTacToe/bin/Debug/AutoUpdater.exe"), prog)
            Timer1.Start()
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Process.Start(prog)
        Application.Restart()
    End Sub
End Class