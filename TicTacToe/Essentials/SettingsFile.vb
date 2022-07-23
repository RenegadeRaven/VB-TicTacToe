Imports System.IO
Imports Newtonsoft.Json.Linq
Module SettingsFile
    Dim Settings As JObject

    Public Sub ReadSettings()
        Dim lang As String = File.ReadAllText(Main.Local & "\settings.json")
        If lang IsNot Nothing Then Settings = JObject.Parse(lang)
        My.Settings.Language = Settings("Language")
        My.Settings.Score = Settings("Score")
        My.Settings.DarkMode = Settings("Dark_Mode")
        My.Settings.Mute = Settings("Mute")
    End Sub
    Public Sub WriteSettings()
        If Not File.Exists(Main.Local & "\settings.json") Then CreateSettings()
        Dim lang As String = File.ReadAllText(Main.Local & "\settings.json")
        If lang IsNot Nothing Then Settings = JObject.Parse(lang)
        Settings("Language") = My.Settings.Language
        Settings("Score") = My.Settings.Score
        Settings("Dark_Mode") = My.Settings.DarkMode
        Settings("Mute") = My.Settings.Mute
        File.WriteAllText(Main.Local & "\settings.json", Settings.ToString)
    End Sub
    Public Sub CreateSettings()
        Dim dSettings As Object = New JObject()
        dSettings.Language = My.Settings.Language
        dSettings.Score = My.Settings.Score
        dSettings.Dark_Mode = My.Settings.DarkMode
        dSettings.Mute = My.Settings.Mute
        File.WriteAllText(Main.Local & "\settings.json", dSettings.ToString)
    End Sub
End Module