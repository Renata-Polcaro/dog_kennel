using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao_projeto3
{
    [System.Serializable]
    class OutroAnimal: Animais, IAnimals
    {
        public string tipoAnimal;
        private int quantidade;

        public OutroAnimal(string tipoAnimal, string nome, string raca, string porte)
        {
            this.tipoAnimal = tipoAnimal;
            this.nome = nome;
            this.raca = raca;
            this.porte = porte;
        }

        public void Exibir()
        {
            Console.WriteLine("Cadastro de animal diferente");
            Console.WriteLine($"Tipo de animal: {tipoAnimal}");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Raça: {raca}");
            Console.WriteLine($"Porte: {porte}");
            Console.WriteLine($"Quantidade: {quantidade}");
            Console.WriteLine("====================");
        }

        public void AdicionarEntrada()
        {

        }

        public void AdicionarSaida()
        {

        }
    }
}
