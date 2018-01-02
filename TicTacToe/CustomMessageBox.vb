﻿Public Class CustomMessageBox
    Public Sub New(ByVal message As String, ByVal button1Name As String, ByVal button2name As String, ByVal header As String)
        InitializeComponent()
        Label1.Text = message
        Button1.Text = button1Name
        Button2.Text = button2name
        Me.Text = header
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DialogResult = Windows.Forms.DialogResult.Yes
        Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DialogResult = Windows.Forms.DialogResult.No
        Close()
    End Sub
End Class