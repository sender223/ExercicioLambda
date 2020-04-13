using System;
using System.Collections.Generic;
using ExercicioLambda.Entidades;
using System.IO;
using System.Globalization;
using System.Linq;

namespace ExercicioLambda {
    class Program {
        static void Main(string[] args) {

            Console.Write("Entre com o caminho completo do arquivo: ");
            string caminho = Console.ReadLine();

            List<Produto> lista = new List<Produto>();

            using (StreamReader sr = File.OpenText(caminho)) {
                while (!sr.EndOfStream) {
                    //separando os campos com vetor
                    string[] camposProduto = sr.ReadLine().Split(',');
                    //pegando o campo nome
                    string nome = camposProduto[0];
                    //pegando o campo preco
                    double preco = double.Parse(camposProduto[1], CultureInfo.InvariantCulture);
                    //criando uma lista com o nome e o preco
                    lista.Add(new Produto(nome, preco));             

                }
            }
            //para encontrar a média do produto. transformamos uma lista em uma lista de double
            //e utilizando o defaultIfEmpty para colocar 0.0 caso retorne vazio.
            var media = lista.Select(p => p.Preco).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Preço Médio = " + media.ToString("F2", CultureInfo.InvariantCulture));
            //pegar os nomes onde o preço é abaixo do preço médio e em ordem descrecente por nome.
            var nomes = lista.Where(p => p.Preco < media).OrderByDescending(p => p.Nome).Select(p => p.Nome);
            //fazendo um foreach para percorrer cada nome.
            foreach (string nome in nomes) {
                Console.WriteLine(nome);
            }


        }
    }
}
