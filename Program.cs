using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();
Reserva reserva = new Reserva();
Suite suite = new Suite(tipoSuite: "Standard", capacidade: 2, valorDiaria: 30);
//Pessoa p1 = new Pessoa(nome: "Hóspede 1");
//Pessoa p2 = new Pessoa(nome: "Hóspede 2");

//hospedes.Add(p1);
//hospedes.Add(p2);

// Cria a suíte


// Cria uma nova reserva, passando a suíte e os hóspedes
//Reserva reserva = new Reserva(diasReservados: 10);
//reserva.CadastrarSuite(suite);
//reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
//Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
//Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");

bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("ATENCAO - caso nenhuma suite seja cadastrada \n"
                    + "o hospede sera colocado na suite standard capacidade 2 pessoas");
    Console.WriteLine();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar Hospede");
    Console.WriteLine("2 - Cadastrar Suite");
    Console.WriteLine("3 - Listar Reserva");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            hospedes.Clear();
            Console.Write("Quantos hospedes deseja cadastra? ");
            int quantidadeHospedes = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < quantidadeHospedes; i++)
            {
                Console.Write("Por favor digite o nome do hospede: ");
                Pessoa p = new Pessoa(nome: Console.ReadLine());
                hospedes.Add(p);
            }
            suite.CriarSuite();
            reserva.CadastrarSuite(suite);
            reserva.CadastrarHospedes(hospedes);
            break;

        case "2":
            suite.CriarSuite();
            reserva.CadastrarSuite(suite);
            reserva.CadastrarHospedes(hospedes);
            break;

        case "3":       
            bool naoDiasValido = true;
            while (naoDiasValido)
            {
                Console.Write("Por favor digite a quantidade de dias para reserva: ");
                try
                {
                    reserva.DiasReservados = Convert.ToInt32(Console.ReadLine());
                    naoDiasValido = false;
                }
                catch (Exception)
                {
                    Console.Write("Quantidade de dias invalido digite novamente: ");
                };
            };
            // Exibe a quantidade de hóspedes e o valor da diária
            if(hospedes.Count <= suite.Capacidade)
            {
                Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
                Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
            }
            else
            {
                Console.WriteLine($"ATENCAO Capacidade do quarto = {suite.Capacidade}");
                while(suite.Capacidade <= hospedes.Count)
                {
                    Console.WriteLine("Por favor remova um hospede da lista:");
                    foreach(Pessoa p in hospedes)
                    {
                        Console.WriteLine(p.Nome);
                    }
                    Console.Write("Digite o nome do hospede: ");
                    string removerHospede = Console.ReadLine();
                    hospedes.RemoveAll(hospede => hospede.Nome == removerHospede);
                }
            }
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}