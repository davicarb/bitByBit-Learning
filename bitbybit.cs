using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace biyByBit
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. CONFIGURAÇÃO (Faz uma vez só ao abrir o programa, por isso está fora do loop while )
            string diretorioLearning = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resumos");
            string jsonPath = Path.Combine(diretorioLearning, "jsonlearningtopics.json");

            // Lê o JSON
            string jsonString = File.ReadAllText(jsonPath);
            List<LearningTopic> learningTopics = JsonSerializer.Deserialize<List<LearningTopic>>(jsonString) ?? new List<LearningTopic>();

            // Ajusta os caminhos dos arquivos .txt
            foreach (var learningTopic in learningTopics)
            {
                learningTopic.CaminhoArquivo = Path.Combine(diretorioLearning, learningTopic.CaminhoArquivo);
            }


            bool rodando = true;
            while (rodando)
            {

                Console.Clear();
                Console.WriteLine("\n\n\n==== bitByBit ====\n");
                Console.WriteLine("Bem-vindo ao bitByBit.");
                Console.WriteLine("Este software te ensina a aprender sobre software...\n");
                Console.WriteLine("Só que de uma forma melhor.\n");
                Console.WriteLine("Bit by bit.\n");
                Console.WriteLine("\n");
                Console.WriteLine("Sobre qual tópico você gostaria de aprender hoje?");

                int mostrarMenu = ExibeMenu(learningTopics);

                if (mostrarMenu > 0 && mostrarMenu <= learningTopics.Count)
                {
                    //pega a civilização na posição correta
                    LearningTopic escolhido = learningTopics[mostrarMenu - 1];

                    escolhido.ExibirResumo();
                }
                else if (mostrarMenu == 0)
                {
                    rodando = false;
                }
            }
        }

        static int ExibeMenu(List<LearningTopic> lista)
        {
            Console.WriteLine("==== Tópicos sobre Engenharia de Software: ====\n");

            for (int i = 0; i < lista.Count; i++) // esse for roda até o tamanho da lista (abstração do codigo, melhor logica)
            {
                Console.WriteLine($"{i + 1}. {lista[i].Nome}");
            }

            Console.WriteLine("0. SAIR \n");
            Console.WriteLine("Insira a opção: ");

            bool valid = int.TryParse(Console.ReadLine(), out int mostrarMenu);

            if (!valid || mostrarMenu < 0 || lista.Count > 10)
            {
                while (!valid || mostrarMenu < 0 || lista.Count > 10)
                {

                    Console.WriteLine("Opção inválida.\n");
                    Console.WriteLine("Insira novamente: ");

                    valid = int.TryParse(Console.ReadLine(), out mostrarMenu);

                    if (valid && mostrarMenu >= 0 && mostrarMenu <= 10)
                    {
                        return mostrarMenu;
                    }
                }
            }

            else if (mostrarMenu == 0)
            {
                return mostrarMenu;
            }

            else
            {
                return mostrarMenu;
            }

            return 0;
        }

    }

    public class LearningTopic
    {
        public string Nome { get; set; }
        public string CaminhoArquivo { get; set; }

        // CONSTRUTOR

        public LearningTopic() { } // construtor vazio, só p ler o .JSON
        public LearningTopic(string nomeRecebido, string caminhoRecebido)
        {
            Nome = nomeRecebido;
            CaminhoArquivo = caminhoRecebido;
        }



        public void ExibirResumo() // pq este método está dentro do public class? :/
        {
            Console.Clear();
            Console.WriteLine($"=== LENDO SOBRE: {Nome.ToUpper()} ===\n");

            // teste para se ele n achar o arquivo!  Console.WriteLine("TESTE Procurando em: " + Path.GetFullPath(CaminhoArquivo));
            
            if (File.Exists(CaminhoArquivo))
            {
                // Le o TXT INTEIRO de uma vez só
                Console.Clear();
                string conteudo = File.ReadAllText(this.CaminhoArquivo);
                Console.WriteLine(conteudo);
            }
    
            else
            {
                Console.WriteLine($"Erro: Arquivo não encontrado.");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");

            Console.ReadKey();
        }

    }
}