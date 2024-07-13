//screen sound
string mensagemdeBoasVindas = "Boas Vindas ao Screen Sound !";
//List<string> ListasDasBandas = new List<string>{"test1", "test2"};
Dictionary<string, List<int>> BandasRegistradas = new Dictionary<string, List<int>>();
BandasRegistradas.Add("Pink Floyd", new List<int> { 10, 9, 8, 5});
BandasRegistradas.Add("Oficina G3", new List<int> ());

void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine(mensagemdeBoasVindas);
}


void ExibirOpcoes()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a opção que você deseja: ");
    string opcaoEscolhida = Console.ReadLine()!;

    if (opcaoEscolhida == string.Empty)
    {
        Console.Write("\nDigite a opção que você deseja: ");
        Console.Clear();
        ExibirOpcoes();
    }

    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    
   

    switch (opcaoEscolhidaNumerica) { 
        case 1: 
            RegistrarBanda();
            break;
        case 2:
            ExibirBandas();
            break;
        case 3: AvaliarBanda();
            break;
        case 4: MediaDaBanda();
            break;
        case -1: 
            Console.WriteLine("Encerrado Programa");
        break;
        default:
            Console.WriteLine("Opção invalida");
            break;
    }
 
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTitulo("Registro de bandas");

    Console.Write("digite o nome da banda desejada: ");
    string nomeDaBanda = Console.ReadLine()!;
    BandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A Banda {nomeDaBanda} foi adicionada com sucesso");


    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoes();
}

void ExibirBandas()
{
    Console.Clear();
    ExibirTitulo("Exibindo Bandas registradas");

    // for (int i = 0; i < ListasDasBandas.Count; i ++){
    //    Console.WriteLine($"banda: {ListasDasBandas[i]}");
    //}

    foreach(string banda in BandasRegistradas.Keys)
    {
        Console.WriteLine($"banda: {banda}");
    }

    Console.WriteLine("\n Digite qualquer tecla para voltar ao menu principal");

    Console.ReadKey();
    
    List<string> Loading = new List<string>();
    for (int i = 0;i < 50; i ++)
    {
        string load = "=";

        Loading.Add(load);
        Thread.Sleep(40);

        Console.Write($"{Loading[i]}");
    }

    Console.Clear();
    ExibirOpcoes();

}

void ExibirTitulo(string titulo)
{
    int quantidadeLetras = titulo.Length;
    string addDecoracao = string.Empty.PadLeft(quantidadeLetras,'*');
    
    Console.WriteLine(addDecoracao);
    Console.WriteLine(titulo);
    Console.WriteLine(addDecoracao);
}

void AvaliarBanda()
{
    Console.Clear();
    ExibirTitulo("Avaliaçao da Banda");
    Console.Write("\nDigite o nome da Banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    
    if (BandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda}: ");
        int nota = int.Parse(Console.ReadLine()!);
        BandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");

        Thread.Sleep(1000);

        Console.Clear();
        ExibirOpcoes();
    }
    else
    {   

        Console.WriteLine($"\nA banda {nomeDaBanda} não existe no nosso sitema");
        Console.WriteLine($"\nDigite qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    
        ExibirOpcoes();

    }

}

void MediaDaBanda()
{
    Console.Clear();
    ExibirTitulo("Média das Bandas");

    Console.Write("\nQual a banda gostaria de ver a média: ");
    string nomedaBanda = Console.ReadLine()!;

    if (BandasRegistradas.ContainsKey(nomedaBanda))
    {
        List<int> notasDaBanda = BandasRegistradas[nomedaBanda];
        Console.WriteLine($"A média da banda {nomedaBanda} é igual a {notasDaBanda.Average()}");
       
        Console.WriteLine($"\nDigite qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();

        ExibirOpcoes();

    }
    else
    {
        Console.Write($"\nBanda {nomedaBanda} não foi encontrada ou não existe");
        Console.WriteLine($"\nDigite qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();

        ExibirOpcoes();

    }
}

ExibirOpcoes();