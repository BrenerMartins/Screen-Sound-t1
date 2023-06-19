namespace Screen_Sound_t1;

class Program
{
    static void Main(string[] args)
    {
        ExibirLogo();
        Menu();
    }

   // static List<string> ListaDasBandas = new List<string>();
    static Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>(); 
    static void ExibirLogo()
    {

        ExibirTituloDaOpcao("Bem vindo ao Screen Sound");

        Thread.Sleep(2000);

        ExibirTituloDaOpcao("Digite Enter para continuar");

        Console.ReadKey();


    }

    static void Menu()  // void = vazio  
    {
        Console.Clear();

        ExibirTituloDaOpcao("Screen Sound");

        Console.WriteLine("Digite (1) para registrar uma banda!");
        Console.WriteLine("Digite (2) para mostrar todas as bandas");
        Console.WriteLine("Digite (3) para avaliar uma banda");
        Console.WriteLine("Digite (4) para exibir a média de uma banda");
        Console.WriteLine("Digite (0)  para sair");
        Console.WriteLine("Digite a sua opção: ");

        int opcaoEscolhidaNumerica = int.Parse(Console.ReadLine()!);

        switch (opcaoEscolhidaNumerica)
        {

            case 1: RegistrarBanda(); break;
            case 2: MostrarBandas(); break;
            case 3: AvaliarUmaBanda(); break;
            case 4: ExibirMedia(); break;
            case 0: Sair(); break;
            default: Console.WriteLine("Você escolheu uma opção invalida"); break;

        }
    }

    static void RegistrarBanda()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Registro de Bandas");
        Console.WriteLine("Digite o nome da banda que deseja registrar:");
        Console.WriteLine("");

        string NomeDaBanda = Console.ReadLine()!;
        
        //ListaDasBandas.Add(NomeDaBanda);
        bandasRegistradas.Add(NomeDaBanda, new List<int> {1});
        Console.WriteLine("");
        Console.WriteLine($"A banda {NomeDaBanda} foi registrada com sucesso!");
        Console.WriteLine("");

        ExibirTituloDaOpcao("Digite Enter para continuar!");

        Console.ReadKey();
        RegistrarNovaBanda();
    }

    static void MostrarBandas()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Lista das bandas:");

        //  for (int i = 0; i < ListaDasBandas.Count; i++)
        //  {
        //      Console.WriteLine($"Banda: {ListaDasBandas[i]}");
        //  }

       // foreach (string banda in ListaDasBandas)
        foreach (string banda in bandasRegistradas.Keys)
        {
            Console.WriteLine($"Banda: {banda}");
        }

        Console.WriteLine("");

        Thread.Sleep(3000);
        ExibirTituloDaOpcao("Digite Enter para voltar ao menu");

        Console.ReadKey();
        Console.Clear();
        Menu();

    }

    static void RegistrarNovaBanda()
    {
        Console.Clear();
        Console.WriteLine("Deseja Registrar mais uma banda?");

        ExibirTituloDaOpcao("Digite sim ou nao");

        string RegistrarNovaBanda = Console.ReadLine()!;

        Console.WriteLine($"Voçê Digitou {RegistrarNovaBanda}");

        if (RegistrarNovaBanda == "sim")
        {
            RegistrarBanda();
        }
        else if (RegistrarNovaBanda == "nao")
        {
            Console.Clear();
            Menu();
        }
        else
        {
            Console.WriteLine("Você digitou uma resposta invalida!");
        }

        Thread.Sleep(2000);
        Console.Clear();
        Menu();
    }
    static void Sair()
    {
        Console.Clear();
        Console.WriteLine("Obrigado por utilizar o Screen Sound!");
        Console.WriteLine("Tchau tchau!");

        System.Environment.Exit(0);
    }

    static void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string traco = string.Empty.PadLeft(quantidadeDeLetras, '-');
        Console.WriteLine(traco);
        Console.WriteLine(titulo);
        Console.WriteLine(traco + "\n");
    }

    static void AvaliarUmaBanda()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Avaliar banda");
        Console.WriteLine("Digite o nome da banda que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.WriteLine($"Qual a nota que a banda {nomeDaBanda} merece:");
            int nota = int.Parse(Console.ReadLine()!);
            bandasRegistradas[nomeDaBanda].Add(nota);
            
            Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
            Thread.Sleep(2000);
            Console.Clear();
            Menu();
        }
        else
        {
            Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }
    static void ExibirMedia()
        {
            Console.Clear();
            ExibirTituloDaOpcao("Exibir média da banda");
            Console.WriteLine("Digite o nome da banda que deseja exibir a média:");
            string nomeDaBanda = Console.ReadLine()!;

            if (bandasRegistradas.ContainsKey(nomeDaBanda))
            {
            List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
            Console.WriteLine($"A média da banda {nomeDaBanda} é {notasDaBanda.Average()}.");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            Menu();
            } else
            { 
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            Menu();
            }
        }
}

