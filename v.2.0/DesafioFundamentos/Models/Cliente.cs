using AppVeiculo.Models;

namespace AppCliente.Models;
public class Cliente
{
    public string Nome { get; set; } = string.Empty;
    public long Cpf { get; set; }
    public Veiculo Veiculo { get; set; } = new Veiculo("ABC1234", "Modelo", "Marca", "Cor", "Tipo");

    public Cliente(string nome, long cpf, Veiculo veiculo)
    {
        Nome = nome;
        Cpf = cpf;
        Veiculo = veiculo;
    }
}