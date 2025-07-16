public class Program
{
    public static void Main(string[] args)
    {
        var ingrediente = new Ingrediente();
        Produto produto = new Produto();
        bool continuar = true;
        Console.WriteLine("Informe o lucro desejado (em porcentagem, por exemplo, digite 10 para 10%):");
        produto.LucroDesejado = double.Parse(Console.ReadLine()) / 100;
        while (continuar)
        {
            Console.WriteLine("Digite o nome do ingrediente:");
            ingrediente.Nome = Console.ReadLine();

            Console.WriteLine("Digite o preço do ingrediente:");
            ingrediente.Preco = double.Parse(Console.ReadLine());

            produto.Ingredientes.Add(ingrediente);

            Console.WriteLine("Deseja adicionar outro ingrediente? (s/n)");
            string resposta = Console.ReadLine();
            continuar = resposta.ToLower() == "s";

            if (continuar)
                ingrediente = new Ingrediente();
        }
        Console.WriteLine("Digite a quantidade de produto gerada para esta quantidade de ingredientes:");
        produto.Quantidade = double.Parse(Console.ReadLine());

        Console.WriteLine($"O preço sugerido para um lucro de {produto.LucroDesejado * 100}% é: R$ {produto.CalcularPreco()} por unidade.");
        Console.WriteLine("Ingredientes utilizados:");
        foreach (var ing in produto.Ingredientes)
        {
            Console.WriteLine($"Ingrediente: {ing.Nome}, Preço: R$ {ing.Preco}");
        }
    }

}


public class Ingrediente
{
    public string Nome { get; set; }
    public double Preco { get; set; }
}

public class Produto
{
    public string Nome { get; set; }
    public double Quantidade { get; set; }
    public double LucroDesejado { get; set; }
    public List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();

    public Produto(int quantidade = 0)
    {
        Quantidade = quantidade;
    }
    public double CalcularPreco()
    {
        double precoTotal = 0;
        foreach (var ingrediente in Ingredientes)
        {
            precoTotal += ingrediente.Preco + (ingrediente.Preco * LucroDesejado);
        }
        double precoUnitario = precoTotal / Quantidade;
        return Math.Round(precoUnitario, 2);
    }
}