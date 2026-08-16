using System.Diagnostics.Contracts;

public interface IVendavel
{
    void Vender(int quantidade);
}

public interface IReponivel
{
    void ReporEstoque();
}

public interface IContavel
{
    void ContarEstoque();
}

public interface IBuscavel
{
    void BuscarInformacoes();
}



public class Produto:IVendavel, IReponivel, IContavel, IBuscavel
{
    public Produto() {}
    public string Nome {get; set;}
    public decimal Preco {get; set;}
    public int QuantidadeEstoque {get; private set;}
    public bool CondicaoImportacao {get; set;}
    public  string Categoria {get; set;}
    public string CodProduto {get; set;}

    public Produto(string nome, decimal preco, int quantidadeEstoque, bool condicaoImportacao, string categoria, string codProduto)
    {
        Nome = nome;
        Preco = preco;
        QuantidadeEstoque = quantidadeEstoque;
        CondicaoImportacao = condicaoImportacao;
        Categoria = categoria;
        CodProduto = codProduto;
    }


    public void Vender (int quantidadeComprada)
    {   if(ValidarVenda(quantidadeComprada, QuantidadeEstoque)){
        QuantidadeEstoque = QuantidadeEstoque - quantidadeComprada;
        decimal precoTotal = quantidadeComprada * Preco;
        Console.WriteLine($"Você comprou {quantidadeComprada} por {precoTotal}");
    } else
    {
        Console.WriteLine("Não foi possível realizar a venda. O saldo em estoque não é suficiente ou a quantidade é inválida");
    }
    }

    public void ReporEstoque ()
    {   
        Console.Write("Quantas unidades você deseja repor?");
        int quantidadeAdicionada = int.Parse(Console.ReadLine()!);
        QuantidadeEstoque = QuantidadeEstoque + quantidadeAdicionada;
        Console.WriteLine("Estamos repondo o estoque! Só um momento!");
        Thread.Sleep(3000);
        Console.Clear();
        Console.WriteLine($"Estoque reposto com sucesso! O novo estoque de {Nome} é {QuantidadeEstoque}");
        Thread.Sleep(3000);
    }

    public bool ValidarVenda(int quantidadeComprada, int quantidadeEstoque)
    {
        if (quantidadeComprada <= quantidadeEstoque && quantidadeComprada > 0)
        {
            return true;
        } else
        {
            return false;
        }
    }


    public void ContarEstoque()
    {
        Console.WriteLine($"Temos {QuantidadeEstoque} disponíveis");
        if ( QuantidadeEstoque <= 5 && QuantidadeEstoque > 0)
        {
            Console.WriteLine($"Últimas oportunidades! Não perca!");
        } else if (QuantidadeEstoque == 0)
        {
            Console.WriteLine($"Esse produto está esgotado. Pediremos mais em breve!");
        }
    }

    public virtual void BuscarInformacoes()
    {
        Console.WriteLine("");
        Console.Write("Produto: ");
        Console.WriteLine(Nome);
        Console.Write("Preço: ");
        Console.WriteLine(Preco);
        Console.Write("Quantidade: ");
        Console.WriteLine(QuantidadeEstoque);
        Console.Write("Importado: ");
        string importadoRev = CondicaoImportacao ? "Sim" : "Não";
        Console.WriteLine(importadoRev);
        Console.Write("Categoria: ");
        Console.WriteLine(Categoria);
        Console.Write("Código: ");
        Console.WriteLine(CodProduto);
    }


}




public class ItemCura: Produto {
    public int PontosDeCura {get; private set;}
    public string EfeitosAdicionais {get; private set;}
 public  ItemCura (string nome, decimal preco, int quantidadeEstoque, bool condicaoImportcao, string categoria, string codProduto, int pontosDeCura, string efeitosadicionais) : base(nome, preco, quantidadeEstoque, condicaoImportcao, categoria, codProduto )  {
        PontosDeCura = pontosDeCura;
        EfeitosAdicionais = efeitosadicionais;
    }

    public override void BuscarInformacoes()
    {
        Console.WriteLine("");
        Console.Write("Produto: ");
        Console.WriteLine(Nome);
        Console.Write("Preço: ");
        Console.WriteLine(Preco);
        Console.Write("Quantidade: ");
        Console.WriteLine(QuantidadeEstoque);
        Console.Write("Importado: ");
        string importadoRev = CondicaoImportacao ? "Sim" : "Não";
        Console.WriteLine(importadoRev);
        Console.Write("Categoria: ");
        Console.WriteLine(Categoria);
        Console.Write("Código: ");
        Console.WriteLine(CodProduto);
        Console.Write("Pontos de Cura:");
        Console.WriteLine($"{PontosDeCura}");
        Console.Write("Efeitos adicionais:");
        Console.WriteLine($"{EfeitosAdicionais}");
    }
}


public class Pokeball: Produto {
    public int TaxaCaptura {get; private set;}
    public string EfeitosAdicionais {get; private set;}


    public Pokeball (string nome, decimal preco, int quantidadeEstoque, bool condicaoImportcao, string categoria, string codProduto, int taxaCaptura, string efeitosadicionais) : base(nome, preco, quantidadeEstoque, condicaoImportcao, categoria, codProduto )  {
        TaxaCaptura = taxaCaptura;
        EfeitosAdicionais = efeitosadicionais;
    }

    public override void BuscarInformacoes()
    {
        Console.WriteLine("");
        Console.Write("Produto: ");
        Console.WriteLine(Nome);
        Console.Write("Preço: ");
        Console.WriteLine(Preco);
        Console.Write("Quantidade: ");
        Console.WriteLine(QuantidadeEstoque);
        Console.Write("Importado: ");
        string importadoRev = CondicaoImportacao ? "Sim" : "Não";
        Console.WriteLine(importadoRev);
        Console.Write("Categoria: ");
        Console.WriteLine(Categoria);
        Console.Write("Código: ");
        Console.WriteLine(CodProduto);
        Console.Write("Taxa de Captura:");
        Console.WriteLine($"{TaxaCaptura}");
        Console.Write("Efeitos adicionais:");
        Console.WriteLine($"{EfeitosAdicionais}");
    }
}

class Program {
ItemCura revive = new ItemCura ("Revive", 150,  10,  true,  "Cura", "R", 50, "Reviver");
ItemCura potion = new ItemCura ("Potion", 50, 15, true, "Cura", "Ptn", 20, "Nenhum");
Pokeball pokeball = new Pokeball ("Pokeball", 100, 30, false, "Captura", "Pkb", 1, "Nenhum");
List<Produto> produtos = new List<Produto>();



void ExibirCabecalho()
{
    Console.WriteLine("==============================");
    Console.WriteLine("         POKECENTER");
    Console.WriteLine("==============================");
}

void Iniciar()
    {
        produtos.Add(revive);
        produtos.Add(potion);
        produtos.Add(pokeball);
        ExibirMenu();
    }


//Função para exibir menu de interação
void ExibirMenu(){
    string resposta;
do {
    ExibirCabecalho();
    Console.WriteLine("Bem-vindo ao POKECENTER! Como podemos ajudar?");
    Console.WriteLine("");
    Console.WriteLine("1- Comprar produto");
    Console.WriteLine("2- Consultar produto");
    Console.WriteLine("3- Ver estoque");
    Console.WriteLine("4- Repor estoque");
    Console.WriteLine("0- Sair");
    Console.WriteLine("");
    Console.Write("Selecione uma opção:");
    resposta = Console.ReadLine()!;

    switch (resposta)
    {
    case "1":
        Console.Clear();
        ExibirCabecalho();
        RealizarVenda(SelecionarProduto());
        Thread.Sleep(3000);
        Console.Clear();
        break;

    case "2":
        Console.Clear();
        ExibirCabecalho();
        MostrarInformacoesProduto(SelecionarProduto());
        Thread.Sleep(3000);
        Console.Clear();
        break;

    case "3":
        Console.Clear();
        ExibirCabecalho();
        MostrarEstoque(SelecionarProduto());
        Thread.Sleep(3000);
        Console.Clear();
        break;


    case "0":
        Console.Clear();
        Console.WriteLine("Foi um prazer ajudar! Estamos a disposição!");
        Thread.Sleep(3000);
        Console.Clear();
        break;

    case "4":
        Console.Clear();
        ReporProduto(SelecionarProduto());

        break;

    default:
        Console.WriteLine("Não há nenhuma informação correspondente. Favor informar uma das opções do menu.");
        break;

}
    } while (resposta != "0");
}


void ReporProduto(IReponivel item)
    {
    item.ReporEstoque();
    Console.Clear();
    }




void MostrarEstoque(IContavel item)
{   
    item.ContarEstoque();
    Thread.Sleep(3000);
    Console.Clear();
}


void MostrarProdutos()
{   int posicao;
    for (int i = 0;  i < produtos.Count; i++){  
    Console.WriteLine("Os nossos produtos são:");
    Console.WriteLine($"`{i+1} - {produtos[i].Nome}");
    }
}


Produto SelecionarProduto()
{   MostrarProdutos();
    Console.Write("Qual produto você deseja?");
    int resposta = int.Parse(Console.ReadLine()!);
    Produto produto = produtos[resposta];
    return produto;
}


public int IntermediarVenda()
    {
        Console.Write("Quantas unidades você deseja comprar?");
        int quantidadeComprada = int.Parse(Console.ReadLine()!);
        return quantidadeComprada;
    }

void RealizarVenda(IVendavel item)
{
    item.Vender(IntermediarVenda());
}


void MostrarInformacoesProduto(IBuscavel item)
{
    item.BuscarInformacoes();
}

static void Main (string[] args)
    {
        Program programa = new Program();
        programa.Iniciar();
    }


}






