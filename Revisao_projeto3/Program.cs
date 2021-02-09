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
        enum Menu { Listagem = 1, Cadastrar, Remover, Entrada, Saida, Sair };
        static void Main(string[] args)
        {
            Carregar();
            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("GERENCIADOR DE ANIMAIS");
                Console.WriteLine("1-Listagem\n2-Cadastrar animal\n3-Remover animal\n4-Efetuar entrada\n5-Efetuar saída\n6-Sair");
                int opcaoSelecionada = int.Parse(Console.ReadLine());
                Menu opcao = (Menu)opcaoSelecionada;

                if (opcaoSelecionada > 0 && opcaoSelecionada < 7)
                {
                    switch (opcao)
                    {
                        case Menu.Listagem:
                            Listagem();
                            Console.ReadLine();
                            break;
                        case Menu.Cadastrar:
                            Cadastrar();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saida:
                            Saida();
                            break;
                        case Menu.Sair:
                            sair = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida!");
                    Console.ReadLine();
                    sair = false;
                }
                Console.Clear();
            }
        }

        static void Cadastrar()
        {
            Console.Clear();
            Console.WriteLine("========== CADASTRO DE ANIMAL ==========\n");
            Console.WriteLine("1-Cachorro\n2-Gato\n3-Outro Animal");
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    //Console.Clear();
                    CadastroCachorro();
                    break;
                case 2:
                    //Console.Clear();
                    CadastroGato();
                    break;
                case 3:
                    //Console.Clear();
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
                foreach (IAnimals animal in animais)
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
            Cachorro cadastro = new Cachorro(nome, raca, porte);
            animais.Add(cadastro);
            Salvar();
            Console.WriteLine("Cãozinho cadastrado com sucesso!");
            Console.ReadLine();
            Console.Write("Gostaria de adicionar outro cãozinho? 'S' para Sim e 'N' para não: ");
            char opcao = char.Parse(Console.ReadLine());
            try
            {
                if (opcao == 'S' || opcao == 's')
                {
                    CadastroCachorro();
                }
            }
            catch
            {
                Console.WriteLine("Opção Incorreta!");
            }
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
            Console.Write("Gostaria de adicionar outro gatinho? 'S' para Sim e 'N' para não: ");
            char opcao = char.Parse(Console.ReadLine());
            try
            {
                if (opcao == 'S' || opcao == 's')
                {
                    CadastroGato();
                }
            }
            catch
            {
                Console.WriteLine("Opção Incorreta!");
            }
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
            Console.Write("Gostaria de adicionar outro animalzinho? 'S' para Sim e 'N' para não: ");
            char opcao = char.Parse(Console.ReadLine());
            try
            {
                if (opcao == 'S' || opcao == 's')
                {
                    OutroAnimal();
                }
            }
            catch
            {
                Console.WriteLine("Opção Incorreta!");
            }
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

                if (animais == null)
                {
                    animais = new List<IAnimals>();
                }
            }
            catch (Exception e)
            {
                animais = new List<IAnimals>();
            }

            stream.Close();
        }

        static void Remover()
        {
            Listagem();
            Console.Write("Digite o ID que gostaria de remover: ");
            int id = int.Parse(Console.ReadLine());
            try
            {
                if (id >= 0 && id < animais.Count)
                {
                    animais.RemoveAt(id);
                    Salvar();
                    Console.WriteLine("ID removido com sucesso!");
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("ID incorreto!");

                }
                Console.Write("Gostaria de remover outro ID? 'S' para Sim e 'N' para não: ");
                char opcao = char.Parse(Console.ReadLine());
                if (opcao == 'S' || opcao == 's')
                {
                    Remover();
                }
            }
            catch
            {
                Console.WriteLine("ID incorreto!");
            }
        }

        static void Entrada()
        {
            Listagem();
            Console.Write("Informe o ID que gostaria de efetuar a entrada: ");
            int id = int.Parse(Console.ReadLine());
            try
            {
                if(id >= 0 && id < animais.Count)
                {
                    animais[id].AdicionarEntrada();
                    Salvar();
                }
                else
                {
                    Console.WriteLine("ID incorreto!");

                }
                Console.Write("Gostaria de efetuar outra entrada? 'S' para Sim e 'N' para não: ");
                char opcao = char.Parse(Console.ReadLine());
                if (opcao == 'S' || opcao == 's')
                {
                    Entrada();
                }
            }
            catch
            {
                Console.WriteLine("ID incorreto!");
            }
        }

        static void Saida()
        {
            Listagem();
            Console.Write("Informe o ID que gostaria de efetuar a saída/baixa: ");
            int id = int.Parse(Console.ReadLine());
            try
            {
                if (id >= 0 && id < animais.Count)
                {
                    animais[id].AdicionarSaida();
                    Salvar();
                }
                else
                {
                    Console.WriteLine("ID incorreto!");

                }
                Console.Write("Gostaria de efetuar outra entrada? 'S' para Sim e 'N' para não: ");
                char opcao = char.Parse(Console.ReadLine());
                if (opcao == 'S' || opcao == 's')
                {
                    Saida();
                }
            }
            catch
            {
                Console.WriteLine("ID incorreto!");
            }
        }
    }
}