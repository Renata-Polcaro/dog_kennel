﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao_projeto3
{
    [System.Serializable]
    class Cachorro: Animais, IAnimals
    {
        private int quantidade;

        public Cachorro(string nome, string raca, string porte)
        {
            this.nome = nome;
            this.raca = raca;
            this.porte = porte;
        }

        public void Exibir()
        {
            Console.WriteLine("Cadastro de Cachorro");
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