Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.Net
Imports System.Linq
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net.Http

Module operacoesAPI

    Public corFundo As Integer
    Public corMedia As Integer
    Public corTexto As Integer
    Public idload As String
    Public erroBusca As String = Nothing
    Public token As String

#Region "ROTAS API"
    'Rotas API
    Public routerAdm = "https://sistemaifrj.herokuapp.com/admins/"
    Public routerUser = "https://sistemaifrj.herokuapp.com/users/"
    Public routerRecarga = "https://sistemaifrj.herokuapp.com/recargas/"
    Public routerVend = "https://sistemaifrj.herokuapp.com/vendedores/"
    Public routerProd = "https://sistemaifrj.herokuapp.com/produtos/"
    Public routerAcesso = "https://sistemaifrj.herokuapp.com/acessos/"

#End Region

#Region "Criptografia"
    'Function que criptografa dado enviada
    'dado = string para criptografar
    'nivel = numero de camadas de criptografia
    'cont = contador para alcançar nivel PS: Inicialmente igual a 1
    Public Function cripto(ByVal dado As String, nivel As Integer, cont As Integer)
        'Imports Usados
        'System.Text
        'System.Security.Cryptography
        Dim Bytes() As Byte
        Dim sb As New StringBuilder()
        If Not String.IsNullOrEmpty(dado) Then
            Bytes = Encoding.Default.GetBytes(dado)
            Bytes = MD5.Create().ComputeHash(Bytes)
            For x As Integer = 0 To Bytes.Length - 1
                sb.Append(Bytes(x).ToString("x2"))
            Next
        End If
        dado = sb.ToString
        If cont < nivel Then
            dado = cripto(sb.ToString, nivel, cont + 1)
        End If
        Return dado
    End Function
#End Region

#Region "Envio de Dados POST"

    'Envia os dados pelo método POST para a API executar ação
    'uri = rota para conexao com a API
    'jsonDataBytes = informação JSON no formato bytes para execução

    Public Function exeLogin(uri As Uri, jsonDataBytes As Byte(), metodo As String) As String
        Dim response As String
        Dim request As WebRequest
        Dim contentType As String = "application/json"

        'Construindo a requisição HTTP com a rota da API
        request = WebRequest.Create(uri)

        'Criando o objeto JSON da requisição
        request.ContentLength = jsonDataBytes.Length
        request.ContentType = contentType
        request.Method = metodo
        'request.Headers = System.Net.HttpRequestHeader.Authorization) 
        Try

            'Fazendo a escrita das informações no server via requisição HTTP POST
            Using requestStream = request.GetRequestStream
                requestStream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
                requestStream.Close()

                'Capturando a resposta do server após escrita
                Using responseStream = request.GetResponse.GetResponseStream
                    Using reader As New StreamReader(responseStream)
                        response = reader.ReadToEnd()
                    End Using
                End Using
            End Using
            Dim dado As JObject = JObject.Parse(response)
            Dim loginToken As classLogin
            loginToken = JsonConvert.DeserializeObject(Of classLogin)(dado.ToString)

            token = loginToken.token
            formLogin.sucessoLogin = True
            'Limpa tbs
            home.btAdmAddLimpar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgBox(ex.Message)

            'MsgBox(ex.ToString)
        End Try
        Return response
    End Function


    Private Function envioPOST_OR(uri As Uri, jsonDataBytes As Byte(), metodo As String) As String
        Dim response As String
        Dim request As WebRequest
        Dim contentType As String = "application/json"

        'Construindo a requisição HTTP com a rota da API
        request = WebRequest.Create(uri)

        'Criando o objeto JSON da requisição
        request.ContentLength = jsonDataBytes.Length
        request.ContentType = contentType
        request.Method = metodo
        request.Headers(System.Net.HttpRequestHeader.Authorization) = "Bearer " & token
        Try

        'Fazendo a escrita das informações no server via requisição HTTP POST
        Using requestStream = request.GetRequestStream
                requestStream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
                requestStream.Close()

                'Capturando a resposta do server após escrita
                Using responseStream = request.GetResponse.GetResponseStream
                    Using reader As New StreamReader(responseStream)
                        response = reader.ReadToEnd()
                    End Using
                End Using
            End Using
            'Limpa tbs
            home.btAdmAddLimpar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return response
    End Function

#End Region

#Region "Recebimento de Dados GET"

    Public Sub recebimentoADMLoginExc(uri As Uri, contentType As String, method As String, acao As String)

        'Criando as variáveis usadas na criação da requisição HTTP
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim responseString As String

        responseString = ""

        Try

            'Construindo a requisição HTTP com a rota da URL passada
            request = DirectCast(WebRequest.Create(uri), HttpWebRequest)
            request.Headers(System.Net.HttpRequestHeader.Authorization) = "Bearer " & token
            'Fazendo a requisição e coletando a resposta
            'If DirectCast(request.GetResponse(), HttpWebResponse).ToString <> "400" Then
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            'End If


            'Lendo a resposta à requisição
            reader = New StreamReader(response.GetResponseStream())

            'Transformando a resposta em string para facilitar a leitura do JSON
            Dim rawresp As String
            rawresp = reader.ReadToEnd()
            'Fazendo o parse da string para JSON Object
            Dim dado As JObject = JObject.Parse(rawresp)

            'Pegando os dados do administrador localizado e salvando nas property da classAdmins
            Dim administrator As classAdmins
            administrator = JsonConvert.DeserializeObject(Of classAdmins)(dado.ToString)

            'Verifica se está no processo de Exclusão ou Login
            If acao = "exclusao" Then

                'Caso seja exclusão, adiciona nas tbs os dados encontrados
                With home
                    .btAdmDelBusca.BackColor = Color.Green
                    .btAdmDelBusca.Text = "Localizado!"
                    .tbAdmDelNome.Text = administrator.nome
                    .tbAdmDelLogin.Text = administrator.login
                    .tbAdmDelEmail.Text = administrator.email
                    .btAdmDelApagar.Enabled = True
                    .btAdmDelCancelar.Enabled = True
                End With


            End If
        Catch ex As Exception

            'Em caso de erro, abrir uma messagebox
            If acao = "exclusao" Then
                If ex.Message = "O servidor remoto retornou um erro: (400) Solicitação Incorreta." Then '&
                    With home.btAdmDelBusca
                        .Enabled = False
                        .BackColor = Color.Red
                        .Text = "Não Encontrado"
                        .ForeColor = Color.White
                        .Refresh()
                        System.Threading.Thread.Sleep(2000)
                        .Enabled = True
                        .BackColor = Color.White
                        .Text = "Localizar"
                        .ForeColor = Color.FromArgb(32, 32, 32)
                        home.tbAdmDelBusca.Clear()
                        .Refresh()
                    End With
                Else
                    MsgBox(ex.Message)
                End If
            End If
        Finally
            If Not response Is Nothing Then
                response.Close()
            End If
        End Try

    End Sub

    Public Sub recebimentoCartaoExc(uri As Uri, contentType As String, method As String, acao As String)

        'Criando as variáveis usadas na criação da requisição HTTP
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim responseString As String

        responseString = ""

        Try

            'Construindo a requisição HTTP com a rota da URL passada
            request = DirectCast(WebRequest.Create(uri), HttpWebRequest)
            request.Headers(System.Net.HttpRequestHeader.Authorization) = "Bearer " & token
            'Fazendo a requisição e coletando a resposta
            response = DirectCast(request.GetResponse(), HttpWebResponse)

            'Lendo a resposta à requisição
            reader = New StreamReader(response.GetResponseStream())

            'Transformando a resposta em string para facilitar a leitura do JSON
            Dim rawresp As String
            rawresp = reader.ReadToEnd()

            'Fazendo o parse da string para JSON Object
            Dim dado As JObject = JObject.Parse(rawresp)

            'Pegando os dados do administrador localizado e salvando nas property da classAdmins
            Dim usuario As classUsers
            usuario = JsonConvert.DeserializeObject(Of classUsers)(dado.ToString)

            'Verifica se está no processo de Exclusão ou Login


            'Caso seja exclusão, adiciona nas tbs os dados encontrados
            With home
                If acao = "exclusao" Then
                    .tbCartaoDelNome.Text = usuario.nome
                    .tbCartaoDelEmail.Text = usuario.email
                    .tbCartaoDelSaldo.Text = usuario.saldo
                    .btCartaoDelApagar.Enabled = True
                    .btCartaoDelCancelar.Enabled = True
                ElseIf acao = "recarga" Then
                    idload = usuario.id
                    .lbCartaoRecNome.Text = usuario.nome
                    .lbCartaoRecEmail.Text = usuario.email
                    .lbCartaoRecSaldoAt.Text = "R$ " & usuario.saldo
                    .lbCartaoRecSaldoTt.Text = Val(usuario.saldo)
                End If
            End With

            'Caso seja login, verifica validade do login retornando true/false para sucessoLogin


        Catch ex As Exception
            If ex.Message = "O servidor remoto retornou um erro: (400) Solicitação Incorreta." Then
                'Em caso de erro, abrir uma messagebox
                With home.btCartaoDelBusca
                    .Enabled = False
                    .BackColor = Color.Red
                    .Text = "Não Encontrado"
                    .ForeColor = Color.White
                    .Refresh()
                    System.Threading.Thread.Sleep(2000)
                    .Enabled = True
                    .BackColor = Color.White
                    .Text = "Localizar"
                    .ForeColor = Color.FromArgb(32, 32, 32)
                    home.tbCartaoDelBusca.Clear()
                    .Refresh()
                End With
            End If
        Finally
            If Not response Is Nothing Then
                response.Close()
            End If
        End Try

    End Sub

    Public Sub recebimentoVendedorExc(uri As Uri, contentType As String, method As String)

        'Criando as variáveis usadas na criação da requisição HTTP
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim responseString As String

        responseString = ""

        Try

            'Construindo a requisição HTTP com a rota da URL passada
            request = DirectCast(WebRequest.Create(uri), HttpWebRequest)
            request.Headers(System.Net.HttpRequestHeader.Authorization) = "Bearer " & token
            'Fazendo a requisição e coletando a resposta
            response = DirectCast(request.GetResponse(), HttpWebResponse)

            'Lendo a resposta à requisição
            reader = New StreamReader(response.GetResponseStream())

            'Transformando a resposta em string para facilitar a leitura do JSON
            Dim rawresp As String
            rawresp = reader.ReadToEnd()

            'Fazendo o parse da string para JSON Object
            Dim dado As JObject = JObject.Parse(rawresp)

            'Pegando os dados do administrador localizado e salvando nas property da classAdmins
            Dim usuario As classUsers
            usuario = JsonConvert.DeserializeObject(Of classUsers)(dado.ToString)

            'Verifica se está no processo de Exclusão ou Login


            'Caso seja exclusão, adiciona nas tbs os dados encontrados
            With home
                .tbVendDelNome.Text = usuario.nome
                .tbVendDelEmail.Text = usuario.email
                .btVendDelApagar.Enabled = True
                .btVendDelCancelar.Enabled = True
            End With

            'Caso seja login, verifica validade do login retornando true/false para sucessoLogin


        Catch ex As Exception

            'Em caso de erro, abrir uma messagebox

            If ex.Message = "O servidor remoto retornou um erro: (400) Solicitação Incorreta." Then '&
                formMsgBox.chamadaMSG("Vendedor não encontrado.", 1)
            Else
                MsgBox(ex.Message)
            End If
        Finally
            If Not response Is Nothing Then
                response.Close()
            End If
        End Try

    End Sub

#Region "Acessos"

    Public Sub recebimentoTodosAcessos(uri As Uri, contentType As String, method As String)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim responseString As String

        responseString = ""

        Try

            'Construindo a requisição HTTP com a rota da URL passada
            request = DirectCast(WebRequest.Create(uri), HttpWebRequest)
            request.Headers(System.Net.HttpRequestHeader.Authorization) = "Bearer " & token
            'Fazendo a requisição e coletando a resposta
            'If DirectCast(request.GetResponse(), HttpWebResponse).ToString <> "400" Then
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            'End If


            'Lendo a resposta à requisição
            reader = New StreamReader(response.GetResponseStream())

            'Transformando a resposta em string para facilitar a leitura do JSON
            Dim rawresp As String
            rawresp = reader.ReadToEnd()

            'Fazendo o parse da string para JSON Object

            Dim dado As JArray = JArray.Parse(rawresp)

            'Pegando os dados do administrador localizado e salvando nas property da classAdmins

            With home.dgwAcessosAll
                .DataSource = JsonConvert.DeserializeObject(Of classAcessos())(dado.ToString).ToList
                .Columns("id").HeaderText = "ID do Acesso"
                .Columns("nome_vendedor").HeaderText = "Nome do Vendedor"
                .Columns("id_vendedor").HeaderText = "ID do Vendedor"
                .Columns("nome_admin").HeaderText = "Nome do Administrador"
                .Columns("id_admin").HeaderText = "ID do Administrador"
                .Columns("createdAt").HeaderText = "Data de Criação"
                .Columns("updatedAt").HeaderText = "Última Atualização"
                '.AlternatingRowsDefaultCellStyle.BackColor.ToArgb()
                .Visible = True
            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            If Not response Is Nothing Then
                response.Close()
            End If
        End Try
    End Sub

    Public Sub recebimentoAcessosOn(uri As Uri, contentType As String, method As String)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim responseString As String

        responseString = ""

        Try

            'Construindo a requisição HTTP com a rota da URL passada
            request = DirectCast(WebRequest.Create(uri), HttpWebRequest)
            request.Headers(System.Net.HttpRequestHeader.Authorization) = "Bearer " & token
            'Fazendo a requisição e coletando a resposta
            'If DirectCast(request.GetResponse(), HttpWebResponse).ToString <> "400" Then
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            'End If


            'Lendo a resposta à requisição
            reader = New StreamReader(response.GetResponseStream())

            'Transformando a resposta em string para facilitar a leitura do JSON
            Dim rawresp As String
            rawresp = reader.ReadToEnd()

            'Fazendo o parse da string para JSON Object

            Dim dado As JArray = JArray.Parse(rawresp)

            'Pegando os dados do administrador localizado e salvando nas property da classAdmins

            With home.dgwAcessosOn
                .DataSource = JsonConvert.DeserializeObject(Of classAcessos())(dado.ToString).ToList
                .Columns("id").HeaderText = "ID do Acesso"
                .Columns("nome_vendedor").HeaderText = "Nome do Vendedor"
                .Columns("id_vendedor").HeaderText = "ID do Vendedor"
                .Columns("nome_admin").HeaderText = "Nome do Administrador"
                .Columns("id_admin").HeaderText = "ID do Administrador"
                .Columns("createdAt").HeaderText = "Data de Criação"
                .Columns("updatedAt").HeaderText = "Última Atualização"
                '.AlternatingRowsDefaultCellStyle.BackColor.ToArgb()
                .Visible = True
            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            If Not response Is Nothing Then
                response.Close()
            End If
        End Try
    End Sub

    Public Sub recebimentoAcessosOff(uri As Uri, contentType As String, method As String)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim responseString As String

        responseString = ""

        Try

            'Construindo a requisição HTTP com a rota da URL passada
            request = DirectCast(WebRequest.Create(uri), HttpWebRequest)
            request.Headers(System.Net.HttpRequestHeader.Authorization) = "Bearer " & token
            'Fazendo a requisição e coletando a resposta
            'If DirectCast(request.GetResponse(), HttpWebResponse).ToString <> "400" Then
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            'End If


            'Lendo a resposta à requisição
            reader = New StreamReader(response.GetResponseStream())

            'Transformando a resposta em string para facilitar a leitura do JSON
            Dim rawresp As String
            rawresp = reader.ReadToEnd()

            'Fazendo o parse da string para JSON Object

            Dim dado As JArray = JArray.Parse(rawresp)

            'Pegando os dados do administrador localizado e salvando nas property da classAdmins

            With home.dgwAcessosOff
                .DataSource = JsonConvert.DeserializeObject(Of classAcessos())(dado.ToString).ToList
                .Columns("id").HeaderText = "ID do Acesso"
                .Columns("nome_vendedor").HeaderText = "Nome do Vendedor"
                .Columns("id_vendedor").HeaderText = "ID do Vendedor"
                .Columns("nome_admin").HeaderText = "Nome do Administrador"
                .Columns("id_admin").HeaderText = "ID do Administrador"
                .Columns("createdAt").HeaderText = "Data de Criação"
                .Columns("updatedAt").HeaderText = "Última Atualização"
                '.AlternatingRowsDefaultCellStyle.BackColor.ToArgb()
                .Visible = True
            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            If Not response Is Nothing Then
                response.Close()
            End If
        End Try
    End Sub

    Public Sub recebimentoAcessosByVend(uri As Uri, contentType As String, method As String)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim responseString As String

        responseString = ""

        Try

            'Construindo a requisição HTTP com a rota da URL passada
            request = DirectCast(WebRequest.Create(uri), HttpWebRequest)
            request.Headers(System.Net.HttpRequestHeader.Authorization) = "Bearer " & token
            'Fazendo a requisição e coletando a resposta
            'If DirectCast(request.GetResponse(), HttpWebResponse).ToString <> "400" Then
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            'End If


            'Lendo a resposta à requisição
            reader = New StreamReader(response.GetResponseStream())

            'Transformando a resposta em string para facilitar a leitura do JSON
            Dim rawresp As String
            rawresp = reader.ReadToEnd()

            'Fazendo o parse da string para JSON Object

            Dim dado As JObject = JObject.Parse(rawresp)

            Dim acesso As classVendedors

            acesso = JsonConvert.DeserializeObject(Of classVendedors)(dado.ToString)

            'Pegando os dados do administrador localizado e salvando nas property da classAdmins

            With home.dgwAcessosByVend
                .DataSource = JsonConvert.DeserializeObject(Of classAcessos())(acesso.VENDacessos.ToString).ToList
                .Columns("id").HeaderText = "ID do Acesso"
                .Columns("nome_vendedor").HeaderText = "Nome do Vendedor"
                .Columns("id_vendedor").HeaderText = "ID do Vendedor"
                .Columns("nome_admin").HeaderText = "Nome do Administrador"
                .Columns("id_admin").HeaderText = "ID do Administrador"
                .Visible = True
            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            If Not response Is Nothing Then
                response.Close()
            End If
        End Try
    End Sub

    Public Sub recebimentoAcessosByData(uri As Uri, contentType As String, method As String)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim responseString As String

        responseString = ""

        Try

            'Construindo a requisição HTTP com a rota da URL passada
            request = DirectCast(WebRequest.Create(uri), HttpWebRequest)
            request.Headers(System.Net.HttpRequestHeader.Authorization) = "Bearer " & token
            'Fazendo a requisição e coletando a resposta
            'If DirectCast(request.GetResponse(), HttpWebResponse).ToString <> "400" Then
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            'End If


            'Lendo a resposta à requisição
            reader = New StreamReader(response.GetResponseStream())

            'Transformando a resposta em string para facilitar a leitura do JSON
            Dim rawresp As String
            rawresp = reader.ReadToEnd()

            'Fazendo o parse da string para JSON Object

            Dim dado As JArray = JArray.Parse(rawresp)

            'Pegando os dados do administrador localizado e salvando nas property da classAdmins

            With home.dgwAcessosByData
                .DataSource = JsonConvert.DeserializeObject(Of classAcessos())(dado.ToString).ToList
                .Columns("id").HeaderText = "ID do Acesso"
                .Columns("nome_vendedor").HeaderText = "Nome do Vendedor"
                .Columns("id_vendedor").HeaderText = "ID do Vendedor"
                .Columns("nome_admin").HeaderText = "Nome do Administrador"
                .Columns("id_admin").HeaderText = "ID do Administrador"
                .Columns("createdAt").HeaderText = "Data de Criação"
                .Columns("updatedAt").HeaderText = "Última Atualização"
                '.AlternatingRowsDefaultCellStyle.BackColor.ToArgb()
                .Visible = True
            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            If Not response Is Nothing Then
                response.Close()
            End If
        End Try
    End Sub


#End Region

#End Region

#Region "Exclusão de Dados DELETE"

    'Variável que indica sucesso ou falha na exclusão
    Public sucessDelete As Boolean

    'Execução Exclusão
    Public Sub delete(parametro As String, myUri As String)
        Try
            Dim sURL As String = routerAdm & "l/" & parametro
            Dim request As WebRequest = WebRequest.Create(sURL)
            request.Method = "DELETE"
            request.Headers(System.Net.HttpRequestHeader.Authorization) = "Bearer " & token
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Dim status = Val(response.StatusCode)
            If response.StatusCode = 200 Then
                If myUri.Contains(routerAdm) Then
                    With home.btAdmDelApagar
                        .BackColor = Color.Green
                        .Text = "Excluído"
                        .Enabled = False
                        .Refresh()
                        System.Threading.Thread.Sleep(1500)
                        home.btAdmDelBusca.Text = "Localizar"
                        home.btAdmDelBusca.BackColor = Color.White
                        home.btAdmDelBusca.Enabled = True
                        .BackColor = Color.White
                        .Text = "Apagar"
                        home.btAdmDelCancelar_Click(Nothing, Nothing)
                        .Refresh()
                    End With

                ElseIf myUri.Contains(routerUser) Then
                    With home.btCartaoDelApagar
                        .BackColor = Color.Green
                        .Text = "Excluído"
                        .Enabled = False
                        .Refresh()
                        System.Threading.Thread.Sleep(1500)
                        home.btCartaoDelBusca.Text = "Localizar"
                        home.btCartaoDelBusca.BackColor = Color.White
                        home.btCartaoDelBusca.Enabled = True
                        .BackColor = Color.White
                        .Text = "Apagar"
                        home.btAdmDelCancelar_Click(Nothing, Nothing)
                        .Refresh()
                    End With
                ElseIf myUri.Contains(routerVend) Then

                    With home.btVendDelApagar
                        .BackColor = Color.Green
                        .Text = "Excluído"
                        .Enabled = False
                        .Refresh()
                        System.Threading.Thread.Sleep(1500)
                        home.btVendDelBusca.Text = "Localizar"
                        home.btVendDelBusca.BackColor = Color.White
                        home.btVendDelBusca.Enabled = True
                        .BackColor = Color.White
                        .Text = "Apagar"
                        home.btAdmDelCancelar_Click(Nothing, Nothing)
                        .Refresh()
                    End With
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "Admin Operacoes"
    Public Sub addAdmin(nome As String, login As String, senha As String, email As String)
        'MsgBox("Nome:" & nome & vbNewLine & "Login:" & login & vbNewLine & "senha:" & senha & vbNewLine & "Email:" & email)
        'String JSON usada para cadastro de usuário
        Dim jsonString As String
        jsonString = "{""nome"":""" &
                       nome &
                        """,""login"":""" &
                        login &
                        """,""crpsenha"":""" &
                        senha &
                        """,""email"":""" &
                        email & """}"
        'URL para a rota de criação de usuários (definida na API pelo Erick)
        Dim myUri As New Uri(routerAdm)
        With home.btAdmAddSalvar
            'Codificando a string JSON para ser enviada na requisição HTTP do tipo POST
            Dim data = Encoding.UTF8.GetBytes(jsonString)
            Dim result_post = envioPOST_OR(myUri, data, "POST")
            If result_post = "200" Then
                .Text = "Salvo!"
                .BackColor = Color.Green
                .ForeColor = Color.White
                .Refresh()
            Else
                .Text = "Erro!"
                .BackColor = Color.Red
                .ForeColor = Color.White
                .Refresh()
            End If
            System.Threading.Thread.Sleep(1000)
            .Text = "Salvar"
            .BackColor = Color.White
            .ForeColor = Color.FromArgb(32, 32, 32)
            .Enabled = True
            .Refresh()
        End With
    End Sub

    'Busca de Admin para exclusão
    'Exclusão oficial feita no formHome
    Public Sub excAdmin(parametro As String)
        Dim myUri As Uri
        'URL para rota de lista de admins por login informado
        If home.cbAdmDellBy.Text = "Login" Then
            myUri = New Uri(routerAdm & "l/" & parametro)
        ElseIf home.cbAdmDellBy.Text = "E-mail" Then
            myUri = New Uri(routerAdm & "e/" & parametro)
        End If
        'Usando a função recebimentoADMLoginExc para buscar os usuários cadastrados. Usando o método GET para a requisição HTTP
        recebimentoADMLoginExc(myUri, "application/json", "GET", "exclusao")
    End Sub
#End Region

#Region "Cartao Operacoes"

    Public Sub addCartao(mat As String, nome As String, email As String, saldo As String)
        Dim jsonString As String

        jsonString = "{""matricula"":""" &
                        mat &
                        """,""nome"":""" &
                        nome &
                        """,""email"":""" &
                        email &
                        """,""saldo"":" &
                        saldo & "}"

        'URL para a rota de criação de usuários (definida na API pelo Erick)
        Dim myUri As New Uri(routerUser)
        With home.btCartaoAddSalvar
            .Text = "Salvando..."
            .Enabled = False
            .Refresh()
            System.Threading.Thread.Sleep(250)
            'Codificando a string JSON para ser enviada na requisição HTTP do tipo POST
            Dim data = Encoding.UTF8.GetBytes(jsonString)
            Dim result_post = envioPOST_OR(myUri, data, "POST")
            If result_post = "200" Then
                .Text = "Salvo!"
                .BackColor = Color.Green
                .ForeColor = Color.White
                .Refresh()
            Else
                .Text = "Erro!"
                .BackColor = Color.Red
                .ForeColor = Color.White
                .Refresh()
            End If
            System.Threading.Thread.Sleep(1000)
            .Text = "Salvar"
            .BackColor = Color.White
            .Enabled = True
            .Refresh()
        End With
    End Sub

    Public Sub excCartao(matricula As String)

        'URL para rota de lista de users plea matricula informada
        Dim myUri As New Uri(routerUser & matricula)

        'Usando a função recebimentoADMLoginExc para buscar os usuários cadastrados. Usando o método GET para a requisição HTTP
        recebimentoCartaoExc(myUri, "application/json", "GET", "exclusao")
    End Sub
    Public Sub recCartao(matricula As String)

        'URL para rota de lista de users plea matricula informada
        Dim myUri As New Uri(routerUser & matricula & "/")

        'Usando a função recebimentoADMLoginExc para buscar os usuários cadastrados. Usando o método GET para a requisição HTTP
        recebimentoCartaoExc(myUri, "application/json", "GET", "recarga")
    End Sub

    Public Sub exeRecarga(modo As String, valor As Integer)
        'URL para rota de lista de users plea matricula informada
        'valor = 50
        Dim myUri As New Uri(routerRecarga & idload)
        Dim jsonString As String
        jsonString = "{""modo_pagto"" :  """ &
        modo &
           """,""valor_recarga"":" &
        valor & "}"
        Dim data = Encoding.UTF8.GetBytes(jsonString)
        Dim result_post = envioPOST_OR(myUri, data, "POST")
        jsonString = "{""saldo"":" &
                        Val(home.lbCartaoRecSaldoTt.Text) & "}"
        'URL para a rota de criação de usuários (definida na API pelo Erick)
        myUri = New Uri(routerUser & home.tbCartaoRecMat.Text & "/")
        'Codificando a string JSON para ser enviada na requisição HTTP do tipo POST
        data = Encoding.UTF8.GetBytes(jsonString)
        result_post = envioPOST_OR(myUri, data, "PUT")
    End Sub

#End Region

#Region "Vendedor Operacoes"
    Public Sub addVend(mat As String, nome As String, email As String, senha As String)
        Dim jsonString As String
        jsonString = "{""matricula"":""" &
                       mat &
                        """,""nome"":""" &
                        nome &
                        """,""email"":""" &
                        email &
                        """,""senha"":""" &
                        senha & """}"
        'URL para a rota de criação de usuários (definida na API pelo Erick)
        Dim myUri As New Uri(routerVend)
        With home.btVendAddSalvar
            .Text = "Salvando..."
            .Enabled = False
            .ForeColor = Color.White
            .Refresh()
            System.Threading.Thread.Sleep(250)
            'Codificando a string JSON para ser enviada na requisição HTTP do tipo POST
            Dim data = Encoding.UTF8.GetBytes(jsonString)
            Dim result_post = envioPOST_OR(myUri, data, "POST")
            If result_post = "200" Then
                .Text = "Salvo!"
                .BackColor = Color.Green
                .ForeColor = Color.White
                .Refresh()
            Else
                .Text = "Erro!"
                .BackColor = Color.Red
                .ForeColor = Color.White
                .Refresh()
            End If
            System.Threading.Thread.Sleep(1000)
            home.btVendAddLimpar_Click(Nothing, Nothing)
            .Text = "Salvar"
            .BackColor = Color.White
            .ForeColor = Color.FromArgb(32, 32, 32)
            .Enabled = True
            .Refresh()
        End With
    End Sub

    Public Sub excVendedor(parametro As String)
        Dim myUri As Uri
        'URL para rota de lista de admins por login informado
        If home.cbVendDellBy.Text = "Matrícula" Then
            myUri = New Uri(routerVend & "m/" & parametro)
        ElseIf home.cbVendDellBy.Text = "E-mail" Then
            myUri = New Uri(routerVend & "e/" & parametro)
        End If
        'Usando a função recebimentoADMLoginExc para buscar os usuários cadastrados. Usando o método GET para a requisição HTTP
        recebimentoVendedorExc(myUri, "application/json", "GET")
    End Sub
#End Region

#Region "Produto Operacoes"

    Public Sub addProduto(nome As String, categoria As String, preco As Integer, estoque As Integer)
        Dim jsonString As String
        jsonString = "{""nome"":""" &
                       nome &
                        """,""preco"":" &
                        preco &
                        ",""estoque"":" &
                        estoque &
                        ",""categoria"":""" &
                        categoria & """}"
        'URL para a rota de criação de usuários (definida na API pelo Erick)
        Dim myUri As New Uri(routerProd)
        MsgBox(jsonString)
        Dim data = Encoding.UTF8.GetBytes(jsonString)
        Dim result_post = envioPOST_OR(myUri, data, "POST")
    End Sub


#End Region


End Module
