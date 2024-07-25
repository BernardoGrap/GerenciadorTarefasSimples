using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorTarefas
{
    class Program
    {
        static List<Tarefa> tarefas = new List<Tarefa>();
        static string ordem = "criação"; // Pode ser "criação" ou "alfabética"

        static void Main(string[] args)
        {
            while (true)
            {
                ExibirMenu();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarTarefa();
                        break;
                    case "2":
                        ListarTarefas();
                        break;
                    case "3":
                        RemoverTarefa();
                        break;
                    case "4":
                        ConfigurarOrdem();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para tentar novamente.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ExibirMenu()
        {
            Console.WriteLine("\nGerenciador de Tarefas");
            Console.WriteLine("1. Adicionar Tarefa");
            Console.WriteLine("2. Listar Tarefas");
            Console.WriteLine("3. Remover Tarefa");
            Console.WriteLine("4. Configurar Ordem de Listagem");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");
        }

        static void AdicionarTarefa()
        {
            Console.Write("\nDigite o nome da tarefa: ");
            string descricao = Console.ReadLine();
            tarefas.Add(new Tarefa { Descricao = descricao, DataCriacao = DateTime.Now });
            Console.WriteLine("Tarefa adicionada com sucesso! Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        static void ListarTarefas()
        {
            Console.WriteLine();
            if (tarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa adicionada.");
            }
            else
            {
                List<Tarefa> tarefasOrdenadas = ObterTarefasOrdenadas();

                Console.WriteLine("Lista de Tarefas:");
                for (int i = 0; i < tarefasOrdenadas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tarefasOrdenadas[i].Descricao} (Criada em: {tarefasOrdenadas[i].DataCriacao})");
                }
            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        static List<Tarefa> ObterTarefasOrdenadas()
        {
            return ordem == "alfabética" ? tarefas.OrderBy(t => t.Descricao).ToList() : tarefas;
        }

        static void RemoverTarefa()
        {
            Console.WriteLine();
            List<Tarefa> tarefasOrdenadas = ObterTarefasOrdenadas();

            if (tarefasOrdenadas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa para remover. Pressione qualquer tecla para voltar ao menu.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Lista de Tarefas:");
            for (int i = 0; i < tarefasOrdenadas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tarefasOrdenadas[i].Descricao} (Criada em: {tarefasOrdenadas[i].DataCriacao})");
            }

            Console.Write("\nDigite o número da tarefa que deseja remover: ");
            int indice;
            if (int.TryParse(Console.ReadLine(), out indice) && indice > 0 && indice <= tarefasOrdenadas.Count)
            {
                tarefas.Remove(tarefasOrdenadas[indice - 1]);
                Console.WriteLine("Tarefa removida com sucesso! Pressione qualquer tecla para voltar ao menu.");
            }
            else
            {
                Console.WriteLine("Número inválido. Pressione qualquer tecla para tentar novamente.");
            }
            Console.ReadKey();
        }

        static void ConfigurarOrdem()
        {
            Console.WriteLine("\nConfigurar Ordem de Listagem:");
            Console.WriteLine("1. Ordem de Criação");
            Console.WriteLine("2. Ordem Alfabética (A-Z)");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    ordem = "criação";
                    break;
                case "2":
                    ordem = "alfabética";
                    break;
                default:
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    class Tarefa
    {
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}