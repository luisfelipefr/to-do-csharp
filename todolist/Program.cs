// See https://aka.ms/new-console-template for more information
using System.Text.Json;

public class Tarefa
{
    public string Descricao { get; set; }
    public bool Concluida { get; set; }

    public Tarefa(string descricao)
    {
        Descricao = descricao;
        Concluida = false;
    }
}

class Program
{
    
    static void Main(string[] args)
    {
        Console.WriteLine();
        Console.WriteLine("Seja bem vindo ao seu TO-DO!");
        Console.WriteLine("O que deseja fazer?");
        List<Tarefa> tarefas = new List<Tarefa>();
        while (true)
        {
            Console.WriteLine("1 - Criar Tarefa");
            Console.WriteLine("2 - Listar Tarefas");
            Console.WriteLine("3 - Concluir Tarefa");
            Console.WriteLine("4 - Listar Tarefas Concluidas");
            Console.WriteLine("5 - Sair");
            Console.WriteLine();
            
            
            string opcao = Console.ReadLine();
            
            switch (opcao)
            {
                case "1":  
                    Console.WriteLine("Digite a tarefa:");
                    Tarefa tarefa = new Tarefa($"{Console.ReadLine()}");
                    Console.WriteLine();
                    tarefas.Add(tarefa);
                    break;
                case "2":
                    if (tarefas.Count < 1)
                    {
                        Console.WriteLine("Você não tem tarefas");
                        continue;
                    }
                    Console.WriteLine("Suas tarefas são:");
                    Console.WriteLine();
                    for (int i = 0; i < tarefas.Count; i++)
                    {
                        if (tarefas[i].Concluida == false)
                        {
                            Console.WriteLine($"[{i}] {tarefas[i].Descricao}");
                            Console.WriteLine();
                        }
                    }
                    break;
                case "3":
                    Console.WriteLine("Escolha o numero de qual tarefa deseja concluir");
                    for (int i = 0; i < tarefas.Count; i++)
                    {
                        if (!tarefas[i].Concluida)
                        {
                            Console.WriteLine($"[{i}] {tarefas[i].Descricao}");
                            Console.WriteLine();
                        }
                    }
                    string numero = Console.ReadLine();
                    if (int.TryParse(numero, out int numeroConvert) && numeroConvert >= 0 && numeroConvert < tarefas.Count)
                    {
                        tarefas[numeroConvert].Concluida = true;
                        Console.WriteLine($"Sua tarefa concluida: {tarefas[numeroConvert].Descricao}");
                    }
                    else
                    {
                        Console.WriteLine("Não foi possivel concluir a tarefa");
                    }
                    break;
                case "4": 
                    Console.WriteLine("Suas tarefas concluidas são:");
                    for (int i = 0; i < tarefas.Count; i++)
                    {
                        if (tarefas[i].Concluida)
                        {
                            Console.WriteLine($"[{i}] {tarefas[i].Descricao}");
                            Console.WriteLine();
                        }
                    }
                    break;
                case "5":
                    Console.WriteLine("Até a proxima");
                    return;
                default:
                    Console.WriteLine("Nenhuma das opções foram selecionadas");
                    break;
            }
        }
    }
}