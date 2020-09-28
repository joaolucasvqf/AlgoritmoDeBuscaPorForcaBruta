using System;
using System.Text;

namespace BuscaPorForcaBruta
{
    class Program
    {
        static void Main(string[] args)
        {
            string repetir = "0";
            do
            {
                //Inicialização das vriáveis.
                int[] arr = new int[1000];
                int count = 0;
                Array.Clear(arr, 0, 1000);
                Random r = new Random();
                pessoa p1 = new pessoa() { id = 1, posicao = r.Next(0, 999), direcao = r.Next(0, 999) < 500 };
                pessoa p2 = new pessoa() { id = 2, posicao = r.Next(0, 999), direcao = r.Next(0, 999) < 500 };
                //Antes de iniciar a busca, é informada a posição inicial de cada uma das pessoas.
                Console.WriteLine($"A pessoa 1 iniciou na posição {p1.posicao}");
                Console.WriteLine($"A pessoa 2 iniciou na posição {p2.posicao}");
                Console.WriteLine("Pressione enter para iniciar!");
                //Aguarda que qualquer tecl seja pressionda para iniciar a busca.
                Console.ReadLine();
                //Estrutura de repetição que simul o movimento das duas pessoas.
                while (p1.posicao != p2.posicao)
                {
                    AndarUmaCasa(arr, p1);
                    AndarUmaCasa(arr, p2);

                    //Informa a direção que cada uma das pessoas está se movimentando.
                    if (p1.direcao)
                        Console.WriteLine("P1 andando para a direita!");
                    else
                        Console.WriteLine("P1 andando para a esquerda!");
                    if (p2.direcao)
                        Console.WriteLine("P2 andando para a direita!");
                    else
                        Console.WriteLine("P2 andando para a esquerda!");

                    MarcarPosicao(arr, p1);
                    MarcarPosicao(arr, p2);
                    //Marca o fim de uma iteração
                    count++;
                    //Caso o número de iterações ultrapasse o limite definido, o programa é interrompido.
                    if (count > 1000000)
                    {
                        Console.WriteLine("Não foi encontrada uma resposta válida no intervalo de iterações definido!");
                        Console.WriteLine($"Foram realizadas {count} iterações!");
                        break;
                    }
                }
                //Caso a busca tenha sido bem sucedida, é apresentada a posição na qual as pessoas se encontraram.
                if (p1.posicao == p2.posicao)
                {
                    Console.WriteLine($"As pessoinhas se encontraram na posicao {p1.posicao}!");
                    Console.WriteLine($"Foram necessárias {count} iterações!");
                }
                //Controle de repetiçõe.
                Console.WriteLine("Caso deseje realizar mais uma simulação, digite 1, caso contrario, digite 0!");
                repetir = Console.ReadLine();
            } while (repetir != "0");
        }
        /// <summary>
        /// Decide qual o proximo passo a ser realisado pela pessoa e executa o próximo movimento.
        /// </summary>
        /// <param name="arr">Array que simula a linha que as pessoas percorrem</param>
        /// <param name="p">Objeto que controla os dados da pessoa</param>
        private static void AndarUmaCasa(int[] arr, pessoa p)
        {
            //Valida se  prosição atual da pessoa já está marcada com o cheiro de outro cachorro
            if (p.SentiuOCheiroDoCachorro)
            {
                //Caso o cachorro tenha sentido o cheiro de outro, continua se movendo na direção que já estava
                if (p.direcao)
                {
                    if (p.posicao + 1 < arr.Length)
                        p.posicao++;
                }
                else
                {
                    if (p.posicao - 1 > 0)
                        p.posicao--;
                }
            }
            else
            {
                //caso não tenha sentido o cheiro de outro cachorro, a pessoa deve se mover até o ultimo ponto que está marcdo com o cheiro do seu cachorro, andar mais uma casa e inverter a direção de seu movimento.
                if (p.direcao)
                {
                    if (p.posicao + 1 >= arr.Length - 1)
                    {
                        p.posicao--;
                        p.direcao = false;
                    }
                    else if (arr[p.posicao + 1] == 0)
                    {
                        p.posicao++;
                        p.direcao = false;
                    }
                    else
                        p.posicao++;
                }
                else
                {
                    if (p.posicao - 1 <= 0)
                    {
                        p.posicao++;
                        p.direcao = true;
                    }
                    else if (arr[p.posicao - 1] == 0)
                    {
                        p.posicao--;
                        p.direcao = true;
                    }
                    else
                        p.posicao--;
                }

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="p"></param>
        private static void MarcarPosicao(int[] arr, pessoa p)
        {
            if (arr[p.posicao] == 0)
                arr[p.posicao] = p.id;
            else if (arr[p.posicao] != p.id)
                p.SentiuOCheiroDoCachorro = true;
        }
        class pessoa
        {
            public int id { get; set; }
            public int posicao { get; set; }
            public bool SentiuOCheiroDoCachorro { get; set; } = false;
            public bool direcao { get; set; }
        }
    }
}
