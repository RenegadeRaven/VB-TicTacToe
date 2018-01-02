Public Class LangMessageBox
    Public Sub New(ByVal button1Name As String, ByVal button2name As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        'Label1.Text = message
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
        Form1.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Français" Then
            Form1.Language.Text = "Français"
            Button2.Text = "Annuler"
            Button1.Enabled = True
        ElseIf ComboBox1.Text = "English" Then
            Form1.Language.Text = "English"
            Button2.Text = "Cancel"
            Button1.Enabled = True
        ElseIf ComboBox1.Text = "----Language----" Then
            Form1.Language.Text = "----Language----"
            Button2.Text = "Cancel"
            Button1.Enabled = False
        End If
    End Sub
End Class