Imports System.Xml
Module SettingsFile
    Dim Settings As XmlDocument

    Public Sub ReadSettings()
        Settings = New XmlDocument
        Settings.Load(Main.Local & "\settings.xml")
        My.Settings.Language = GetValue("Language")
        My.Settings.DarkMode = GetValue("DarkMode")
        My.Settings.Mute = GetValue("Mute")
        My.Settings.Score = GetValue("Score")
    End Sub
    Private Function GetValue(SettingName) As String
        Return Settings.SelectSingleNode("Settings/" & SettingName).InnerText
    End Function
    Public Sub WriteSettings()
        If Not IO.File.Exists(Main.Local & "\settings.xml") Then CreateSettings()
        SetValue("Language", My.Settings.Language)
        SetValue("DarkMode", My.Settings.DarkMode)
        SetValue("Mute", My.Settings.Mute)
        SetValue("Score", My.Settings.Score)
        Settings.Save(Main.Local & "\settings.xml")
    End Sub
    Private Sub SetValue(SettingName As String, SettingValue As String)
        Dim SettingNode As XmlElement
        Try
            SettingNode = DirectCast(Settings.SelectSingleNode("Settings/" & SettingName), XmlElement)
        Catch
            SettingNode = Nothing
        End Try
        If SettingNode IsNot Nothing Then
            SettingNode.InnerText = SettingValue
        Else
            SettingNode = Settings.CreateElement(SettingName)
            SettingNode.InnerText = SettingValue
            Settings.SelectSingleNode("Settings").AppendChild(SettingNode)
        End If
    End Sub
    Private Sub CreateSettings()
        Settings = New XmlDocument
        Dim dec As XmlDeclaration = Settings.CreateXmlDeclaration("1.0", "utf-8", String.Empty)
        Settings.AppendChild(dec)

        Dim nodeRoot As XmlNode
        nodeRoot = Settings.CreateNode(XmlNodeType.Element, "Settings", "")
        Settings.AppendChild(nodeRoot)
    End Sub
End Module