using System;
using System.Collections;

namespace civilipedia
{
    class Program
    {
        static void Main(string[] args)
        {
            bool rodando = true;

            while (rodando)
            {

                Console.Clear();

                Console.WriteLine("\n\n\n==== CiviliPedia ====\n");
                Console.WriteLine("Seja bem-vindo a CiviliPedia!");
                Console.WriteLine("Se você gosta de história...");
                Console.WriteLine("Aqui você pode aprender sobre ela, e mais um pouco.\n");
                Console.WriteLine("Até agora o sistema conta com 10 civilizações, onde você pode ter um breve resumo sobre elas e como elas impactam o seu dia a dia hoje.\n");
                Console.WriteLine("\n");
                Console.WriteLine("Qual civilização gostaria de aprender sobre? (0 para sair, caso já tenha lido bastante :) ");

                int mostrarMenu = ExibeMenu();

                switch (mostrarMenu)
                {
                    case 1:
                        // trocar por um caminho que funcione em qualquer pc em todos os cases
                        Civilizacao egipcios = new Civilizacao("Egípcios", @"C:\Users\davic\Desktop\CiviliPedia\egito.txt.txt");
                        egipcios.ExibirResumo();
                        break;
                    
                    case 2:

                        Civilizacao romanos = new Civilizacao("Romanos", @"C:\Users\davic\Desktop\CiviliPedia\romanos.txt.txt");
                        romanos.ExibirResumo();
                        break;
                    case 3:

                        Civilizacao babilonicos = new Civilizacao("Babilonicos", @"C:\Users\davic\Desktop\CiviliPedia\babilonicos.txt.txt");
                        babilonicos.ExibirResumo();
                        break;
                    case 4:

                        Civilizacao gregos = new Civilizacao("Gregos", @"C:\Users\davic\Desktop\CiviliPedia\gregos.txt.txt");
                        gregos.ExibirResumo();
                        break;
                    case 5:

                        Civilizacao chineses = new Civilizacao("Chineses", @"C:\Users\davic\Desktop\CiviliPedia\chineses.txt.txt");
                        chineses.ExibirResumo();
                        break;
                    case 6:

                        Civilizacao maias = new Civilizacao("Maias", @"C:\Users\davic\Desktop\CiviliPedia\maias.txt.txt");
                        maias.ExibirResumo();
                        break;
                    case 7:

                        Civilizacao indos = new Civilizacao("Indos", @"C:\Users\davic\Desktop\CiviliPedia\indos.txt.txt");
                        indos.ExibirResumo();
                        break;
                    case 8:

                        Civilizacao persas = new Civilizacao("Persas", @"C:\Users\davic\Desktop\CiviliPedia\persas.txt.txt");
                        persas.ExibirResumo();
                        break;
                    case 9:

                        Civilizacao fenicios = new Civilizacao("Fenicios", @"C:\Users\davic\Desktop\CiviliPedia\fenicios.txt.txt");
                        fenicios.ExibirResumo();
                        break;
                    case 10:

                        Civilizacao astecas = new Civilizacao("Astecas", @"C:\Users\davic\Desktop\CiviliPedia\astecas.txt.txt");
                        astecas.ExibirResumo();
                        break;


                        // caso 0 = sai do programa
                    case 0:
                        Console.WriteLine("Saindo...");
                        rodando = false;
                        break;
                }
            }
        }

        static int ExibeMenu()
        {
            Console.WriteLine("==== Qual das civilizações a seguir gostaria de saber sobre? ====\n");
            Console.WriteLine("1. Egípcios");
            Console.WriteLine("2. Romanos");
            Console.WriteLine("3. Babilonicos");
            Console.WriteLine("4. Gregos");
            Console.WriteLine("5. Chineses");
            Console.WriteLine("6. Maias");
            Console.WriteLine("7. Indos");
            Console.WriteLine("8. Persas");
            Console.WriteLine("9. Fenicios");
            Console.WriteLine("10. Astecas\n");
            Console.WriteLine("0. SAIR\n");

            Console.WriteLine("Insira a opção: ");
            bool valid = int.TryParse(Console.ReadLine(), out int mostrarMenu);

            if (!valid || mostrarMenu < 0 || mostrarMenu > 10)
            {
                while (!valid || mostrarMenu < 0 || mostrarMenu > 10)
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

    public class Civilizacao
    {
        public string Nome { get; set; }
        public string CaminhoArquivo { get; set; }

        // CONSTRUTOR

        public Civilizacao(string nomeRecebido, string caminhoRecebido)
        {
            Nome = nomeRecebido;
            CaminhoArquivo = caminhoRecebido;
        }

        public void ExibirResumo() // pq este método está dentro do public class? :/
        {
            Console.Clear();
            Console.WriteLine($"=== LENDO SOBRE: {Nome.ToUpper()} ===\n");

            if (File.Exists(CaminhoArquivo))
            {
                // Le o TXT INTEIRO de uma vez só

                string conteudo = File.ReadAllText(CaminhoArquivo);
                Console.WriteLine(conteudo);
            }

            else
            {
                Console.WriteLine($"Erro: Arquivo não encontrado.");
            }

            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");

            Console.ReadKey();
        }
    }
}