using AppCliente.Models;
using AppVeiculo.Models;

namespace AppEstacionamento.Models;

public class Estacionamento
{
    //Variáveis Iniciais
    private const decimal PrecoInicial = 5.0m;
    private const decimal PrecoAdicional = 2.0m;
    private const int TotalVagas = 3000;
    private const int VagasRot = 1500;

    //Listas
    private List<Cliente> clientes = new List<Cliente>();
    private List<string> veiculosRotativos = new List<string>();
    private List<string> veiculosReservados = new List<string>();
    private Dictionary<string, DateTime> veiculosRotativosDateTime = new Dictionary<string, DateTime>();
    private Dictionary<string, DateTime> veiculosReservadosDateTime = new Dictionary<string, DateTime>();

    //Gerador de Vagas
    private Random random = new Random();
    public string GeradorVaga(string tipoVeiculo){
        int numero = random.Next(1, TotalVagas + 1);
        Dictionary<string, string> prefixos = new Dictionary<string, string>{{ "Moto", numero <= VagasRot ? "PA" : "OA" }, { "Carro", numero <= VagasRot ? "PB" : "OB" }, { "Outro", numero <= VagasRot ? "PC" : "OC" }};
        return $"{prefixos[tipoVeiculo]}{(numero <= VagasRot ? numero : numero - VagasRot)}";
    }

    //Calculador de preços
    public decimal CalcularPreco(DateTime dataHoraEntrada){
        TimeSpan duracao = DateTime.Now - dataHoraEntrada;
        return PrecoInicial + (decimal)duracao.TotalHours * PrecoAdicional;
    }

    //Método com o Menu Inicial
    public void MenuInicial(){
        Console.WriteLine("Para iniciar, escolha uma das opções abaixo:\n" + "1 - Área do Usuário\n" + "2 - Vagas Rotativas\n" + "3 - Vagas Reservadas\n" + "4 - Encerra");
        string opcao = Console.ReadLine() ?? string.Empty;
        Console.Clear();
        switch (opcao){
            case "1":
                AreaUsuario();
                break;
            case "2":
                VagasRotativas();
                break;
            case "3":
                VagasReservadas();
                break;
            case "4":
                Console.WriteLine("Aguarde!\nO programa está sendo finalizado...");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                MenuInicial();
                break;
        }
    }

    //Método com outros menus
    public void AreaUsuario(){
        Console.WriteLine("Escolha uma opção abaixo:\n" + "1 - Cadastrar Veículo\n" + "2 - Modificar Veículo\n" + "3 - Excluir Veículo\n" + "4 - Listar Veículos Cadastrados\n" + "5 - Listar Vagas Ocupadas\n" + "6 - Voltar ao Menu Inicial\n" + "7 - Encerrar");
        string opcao = Console.ReadLine() ?? string.Empty;
        Console.Clear();
        switch (opcao){
            case "1":
                CadastraVeiculo();
                break;
            case "2":
                ModificaVeiculo();
                break;
            case "3":
                ExcluirVeiculo();
                break;
            case "4":
                ListarVeiculosCadastrados();
                break;
            case "5":
                ListarVagasOcupadas();
                break;
            case "6":
                Console.WriteLine("Aguarde!\nVocê está sendo redirecionado ao Menu Inicial...");
                MenuInicial();
                break;
            case "7":
                Console.WriteLine("Aguarde!\nO programa está sendo finalizado...");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                AreaUsuario();
                break;
        }
    }

    public void VagasRotativas(){
        Console.WriteLine("Escolha uma opção abaixo:\n1 - Buscar Placa\n2 - Finalizar Rotativo\n3 - Voltar ao Menu Inicial\n4 - Encerrar");
        string opcao = Console.ReadLine() ?? string.Empty;
        Console.Clear();
        switch (opcao){
            case "1":
                string placa = BuscaPlaca();
                if (placa != null){
                    Console.WriteLine("Deseja solicitar uma Vaga Rotativa para o veículo?\n1 - Sim\n2 - Não");
                    string opcao2 = Console.ReadLine() ?? string.Empty;
                    if (opcao2 == "1"){
                        veiculosRotativos.Add(placa);
                        veiculosRotativosDateTime[placa] = DateTime.Now;
                        Console.Clear();
                        Console.WriteLine("Vaga Rotativa liberada com sucesso!\nVocê está sendo redirecionado ao Menu Inicial...");
                        MenuInicial();
                    }
                    else if (opcao2 == "2"){
                        Console.Clear();
                        Console.WriteLine("Aguarde!\nVocê está sendo redirecionado ao Menu Inicial...");
                        MenuInicial();
                    }
                }else{
                    Console.WriteLine("Deseja cadastrar o veículo\n1 - Sim\n2 - Não");
                    string opcao3 = Console.ReadLine() ?? string.Empty;
                    if (opcao3 == "1"){
                        CadastraVeiculo();
                    }else if (opcao3 == "2"){
                        Console.WriteLine("Vaga Rotativa liberada com sucesso!\nVocê está sendo redirecionado ao Menu Inicial...");
                        MenuInicial();
                    }
                }
                break;
            case "2":
                FinalizarRotativo();
                break;
            case "3":
                Console.WriteLine("Aguarde!\nVocê está sendo redirecionado ao Menu Inicial...");
                MenuInicial();
                break;
            case "4":
                Console.WriteLine("Aguarde!\nO programa está sendo finalizado...");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                VagasRotativas();
                break;
        }
    }

    public void VagasReservadas(){
        Console.WriteLine("Escolha uma opção abaixo:\n1 - Buscar Placa\n2 - Voltar ao Menu Inicial\n3 - Encerrar");
        string opcao = Console.ReadLine() ?? string.Empty;
        Console.Clear();
        switch (opcao){
            case "1":
                string placa = BuscaPlaca();
                Cliente? cliente = clientes.FirstOrDefault(c => c.Veiculo.Placa == placa);
                veiculosReservados.Add(placa);
                if (cliente != null){
                    Console.Clear();
                    Console.WriteLine($"Veículo encontrado!\nNome Cliente: {cliente.Nome}\nCPF Cliente: {cliente.Cpf}\nPlaca: {cliente.Veiculo.Placa}\nModelo: {cliente.Veiculo.Modelo}\nMarca: {cliente.Veiculo.Marca}\nCor: {cliente.Veiculo.Cor}\nTipo: {cliente.Veiculo.Tipo}");
                    Console.WriteLine("Para qual data?");
                    string data = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Para qual horário?");
                    string horario = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Qual o tempo de permanência?");
                    string tempoPermanencia = Console.ReadLine() ?? string.Empty;
                    if (veiculosReservados.Contains(placa)){
                        TimeSpan duracao = TimeSpan.FromHours(double.Parse(tempoPermanencia));
                        decimal precoTotal = PrecoInicial + (decimal)duracao.TotalHours * PrecoAdicional;
                        decimal horaAdicional = (decimal)duracao.TotalHours * PrecoAdicional;
                        Console.WriteLine($"Preço Inicial: R$ {PrecoInicial}\nPreço Horas Adicionais: R$ {horaAdicional}\nValor Total a Pagar: R$ {precoTotal.ToString("N2")}");
                    }else{
                        Console.Clear();
                        Console.WriteLine("Veículo não encontrado!");
                        VagasReservadas();
                    }
                    Pagamento();
                }else{
                    Console.Clear();
                    Console.WriteLine("Veículo não encontrado!");
                    CadastraVeiculo();
                }
                break;
            case "2":
                Console.WriteLine("Aguarde!\nVocê está sendo redirecionado ao Menu Inicial...");
                MenuInicial();
                break;
            case "3":
                Console.WriteLine("Aguarde!\nO programa está sendo finalizado...");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                VagasReservadas();
                break;
        }
    }

    //Outros métodos do programa
    public string BuscaPlaca(){
        Console.WriteLine("Vamos fazer uma busca pela placa!\nDigite a placa do veículo:");
        string placa = Console.ReadLine() ?? string.Empty;
        Console.Clear();
        Cliente? cliente = clientes.FirstOrDefault(c => c.Veiculo.Placa == placa);
        if (cliente != null){
            Console.WriteLine($"Veículo encontrado!\nNome Cliente: {cliente.Nome}\nCPF Cliente: {cliente.Cpf}\nPlaca: {cliente.Veiculo.Placa}\nModelo: {cliente.Veiculo.Modelo}\nMarca: {cliente.Veiculo.Marca}\nCor: {cliente.Veiculo.Cor}\nTipo: {cliente.Veiculo.Tipo}");
        }else{
            Console.Clear();
            Console.WriteLine("Veículo não encontrado!");
        }
        return placa;
    }

    public void CadastraVeiculo(){
        Console.WriteLine("Digite os dados do Veículo/Cliente!\n");
        string nomeCliente = SolicitarDados("Nome do Cliente");
        string input = SolicitarDados("CPF do Cliente");
        if (long.TryParse(input, out long cpfCliente)){
            string placa = SolicitarDados("Placa");
            string modelo = SolicitarDados("Modelo");
            string marca = SolicitarDados("Marca");
            string cor = SolicitarDados("Cor");
            string tipo = SolicitarDados("Tipo");
            Veiculo veiculo = new Veiculo(placa, modelo, marca, cor, tipo);
            Cliente cliente = new Cliente(nomeCliente, cpfCliente, veiculo);
            clientes.Add(cliente);
            Console.Clear();
            Console.WriteLine("Veículo cadastrado com sucesso!");
            AreaUsuario();
        }else{
            Console.WriteLine("Valor inválido! Complete os dados novamente.");
            CadastraVeiculo();
        }
    }

    private string SolicitarDados(string dado){
        Console.Write($"{dado}: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public void ModificaVeiculo(){
        Console.Write("Digite a placa do veículo: ");
        string placa = Console.ReadLine() ?? string.Empty;
        Cliente? cliente = clientes.FirstOrDefault(c => c.Veiculo.Placa == placa);
        Console.Clear();
        if (cliente != null){
            Console.WriteLine($"Veículo encontrado!\nNome Cliente: {cliente.Nome}\nCPF Cliente: {cliente.Cpf}\nPlaca: {cliente.Veiculo.Placa}\nModelo: {cliente.Veiculo.Modelo}\nMarca: {cliente.Veiculo.Marca}\nCor: {cliente.Veiculo.Cor}\nTipo: {cliente.Veiculo.Tipo}");
            Console.WriteLine("Quais dados deseja alterar?\n1 - Nome\n2 - CPF\n3 - Placa\n4 - Modelo\n5 - Marca\n6 - Cor\n7 - Tipo");
            string opcao = Console.ReadLine() ?? string.Empty;
            switch (opcao){
                case "1":
                    Console.Write("Digite o novo nome: ");
                    cliente.Nome = Console.ReadLine() ?? string.Empty;
                    break;
                case "2":
                    Console.Write("Digite o novo CPF: ");
                    cliente.Cpf = long.Parse(Console.ReadLine() ?? string.Empty);
                    break;
                case "3":
                    Console.Write("Digite a nova placa: ");
                    cliente.Veiculo.Placa = Console.ReadLine() ?? string.Empty;
                    break;
                case "4":
                    Console.Write("Digite o novo modelo: ");
                    cliente.Veiculo.Modelo = Console.ReadLine() ?? string.Empty;
                    break;
                case "5":
                    Console.Write("Digite a nova marca: ");
                    cliente.Veiculo.Marca = Console.ReadLine() ?? string.Empty;
                    break;
                case "6":
                    Console.Write("Digite a nova cor: ");
                    cliente.Veiculo.Cor = Console.ReadLine() ?? string.Empty;
                    break;
                case "7":
                    Console.Write("Digite o novo tipo: ");
                    cliente.Veiculo.Tipo = Console.ReadLine() ?? string.Empty;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    ModificaVeiculo();
                    break;
                }
            Console.Clear();
            Console.WriteLine("Dados aletrados com sucesso!\nVocê está sendo redirecionado a Área do Usuário");
            AreaUsuario();
        }else{
            Console.Clear();
            Console.WriteLine("Veículo não encontrado!\nVocê está sendo redirecionado para a Área do Usuário...");
            AreaUsuario();
        }
    }

    public void ExcluirVeiculo(){
        Console.Write("Digite a placa do veículo: ");
        string placa = Console.ReadLine() ?? string.Empty;
        Cliente? cliente = clientes.FirstOrDefault(c => c.Veiculo.Placa == placa);
        Console.Clear();
        if (cliente != null){
            Console.Clear();
            Console.WriteLine($"Veículo encontrado!\nNome Cliente: {cliente.Nome}\nCPF Cliente: {cliente.Cpf}\nPlaca: {cliente.Veiculo.Placa}\nModelo: {cliente.Veiculo.Modelo}\nMarca: {cliente.Veiculo.Marca}\nCor: {cliente.Veiculo.Cor}\nTipo: {cliente.Veiculo.Tipo}");
            Console.WriteLine("Deseja realmente excluir este veículo?\n1 - Sim\n2 - Não");
            string opcao = Console.ReadLine() ?? string.Empty;
            switch (opcao){
                case "1":
                    Cliente? clienteRemover = clientes.FirstOrDefault(cliente => cliente.Veiculo.Placa == placa);
                    if (clienteRemover != null){
                        clientes.Remove(clienteRemover);
                        Console.Clear();
                        Console.WriteLine("Veículo removido com sucesso!\nVocê está sendo redirecionado a Área do Usuário.");
                        AreaUsuario();
                    }else{
                        Console.WriteLine("Veículo não encontrado! Tente novamente com outra placa.");
                        ExcluirVeiculo();
                    }
                    break;
                case "2":
                    Console.WriteLine("Aguarde!\nVocê está sendo redirecionado a Área do Usuário.");
                    AreaUsuario();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    ExcluirVeiculo();
                    break;
            }
        }else{
            Console.WriteLine("Veículo não encontrado!\nVocê está sendo redirecionado para a Área do Usuário...");
            AreaUsuario();
        }
    }

    public void FinalizarRotativo(){
        Console.WriteLine("Deseja encerrar sua estadia?\n1 - Sim\n2 - Não");
        string opcao = Console.ReadLine() ?? string.Empty;
        Console.Clear();
        switch (opcao){
            case "1":
                Console.Write("Digite a placa do veículo: ");
                string placa = Console.ReadLine() ?? string.Empty;
                Console.Clear();
                if (veiculosRotativos.Contains(placa)){
                    DateTime dataHoraEntrada = veiculosRotativosDateTime[placa];
                    TimeSpan duracao = DateTime.Now - dataHoraEntrada;
                    decimal precoTotal = PrecoInicial + (decimal)duracao.TotalHours * PrecoAdicional;
                    Console.WriteLine($"Data de Entrada: {dataHoraEntrada}\nHoras Adicionais: {duracao.TotalHours.ToString("N2")}\nValor da Entrada: R$ {PrecoInicial.ToString("N2")}\nValor das Horas Adicionais: R$ {((decimal)duracao.TotalHours * PrecoAdicional).ToString("N2")}\nValor Total a Pagar: R$ {precoTotal.ToString("N2")}");
                    Pagamento();
                }else{
                    Console.Clear();
                    Console.WriteLine("Veículo não encontrado!");
                    FinalizarRotativo();
                }
                break;
            case "2":
                Console.Clear();
                Console.WriteLine("Aguarde!\nVocê está sendo redirecionado ao Menu Inicial...");
                MenuInicial();
                break;
            default:
                Console.Clear();
                Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                FinalizarRotativo();
                break;
        }
    }

    public static void Pagamento(){
        Console.WriteLine("Qual a forma de pagamento?\n1 - Pix\n2 - Débito\n3 - Crédito");
        string opcao = Console.ReadLine() ?? string.Empty;
        switch (opcao){
            case "1":
                Console.WriteLine("O QR foi enviado para a maquineta!\nPagamento aprovado!\nObrigada pela preferência.\nO programa está sendo finalizado...");
                Environment.Exit(0);
                break;
            case "2":
                Console.WriteLine("Pagamento aprovado!\nObrigada pela preferência.\nO programa está sendo finalizado...");
                Environment.Exit(0);
                break;
            case "3":
                Console.WriteLine("Pagamento autorizado!\nObrigada pela preferência.\nO programa está sendo finalizado...");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                Pagamento();
                break;
        }
    }

    //Busca de Listas
    public void ListarVeiculosCadastrados(){
        Console.Clear();
        if (clientes.Count == 0){
            Console.WriteLine("Veículo não encontrado!\nVocê está sendo redirecionado para a Área do Usuário...");
            AreaUsuario();
        }else{
            Console.WriteLine("Lista de Placas dos Veículos Cadastrados!");
            var veiculosPorTipo = clientes.GroupBy(c => c.Veiculo.Tipo);
            foreach (var grupo in veiculosPorTipo){
                Console.WriteLine($"\n{grupo.Key}");
                foreach (Cliente cliente in grupo){
                    Console.WriteLine($"Placa: {cliente.Veiculo.Placa}");
                }
            }
            Console.WriteLine("Aguarde!\nVocê está sendo redirecionado a Área do Usuário...");
            AreaUsuario();
        }
    }

    public void ListarVagasOcupadas(){
        Console.Clear();
        Console.WriteLine("Vagas Rotativas Ocupadas:");
        foreach (var veiculo in veiculosRotativosDateTime){
            Console.WriteLine($"Placa: {veiculo.Key}, Hora de Entrada: {veiculo.Value}");
        }

        Console.WriteLine("Vagas Reservadas Ocupadas:");
        foreach (var veiculo in veiculosReservadosDateTime){
            Console.WriteLine($"Placa: {veiculo.Key}, Hora de Reserva: {veiculo.Value}");
        }
        Console.WriteLine("Aguarde!\nVocê está sendo redirecionado a Área do Usuário...");
        AreaUsuario();
    }
}