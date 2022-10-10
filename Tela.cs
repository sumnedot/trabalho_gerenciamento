using System;
using GerenciamentoProdutos.entities;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
namespace GerenciamentoProdutos
{
    class Tela
    {
        
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("|===============================|");
            Console.WriteLine("|            MENU               |");
            Console.WriteLine("|===============================|");
            Console.WriteLine("|1 - Cadastrar Produto          |");
            Console.WriteLine("|2 - Listar Produtos            |");
            Console.WriteLine("|3 - Sair                       |");
            Console.WriteLine("|===============================|");
        }
        public static Produto CadastrarProduto(){
            Console.Clear();
            Produto prod = new Produto();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("|       INFORME OS DADOS DO PRODUTO         |");
            Console.WriteLine("---------------------------------------------");
            Console.Write("Nome: ");
            prod.Nome = Console.ReadLine();
            Console.Write("Codigo: ");
            prod.Codigo = int.Parse(Console.ReadLine());
            Console.Write("Custo: R$");
            prod.Custo = double.Parse(Console.ReadLine());
            Console.Write("Venda: R$");
            prod.Venda = double.Parse(Console.ReadLine());
            Console.WriteLine("\nInformações gravadas com sucesso!\n");

            return prod;
        }
        
        public static void ListaProdutos(Produtos p){
            Console.Clear();
            Console.WriteLine("      Nome          |         Codigo       |          Custo      |           Venda       ");
            foreach (Produto prod in p.ProdutosLista){
                Console.WriteLine(prod.ToString());
            }
            Console.WriteLine("\n\nAperte ENTER para voltar ao Menu");
            Console.ReadLine();
        }
    }
}