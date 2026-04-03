# bitByBit Learning, written in C#

02-04-2026

Este projeto foi desenvolvido por Davi, estudante do 1º
semestre de ADS Na UNISANTA (Universidade Santa Cecília).

Ele usa tecnologias mais modernas, como um arquivo .JSON que desserializa
o resto dos arquivos .txt (uma aplicação console que interage com um banco
de dados local.) e um loop for, utilizando uma lista, para mostrar o menu
de uma maneira mais tecnológica.

E, com essa nova forma de exibir o menu, adicionar novos tópicos de estudos
futuramente (ou subtópicos), se torna uma tarefa muito mais simples, pois
só é necessário alterar o .json e os .txt. O programa já lê o json e cria
os objetos por conta própria!


A ideia era criar um programa que auxiliasse os alunos do 1º Semestre
de ADS ( a mim também) a lembrar e estudar os conteúdos de uma forma
mais rápida e prática, induzindo a pessoa a tentar pensar como um computador
pensa.

E também, claro: utilizar software para aprender software. Esse era o ponto
principal para o desesnvolvimento deste programa.

Também utilizei POO para abstrair o código, criando a classe
LearningTopic, que tem objetos como:
"Engenharia de Software";
"Algoritmos e Lógica";
"Variáveis e dados";
"Compiladores e interpretadores";
"Estruturas de decisão";
"Estruturas de repetição";
"IDE e VSCODE";
"Versionamento com Git";
"POO";
"Clean code";

(E, futuramente, planejo em adicionar mais matérias, ao longo do que vou
aprendendo na faculdade e desenvolvendo durante o periodo de aprendizado.)

Essa classe LearningTopic tem duas propriedaes: Nome e CaminhoArquivo.

Exemplo:
Classe: LearningTopic
Objeto:
Nome: "Engenharia de Software
CaminhoArquivo: "@caminhodoarquivo/generico"


Tem também um método chamado ExibirResumo(), que exibe o resumo
do LearningTopic escolhido.

O LearningTopic escolhido acontece na função:

    static int ExibeMenu (List<LearningTopic> lista)

Ali, eu mostro o Menu com todas as opções possíveis para a pessoa
aprender (10 opções) utilizando um loop for.

        for (int i = 0; i < lista.Count; i++) // esse for roda até o tamanho da lista (abstração do codigo, melhor logica)
        {
             Console.WriteLine($"{i + 1}. {lista[i].Nome}");
         }

O interessante de utilizar o loop for foi que eu abstraí a função.
Ao invés de colocar vários Console.WriteLine exibindo todas as opções,
usei a linha de código:

    Console.WriteLine($"{i + 1}. {lista[i].Nome}");

Aqui, o i + 1 está presente pois as listas no C# (assim como os arrays)
sempre se iniciam no número 0, e, no menu, temos que a lista se inicia no
1.

Ou seja: tenho que adicionar um ao meu índice para mostrar
corretamente a opção e, depois, retornar o valor int correto
para a variável mostrarMenu, utilizada na função main, para aí
sim o programa puxar o objeto correto e mostrar o objeto correto
na função ExibirResumo();

{lista[i].Nome} diz:

Para o objeto na posição [i] na lista do JSON, mostre o nome.

Após isso, tenho uma verificação utilizando bool valid utilizando TryParse,
garantindo que o programa não quebre se o usuário digitar um "a" sem querer.
Ele pede o valor até que o valor esteja entre 0 e 10.

É isso!
Espero que gostem :)

Futuramente vou começar a colocar os códigos em inglês...

:D
