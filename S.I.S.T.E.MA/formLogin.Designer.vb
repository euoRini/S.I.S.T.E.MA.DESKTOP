<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formLogin
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnBarraSuperior = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnMinimizar = New System.Windows.Forms.Panel()
        Me.pbMinimizar = New System.Windows.Forms.PictureBox()
        Me.pnFechar = New System.Windows.Forms.Panel()
        Me.pbFechar = New System.Windows.Forms.PictureBox()
        Me.pnLogin = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.pbHideShowSenha = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BTEntrar = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.tbSenha = New System.Windows.Forms.TextBox()
        Me.tbLogin = New System.Windows.Forms.TextBox()
        Me.pbLogoLoginScreen = New System.Windows.Forms.PictureBox()
        Me.pnBarraSuperior.SuspendLayout()
        Me.pnMinimizar.SuspendLayout()
        CType(Me.pbMinimizar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnFechar.SuspendLayout()
        CType(Me.pbFechar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLogin.SuspendLayout()
        CType(Me.pbHideShowSenha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLogoLoginScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnBarraSuperior
        '
        Me.pnBarraSuperior.Controls.Add(Me.Panel2)
        Me.pnBarraSuperior.Controls.Add(Me.pnMinimizar)
        Me.pnBarraSuperior.Controls.Add(Me.pnFechar)
        Me.pnBarraSuperior.Location = New System.Drawing.Point(0, 0)
        Me.pnBarraSuperior.Name = "pnBarraSuperior"
        Me.pnBarraSuperior.Size = New System.Drawing.Size(884, 21)
        Me.pnBarraSuperior.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(0, 20)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(884, 1)
        Me.Panel2.TabIndex = 3
        '
        'pnMinimizar
        '
        Me.pnMinimizar.Controls.Add(Me.pbMinimizar)
        Me.pnMinimizar.Location = New System.Drawing.Point(831, 0)
        Me.pnMinimizar.Name = "pnMinimizar"
        Me.pnMinimizar.Size = New System.Drawing.Size(19, 19)
        Me.pnMinimizar.TabIndex = 2
        '
        'pbMinimizar
        '
        Me.pbMinimizar.Image = Global.S.I.S.T.E.MA.My.Resources.Resources.imgMinimizarIconBranco
        Me.pbMinimizar.Location = New System.Drawing.Point(4, 4)
        Me.pbMinimizar.Name = "pbMinimizar"
        Me.pbMinimizar.Size = New System.Drawing.Size(11, 11)
        Me.pbMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbMinimizar.TabIndex = 1
        Me.pbMinimizar.TabStop = False
        '
        'pnFechar
        '
        Me.pnFechar.Controls.Add(Me.pbFechar)
        Me.pnFechar.Location = New System.Drawing.Point(850, 0)
        Me.pnFechar.Name = "pnFechar"
        Me.pnFechar.Size = New System.Drawing.Size(19, 19)
        Me.pnFechar.TabIndex = 1
        '
        'pbFechar
        '
        Me.pbFechar.Image = Global.S.I.S.T.E.MA.My.Resources.Resources.imgFecharIconBranco
        Me.pbFechar.Location = New System.Drawing.Point(4, 4)
        Me.pbFechar.Name = "pbFechar"
        Me.pbFechar.Size = New System.Drawing.Size(11, 11)
        Me.pbFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbFechar.TabIndex = 2
        Me.pbFechar.TabStop = False
        '
        'pnLogin
        '
        Me.pnLogin.Controls.Add(Me.Panel1)
        Me.pnLogin.Controls.Add(Me.Panel6)
        Me.pnLogin.Controls.Add(Me.pbHideShowSenha)
        Me.pnLogin.Controls.Add(Me.PictureBox3)
        Me.pnLogin.Controls.Add(Me.PictureBox2)
        Me.pnLogin.Controls.Add(Me.BTEntrar)
        Me.pnLogin.Controls.Add(Me.Panel5)
        Me.pnLogin.Controls.Add(Me.tbSenha)
        Me.pnLogin.Controls.Add(Me.tbLogin)
        Me.pnLogin.Location = New System.Drawing.Point(650, 21)
        Me.pnLogin.Name = "pnLogin"
        Me.pnLogin.Size = New System.Drawing.Size(234, 439)
        Me.pnLogin.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 439)
        Me.Panel1.TabIndex = 28
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.Location = New System.Drawing.Point(39, 180)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(166, 1)
        Me.Panel6.TabIndex = 23
        '
        'pbHideShowSenha
        '
        Me.pbHideShowSenha.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbHideShowSenha.Image = Global.S.I.S.T.E.MA.My.Resources.Resources.imgVisiblyIconBranco
        Me.pbHideShowSenha.Location = New System.Drawing.Point(179, 210)
        Me.pbHideShowSenha.Name = "pbHideShowSenha"
        Me.pbHideShowSenha.Size = New System.Drawing.Size(26, 29)
        Me.pbHideShowSenha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbHideShowSenha.TabIndex = 27
        Me.pbHideShowSenha.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.S.I.S.T.E.MA.My.Resources.Resources.imgSenhaIconBranco
        Me.PictureBox3.Location = New System.Drawing.Point(39, 209)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(27, 28)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 26
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.S.I.S.T.E.MA.My.Resources.Resources.imgUserIconBranco
        Me.PictureBox2.Location = New System.Drawing.Point(39, 149)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(27, 28)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 25
        Me.PictureBox2.TabStop = False
        '
        'BTEntrar
        '
        Me.BTEntrar.BackColor = System.Drawing.Color.White
        Me.BTEntrar.FlatAppearance.BorderSize = 0
        Me.BTEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTEntrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTEntrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.BTEntrar.Location = New System.Drawing.Point(81, 259)
        Me.BTEntrar.Name = "BTEntrar"
        Me.BTEntrar.Size = New System.Drawing.Size(92, 31)
        Me.BTEntrar.TabIndex = 24
        Me.BTEntrar.Text = "Entrar"
        Me.BTEntrar.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Location = New System.Drawing.Point(39, 239)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(166, 1)
        Me.Panel5.TabIndex = 22
        '
        'tbSenha
        '
        Me.tbSenha.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.tbSenha.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbSenha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSenha.ForeColor = System.Drawing.Color.White
        Me.tbSenha.Location = New System.Drawing.Point(69, 212)
        Me.tbSenha.Name = "tbSenha"
        Me.tbSenha.Size = New System.Drawing.Size(136, 20)
        Me.tbSenha.TabIndex = 21
        Me.tbSenha.Text = "Senha"
        '
        'tbLogin
        '
        Me.tbLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.tbLogin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLogin.ForeColor = System.Drawing.Color.White
        Me.tbLogin.Location = New System.Drawing.Point(69, 153)
        Me.tbLogin.Name = "tbLogin"
        Me.tbLogin.Size = New System.Drawing.Size(136, 20)
        Me.tbLogin.TabIndex = 20
        Me.tbLogin.Text = "Login"
        '
        'pbLogoLoginScreen
        '
        Me.pbLogoLoginScreen.Image = Global.S.I.S.T.E.MA.My.Resources.Resources.imgLogoCirculo
        Me.pbLogoLoginScreen.Location = New System.Drawing.Point(0, 20)
        Me.pbLogoLoginScreen.Name = "pbLogoLoginScreen"
        Me.pbLogoLoginScreen.Size = New System.Drawing.Size(653, 436)
        Me.pbLogoLoginScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLogoLoginScreen.TabIndex = 2
        Me.pbLogoLoginScreen.TabStop = False
        '
        'formLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(884, 459)
        Me.Controls.Add(Me.pnBarraSuperior)
        Me.Controls.Add(Me.pnLogin)
        Me.Controls.Add(Me.pbLogoLoginScreen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "formLogin"
        Me.Text = "Form1"
        Me.pnBarraSuperior.ResumeLayout(False)
        Me.pnMinimizar.ResumeLayout(False)
        CType(Me.pbMinimizar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnFechar.ResumeLayout(False)
        CType(Me.pbFechar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLogin.ResumeLayout(False)
        Me.pnLogin.PerformLayout()
        CType(Me.pbHideShowSenha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLogoLoginScreen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnBarraSuperior As Panel
    Friend WithEvents pnMinimizar As Panel
    Friend WithEvents pnFechar As Panel
    Friend WithEvents pbMinimizar As PictureBox
    Friend WithEvents pbFechar As PictureBox
    Friend WithEvents pnLogin As Panel
    Friend WithEvents pbLogoLoginScreen As PictureBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents pbHideShowSenha As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents BTEntrar As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents tbSenha As TextBox
    Friend WithEvents tbLogin As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
End Class
