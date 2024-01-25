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

    public void AdicionarVeiculo()
    {
        // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
        // *IMPLEMENTE AQUI*
        Console.WriteLine("Digite a placa do veículo para estacionar:");
        string placa = Console.ReadLine();
        veiculos.Add(placa);
    }

    public void RemoverVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo para remover:");

        // Pedir para o usuário digitar a placa e armazenar na variável placa
        // *IMPLEMENTE AQUI*
        string placa = Console.ReadLine();

        // Verifica se o veículo existe
        if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
        {
            
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado");

            // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
            // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
            // *IMPLEMENTE AQUI*
            int horas = int.Parse(Console.ReadLine());
            decimal valorTotal = precoInicial + (horas * precoHora);
            
            // TODO: Remover a placa digitada da lista de veículos
            // *IMPLEMENTE AQUI*
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
        // Verifica se há veículos no estacionamento
        if (veiculos.Any())
        {
            Console.WriteLine("Os veículos estacionados são:");
            // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
            // *IMPLEMENTE AQUI*
            foreach (var veiculo in veiculos)
            {
                Console.WriteLine(veiculo);
            }
        }else{
            Console.WriteLine("Não há veículos estacionados.");
        }
    }
}