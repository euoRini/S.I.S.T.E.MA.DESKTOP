Public Class formMsgBox
    Private Sub formMsgBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Height = 264
        Me.Width = 382
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
        Me.BackColor = Color.FromArgb(32, 32, 32)
    End Sub
End Class