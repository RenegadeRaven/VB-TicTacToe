<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bt_NewGame = New System.Windows.Forms.Button()
        Me.lb_BoardX = New System.Windows.Forms.Label()
        Me.lb_BoardO = New System.Windows.Forms.Label()
        Me.lb_ScoreX = New System.Windows.Forms.Label()
        Me.lb_ScoreO = New System.Windows.Forms.Label()
        Me.lb_ScoreDraw = New System.Windows.Forms.Label()
        Me.lb_BoardDraw = New System.Windows.Forms.Label()
        Me.Language = New System.Windows.Forms.Label()
        Me.bt_Restart = New System.Windows.Forms.Button()
        Me.bt_Close = New System.Windows.Forms.Button()
        Me.pb_BottomRight = New System.Windows.Forms.PictureBox()
        Me.pb_BottomMiddle = New System.Windows.Forms.PictureBox()
        Me.pb_BottomLeft = New System.Windows.Forms.PictureBox()
        Me.pb_CenterRight = New System.Windows.Forms.PictureBox()
        Me.pb_CenterMiddle = New System.Windows.Forms.PictureBox()
        Me.pb_CenterLeft = New System.Windows.Forms.PictureBox()
        Me.pb_TopRight = New System.Windows.Forms.PictureBox()
        Me.pb_TopMiddle = New System.Windows.Forms.PictureBox()
        Me.pb_TopLeft = New System.Windows.Forms.PictureBox()
        Me.pb_bhBar = New System.Windows.Forms.PictureBox()
        Me.pb_thBar = New System.Windows.Forms.PictureBox()
        Me.pb_rvBar = New System.Windows.Forms.PictureBox()
        Me.pb_lvBar = New System.Windows.Forms.PictureBox()
        Me.lklb_Author = New System.Windows.Forms.LinkLabel()
        Me.lb_By = New System.Windows.Forms.Label()
        Me.lklb_Update = New System.Windows.Forms.LinkLabel()
        Me.pb_Donate = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.tsmi_Options = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_Language = New System.Windows.Forms.ToolStripMenuItem()
        Me.tscb_Languages = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmi_InvertColours = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_Mute = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_Score = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_Points = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_Percentage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.pb_BottomRight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_BottomMiddle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_BottomLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_CenterRight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_CenterMiddle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_CenterLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_TopRight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_TopMiddle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_TopLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_bhBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_thBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_rvBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_lvBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_Donate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Name = "Label1"
        '
        'bt_NewGame
        '
        Me.bt_NewGame.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.bt_NewGame, "bt_NewGame")
        Me.bt_NewGame.Name = "bt_NewGame"
        Me.bt_NewGame.UseVisualStyleBackColor = False
        '
        'lb_BoardX
        '
        resources.ApplyResources(Me.lb_BoardX, "lb_BoardX")
        Me.lb_BoardX.Cursor = System.Windows.Forms.Cursors.Default
        Me.lb_BoardX.Name = "lb_BoardX"
        '
        'lb_BoardO
        '
        resources.ApplyResources(Me.lb_BoardO, "lb_BoardO")
        Me.lb_BoardO.Cursor = System.Windows.Forms.Cursors.Default
        Me.lb_BoardO.Name = "lb_BoardO"
        '
        'lb_ScoreX
        '
        resources.ApplyResources(Me.lb_ScoreX, "lb_ScoreX")
        Me.lb_ScoreX.BackColor = System.Drawing.Color.Transparent
        Me.lb_ScoreX.Cursor = System.Windows.Forms.Cursors.Default
        Me.lb_ScoreX.Name = "lb_ScoreX"
        '
        'lb_ScoreO
        '
        resources.ApplyResources(Me.lb_ScoreO, "lb_ScoreO")
        Me.lb_ScoreO.BackColor = System.Drawing.Color.Transparent
        Me.lb_ScoreO.Cursor = System.Windows.Forms.Cursors.Default
        Me.lb_ScoreO.Name = "lb_ScoreO"
        '
        'lb_ScoreDraw
        '
        resources.ApplyResources(Me.lb_ScoreDraw, "lb_ScoreDraw")
        Me.lb_ScoreDraw.BackColor = System.Drawing.Color.Transparent
        Me.lb_ScoreDraw.Cursor = System.Windows.Forms.Cursors.Default
        Me.lb_ScoreDraw.Name = "lb_ScoreDraw"
        '
        'lb_BoardDraw
        '
        resources.ApplyResources(Me.lb_BoardDraw, "lb_BoardDraw")
        Me.lb_BoardDraw.Cursor = System.Windows.Forms.Cursors.Default
        Me.lb_BoardDraw.Name = "lb_BoardDraw"
        '
        'Language
        '
        resources.ApplyResources(Me.Language, "Language")
        Me.Language.Name = "Language"
        '
        'bt_Restart
        '
        Me.bt_Restart.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.bt_Restart, "bt_Restart")
        Me.bt_Restart.Name = "bt_Restart"
        Me.bt_Restart.UseVisualStyleBackColor = True
        '
        'bt_Close
        '
        Me.bt_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.bt_Close, "bt_Close")
        Me.bt_Close.Name = "bt_Close"
        Me.bt_Close.UseVisualStyleBackColor = True
        '
        'pb_BottomRight
        '
        Me.pb_BottomRight.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.pb_BottomRight, "pb_BottomRight")
        Me.pb_BottomRight.Name = "pb_BottomRight"
        Me.pb_BottomRight.TabStop = False
        '
        'pb_BottomMiddle
        '
        Me.pb_BottomMiddle.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.pb_BottomMiddle, "pb_BottomMiddle")
        Me.pb_BottomMiddle.Name = "pb_BottomMiddle"
        Me.pb_BottomMiddle.TabStop = False
        '
        'pb_BottomLeft
        '
        Me.pb_BottomLeft.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.pb_BottomLeft, "pb_BottomLeft")
        Me.pb_BottomLeft.Name = "pb_BottomLeft"
        Me.pb_BottomLeft.TabStop = False
        '
        'pb_CenterRight
        '
        Me.pb_CenterRight.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.pb_CenterRight, "pb_CenterRight")
        Me.pb_CenterRight.Name = "pb_CenterRight"
        Me.pb_CenterRight.TabStop = False
        '
        'pb_CenterMiddle
        '
        Me.pb_CenterMiddle.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.pb_CenterMiddle, "pb_CenterMiddle")
        Me.pb_CenterMiddle.Name = "pb_CenterMiddle"
        Me.pb_CenterMiddle.TabStop = False
        '
        'pb_CenterLeft
        '
        Me.pb_CenterLeft.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.pb_CenterLeft, "pb_CenterLeft")
        Me.pb_CenterLeft.Name = "pb_CenterLeft"
        Me.pb_CenterLeft.TabStop = False
        '
        'pb_TopRight
        '
        Me.pb_TopRight.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.pb_TopRight, "pb_TopRight")
        Me.pb_TopRight.Name = "pb_TopRight"
        Me.pb_TopRight.TabStop = False
        '
        'pb_TopMiddle
        '
        Me.pb_TopMiddle.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.pb_TopMiddle, "pb_TopMiddle")
        Me.pb_TopMiddle.Name = "pb_TopMiddle"
        Me.pb_TopMiddle.TabStop = False
        '
        'pb_TopLeft
        '
        Me.pb_TopLeft.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.pb_TopLeft, "pb_TopLeft")
        Me.pb_TopLeft.Name = "pb_TopLeft"
        Me.pb_TopLeft.TabStop = False
        '
        'pb_bhBar
        '
        Me.pb_bhBar.BackColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.pb_bhBar, "pb_bhBar")
        Me.pb_bhBar.Name = "pb_bhBar"
        Me.pb_bhBar.TabStop = False
        '
        'pb_thBar
        '
        Me.pb_thBar.BackColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.pb_thBar, "pb_thBar")
        Me.pb_thBar.Name = "pb_thBar"
        Me.pb_thBar.TabStop = False
        '
        'pb_rvBar
        '
        Me.pb_rvBar.BackColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.pb_rvBar, "pb_rvBar")
        Me.pb_rvBar.Name = "pb_rvBar"
        Me.pb_rvBar.TabStop = False
        '
        'pb_lvBar
        '
        Me.pb_lvBar.BackColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.pb_lvBar, "pb_lvBar")
        Me.pb_lvBar.Name = "pb_lvBar"
        Me.pb_lvBar.TabStop = False
        '
        'lklb_Author
        '
        resources.ApplyResources(Me.lklb_Author, "lklb_Author")
        Me.lklb_Author.Name = "lklb_Author"
        Me.lklb_Author.TabStop = True
        '
        'lb_By
        '
        resources.ApplyResources(Me.lb_By, "lb_By")
        Me.lb_By.Name = "lb_By"
        '
        'lklb_Update
        '
        resources.ApplyResources(Me.lklb_Update, "lklb_Update")
        Me.lklb_Update.Name = "lklb_Update"
        Me.lklb_Update.TabStop = True
        '
        'pb_Donate
        '
        Me.pb_Donate.BackColor = System.Drawing.SystemColors.Control
        Me.pb_Donate.BackgroundImage = Global.TicTacToe.My.Resources.Resources.ppdb
        resources.ApplyResources(Me.pb_Donate, "pb_Donate")
        Me.pb_Donate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Donate.Name = "pb_Donate"
        Me.pb_Donate.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_Options})
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Stretch = False
        '
        'tsmi_Options
        '
        Me.tsmi_Options.BackColor = System.Drawing.Color.Transparent
        Me.tsmi_Options.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_Language, Me.ToolStripSeparator1, Me.tsmi_InvertColours, Me.tsmi_Mute, Me.tsmi_Score, Me.ToolStripSeparator2, Me.ToolStripMenuItem2})
        Me.tsmi_Options.Name = "tsmi_Options"
        resources.ApplyResources(Me.tsmi_Options, "tsmi_Options")
        '
        'tsmi_Language
        '
        Me.tsmi_Language.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tscb_Languages})
        Me.tsmi_Language.Name = "tsmi_Language"
        resources.ApplyResources(Me.tsmi_Language, "tsmi_Language")
        '
        'tscb_Languages
        '
        Me.tscb_Languages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tscb_Languages.Items.AddRange(New Object() {resources.GetString("tscb_Languages.Items"), resources.GetString("tscb_Languages.Items1")})
        Me.tscb_Languages.Name = "tscb_Languages"
        resources.ApplyResources(Me.tscb_Languages, "tscb_Languages")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'tsmi_InvertColours
        '
        Me.tsmi_InvertColours.CheckOnClick = True
        Me.tsmi_InvertColours.Name = "tsmi_InvertColours"
        resources.ApplyResources(Me.tsmi_InvertColours, "tsmi_InvertColours")
        '
        'tsmi_Mute
        '
        Me.tsmi_Mute.CheckOnClick = True
        Me.tsmi_Mute.Name = "tsmi_Mute"
        resources.ApplyResources(Me.tsmi_Mute, "tsmi_Mute")
        '
        'tsmi_Score
        '
        Me.tsmi_Score.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_Points, Me.tsmi_Percentage})
        Me.tsmi_Score.Name = "tsmi_Score"
        resources.ApplyResources(Me.tsmi_Score, "tsmi_Score")
        '
        'tsmi_Points
        '
        Me.tsmi_Points.CheckOnClick = True
        Me.tsmi_Points.Name = "tsmi_Points"
        resources.ApplyResources(Me.tsmi_Points, "tsmi_Points")
        '
        'tsmi_Percentage
        '
        Me.tsmi_Percentage.CheckOnClick = True
        Me.tsmi_Percentage.Name = "tsmi_Percentage"
        resources.ApplyResources(Me.tsmi_Percentage, "tsmi_Percentage")
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'ToolStripMenuItem2
        '
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        Me.ToolStripMenuItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        '
        'Main
        '
        Me.AcceptButton = Me.bt_NewGame
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.bt_Restart
        Me.Controls.Add(Me.pb_Donate)
        Me.Controls.Add(Me.lklb_Update)
        Me.Controls.Add(Me.lklb_Author)
        Me.Controls.Add(Me.bt_Close)
        Me.Controls.Add(Me.bt_Restart)
        Me.Controls.Add(Me.Language)
        Me.Controls.Add(Me.lb_ScoreDraw)
        Me.Controls.Add(Me.lb_BoardDraw)
        Me.Controls.Add(Me.lb_ScoreO)
        Me.Controls.Add(Me.lb_ScoreX)
        Me.Controls.Add(Me.lb_BoardO)
        Me.Controls.Add(Me.lb_BoardX)
        Me.Controls.Add(Me.bt_NewGame)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pb_BottomRight)
        Me.Controls.Add(Me.pb_BottomMiddle)
        Me.Controls.Add(Me.pb_BottomLeft)
        Me.Controls.Add(Me.pb_CenterRight)
        Me.Controls.Add(Me.pb_CenterMiddle)
        Me.Controls.Add(Me.pb_CenterLeft)
        Me.Controls.Add(Me.pb_TopRight)
        Me.Controls.Add(Me.pb_TopMiddle)
        Me.Controls.Add(Me.pb_TopLeft)
        Me.Controls.Add(Me.pb_bhBar)
        Me.Controls.Add(Me.pb_thBar)
        Me.Controls.Add(Me.pb_rvBar)
        Me.Controls.Add(Me.pb_lvBar)
        Me.Controls.Add(Me.lb_By)
        Me.Controls.Add(Me.MenuStrip1)
        Me.HelpButton = True
        Me.Name = "Main"
        CType(Me.pb_BottomRight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_BottomMiddle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_BottomLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_CenterRight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_CenterMiddle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_CenterLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_TopRight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_TopMiddle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_TopLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_bhBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_thBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_rvBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_lvBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_Donate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pb_lvBar As PictureBox
    Friend WithEvents pb_rvBar As PictureBox
    Friend WithEvents pb_thBar As PictureBox
    Friend WithEvents pb_bhBar As PictureBox
    Friend WithEvents pb_TopLeft As PictureBox
    Friend WithEvents pb_TopMiddle As PictureBox
    Friend WithEvents pb_TopRight As PictureBox
    Friend WithEvents pb_CenterLeft As PictureBox
    Friend WithEvents pb_CenterMiddle As PictureBox
    Friend WithEvents pb_CenterRight As PictureBox
    Friend WithEvents pb_BottomLeft As PictureBox
    Friend WithEvents pb_BottomMiddle As PictureBox
    Friend WithEvents pb_BottomRight As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents bt_NewGame As Button
    Friend WithEvents lb_BoardX As Label
    Friend WithEvents lb_BoardO As Label
    Friend WithEvents lb_ScoreX As Label
    Friend WithEvents lb_ScoreO As Label
    Friend WithEvents lb_ScoreDraw As Label
    Friend WithEvents lb_BoardDraw As Label
    Friend WithEvents Language As Label
    Friend WithEvents bt_Restart As Button
    Friend WithEvents bt_Close As Button
    Friend WithEvents lklb_Author As LinkLabel
    Friend WithEvents lb_By As Label
    Friend WithEvents lklb_Update As LinkLabel
    Friend WithEvents pb_Donate As PictureBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents tsmi_Options As ToolStripMenuItem
    Friend WithEvents tsmi_InvertColours As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents tsmi_Mute As ToolStripMenuItem
    Friend WithEvents tsmi_Score As ToolStripMenuItem
    Friend WithEvents tsmi_Points As ToolStripMenuItem
    Friend WithEvents tsmi_Percentage As ToolStripMenuItem
    Friend WithEvents tsmi_Language As ToolStripMenuItem
    Friend WithEvents tscb_Languages As ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
End Class
