Public Class LangMessageBox
    Public Sub New(ByVal button1Name As String, ByVal button2name As String)
        InitializeComponent()
        Button1.Text = button1Name
        Button2.Text = button2name
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DialogResult = Windows.Forms.DialogResult.Yes
        Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DialogResult = Windows.Forms.DialogResult.No
        Close()
        Main.Close()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Français" Then
            My.Settings.Lang = "Français"
            Button2.Text = "Annuler"
            Me.Text = "Sélection du Langage"
            Button1.Enabled = True
        ElseIf ComboBox1.Text = "English" Then
            My.Settings.Lang = "English"
            Button2.Text = "Cancel"
            Me.Text = "Language Selection"
            Button1.Enabled = True
        ElseIf ComboBox1.Text = "----Language----" Then
            My.Settings.Lang = "----Language----"
            Button2.Text = "Cancel"
            Me.Text = "Language Selection"
            Button1.Enabled = False
        End If
    End Sub
End Class