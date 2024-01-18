using System.Text.RegularExpressions;


public class ClienteService
{
    public class OperacaoClienteResponse
    {
        public bool Sucesso { get; set; }
        public string MensagemErro { get; set; }
        public Cliente Cliente { get; set; }
    }

    private List<Cliente> _clientes;

    public ClienteService()
    {
        _clientes = new List<Cliente>
        //REGISTROS INICIAIS TESTE
        {
            new Cliente
            {
                Id = 1,
                Nome = "João",
                Email = "joao@example.com",
                CPF = "12345678901",
                RG = "1234567",
                Contatos = new List<Contato>
                {
                    new Contato { Id = 1, Tipo = "Celular", DDD = 11, Telefone = 987654321 }
                },
                Enderecos = new List<Endereco>
                {
                    new Endereco { Id = 1, Tipo = "Residencial", CEP = "12345-678", Logradouro = "Rua A", Numero = 123, Bairro = "Centro", Cidade = "São Paulo", Estado = "SP", Referencia = "Próximo à praça" }
                }
            },
            new Cliente
            {
                Id = 2,
                Nome = "Maria",
                Email = "maria@example.com",
                CPF = "98765432109",
                RG = "7654321",
                Contatos = new List<Contato>
                {
                    new Contato { Id = 2, Tipo = "Comercial", DDD = 21, Telefone = 123456789 }
                },
                Enderecos = new List<Endereco>
                {
                    new Endereco { Id = 2, Tipo = "Entrega", CEP = "54321-876", Logradouro = "Av. B", Numero = 456, Bairro = "Centro", Cidade = "Rio de Janeiro", Estado = "RJ", Referencia = "Próximo ao shopping" }
                }
            },
                        
        };
    }
    // VALIDAÇÃO UTILIZANDO A BIBLLIOTECA REGEX

     private bool ValidarEmail(string email)
    {
        
        string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
        return Regex.IsMatch(email, pattern);
    }

    private bool ValidarCPF(string cpf)
    {
        
        string pattern = @"^\d{11}$";
        return Regex.IsMatch(cpf, pattern);
    }

    private bool ValidarRG(string rg)
    {
        
        string pattern = @"^\d{5,}$";
        return Regex.IsMatch(rg, pattern);
    }

    private bool ValidarCEP(string CEP)
    {
       
        string pattern = @"^\d{5}-\d{3}$";
        return Regex.IsMatch(CEP, pattern);
    }


    private bool ValidarCliente(Cliente cliente)
    {
       
        return ValidarEmail(cliente.Email) && ValidarCPF(cliente.CPF) && ValidarRG(cliente.RG) && cliente.Enderecos.All(e => ValidarCEP(e.CEP));;
    }

   
     

    public Cliente ObterClientePorId(int id)
    {
        return _clientes.FirstOrDefault(c => c.Id == id);
    }

    public List<Cliente> ListarClientes(string nome = null, string email = null, string cpf = null)
    {
        var clientesFiltrados = _clientes;

        // FILTROS
        if (!string.IsNullOrEmpty(nome))
        {
            clientesFiltrados = clientesFiltrados.Where(c => c.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (!string.IsNullOrEmpty(email))
        {
            clientesFiltrados = clientesFiltrados.Where(c => c.Email.Contains(email, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (!string.IsNullOrEmpty(cpf))
        {
            clientesFiltrados = clientesFiltrados.Where(c => c.CPF == cpf).ToList();
        }

        
        return clientesFiltrados;
    }

    public OperacaoClienteResponse AdicionarCliente(Cliente cliente)
    {
        
        if (!ValidarCliente(cliente))
        {
           
           return new OperacaoClienteResponse
            {
                Sucesso = false,
                MensagemErro = "Erro ao adicionar cliente. Por favor, verifique os dados de entrada, email, CPF, RG e CEP.",
                Cliente = null
            };
        }
        _clientes.Add(cliente);
       return new OperacaoClienteResponse
        {
            Sucesso = true,
            MensagemErro = null,
            Cliente = cliente
        };
    }

public Cliente AtualizarCliente(int id, Cliente clienteAtualizado)
{
    var clienteExistente = _clientes.FirstOrDefault(c => c.Id == id);

    if (clienteExistente != null)
    {
        //ATUALIZAR CLIENTE
        clienteExistente.Nome = clienteAtualizado.Nome;

        
        if (clienteExistente.Contatos != null && clienteAtualizado.Contatos != null)
        {
            foreach (var contatoAtualizado in clienteAtualizado.Contatos)
            {
               
                var contatoExistente = clienteExistente.Contatos.FirstOrDefault(c => c.Id == contatoAtualizado.Id);

                if (contatoExistente != null)
                {
                    // ATUALIZAR CONTATO
                    contatoExistente.Tipo = contatoAtualizado.Tipo;
                    contatoExistente.DDD = contatoAtualizado.DDD;
                    contatoExistente.Telefone = contatoAtualizado.Telefone;
                }
            }
        }

        
        if (clienteExistente.Enderecos != null && clienteAtualizado.Enderecos != null)
        {
            foreach (var enderecoAtualizado in clienteAtualizado.Enderecos)
            {
                
                var enderecoExistente = clienteExistente.Enderecos.FirstOrDefault(e => e.Id == enderecoAtualizado.Id);

                if (enderecoExistente != null)
                {
                    // ATUALIZAR ENDEREÇO
                    enderecoExistente.Tipo = enderecoAtualizado.Tipo;
                    enderecoExistente.CEP = enderecoAtualizado.CEP;
                    enderecoExistente.Logradouro = enderecoAtualizado.Logradouro;
                    enderecoExistente.Numero = enderecoAtualizado.Numero;
                    enderecoExistente.Bairro = enderecoAtualizado.Bairro;
                    enderecoExistente.Complemento = enderecoAtualizado.Complemento;
                    enderecoExistente.Cidade = enderecoAtualizado.Cidade;
                    enderecoExistente.Estado = enderecoAtualizado.Estado;
                    enderecoExistente.Referencia = enderecoAtualizado.Referencia;
                }
            }
        }

        return clienteExistente;
    }

    return null; 
}


    public void RemoverCliente(int id)
    {
        var clienteExistente = _clientes.FirstOrDefault(c => c.Id == id);
        if (clienteExistente != null)
        {
            _clientes.Remove(clienteExistente);
        }
    }
}
