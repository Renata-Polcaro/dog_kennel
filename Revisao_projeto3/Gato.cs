using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao_projeto3
{
    [System.Serializable]
    class Gato: Animais, IAnimals
    {
        private int quantidade;

        public Gato(string nome, string porte, string raca)
        {
            this.nome = nome;
            this.porte = porte;
            this.raca = raca;
        }

        public void Exibir()
        {
            Console.WriteLine("Cadastro de Gato");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Raça: {raca}");
            Console.WriteLine($"Porte: {porte}");
            Console.WriteLine($"Quantidade: {quantidade}");
            Console.WriteLine("====================");
        }

        public void AdicionarEntrada()
        {
            //Console.Clear();
           // Console.WriteLine($"Entrada de {nome}");
            Console.Write("Digite a quantidade de entrada: ");
            int estoque = int.Parse(Console.ReadLine());
            quantidade += estoque;
            Console.WriteLine("Entrada efetuada com sucesso!");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            //Console.Clear();
           // Console.WriteLine($"Saída de {nome}");
            Console.Write("Digite a quantidade de saída: ");
            int estoque = int.Parse(Console.ReadLine());
            quantidade -= estoque;
            Console.WriteLine("Saída efetuada com sucesso!");
            Console.ReadLine();
        }
    }
}
