using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Revisao_projeto3
{
	[System.Serializable]
	class Program
	{
		static List<IAnimals> animais = new List<IAnimals>();
		enum Menu {Listagem = 1, Cadastrar, Remover, Entrada, Saida, Sair };
		static void Main(string[] args)
		{
			Carregar();
			bool sair = false;
			Console.WriteLine("GERENCIADOR DE ANIMAIS");
			Console.WriteLine("1-Listagem\n2-Cadastrar animal\n3-Remover animal\n4-Efetuar entrada\n5-Efetuar saída\n6-Sair");
			int opcaoSelecionada = int.Parse(Console.ReadLine());
			Menu opcao = (Menu)opcaoSelecionada;
			while(!sair)
			{
				switch (opcao)
				{
					case Menu.Listagem:
						Listagem();
						break;
					case Menu.Cadastrar:
						Cadastrar();
						break;
					case Menu.Remover:
						break;
					case Menu.Entrada:
						break;
					case Menu.Saida:
						break;
					case Menu.Sair:
						sair = true;
						break;
				}
			}
		}

		static void Cadastrar()
		{
			Console.WriteLine("========== CADASTRO DE ANIMAL ==========\n");
			Console.WriteLine("1-Cachorro\n2-Gato\n3-Outro Animal");
			int opcao = int.Parse(Console.ReadLine());
			switch (opcao)
			{
				case 1:
				   // Console.Clear();
					CadastroCachorro();
					break;
				case 2:
				   // Console.Clear();
					CadastroGato();
					break;
				case 3:
				   // Console.Clear();
					OutroAnimal();
					break;
			}
		}

		static void Listagem()
		{
			int i = 0;
  
			Console.WriteLine("LISTA DE ANIMAIS CADASTRADOS");
			if (animais == null || animais.Count == 0)
			{
				Console.WriteLine("Não existem animais cadastrados!");
				Console.ReadLine();
			}
			else
			{
				foreach(IAnimals animal in animais)
				{
					Console.WriteLine("ID: " + i);
					animal.Exibir();
					i++;
				}
			} 
		}

		static void CadastroCachorro()
		{
			Console.WriteLine("Nome: ");
			string nome = Console.ReadLine();
			Console.WriteLine("Raça: ");
			string raca = Console.ReadLine();
			Console.WriteLine("Porte: ");
			string porte = Console.ReadLine();
			Cachorro cadastro = new Cachorro(nome,raca,porte);
			animais.Add(cadastro);
			Salvar();
			Console.WriteLine("Cãozinho cadastrado com sucesso!");
			Console.ReadLine();
		}

		static void CadastroGato()
		{
			Console.WriteLine("Nome: ");
			string nome = Console.ReadLine();
			Console.WriteLine("Raça: ");
			string raca = Console.ReadLine();
			Console.WriteLine("Porte: ");
			string porte = Console.ReadLine();
			Gato cadastro = new Gato(nome, raca, porte);
			animais.Add(cadastro);
			Salvar();
			Console.WriteLine("Gatinho cadastrado com sucesso!");
			Console.ReadLine();
		}

		static void OutroAnimal()
		{
			Console.WriteLine("Tipo de animal: ");
			string tipoAnimal = Console.ReadLine();
			Console.WriteLine("Nome: ");
			string nome = Console.ReadLine();
			Console.WriteLine("Raça: ");
			string raca = Console.ReadLine();
			Console.WriteLine("Porte: ");
			string porte = Console.ReadLine();
			OutroAnimal cadastro = new OutroAnimal(tipoAnimal, nome, raca, porte);
			animais.Add(cadastro);
			Salvar();
			Console.WriteLine("Animal cadastrado com sucesso!");
			Console.ReadLine();
		}

		static void Salvar()
		{
			FileStream stream = new FileStream("CadastrodeAnimais.txt", FileMode.OpenOrCreate);
			BinaryFormatter encoder = new BinaryFormatter();
			
			encoder.Serialize(stream, animais);

			stream.Close();
		}

		static void Carregar()
		{
			FileStream stream = new FileStream("CadastrodeAnimais.txt", FileMode.OpenOrCreate);
			BinaryFormatter encoder = new BinaryFormatter();

			try
			{
				animais = (List<IAnimals>)encoder.Deserialize(stream);

				if(animais == null)
				{
					animais = new List<IAnimals>();
				}
			}
			catch(Exception e)
			{
				animais = new List<IAnimals>();
			}

			stream.Close();
		}
	}
}