Imports System.IO

Module LocalManagement
    'Creates Local Files and Folders
    Private Sub CreateFolders(ByVal directories As String())
        Try
            For i = 0 To UBound(directories) Step 1
                If Not directories(i).Contains(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)) Then
                    directories(i) = Main.userLocal & directories(i)
                End If
                Do While Not Directory.Exists(directories(i))
                    If Not Directory.Exists(directories(i)) Then Directory.CreateDirectory(directories(i))
                Loop
            Next i
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub CreateFiles(ByVal files(,))
        Try
            For i = 0 To UBound(files) Step 1
                If Not files(i, 0).Contains(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)) Then
                    files(i, 0) = Main.userLocal & files(i, 0)
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
    Public Sub CheckLocal()
        Dim locals As String() = {Main.userLocal}
        CreateFolders(locals)

        If Not File.Exists(Main.userLocal & "\settings.xml") Then WriteSettings()
        ReadSettings()
    End Sub
End Module
