namespace AppEstacionamento.Models;

public class Estacionamento
{
    private decimal precoInicial = 0;
    private decimal precoHora = 0;
    private List<string> veiculos = new List<string>();

    public Estacionamento(decimal precoInicial, decimal precoHora)
    {
        this.precoInicial = precoInicial;
        this.precoHora = precoHora;
    }

    //Entrada para digitar a placa do veículo
    public void AdicionarVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo para estacionar:");
        string placa = Console.ReadLine();
        veiculos.Add(placa);
    }

    //Entrada para remover a placa do veículo
    public void RemoverVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo para remover:");
        //Entrada para o usuário digitar a placa e armazenar a variável
        string placa = Console.ReadLine();

        //Verificação de existência do veículo
        if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
        {
            //Solicitar do usuário a quantidade de horas que permaneceu estacionado
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado");
            int horas = int.Parse(Console.ReadLine());
            decimal valorTotal = precoInicial + (horas * precoHora);
            //Exibir o preço total a ser pago
            Console.WriteLine($"O veículo {placa} foi removido e o preço total a pagar é de R$ {valorTotal}");
            veiculos.Remove(placa);
        }
        else
        {
            Console.WriteLine("Veículo não encontrado.");
        }
    }

    public void ListarVeiculos()
    {
        if (veiculos.Any())
        {
            Console.WriteLine("Os veículos estacionados são:");
            foreach (var veiculo in veiculos)
            {
                Console.WriteLine(veiculo);
            }
        }else{
            Console.WriteLine("Não há veículos estacionados.");
        }
    }
}