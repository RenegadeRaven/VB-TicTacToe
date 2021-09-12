Module Computer
#Region "Ordinateur"
    Private Sub rndPick()
        'Random number generator variable 
        Dim gen As New Random
        'Use the random number generator 
        Form1.ordPlay = gen.Next(1, 10)
    End Sub 'Choisir un nombre au hazard pour l'ordinateur
    Public Sub comp()
1:
        Form1.ErrorCount = Form1.ErrorCount + 1
        If Form1.ErrorCount > 3 Then
            GoTo 3
        End If
        'horizontal
        'Top
        'If ( Form1.Pos(3)  = Form1.Player) And ( Form1.Pos(5)  = Form1.Computer) And ( Form1.Pos(3)  =  Form1.Pos(2)  =  Form1.Pos(8) ) And ( Form1.Pos(5)  =  Form1.Pos(4) ) And ( Form1.Pos(0)  = 0) And ( Form1.Pos(0)  =  Form1.Pos(1)  =  Form1.Pos(6)  =  Form1.Pos(7) ) Then
        'Form1.ordPlay = 2
        'GoTo 2
        'Else
        If ((Form1.Pos(0) = Form1.Computer) And Form1.Pos(0) = Form1.Pos(1) And Form1.Pos(2) = 0) Then
            Form1.ordPlay = 3
            GoTo 2
        ElseIf ((Form1.Pos(0) = Form1.Computer) And Form1.Pos(0) = Form1.Pos(2) And Form1.Pos(1) = 0) Then
            Form1.ordPlay = 2
            GoTo 2
        ElseIf ((Form1.Pos(1) = Form1.Computer) And Form1.Pos(1) = Form1.Pos(0) And Form1.Pos(2) = 0) Then
            Form1.ordPlay = 3
            GoTo 2
        ElseIf ((Form1.Pos(1) = Form1.Computer) And Form1.Pos(1) = Form1.Pos(2) And Form1.Pos(0) = 0) Then
            Form1.ordPlay = 1
            GoTo 2
        ElseIf ((Form1.Pos(2) = Form1.Computer) And Form1.Pos(2) = Form1.Pos(0) And Form1.Pos(1) = 0) Then
            Form1.ordPlay = 2
            GoTo 2
        ElseIf ((Form1.Pos(2) = Form1.Computer) And Form1.Pos(2) = Form1.Pos(1) And Form1.Pos(0) = 0) Then
            Form1.ordPlay = 1
            GoTo 2
            'Middle	
        ElseIf ((Form1.Pos(3) = Form1.Computer) And Form1.Pos(3) = Form1.Pos(4) And Form1.Pos(5) = 0) Then
            Form1.ordPlay = 6
            GoTo 2
        ElseIf ((Form1.Pos(3) = Form1.Computer) And Form1.Pos(3) = Form1.Pos(5) And Form1.Pos(4) = 0) Then
            Form1.ordPlay = 5
            GoTo 2
        ElseIf ((Form1.Pos(4) = Form1.Computer) And Form1.Pos(4) = Form1.Pos(5) And Form1.Pos(3) = 0) Then
            Form1.ordPlay = 4
            GoTo 2
        ElseIf ((Form1.Pos(4) = Form1.Computer) And Form1.Pos(4) = Form1.Pos(3) And Form1.Pos(5) = 0) Then
            Form1.ordPlay = 6
            GoTo 2
        ElseIf ((Form1.Pos(5) = Form1.Computer) And Form1.Pos(5) = Form1.Pos(4) And Form1.Pos(3) = 0) Then
            Form1.ordPlay = 4
            GoTo 2
        ElseIf ((Form1.Pos(5) = Form1.Computer) And Form1.Pos(5) = Form1.Pos(3) And Form1.Pos(4) = 0) Then
            Form1.ordPlay = 5
            GoTo 2
            'Bottom
        ElseIf ((Form1.Pos(6) = Form1.Computer) And Form1.Pos(6) = Form1.Pos(7) And Form1.Pos(8) = 0) Then
            Form1.ordPlay = 9
            GoTo 2
        ElseIf ((Form1.Pos(6) = Form1.Computer) And Form1.Pos(6) = Form1.Pos(8) And Form1.Pos(7) = 0) Then
            Form1.ordPlay = 8
            GoTo 2
        ElseIf ((Form1.Pos(7) = Form1.Computer) And Form1.Pos(7) = Form1.Pos(6) And Form1.Pos(8) = 0) Then
            Form1.ordPlay = 9
            GoTo 2
        ElseIf ((Form1.Pos(7) = Form1.Computer) And Form1.Pos(7) = Form1.Pos(8) And Form1.Pos(6) = 0) Then
            Form1.ordPlay = 7
            GoTo 2
        ElseIf ((Form1.Pos(8) = Form1.Computer) And Form1.Pos(8) = Form1.Pos(7) And Form1.Pos(6) = 0) Then
            Form1.ordPlay = 7
            GoTo 2
        ElseIf ((Form1.Pos(8) = Form1.Computer) And Form1.Pos(8) = Form1.Pos(6) And Form1.Pos(7) = 0) Then
            Form1.ordPlay = 8
            GoTo 2
            'Vertical
            'left
        ElseIf ((Form1.Pos(0) = Form1.Computer) And Form1.Pos(0) = Form1.Pos(6) And Form1.Pos(3) = 0) Then
            Form1.ordPlay = 4
            GoTo 2
        ElseIf ((Form1.Pos(0) = Form1.Computer) And Form1.Pos(0) = Form1.Pos(3) And Form1.Pos(6) = 0) Then
            Form1.ordPlay = 7
            GoTo 2
        ElseIf ((Form1.Pos(3) = Form1.Computer) And Form1.Pos(3) = Form1.Pos(6) And Form1.Pos(0) = 0) Then
            Form1.ordPlay = 1
            GoTo 2
        ElseIf ((Form1.Pos(3) = Form1.Computer) And Form1.Pos(3) = Form1.Pos(0) And Form1.Pos(6) = 0) Then
            Form1.ordPlay = 7
            GoTo 2
        ElseIf ((Form1.Pos(6) = Form1.Computer) And Form1.Pos(6) = Form1.Pos(0) And Form1.Pos(3) = 0) Then
            Form1.ordPlay = 4
            GoTo 2
        ElseIf ((Form1.Pos(6) = Form1.Computer) And Form1.Pos(6) = Form1.Pos(3) And Form1.Pos(0) = 0) Then
            Form1.ordPlay = 1
            GoTo 2
            'middle
        ElseIf ((Form1.Pos(1) = Form1.Computer) And Form1.Pos(1) = Form1.Pos(7) And Form1.Pos(4) = 0) Then
            Form1.ordPlay = 5
            GoTo 2
        ElseIf ((Form1.Pos(1) = Form1.Computer) And Form1.Pos(1) = Form1.Pos(4) And Form1.Pos(7) = 0) Then
            Form1.ordPlay = 8
            GoTo 2
        ElseIf ((Form1.Pos(4) = Form1.Computer) And Form1.Pos(4) = Form1.Pos(7) And Form1.Pos(1) = 0) Then
            Form1.ordPlay = 2
            GoTo 2
        ElseIf ((Form1.Pos(4) = Form1.Computer) And Form1.Pos(4) = Form1.Pos(1) And Form1.Pos(7) = 0) Then
            Form1.ordPlay = 8
            GoTo 2
        ElseIf ((Form1.Pos(7) = Form1.Computer) And Form1.Pos(7) = Form1.Pos(1) And Form1.Pos(4) = 0) Then
            Form1.ordPlay = 5
            GoTo 2
        ElseIf ((Form1.Pos(7) = Form1.Computer) And Form1.Pos(7) = Form1.Pos(4) And Form1.Pos(1) = 0) Then
            Form1.ordPlay = 2
            GoTo 2
            'right	
        ElseIf ((Form1.Pos(2) = Form1.Computer) And Form1.Pos(2) = Form1.Pos(8) And Form1.Pos(5) = 0) Then
            Form1.ordPlay = 6
            GoTo 2
        ElseIf ((Form1.Pos(2) = Form1.Computer) And Form1.Pos(2) = Form1.Pos(5) And Form1.Pos(8) = 0) Then
            Form1.ordPlay = 9
            GoTo 2
        ElseIf ((Form1.Pos(5) = Form1.Computer) And Form1.Pos(5) = Form1.Pos(8) And Form1.Pos(2) = 0) Then
            Form1.ordPlay = 3
            GoTo 2
        ElseIf ((Form1.Pos(5) = Form1.Computer) And Form1.Pos(5) = Form1.Pos(2) And Form1.Pos(8) = 0) Then
            Form1.ordPlay = 9
            GoTo 2
        ElseIf ((Form1.Pos(8) = Form1.Computer) And Form1.Pos(8) = Form1.Pos(5) And Form1.Pos(2) = 0) Then
            Form1.ordPlay = 3
            GoTo 2
        ElseIf ((Form1.Pos(8) = Form1.Computer) And Form1.Pos(8) = Form1.Pos(2) And Form1.Pos(5) = 0) Then
            Form1.ordPlay = 6
            GoTo 2
            'diagonal
            'backslash
        ElseIf ((Form1.Pos(0) = Form1.Computer) And Form1.Pos(0) = Form1.Pos(4) And Form1.Pos(8) = 0) Then
            Form1.ordPlay = 9
            GoTo 2
        ElseIf ((Form1.Pos(0) = Form1.Computer) And Form1.Pos(0) = Form1.Pos(8) And Form1.Pos(4) = 0) Then
            Form1.ordPlay = 5
            GoTo 2
        ElseIf ((Form1.Pos(4) = Form1.Computer) And Form1.Pos(4) = Form1.Pos(0) And Form1.Pos(8) = 0) Then
            Form1.ordPlay = 9
            GoTo 2
        ElseIf ((Form1.Pos(4) = Form1.Computer) And Form1.Pos(4) = Form1.Pos(8) And Form1.Pos(0) = 0) Then
            Form1.ordPlay = 1
            GoTo 2
        ElseIf ((Form1.Pos(8) = Form1.Computer) And Form1.Pos(8) = Form1.Pos(4) And Form1.Pos(0) = 0) Then
            Form1.ordPlay = 1
            GoTo 2
        ElseIf ((Form1.Pos(8) = Form1.Computer) And Form1.Pos(8) = Form1.Pos(0) And Form1.Pos(4) = 0) Then
            Form1.ordPlay = 5
            GoTo 2
            'forwardslash
        ElseIf ((Form1.Pos(2) = Form1.Computer) And Form1.Pos(2) = Form1.Pos(6) And Form1.Pos(4) = 0) Then
            Form1.ordPlay = 5
            GoTo 2
        ElseIf ((Form1.Pos(2) = Form1.Computer) And Form1.Pos(2) = Form1.Pos(4) And Form1.Pos(6) = 0) Then
            Form1.ordPlay = 7
            GoTo 2
        ElseIf ((Form1.Pos(4) = Form1.Computer) And Form1.Pos(4) = Form1.Pos(6) And Form1.Pos(2) = 0) Then
            Form1.ordPlay = 3
            GoTo 2
        ElseIf ((Form1.Pos(4) = Form1.Computer) And Form1.Pos(4) = Form1.Pos(2) And Form1.Pos(6) = 0) Then
            Form1.ordPlay = 7
            GoTo 2
        ElseIf ((Form1.Pos(6) = Form1.Computer) And Form1.Pos(6) = Form1.Pos(2) And Form1.Pos(4) = 0) Then
            Form1.ordPlay = 5
            GoTo 2
        ElseIf ((Form1.Pos(6) = Form1.Computer) And Form1.Pos(6) = Form1.Pos(4) And Form1.Pos(2) = 0) Then
            Form1.ordPlay = 3
            GoTo 2

            'horizontal
            'Top
        ElseIf ((Form1.Pos(0) = Form1.Player) And Form1.Pos(0) = Form1.Pos(1) And Form1.Pos(2) = 0) Then
            Form1.ordPlay = 3
            GoTo 2
        ElseIf ((Form1.Pos(0) = Form1.Player) And Form1.Pos(0) = Form1.Pos(2) And Form1.Pos(1) = 0) Then
            Form1.ordPlay = 2
            GoTo 2
        ElseIf ((Form1.Pos(1) = Form1.Player) And Form1.Pos(1) = Form1.Pos(0) And Form1.Pos(2) = 0) Then
            Form1.ordPlay = 3
            GoTo 2
        ElseIf ((Form1.Pos(1) = Form1.Player) And Form1.Pos(1) = Form1.Pos(2) And Form1.Pos(0) = 0) Then
            Form1.ordPlay = 1
            GoTo 2
        ElseIf ((Form1.Pos(2) = Form1.Player) And Form1.Pos(2) = Form1.Pos(0) And Form1.Pos(1) = 0) Then
            Form1.ordPlay = 2
            GoTo 2
        ElseIf ((Form1.Pos(2) = Form1.Player) And Form1.Pos(2) = Form1.Pos(1) And Form1.Pos(0) = 0) Then
            Form1.ordPlay = 1
            GoTo 2
            'Middle	
        ElseIf ((Form1.Pos(3) = Form1.Player) And Form1.Pos(3) = Form1.Pos(4) And Form1.Pos(5) = 0) Then
            Form1.ordPlay = 6
            GoTo 2
        ElseIf ((Form1.Pos(3) = Form1.Player) And Form1.Pos(3) = Form1.Pos(5) And Form1.Pos(4) = 0) Then
            Form1.ordPlay = 5
            GoTo 2
        ElseIf ((Form1.Pos(4) = Form1.Player) And Form1.Pos(4) = Form1.Pos(5) And Form1.Pos(3) = 0) Then
            Form1.ordPlay = 4
            GoTo 2
        ElseIf ((Form1.Pos(4) = Form1.Player) And Form1.Pos(4) = Form1.Pos(3) And Form1.Pos(5) = 0) Then
            Form1.ordPlay = 6
            GoTo 2
        ElseIf ((Form1.Pos(5) = Form1.Player) And Form1.Pos(5) = Form1.Pos(4) And Form1.Pos(3) = 0) Then
            Form1.ordPlay = 4
            GoTo 2
        ElseIf ((Form1.Pos(5) = Form1.Player) And Form1.Pos(5) = Form1.Pos(3) And Form1.Pos(4) = 0) Then
            Form1.ordPlay = 5
            GoTo 2
            'Bottom
        ElseIf ((Form1.Pos(6) = Form1.Player) And Form1.Pos(6) = Form1.Pos(7) And Form1.Pos(8) = 0) Then
            Form1.ordPlay = 9
            GoTo 2
        ElseIf ((Form1.Pos(6) = Form1.Player) And Form1.Pos(6) = Form1.Pos(8) And Form1.Pos(7) = 0) Then
            Form1.ordPlay = 8
            GoTo 2
        ElseIf ((Form1.Pos(7) = Form1.Player) And Form1.Pos(7) = Form1.Pos(6) And Form1.Pos(8) = 0) Then
            Form1.ordPlay = 9
            GoTo 2
        ElseIf ((Form1.Pos(7) = Form1.Player) And Form1.Pos(7) = Form1.Pos(8) And Form1.Pos(6) = 0) Then
            Form1.ordPlay = 7
            GoTo 2
        ElseIf ((Form1.Pos(8) = Form1.Player) And Form1.Pos(8) = Form1.Pos(7) And Form1.Pos(6) = 0) Then
            Form1.ordPlay = 7
            GoTo 2
        ElseIf ((Form1.Pos(8) = Form1.Player) And Form1.Pos(8) = Form1.Pos(6) And Form1.Pos(7) = 0) Then
            Form1.ordPlay = 8
            GoTo 2
            'Vertical
            'left
        ElseIf ((Form1.Pos(0) = Form1.Player) And Form1.Pos(0) = Form1.Pos(6) And Form1.Pos(3) = 0) Then
            Form1.ordPlay = 4
            GoTo 2
        ElseIf ((Form1.Pos(0) = Form1.Player) And Form1.Pos(0) = Form1.Pos(3) And Form1.Pos(6) = 0) Then
            Form1.ordPlay = 7
            GoTo 2
        ElseIf ((Form1.Pos(3) = Form1.Player) And Form1.Pos(3) = Form1.Pos(6) And Form1.Pos(0) = 0) Then
            Form1.ordPlay = 1
            GoTo 2
        ElseIf ((Form1.Pos(3) = Form1.Player) And Form1.Pos(3) = Form1.Pos(0) And Form1.Pos(6) = 0) Then
            Form1.ordPlay = 7
            GoTo 2
        ElseIf ((Form1.Pos(6) = Form1.Player) And Form1.Pos(6) = Form1.Pos(0) And Form1.Pos(3) = 0) Then
            Form1.ordPlay = 4
            GoTo 2
        ElseIf ((Form1.Pos(6) = Form1.Player) And Form1.Pos(6) = Form1.Pos(3) And Form1.Pos(0) = 0) Then
            Form1.ordPlay = 1
            GoTo 2
            'middle
        ElseIf ((Form1.Pos(1) = Form1.Player) And Form1.Pos(1) = Form1.Pos(7) And Form1.Pos(4) = 0) Then
            Form1.ordPlay = 5
            GoTo 2
        ElseIf ((Form1.Pos(1) = Form1.Player) And Form1.Pos(1) = Form1.Pos(4) And Form1.Pos(7) = 0) Then
            Form1.ordPlay = 8
            GoTo 2
        ElseIf ((Form1.Pos(4) = Form1.Player) And Form1.Pos(4) = Form1.Pos(7) And Form1.Pos(1) = 0) Then
            Form1.ordPlay = 2
            GoTo 2
        ElseIf ((Form1.Pos(4) = Form1.Player) And Form1.Pos(4) = Form1.Pos(1) And Form1.Pos(7) = 0) Then
            Form1.ordPlay = 8
            GoTo 2
        ElseIf ((Form1.Pos(7) = Form1.Player) And Form1.Pos(7) = Form1.Pos(1) And Form1.Pos(4) = 0) Then
            Form1.ordPlay = 5
            GoTo 2
        ElseIf ((Form1.Pos(7) = Form1.Player) And Form1.Pos(7) = Form1.Pos(4) And Form1.Pos(1) = 0) Then
            Form1.ordPlay = 2
            GoTo 2
            'right	
        ElseIf ((Form1.Pos(2) = Form1.Player) And Form1.Pos(2) = Form1.Pos(8) And Form1.Pos(5) = 0) Then
            Form1.ordPlay = 6
            GoTo 2
        ElseIf ((Form1.Pos(2) = Form1.Player) And Form1.Pos(2) = Form1.Pos(5) And Form1.Pos(8) = 0) Then
            Form1.ordPlay = 9
            GoTo 2
        ElseIf ((Form1.Pos(5) = Form1.Player) And Form1.Pos(5) = Form1.Pos(8) And Form1.Pos(2) = 0) Then
            Form1.ordPlay = 3
            GoTo 2
        ElseIf ((Form1.Pos(5) = Form1.Player) And Form1.Pos(5) = Form1.Pos(2) And Form1.Pos(8) = 0) Then
            Form1.ordPlay = 9
            GoTo 2
        ElseIf ((Form1.Pos(8) = Form1.Player) And Form1.Pos(8) = Form1.Pos(5) And Form1.Pos(2) = 0) Then
            Form1.ordPlay = 3
            GoTo 2
        ElseIf ((Form1.Pos(8) = Form1.Player) And Form1.Pos(8) = Form1.Pos(2) And Form1.Pos(5) = 0) Then
            Form1.ordPlay = 6
            GoTo 2
            'diagonal
            'backslash
        ElseIf ((Form1.Pos(0) = Form1.Player) And Form1.Pos(0) = Form1.Pos(4) And Form1.Pos(8) = 0) Then
            Form1.ordPlay = 9
            GoTo 2
        ElseIf ((Form1.Pos(0) = Form1.Player) And Form1.Pos(0) = Form1.Pos(8) And Form1.Pos(4) = 0) Then
            Form1.ordPlay = 5
            GoTo 2
        ElseIf ((Form1.Pos(4) = Form1.Player) And Form1.Pos(4) = Form1.Pos(0) And Form1.Pos(8) = 0) Then
            Form1.ordPlay = 9
            GoTo 2
        ElseIf ((Form1.Pos(4) = Form1.Player) And Form1.Pos(4) = Form1.Pos(8) And Form1.Pos(0) = 0) Then
            Form1.ordPlay = 1
            GoTo 2
        ElseIf ((Form1.Pos(8) = Form1.Player) And Form1.Pos(8) = Form1.Pos(4) And Form1.Pos(0) = 0) Then
            Form1.ordPlay = 1
            GoTo 2
        ElseIf ((Form1.Pos(8) = Form1.Player) And Form1.Pos(8) = Form1.Pos(0) And Form1.Pos(4) = 0) Then
            Form1.ordPlay = 5
            GoTo 2
            'forwardslash
        ElseIf ((Form1.Pos(2) = Form1.Player) And Form1.Pos(2) = Form1.Pos(6) And Form1.Pos(4) = 0) Then
            Form1.ordPlay = 5
            GoTo 2
        ElseIf ((Form1.Pos(2) = Form1.Player) And Form1.Pos(2) = Form1.Pos(4) And Form1.Pos(6) = 0) Then
            Form1.ordPlay = 7
            GoTo 2
        ElseIf ((Form1.Pos(4) = Form1.Player) And Form1.Pos(4) = Form1.Pos(6) And Form1.Pos(2) = 0) Then
            Form1.ordPlay = 3
            GoTo 2
        ElseIf ((Form1.Pos(4) = Form1.Player) And Form1.Pos(4) = Form1.Pos(2) And Form1.Pos(6) = 0) Then
            Form1.ordPlay = 7
            GoTo 2
        ElseIf ((Form1.Pos(6) = Form1.Player) And Form1.Pos(6) = Form1.Pos(2) And Form1.Pos(4) = 0) Then
            Form1.ordPlay = 5
            GoTo 2
        ElseIf ((Form1.Pos(6) = Form1.Player) And Form1.Pos(6) = Form1.Pos(4) And Form1.Pos(2) = 0) Then
            Form1.ordPlay = 3
            GoTo 2

        Else
            If (Form1.ordToPlay <> 0) Then
                Form1.ordPlay = Form1.ordToPlay
                Form1.ordToPlay = 0
                GoTo 2
            ElseIf ((Form1.Pos(0) = Form1.Computer) And (Form1.Pos(0) = Form1.Pos(2)) And (Form1.Pos(8) = 0)) Then
                Form1.ordPlay = 9
                GoTo 2
            ElseIf ((Form1.Pos(0) = Form1.Computer) And (Form1.Pos(0) = Form1.Pos(2)) And (Form1.Pos(6) = 0)) Then
                Form1.ordPlay = 7
                GoTo 2
            ElseIf ((Form1.Pos(2) = Form1.Computer) And (Form1.Pos(2) = Form1.Pos(8)) And (Form1.Pos(6) = 0)) Then
                Form1.ordPlay = 7
                GoTo 2
            ElseIf ((Form1.Pos(2) = Form1.Computer) And (Form1.Pos(2) = Form1.Pos(8)) And (Form1.Pos(0) = 0)) Then
                Form1.ordPlay = 1
                GoTo 2
            ElseIf ((Form1.Pos(8) = Form1.Computer) And (Form1.Pos(8) = Form1.Pos(6)) And (Form1.Pos(0) = 0)) Then
                Form1.ordPlay = 1
                GoTo 2
            ElseIf ((Form1.Pos(8) = Form1.Computer) And (Form1.Pos(8) = Form1.Pos(6)) And (Form1.Pos(2) = 0)) Then
                Form1.ordPlay = 3
                GoTo 2
            ElseIf ((Form1.Pos(0) = Form1.Computer) And (Form1.Pos(0) = Form1.Pos(6)) And (Form1.Pos(2) = 0)) Then
                Form1.ordPlay = 3
                GoTo 2
            ElseIf ((Form1.Pos(0) = Form1.Computer) And (Form1.Pos(0) = Form1.Pos(6)) And (Form1.Pos(8) = 0)) Then
                Form1.ordPlay = 9
                GoTo 2
            ElseIf ((Form1.Pos(0) = Form1.Computer) And (Form1.Pos(0) = Form1.Pos(8)) And (Form1.Pos(2) = 0)) Then
                Form1.ordPlay = 3
                GoTo 2
            ElseIf ((Form1.Pos(0) = Form1.Computer) And (Form1.Pos(0) = Form1.Pos(8)) And (Form1.Pos(6) = 0)) Then
                Form1.ordPlay = 7
                GoTo 2
            ElseIf ((Form1.Pos(2) = Form1.Computer) And (Form1.Pos(2) = Form1.Pos(6)) And (Form1.Pos(0) = 0)) Then
                Form1.ordPlay = 1
                GoTo 2
            ElseIf ((Form1.Pos(2) = Form1.Computer) And (Form1.Pos(2) = Form1.Pos(6)) And (Form1.Pos(8) = 0)) Then
                Form1.ordPlay = 9
                GoTo 2
            ElseIf (Form1.Pos(0) = Form1.Player) And (Form1.Pos(1) = 0) And (Form1.Pos(1) = Form1.Pos(2) = Form1.Pos(3) = Form1.Pos(4) = Form1.Pos(5) = Form1.Pos(6) = Form1.Pos(7) = Form1.Pos(8)) Then
                Form1.ordPlay = 5
                GoTo 2
            ElseIf (Form1.Pos(2) = Form1.Player) And (Form1.Pos(1) = 0) And (Form1.Pos(1) = Form1.Pos(0) = Form1.Pos(3) = Form1.Pos(4) = Form1.Pos(5) = Form1.Pos(6) = Form1.Pos(7) = Form1.Pos(8)) Then
                Form1.ordPlay = 5
                GoTo 2
            ElseIf (Form1.Pos(6) = Form1.Player) And (Form1.Pos(1) = 0) And (Form1.Pos(1) = Form1.Pos(2) = Form1.Pos(3) = Form1.Pos(4) = Form1.Pos(5) = Form1.Pos(0) = Form1.Pos(7) = Form1.Pos(8)) Then
                Form1.ordPlay = 5
                GoTo 2
            ElseIf (Form1.Pos(8) = Form1.Player) And (Form1.Pos(1) = 0) And (Form1.Pos(1) = Form1.Pos(2) = Form1.Pos(3) = Form1.Pos(4) = Form1.Pos(5) = Form1.Pos(6) = Form1.Pos(7) = Form1.Pos(0)) Then
                Form1.ordPlay = 5
                GoTo 2
            ElseIf (Form1.Pos(1) = Form1.Player) And (Form1.Pos(2) = 0) Then
                Form1.ordPlay = 3
                If (Form1.Pos(4) = 0) Then
                    Form1.ordToPlay = 5
                Else
                    Form1.ordToPlay = 0
                End If
                GoTo 2
            ElseIf (Form1.Pos(5) = Form1.Player) And (Form1.Pos(8) = 0) Then
                Form1.ordPlay = 9
                If (Form1.Pos(4) = 0) Then
                    Form1.ordToPlay = 5
                Else
                    Form1.ordToPlay = 0
                End If
                GoTo 2
            ElseIf (Form1.Pos(7) = Form1.Player) And (Form1.Pos(6) = 0) Then
                Form1.ordPlay = 7
                If (Form1.Pos(4) = 0) Then
                    Form1.ordToPlay = 5
                Else
                    Form1.ordToPlay = 0
                End If
                GoTo 2
            ElseIf (Form1.Pos(3) = Form1.Player) And (Form1.Pos(0) = 0) Then
                Form1.ordPlay = 1
                If (Form1.Pos(4) = 0) Then
                    Form1.ordToPlay = 5
                Else
                    Form1.ordToPlay = 0
                End If
                GoTo 2
            ElseIf ((Form1.Pos(0) = Form1.Player) And (Form1.Pos(0) = Form1.Pos(8)) And (Form1.Pos(4) = Form1.Computer)) Then
                Form1.ordPlay = 8
                GoTo 2
            ElseIf ((Form1.Pos(2) = Form1.Player) And (Form1.Pos(2) = Form1.Pos(6)) And (Form1.Pos(4) = Form1.Computer)) Then
                Form1.ordPlay = 2
                GoTo 2
            ElseIf (Form1.Pos(1) = Form1.Player) And (Form1.Pos(1) = Form1.Pos(3)) And (Form1.Pos(0) = 0) Then
                Form1.ordPlay = 1
                GoTo 2
            ElseIf (Form1.Pos(1) = Form1.Player) And (Form1.Pos(1) = Form1.Pos(5)) And (Form1.Pos(2) = 0) Then
                Form1.ordPlay = 3
                GoTo 2
            ElseIf (Form1.Pos(3) = Form1.Player) And (Form1.Pos(3) = Form1.Pos(7)) And (Form1.Pos(6) = 0) Then
                Form1.ordPlay = 7
                GoTo 2
            ElseIf (Form1.Pos(5) = Form1.Player) And (Form1.Pos(5) = Form1.Pos(7)) And (Form1.Pos(8) = 0) Then
                Form1.ordPlay = 9
                GoTo 2
            ElseIf (Form1.Pos(1) = Form1.Player) And (Form1.Pos(1) = Form1.Pos(3)) And (Form1.Pos(4) = 0) Then
                Form1.ordPlay = 5
                GoTo 2
            ElseIf (Form1.Pos(1) = Form1.Player) And (Form1.Pos(1) = Form1.Pos(5)) And (Form1.Pos(4) = 0) Then
                Form1.ordPlay = 5
                GoTo 2
            ElseIf (Form1.Pos(3) = Form1.Player) And (Form1.Pos(3) = Form1.Pos(7)) And (Form1.Pos(4) = 0) Then
                Form1.ordPlay = 5
                GoTo 2
            ElseIf (Form1.Pos(5) = Form1.Player) And (Form1.Pos(5) = Form1.Pos(7)) And (Form1.Pos(4) = 0) Then
                Form1.ordPlay = 5
                GoTo 2
            Else
3:
                Dim gen As New Random
                Form1.Pick = gen.Next(1, 6)
                If (Form1.Pick = 1 And Form1.Pos(0) = 0) Then
                    Form1.ordPlay = 1
                    GoTo 2
                ElseIf (Form1.Pick = 2 And Form1.Pos(2) = 0) Then
                    Form1.ordPlay = 3
                    GoTo 2
                ElseIf (Form1.Pick = 3 And Form1.Pos(4) = 0) Then
                    Form1.ordPlay = 5
                    GoTo 2
                ElseIf (Form1.Pick = 4 And Form1.Pos(6) = 0) Then
                    Form1.ordPlay = 7
                    GoTo 2
                ElseIf (Form1.Pick = 5 And Form1.Pos(8) = 0) Then
                    Form1.ordPlay = 9
                    GoTo 2
                ElseIf Form1.Pick <> 1 And Form1.Pick <> 2 And Form1.Pick <> 3 And Form1.Pick <> 4 And Form1.Pick <> 5 Then
                    GoTo 3
                Else
                    rndPick()
                End If
            End If
        End If
2:
        'Debug.Print(Form1.ordPlay)
        '        Form1.Refresh()
        '        Threading.Thread.Sleep(675)
        '        If sfx = True Then
        '            My.Form1.Computer.Audio.Play(My.Resources.drop, AudioPlayMode.Background)
        '        End If
        '        If Form1.ordPlay = 1 Then
        '            If Form1.Pos(0) = 0 Then
        '                checkTurn()
        '                If Turn = 1 Then
        '                    PictureBox5.BackgroundImage = My.Resources.O
        '                    Form1.Pos(0) = 2
        '                    turnCount()

        '                ElseIf Turn = 0 Then
        '                    PictureBox5.BackgroundImage = My.Resources.X
        '                    Form1.Pos(0) = 1
        '                    turnCount()

        '                End If
        '                ordTurn = 1
        '            Else
        '                GoTo 1
        '            End If
        '        ElseIf Form1.ordPlay = 2 Then
        '            If Form1.Pos(1) = 0 Then
        '                checkTurn()
        '                If Turn = 1 Then
        '                    PictureBox6.BackgroundImage = My.Resources.O
        '                    Form1.Pos(1) = 2
        '                    turnCount()

        '                ElseIf Turn = 0 Then
        '                    PictureBox6.BackgroundImage = My.Resources.X
        '                    Form1.Pos(1) = 1
        '                    turnCount()

        '                End If
        '                ordTurn = 1
        '            Else
        '                GoTo 1
        '            End If
        '        ElseIf Form1.ordPlay = 3 Then
        '            If Form1.Pos(2) = 0 Then
        '                checkTurn()
        '                If Turn = 1 Then
        '                    PictureBox7.BackgroundImage = My.Resources.O
        '                    Form1.Pos(2) = 2
        '                    turnCount()

        '                ElseIf Turn = 0 Then
        '                    PictureBox7.BackgroundImage = My.Resources.X
        '                    Form1.Pos(2) = 1
        '                    turnCount()

        '                End If
        '                ordTurn = 1
        '            Else
        '                GoTo 1
        '            End If
        '        ElseIf Form1.ordPlay = 4 Then
        '            If Form1.Pos(3) = 0 Then
        '                checkTurn()
        '                If Turn = 1 Then
        '                    PictureBox8.BackgroundImage = My.Resources.O
        '                    Form1.Pos(3) = 2
        '                    turnCount()

        '                ElseIf Turn = 0 Then
        '                    PictureBox8.BackgroundImage = My.Resources.X
        '                    Form1.Pos(3) = 1
        '                    turnCount()

        '                End If
        '                ordTurn = 1
        '            Else
        '                GoTo 1
        '            End If
        '        ElseIf Form1.ordPlay = 5 Then
        '            If Form1.Pos(4) = 0 Then
        '                checkTurn()
        '                If Turn = 1 Then
        '                    PictureBox9.BackgroundImage = My.Resources.O
        '                    Form1.Pos(4) = 2
        '                    turnCount()

        '                ElseIf Turn = 0 Then
        '                    PictureBox9.BackgroundImage = My.Resources.X
        '                    Form1.Pos(4) = 1
        '                    turnCount()

        '                End If
        '                ordTurn = 1
        '            Else
        '                GoTo 1
        '            End If
        '        ElseIf Form1.ordPlay = 6 Then
        '            If Form1.Pos(5) = 0 Then
        '                checkTurn()
        '                If Turn = 1 Then
        '                    PictureBox10.BackgroundImage = My.Resources.O
        '                    Form1.Pos(5) = 2
        '                    turnCount()

        '                ElseIf Turn = 0 Then
        '                    PictureBox10.BackgroundImage = My.Resources.X
        '                    Form1.Pos(5) = 1
        '                    turnCount()

        '                End If
        '                ordTurn = 1
        '            Else
        '                GoTo 1
        '            End If
        '        ElseIf Form1.ordPlay = 7 Then
        '            If Form1.Pos(6) = 0 Then
        '                checkTurn()
        '                If Turn = 1 Then
        '                    PictureBox11.BackgroundImage = My.Resources.O
        '                    Form1.Pos(6) = 2
        '                    turnCount()

        '                ElseIf Turn = 0 Then
        '                    PictureBox11.BackgroundImage = My.Resources.X
        '                    Form1.Pos(6) = 1
        '                    turnCount()

        '                End If
        '                ordTurn = 1
        '            Else
        '                GoTo 1
        '            End If
        '        ElseIf Form1.ordPlay = 8 Then
        '            If Form1.Pos(7) = 0 Then
        '                checkTurn()
        '                If Turn = 1 Then
        '                    PictureBox12.BackgroundImage = My.Resources.O
        '                    Form1.Pos(7) = 2
        '                    turnCount()

        '                ElseIf Turn = 0 Then
        '                    PictureBox12.BackgroundImage = My.Resources.X
        '                    Form1.Pos(7) = 1
        '                    turnCount()

        '                End If
        '                ordTurn = 1
        '            Else
        '                GoTo 1
        '            End If
        '        ElseIf Form1.ordPlay = 9 Then
        '            If Form1.Pos(8) = 0 Then
        '                checkTurn()
        '                If Turn = 1 Then
        '                    PictureBox13.BackgroundImage = My.Resources.O
        '                    Form1.Pos(8) = 2
        '                    turnCount()

        '                ElseIf Turn = 0 Then
        '                    PictureBox13.BackgroundImage = My.Resources.X
        '                    Form1.Pos(8) = 1
        '                    turnCount()

        '                End If
        '                ordTurn = 1
        '            Else
        '                GoTo 1
        '            End If
        '        Else
        '            GoTo 1
        '        End If
        '        Form1.ErrorCount = 0
        '        Log = Log & "Form1.Computer - P" & Form1.ordPlay & "
        '"
        '        checkWin()
    End Sub 'Comment l'ordinateur choisir où jouer

    '    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
    '        If (RadioButton2.Checked) Then
    '            Form1.ORD = 1
    '        Else
    '            Form1.ORD = 0
    '        End If
    '        newGame()
    '    End Sub 'Selection de Jouer Contre
    '    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
    '        newGame()
    '    End Sub 'RadioButton vide
#End Region
End Module
