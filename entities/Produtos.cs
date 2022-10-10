using System;
using GerenciamentoProdutos.entities;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
namespace GerenciamentoProdutos.entities
{
    public class Produtos
    {
        public List<Produto> ProdutosLista { get; set; }
        public void AdicionarProduto(Produto p)
        {
            ProdutosLista.Add(p);
        }
        public Produtos()
        {
            ProdutosLista = new List<Produto>();
        }
        public string RetornaNomeArquivo(){
            string NomeArquivo = "dados";
            string Diretorio = Directory.GetCurrentDirectory();

            string ArquivoComCaminho = Diretorio + @"\" + NomeArquivo + ".xml"; 
            return ArquivoComCaminho; 
        }
        public string GravarProduto(){
            string NomeArquivo = RetornaNomeArquivo();
            
            if (File.Exists(NomeArquivo) == true)
            {
                File.Delete(NomeArquivo);
            }

            StreamWriter sw = new StreamWriter(NomeArquivo);
            sw.WriteLine("<XML>");
            sw.WriteLine("    <Produtos>");
            
            int contaproduto = 1;
            
            foreach (Produto prod in ProdutosLista)
            {   
                sw.WriteLine("        <Prod" + contaproduto +">");
                sw.WriteLine("            <Nome>" + prod.Nome + "</Nome>");
                sw.WriteLine("            <Codigo>" + prod.Codigo  + "</Codigo>");
                sw.WriteLine("            <Custo>" + prod.Custo.ToString("F2")  + "</Custo>");
                sw.WriteLine("            <Venda>" + prod.Venda.ToString("F2")  + "</Venda>");
                sw.WriteLine("        </Prod" + contaproduto +">");
                contaproduto ++;
            }
            sw.WriteLine("    </Produtos>");
            sw.WriteLine("</XML>");
            sw.Close();
            return "";
        }
        public void CarregarXml(string xmls){
            string xml = File.ReadAllText(xmls);
            int ContaProduto = 1;
            string TagProd = "Prod" + ContaProduto;
            string TagProduto = LerTag(TagProd,xml);

            while (TagProduto !=  "")
            {
                Produto prod = new Produto();
                prod.Nome = LerTag("Nome",TagProduto);
                prod.Codigo = int.Parse(LerTag("Codigo",TagProduto));
                prod.Custo = double.Parse(LerTag("Custo",TagProduto));
                prod.Venda = double.Parse(LerTag("Venda",TagProduto));

                AdicionarProduto(prod);

                ContaProduto ++;
                TagProd = "Prod" + ContaProduto;
                TagProduto = LerTag(TagProd,xml);
            }
        }
        private string LerTag(string Tag, string xml)
        {
            int piTag = xml.IndexOf(Tag);
            int pfTag = xml.IndexOf("/" + Tag);
            piTag += Tag.Length + 1;
            pfTag = pfTag - 1;
            int comprimento = pfTag - piTag;
            string retorno = "";
            if(comprimento > 0){
                retorno = xml.Substring(piTag,comprimento);
            }else{
                retorno = "";
            }
            return retorno;
        }
    }
}