# ClienteAPI
API de cadastro de clientes. Neste serviço podemos incluir novo cliente, alterar cliente existente, listar todos os clientes, listar clientes com filtro, por nome e/ou, por cpf e/ou, por email. e por fim excluir cliente.

ClienteAPI
API de cadastro de clientes.

Neste serviço podemos incluir novo cliente, alterar cliente existente, listar todos os clientes, listar clientes com filtro, por nome e/ou, por cpf e/ou, por email. e por fim excluir cliente.

VSCODE:

1 - Abrir pasta ClienteAPI

2 - Abrir terminal

3 - dotnet run

4 - http://localhost:5167/cliente/ - Verificar qual porta o VSCODE disponibilizou a API.

Modelo Json para inserir novos dados, ou atualizar cadastro existente:

*Não é necessário inserir "Id", o mesmo é inserido automaticamente a cada cadastro.

{
    
    "Nome": "leo",
    "Email": "e@email.com",
    "CPF": "44444444421",
    "RG": "43564825",
    "Contatos": [
        {
            
            "Tipo": "celular",
            "DDD": 11,
            "Telefone": 945658525
        }
    ],
    "Enderecos": [
        {
            
            "Tipo": "casa",
            "CEP": "10405-681",
            "Logradouro": "Rua Exemplo",
            "Numero": 123,
            "Bairro": "Bairro Exemplo",
            "Complemento": "Complemento Exemplo",
            "Cidade": "Cidade Exemplo",
            "Estado": "SP",
            "Referencia": "ao lado"
        }
    ]
}

# GET
# Listar
# http://localhost:5167/cliente/listar
This endpoint makes an HTTP GET request to retrieve a list of clients. The request does not include a request body. The response will have a status code of 200, and it will contain an array of client objects. Each client object will have an "id", "nome", "email", "cpf", "rg", "contatos", and "enderecos" properties. The "contatos" property will contain an array of contact objects, and the "enderecos" property will contain an array of address objects. Each contact object will have an "id", "tipo", "ddd", and "telefone" properties, while each address object will have an "id", "tipo", "cep", "logradouro", "numero", "bairro", "complemento", "cidade", "estado", and "referencia" properties.

﻿


# GET
# Listar com filtro Nome
# http://localhost:5167/cliente/listar?nome=João
This endpoint makes an HTTP GET request to retrieve a list of clients based on the provided name parameter. The request should be sent to http://localhost:5167/cliente/listar with the query parameter "nome" set to the desired name.

The response will have a status code of 200, and it will contain an array of client objects. Each client object includes an "id", "nome", "email", "cpf", "rg", "contatos", and "enderecos" properties. The "contatos" property is an array of contact objects, and the "enderecos" property is an array of address objects.

Please note that the response data is intentionally masked/minified to protect user's data privacy.

﻿

Query Params
nome
João
GET
Listar com filtro CPF
http://localhost:5167/cliente/listar?cpf=77777777777
This endpoint makes an HTTP GET request to retrieve a list of clients based on the provided CPF (Cadastro de Pessoas Físicas) number. The CPF is passed as a query parameter in the URL.

Request Parameters
cpf: The CPF number of the client for which the list is to be retrieved.

Response
The response returns a status code of 200 along with an empty array, indicating that no clients were found based on the provided CPF.

﻿

Query Params
cpf
77777777777
# GET
# Listar com filtro email
# http://localhost:5167/cliente/listar?email=email@exemple.com
This endpoint is used to retrieve a list of clients based on the provided email address. The HTTP GET request should be sent to http://localhost:5167/cliente/listar?email=email@exemple.com.

The request does not require a request body, and the response will have a status code of 200 with an empty array as the data payload.

﻿

Query Params
email
email@exemple.com
# GET
# Listar com filtros
# http://localhost:5167/cliente/listar?nome=João&email=email@example.com&cpf=77777777777
This endpoint sends an HTTP GET request to retrieve a list of clients based on the provided query parameters. The query parameters include 'nome' for the client's name, 'email' for the client's email, and 'cpf' for the client's CPF. The request does not contain a request body.

The response to the last execution had a status code of 200 and an empty array as the response body, indicating that no clients matching the provided query parameters were found.

﻿

Query Params
nome
João
email
email@example.com
cpf
77777777777
# POST
# Criar
# http://localhost:5167/cliente/criar
This API endpoint allows you to create a new client. When you make a POST request to http://localhost:5167/cliente/criar, with the required payload in the raw request body, a new client will be created.

Request Body
Nome (string): The name of the client.

Email (string): The email address of the client.

CPF (string): The CPF (Cadastro de Pessoas Físicas) of the client.

RG (string): The RG (Registro Geral) of the client.

Contatos (array): An array of contact information for the client, including:

Tipo (string): The type of contact.

DDD (number): The area code for the phone number.

Telefone (number): The phone number.

Enderecos (array): An array of addresses for the client, including:

Tipo (string): The type of address.

CEP (string): The postal code.

Logradouro (string): The street address.

Numero (number): The street number.

Bairro (string): The neighborhood.

Complemento (string): Additional address details.

Cidade (string): The city.

Estado (string): The state.

Referencia (string): Any reference point for the address.

Response
Upon successful creation of the client, the API will respond with a status code of 200 and a JSON object containing:

sucesso (boolean): Indicates if the operation was successful.

mensagemErro (string): If an error occurred, this field will contain an error message.

cliente (object): Details of the created client, including:

id (number): The unique identifier of the client.

nome (string): The name of the client.

email (string): The email address of the client.

cpf (string): The CPF of the client.

rg (string): The RG of the client.

contatos (array): An array of contact information for the client, including:

id (number): The unique identifier of the contact.

tipo (string): The type of contact.

ddd (number): The area code for the phone number.

telefone (number): The phone number.

enderecos (array): An array of addresses for the client, including:

id (number): The unique identifier of the address.

tipo (string): The type of address.

cep (string): The postal code.

logradouro (string): The street address.

numero (number): The street number.

bairro (string): The neighborhood.

complemento (string): Additional address details.

cidade (string): The city.

estado (string): The state.

referencia (string): Any reference point for the address.

﻿

Body
raw (json)
View More
json
{
    
    "Nome": "leo",
    "Email": "e@email.com",
    "CPF": "44444444421",
    "RG": "43564825",
    "Contatos": [
        {
            
            "Tipo": "celular",
            "DDD": 11,
            "Telefone": 945658525
        }
    ],
    "Enderecos": [
        {
            
            "Tipo": "casa",
            "CEP": "10405-681",
            "Logradouro": "Rua Exemplo",
            "Numero": 123,
            "Bairro": "Bairro Exemplo",
            "Complemento": "Complemento Exemplo",
            "Cidade": "Cidade Exemplo",
            "Estado": "SP",
            "Referencia": "ao lado"
        }
    ]
}
# PUT
# Atualizar
# http://localhost:5167/cliente/atualizar/{id}
Update Client Details
This endpoint allows you to update the details of a client by providing the client's ID in the URL path.

Request
Request URL
PUT http://localhost:5167/cliente/atualizar/{id}

Request Body
Type: Raw

Payload:

JSON
      {
          "Nome":"",
          "Email":"",
          "CPF":"",
          "RG":"",
          "Contatos":[
              {
                  "Tipo":"",
                  "DDD":0,
                  "Telefone":0
              }
          ],
          "Enderecos":[
              {
                  "Tipo":"",
                  "CEP":"",
                  "Logradouro":"",
                  "Numero":0,
                  "Bairro":"",
                  "Complemento":"",
                  "Cidade":"",
                  "Estado":"",
                  "Referencia":""
              }
          ]
      }
Response
Status: 400

Body:

JSON
      {
          "type":"",
          "title":"",
          "status":0,
          "errors":{
              "id":[""]
          },
          "traceId":""
      }
﻿

Body
raw (json)
View More
json
{
    
    "Nome": "leo",
    "Email": "e@email.com",
    "CPF": "44444444421",
    "RG": "43564825",
    "Contatos": [
        {
            
            "Tipo": "casa",
            "DDD": 11,
            "Telefone": 945658525
        }
    ],
    "Enderecos": [
        {
            
            "Tipo": "En",
            "CEP": "10405-681",
            "Logradouro": "Rua Exemplo",
            "Numero": 123,
            "Bairro": "Bairro Exemplo",
            "Complemento": "Complemento Exemplo",
            "Cidade": "Cidade Exemplo",
            "Estado": "SP",
            "Referencia": "ao lado"
        }
    ]
}
# DELETE
# Remover
# http://localhost:5167/cliente/remover/{id}
Delete Cliente
This endpoint is used to delete a specific client by their ID.

Request
Method: DELETE

Endpoint: http://localhost:5167/cliente/remover/{id}

URL Parameters:

id (required): The unique identifier of the client to be deleted.

Request Body
The request does not require a request body.

Response
Status: 400

Body:

JSON
    {
      "type": "",
      "title": "",
      "status": 0,
      "errors": {
        "id": [""]
      },
      "traceId": ""
    }
type: The type of the error.

title: The title of the error.

status: The status code of the response.

errors: An object containing specific error details, in this case, the id field with an empty array.

traceId: The trace identifier for the error.

﻿

Bod
