<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formMsgBox
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnMsg = New System.Windows.Forms.Panel()
        Me.lbMsg = New System.Windows.Forms.Label()
        Me.pnButtonOk = New System.Windows.Forms.Panel()
        Me.btMSGBOXOk = New System.Windows.Forms.Button()
        Me.pnFundo = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnBarraSuperior.SuspendLayout()
        Me.pnMsg.SuspendLayout()
        Me.pnButtonOk.SuspendLayout()
        Me.pnFundo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnBarraSuperior
        '
        Me.pnBarraSuperior.BackColor = System.Drawing.Color.Red
        Me.pnBarraSuperior.Controls.Add(Me.Panel1)
        Me.pnBarraSuperior.Location = New System.Drawing.Point(-1, -4)
        Me.pnBarraSuperior.Name = "pnBarraSuperior"
        Me.pnBarraSuperior.Size = New System.Drawing.Size(358, 22)
        Me.pnBarraSuperior.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Red
        Me.Panel1.Location = New System.Drawing.Point(-2, 21)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(358, 1)
        Me.Panel1.TabIndex = 2
        Me.Panel1.Visible = False
        '
        'pnMsg
        '
        Me.pnMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.pnMsg.Controls.Add(Me.lbMsg)
        Me.pnMsg.Location = New System.Drawing.Point(112, 38)
        Me.pnMsg.Name = "pnMsg"
        Me.pnMsg.Size = New System.Drawing.Size(227, 133)
        Me.pnMsg.TabIndex = 2
        '
        'lbMsg
        '
        Me.lbMsg.AutoSize = True
        Me.lbMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMsg.ForeColor = System.Drawing.Color.White
        Me.lbMsg.Location = New System.Drawing.Point(7, 48)
        Me.lbMsg.Name = "lbMsg"
        Me.lbMsg.Size = New System.Drawing.Size(122, 20)
        Me.lbMsg.TabIndex = 0
        Me.lbMsg.Text = "mesangem aqui"
        '
        'pnButtonOk
        '
        Me.pnButtonOk.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.pnButtonOk.Controls.Add(Me.btMSGBOXOk)
        Me.pnButtonOk.Location = New System.Drawing.Point(222, 177)
        Me.pnButtonOk.Name = "pnButtonOk"
        Me.pnButtonOk.Size = New System.Drawing.Size(116, 40)
        Me.pnButtonOk.TabIndex = 3
        '
        'btMSGBOXOk
        '
        Me.btMSGBOXOk.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btMSGBOXOk.FlatAppearance.BorderSize = 0
        Me.btMSGBOXOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btMSGBOXOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btMSGBOXOk.ForeColor = System.Drawing.Color.Black
        Me.btMSGBOXOk.Location = New System.Drawing.Point(6, 5)
        Me.btMSGBOXOk.Name = "btMSGBOXOk"
        Me.btMSGBOXOk.Size = New System.Drawing.Size(103, 30)
        Me.btMSGBOXOk.TabIndex = 52
        Me.btMSGBOXOk.Text = "Ok"
        Me.btMSGBOXOk.UseVisualStyleBackColor = False
        '
        'pnFundo
        '
        Me.pnFundo.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.pnFundo.Controls.Add(Me.PictureBox1)
        Me.pnFundo.Controls.Add(Me.pnBarraSuperior)
        Me.pnFundo.Location = New System.Drawing.Point(-2, 2)
        Me.pnFundo.Name = "pnFundo"
        Me.pnFundo.Size = New System.Drawing.Size(356, 228)
        Me.pnFundo.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.PictureBox1.Image = Global.S.I.S.T.E.MA.My.Resources.Resources.imgMSGBOXErroIconPreto3
        Me.PictureBox1.Location = New System.Drawing.Point(23, 69)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(70, 70)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'formMsgBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Red
        Me.ClientSize = New System.Drawing.Size(350, 224)
        Me.Controls.Add(Me.pnButtonOk)
        Me.Controls.Add(Me.pnMsg)
        Me.Controls.Add(Me.pnFundo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "formMsgBox"
        Me.Text = "formMsgBox"
        Me.pnBarraSuperior.ResumeLayout(False)
        Me.pnMsg.ResumeLayout(False)
        Me.pnMsg.PerformLayout()
        Me.pnButtonOk.ResumeLayout(False)
        Me.pnFundo.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnBarraSuperior As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pnMsg As Panel
    Friend WithEvents pnButtonOk As Panel
    Friend WithEvents btMSGBOXOk As Button
    Friend WithEvents pnFundo As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbMsg As Label
End Class
