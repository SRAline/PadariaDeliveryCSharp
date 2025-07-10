using System;
using System.Collections.Generic;

public class Produto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }

    public Produto(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }
}

public class Cliente
{
    public string Nome { get; set; }
    public string Endereco { get; set; }

    public Cliente(string nome, string endereco)
    {
        Nome = nome;
        Endereco = endereco;
    }
}

public class Pedido
{
    public Cliente Cliente { get; set; }
    public List<Produto> Produtos { get; set; } = new List<Produto>();

    public Pedido(Cliente cliente)
    {
        Cliente = cliente;
    }

    public void AdicionarProduto(Produto produto)
    {
        Produtos.Add(produto);
    }

    public decimal CalcularTotal()
    {
        decimal total = 0;
        foreach (var produto in Produtos)
        {
            total += produto.Preco;
        }
        return total;
    }
}

public class Program
{
    public static void Main()
    {
        Produto pao = new Produto("Pão", 2.50m);
        Produto bolo = new Produto("Bolo de Chocolate", 15.00m);
        Produto cafe = new Produto("Café", 5.00m);

        Cliente cliente = new Cliente("João Silva", "Rua das Flores, 123");

        Pedido pedido = new Pedido(cliente);
        pedido.AdicionarProduto(pao);
        pedido.AdicionarProduto(bolo);
        pedido.AdicionarProduto(cafe);

        Console.WriteLine($"Pedido para: {cliente.Nome}");
        Console.WriteLine($"Endereço: {cliente.Endereco}");
        Console.WriteLine("\nProdutos no pedido:");
        foreach (var produto in pedido.Produtos)
        {
            Console.WriteLine($"- {produto.Nome}: R${produto.Preco:F2}");
        }

        decimal total = pedido.CalcularTotal();
        Console.WriteLine($"
Total do pedido: R${total:F2}");
    }
}