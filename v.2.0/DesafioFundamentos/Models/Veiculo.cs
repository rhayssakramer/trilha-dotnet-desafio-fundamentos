namespace AppVeiculo.Models;

public class Veiculo
{
    public string Placa { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;

    public Veiculo(string placa, string modelo, string marca, string cor, string tipo)
    {
        Placa = placa;
        Modelo = modelo;
        Marca = marca;
        Cor = cor;
        Tipo = tipo;
    }
}