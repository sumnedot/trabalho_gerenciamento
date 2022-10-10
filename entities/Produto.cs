using System;
using System.Globalization;
namespace GerenciamentoProdutos.entities
{
    public class Produto
    {
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public double Custo { get; set; }
        public double Venda { get; set; }
        public override string ToString()
        {
            return String.Format("{0,10}{1,25}{2,25}{3,22}", Nome, Codigo, Custo.ToString("F2", CultureInfo.InvariantCulture), Venda.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}