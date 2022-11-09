## 🛠️ Abrir e rodar o projeto

Altere o arquivo appsettings.json incluindo o código:

` "ConnectionStrings": { "UsuarioConnection": //string de conexão }`
<br>
Adicionar user-secrets:

```
{
  "EmailSettings:SmtpServer": "",
  "EmailSettings:Port": "",
  "EmailSettings:Password": "",
  "EmailSettings:From": ""
}

```

Criar a base de dados:

`dotnet ef database update`

## Uso

Ao iniciar o projeto, será criado um usuário admin no banco de dados, todos os outros usuários criados terão papel regular.

# **Cadastro**

### 1.1 Cadastrar um novo usuário

| Método | Autorização | Rota      | Descrição           | Body Params | Query Params |
| ------ | ----------- | --------- | ------------------- | ----------- | ------------ |
| POST   | -           | /cadastro | Cadastra um usuário | JSON        | -            |

#### Body Params exemplo:

```
{
  "username": "Joao",
  "email": "user.joao@user.com",
  "password": "Usuario123!",
  "rePassword": "Usuario123!",
  "dataNascimento": "2010-09-03T20:48:28.629Z"
}
```

#### Token de ativação exemplo:

```
{
  "message": "CfDJ8FLWI/3e2SdKgZIFRBo8uosmO4UzaYnnCH+cMgLiE7sqEoaSs0zz8MHCVZKtqO/nph504j37rBQy3J0YB22qdCrbkUR/XdMdbGF/Wlx4PE5bALN6TUc3MYoXaqpLGo7/3drIshRT6jBxnMQURt/8SUE7zVsoyV4l2zShb16M548Ocqw0aNYyx2g4r7C2QDyzWfPpApNHUdgTkDYn82GY+Tk=",
  "metadata": {}
}
```

#

### 1.2 Ativa conta

| Método | Autorização | Rota   | Descrição                        | Body Params | Query Params                                |
| ------ | ----------- | ------ | -------------------------------- | ----------- | ------------------------------------------- |
| GET    | -           | /ativa | Ativa a conta de um novo usuário | -           | ?UsuarioId=`{int}`&CodigoAtivacao=`{token}` |

#

<br><br>

# **Login**

### 2.1 Cadastrar um novo usuário

| Método | Autorização | Rota   | Descrição       | Body Params | Query Params |
| ------ | ----------- | ------ | --------------- | ----------- | ------------ |
| POST   | -           | /login | Loga um usuário | JSON        | -            |

#### Body Params exemplo:

```
{
  "username": "Joao",
  "password": "Usuario123!"
}
```

#### Resposta - token de acesso válido por 1 hora, exemplo:

```
{
  "message": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6IkpvYW8iLCJpZCI6IjEwMDAwMyIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6InJlZ3VsYXIiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9kYXRlb2ZiaXJ0aCI6IjkvMy8yMDEwIDg6NDg6MjggUE0iLCJleHAiOjE2NjgwMTA0Mzl9.uikZRJZNBhSNMEdzVaFeVvyOf_bMP6HsRPLD053tcyE",
  "metadata": {}
}
```

<br><br>

# **Logout**

### 3.1 Efetua logout usuário

| Método | Autorização | Rota    | Descrição       | Body Params | Query Params |
| ------ | ----------- | ------- | --------------- | ----------- | ------------ |
| POST   | -           | /logout | Desloga usuário | -           | -            |

<br><br>

# **Reset**

### 4.1 Solicita reset

| Método | Autorização | Rota            | Descrição                      | Body Params | Query Params |
| ------ | ----------- | --------------- | ------------------------------ | ----------- | ------------ |
| POST   | -           | /solicita-reset | solicitaçãod de reset de senha | JSON        | -            |

```
{
  "email": "user.joao@user.com"
}
```

#### Resposta - token de reset, exemplo:

```
{
  "message": "CfDJ8FLWI/3e2SdKgZIFRBo8uouA8/mC6onshmrCczpFJvivzPtDxnHdgZj38I3ofPlvQbrKSmmMTA52kjiwltjqFxb0aSSnTDpHkygumojRYnDTxwoY4MlIPtfTB2337ZBk09+GTuhH5kkCrIdSUjfkPEh4j4J8fd0bvjSijEhDEiJyRpPsbmSFdAySimEx/fUC+g==",
  "metadata": {}
}
```

### 4.2 Reset da senha

| Método | Autorização | Rota          | Descrição                | Body Params | Query Params |
| ------ | ----------- | ------------- | ------------------------ | ----------- | ------------ |
| POST   | -           | /efetua-reset | Realiza o reset de senha | JSON        | -            |

```
{
  "password": "Usuario123!!!",
  "rePassword": "Usuario123!!!",
  "email": "user.joao@user.com",
  "token": "CfDJ8FLWI/3e2SdKgZIFRBo8uouA8/mC6onshmrCczpFJvivzPtDxnHdgZj38I3ofPlvQbrKSmmMTA52kjiwltjqFxb0aSSnTDpHkygumojRYnDTxwoY4MlIPtfTB2337ZBk09+GTuhH5kkCrIdSUjfkPEh4j4J8fd0bvjSijEhDEiJyRpPsbmSFdAySimEx/fUC+g=="
}
```
