using AppEstacionamento.Models;

//Encodign para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoHora = 0;

//Entradas Iniciais do Programa
Console.WriteLine("Sejam bem-vindos(as) ao Park Estacionamento!\n" + "Digite o preço inicial do estacionamento:");
//Variáveis Iniciais
precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Agora digite o preço por hora do estacionamento:");
precoHora = Convert.ToDecimal(Console.ReadLine());

//Instância de Classe Estacionamento
Estacionamento estac = new Estacionamento(precoInicial, precoHora);

string opcao = string.Empty;
bool exibirMenu = true;

//Realizar Looping
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar Menu");

    switch (Console.ReadLine())
    {
        case "1":
            estac.AdicionarVeiculo();
            break;
        case "2":
            estac.RemoverVeiculo();
            break;
        case "3":
            estac.ListarVeiculos();
            break;
        case "4":
            exibirMenu = false;
            break;
        default:
            Console.WriteLine("Opção inválida, digite uma opção válida!");
            break;
    }
    Console.WriteLine("Pressione qualquer tecla para continuar...");
    Console.ReadKey();
}