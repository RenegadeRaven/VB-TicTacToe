Imports System.Xml
Module SettingsFile
    Dim Settings As XmlDocument

    Public Sub ReadSettings()
        Settings = New XmlDocument
        Settings.Load(Main.userLocal & "\settings.xml")
        My.Settings.Language = getValue("Language")
        My.Settings.DarkMode = getValue("DarkMode")
        My.Settings.Mute = getValue("Mute")
        My.Settings.Score = getValue("Score")
    End Sub
    Private Function GetValue(SettingName) As String
        Return Settings.SelectSingleNode("Settings/" & SettingName).InnerText
    End Function
    Public Sub WriteSettings()
        If Not IO.File.Exists(Main.userLocal & "\settings.xml") Then createSettings()
        setValue("Language", My.Settings.Language)
        setValue("DarkMode", My.Settings.DarkMode)
        setValue("Mute", My.Settings.Mute)
        setValue("Score", My.Settings.Score)
        Settings.Save(Main.userLocal & "\settings.xml")
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