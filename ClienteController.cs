
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ClienteService _clienteService;

    public ClienteController(ClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet("listar")]
    public ActionResult<List<Cliente>> ListarClientes(string nome = null, string email = null, string cpf = null)
    {
        var clientes = _clienteService.ListarClientes(nome, email, cpf);
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public ActionResult<Cliente> ObterClientePorId(int id)
    {
        var cliente = _clienteService.ObterClientePorId(id);

        if (cliente == null)
        {
            return NotFound(); 
        }

        return Ok(cliente);
    }

    [HttpPost("criar")]
    public ActionResult<Cliente> AdicionarCliente(Cliente cliente)
    {
        var novoCliente = _clienteService.AdicionarCliente(cliente);
        return Ok(novoCliente);
    }
    
    [HttpPut("atualizar/{id}")]
    public ActionResult<Cliente> AtualizarCliente(int id, Cliente clienteAtualizado)
    {
        var clienteExistente = _clienteService.AtualizarCliente(id, clienteAtualizado);

        if (clienteExistente == null)
        {
            return NotFound(); 
        }

        return Ok(clienteExistente);
    }

    [HttpDelete("remover/{id}")]
    public ActionResult RemoverCliente(int id)
    {
        _clienteService.RemoverCliente(id);
        return NoContent();
    }
}
