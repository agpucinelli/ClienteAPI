public class Cliente
{
     private static int contador = 0;

    public int Id { get; set;}
    public string Nome { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }
    public string RG { get; set; }
    public List<Contato> Contatos { get; set; }
    public List<Endereco> Enderecos { get; set; }

     public Cliente()
    {
        Id = ++contador;
    }
}


public class Contato
{
    private static int contador = 0;
    public int Id { get; set; }
    public string Tipo { get; set; }
    public int DDD { get; set; }
    public decimal Telefone { get; set; }

    public Contato()
    {
        Id = ++contador;
    }
}


public class Endereco
{
    private static int contador = 0;
    public int Id { get; set; }
    public string Tipo { get; set; }
    public string CEP { get; set; }
    public string Logradouro { get; set; }
    public int Numero { get; set; }
    public string Bairro { get; set; }
    public string Complemento { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Referencia { get; set; }

    public Endereco()
    {
        Id = ++contador;
    }
}
