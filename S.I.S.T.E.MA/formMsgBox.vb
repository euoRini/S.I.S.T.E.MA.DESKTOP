Public Class formMsgBox
    Dim arraste As Boolean
    Dim mouseX As Integer
    Dim mouseY As Integer

    Public fechamento As Task(Of Boolean)
    Public resposta As Boolean
    Public Sub formMsgBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim first As Boolean = True
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Height = 225
        Me.Width = 350
        Dim p As New Drawing2D.GraphicsPath()
        p.StartFigure()
        p.AddArc(New Rectangle(0, 0, 30, 30), 180, 90)
        p.AddLine(30, 0, Me.Width - 30, 0)
        p.AddArc(New Rectangle(Me.Width - 30, 0, 30, 30), -90, 90)
        p.AddLine(Me.Width, 30, Me.Width, Me.Height - 30)
        p.AddArc(New Rectangle(Me.Width - 30, Me.Height - 30, 30, 30), 0, 90)
        p.AddLine(Me.Width - 30, Me.Height, 30, Me.Height)
        p.AddArc(New Rectangle(0, Me.Height - 30, 30, 30), 90, 90)
        p.CloseFigure()
        Me.Region = New Region(p)
        'pnFun
        Me.BackColor = Color.Red
    End Sub

    Public Sub formMsgBox_Loadeffect()
        For FadeIn = 0.0 To 1.0 Step 0.25
            Me.Opacity = FadeIn
            Me.Refresh()
            System.Threading.Thread.Sleep(2)
        Next
    End Sub

    Private Sub pnBarraSuperior_MouseDown(sender As Object, e As MouseEventArgs) Handles pnBarraSuperior.MouseDown
        arraste = True
        mouseX = Cursor.Position.X - Me.Left
        mouseY = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub pnBarraSuperior_MouseMove(sender As Object, e As MouseEventArgs) Handles pnBarraSuperior.MouseMove
        If arraste Then
            Me.Top = Cursor.Position.Y - mouseY
            Me.Left = Cursor.Position.X - mouseX
        End If
    End Sub
    Private Sub pnBarraSuperior_MouseUp(sender As Object, e As MouseEventArgs) Handles pnBarraSuperior.MouseUp
        arraste = False
    End Sub


    Private Sub FechaMSG()
        home.backHome()
        Me.Close()
    End Sub

    Public Async Sub chamadaMSG(msg As String, typeMSG As Integer)
        pnButtonOk.Visible = False
        pnYesNo.Visible = False
        If typeMSG = 1 Then
            pbIcone.Image = My.Resources.imgMSGBOXErroIconPreto3
            pnBarraSuperior.BackColor = Color.Red
            pnButtonOk.Visible = True
            lbMsg.Location = New Point(7, 55)
        ElseIf typeMSG = 2 Then
            pbIcone.Image = My.Resources.imgDoneMSGBOXIconBranco
            pnButtonOk.Visible = True
            pnBarraSuperior.BackColor = Color.Green
        ElseIf typeMSG = 3 Then
            pbIcone.Image = My.Resources.imgInfoMSGBOXIconBranco
            pnYesNo.Visible = True
            pnBarraSuperior.BackColor = Color.LightBlue
            lbMsg.Font = New Font(lbMsg.Font.FontFamily, 12)
            lbMsg.Location = New Point(7, 28)
        End If
        lbMsg.Text = msg
        Me.Show()
        home.Enabled = False
    End Sub

    Private Sub btSim_Click(sender As Object, e As EventArgs) Handles btSim.Click
        resposta = True
        fechamento = Task.CompletedTask
        'FechaMSG()
    End Sub

    Private Sub btNao_Click(sender As Object, e As EventArgs) Handles btNao.Click
        resposta = False
        fechamento = Task.CompletedTask
        ' FechaMSG()
    End Sub

    Private Sub btMSGBOXOk_Click(sender As Object, e As EventArgs) Handles btMSGBOXOk.Click
        'fechamento = Task.CompletedTask
        FechaMSG()
    End Sub
End Class