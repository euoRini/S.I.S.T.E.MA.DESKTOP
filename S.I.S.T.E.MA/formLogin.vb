Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.Net
Imports System.Linq
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net.Http

Public Class formLogin

#Region "Declaração Variaveis"
    Dim arraste As Boolean
    Dim mouseX As Integer
    Dim mouseY As Integer
    Dim visible As Boolean = False
    Dim brightMode As Boolean
    Public sucessoLogin As Boolean
#End Region

#Region "Load/Fechar/Minimizar/Movimentação"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim horaatual As Int32 = DateTime.Now.Hour
        'horaatual = 15
        If (horaatual >= 6 And horaatual <= 17) Then
            brightMode = True
        Else
            brightMode = False
        End If
        alteraDesign()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Height = 459
        Me.Width = 884
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
    End Sub

    Public Sub alteraDesign()
        If brightMode Then
            Me.BackColor = Color.White
            pbFechar.Image = My.Resources.imgFecharCinza
            pbMinimizar.Image = My.Resources.imgMinimizarIconCinza
            pnLogin.BackColor = Color.White
            pnBarraSuperior.BackColor = Color.White
            Panel1.BackColor = Color.FromArgb(120, 120, 120)
            Panel2.BackColor = Color.FromArgb(120, 120, 120)
            Panel5.BackColor = Color.FromArgb(32, 32, 32)
            Panel6.BackColor = Color.FromArgb(32, 32, 32)
            pbLogoLoginScreen.Image = My.Resources.imgLogoCirculoPreto
            PictureBox2.Image = My.Resources.imgUserIconPreto
            PictureBox3.Image = My.Resources.imgSenhaIconPreto
            tbLogin.BackColor = Color.White
            tbLogin.ForeColor = Color.FromArgb(32, 32, 32)
            tbSenha.BackColor = Color.White
            tbSenha.ForeColor = Color.FromArgb(32, 32, 32)
            pbHideShowSenha.Image = My.Resources.imgVisiblyIconPreto
            BTEntrar.BackColor = Color.FromArgb(32, 32, 32)
            BTEntrar.ForeColor = Color.White
        Else
            Me.BackColor = Color.FromArgb(32, 32, 32)
            pbMinimizar.Image = My.Resources.imgMinimizarIconBranco
            pbFechar.Image = My.Resources.imgFecharIconBranco
            pbLogoLoginScreen.Image = My.Resources.imgLogoCirculo
            pnLogin.BackColor = Color.FromArgb(32, 32, 32)
            pnBarraSuperior.BackColor = Color.FromArgb(32, 32, 32)

            Panel1.BackColor = Color.FromArgb(56, 56, 56)
            Panel2.BackColor = Color.FromArgb(56, 56, 56)
            Panel5.BackColor = Color.White
            Panel6.BackColor = Color.White

            pbLogoLoginScreen.Image = My.Resources.imgLogoCirculo
            PictureBox2.Image = My.Resources.imgUserIconBranco
            PictureBox3.Image = My.Resources.imgSenhaIconBranco
            tbLogin.BackColor = Color.FromArgb(32, 32, 32)
            tbLogin.ForeColor = Color.White
            tbSenha.BackColor = Color.FromArgb(32, 32, 32)
            tbSenha.ForeColor = Color.White

            BTEntrar.BackColor = Color.White
            BTEntrar.ForeColor = Color.FromArgb(32, 32, 32)

        End If

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
    Private Sub pnFechar_Click(sender As Object, e As EventArgs) Handles pnFechar.Click
        pbFechar_Click(sender, e)
    End Sub
    Private Sub pbFechar_Click(sender As Object, e As EventArgs) Handles pbFechar.Click
        Application.Exit()
    End Sub
    Private Sub pnMinimizar_Click(sender As Object, e As EventArgs) Handles pnMinimizar.Click
        pbMinimizar_Click(sender, e)
    End Sub

    Private Sub pbMinimizar_Click(sender As Object, e As EventArgs) Handles pbMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
#End Region

#Region "Conexao API Login"

    'Login
    Private Sub BTEntrar_Click(sender As Object, e As EventArgs) Handles BTEntrar.Click
        Dim login = tbLogin.Text
        Dim senha = tbSenha.Text
        Dim jsonString As String
        jsonString = "{""login"":""" &
                       login &
                        """,""senha"":""" &
                        senha & """}"
        Dim data = Encoding.UTF8.GetBytes(jsonString)
        'Processo de conexao API para recebimento de dados de login

        'URL para rota de lista de admins por login informado
        Dim myUri As New Uri("https://sistemaifrj.herokuapp.com/systemlogin")

        'Usando a função recebimentoADMLoginExc para buscar o admin com login informado. 
        'Usando o método GET para a requisição HTTP
        Dim response = exeLogin(myUri, data, "POST")
        'recebimentroADMLoginExc altera sucessoLogin:
        'True quando login válido e entra no aplicativo
        'False quando login inválido e mensagem de erro
        If sucessoLogin Then
            home.Show()
            Me.Hide()
        Else
            MsgBox("Login Inválido", vbCritical)
        End If


    End Sub

    Private Sub pbLogoLoginScreen_Click(sender As Object, e As EventArgs) Handles pbLogoLoginScreen.Click
        home.Show()
        Me.Hide()
    End Sub

#End Region

#Region "Outros"
    Private Sub pbHideShowSenha_Click(sender As Object, e As EventArgs) Handles pbHideShowSenha.Click
        If brightMode Then
            If Not visible Then
                pbHideShowSenha.Image = My.Resources.imgHideIconPreto
                visible = True
            Else
                pbHideShowSenha.Image = My.Resources.imgVisiblyIconPreto
                visible = False
            End If
        Else
            If Not visible Then
                pbHideShowSenha.Image = My.Resources.imgHideIconBranco
                visible = True
            Else
                pbHideShowSenha.Image = My.Resources.imgVisiblyIconBranco
                visible = False
            End If
        End If

    End Sub
#End Region

End Class
