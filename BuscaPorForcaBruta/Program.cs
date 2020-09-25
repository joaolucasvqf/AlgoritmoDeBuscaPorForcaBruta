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

                int[] arr = new int[1000];
                int count = 0;
                Array.Clear(arr, 0, 1000);
                Random r = new Random();
                pessoa p1 = new pessoa() { posicao = r.Next(0, 999), direcao = r.Next(0, 999) < 500 };
                pessoa p2 = new pessoa() { posicao = r.Next(0, 999), direcao = r.Next(0, 999) < 500 };
                Console.WriteLine($"A pessoa 1 iniciou na posição {p1.posicao}");
                Console.WriteLine($"A pessoa 2 iniciou na posição {p2.posicao}");
                Console.WriteLine("Pressione enter para iniciar!");
                Console.ReadLine();

                while (p1.posicao != p2.posicao)
                {
                    if (p1.SentiuOCheiroDoCouro)
                    {
                        if (p1.direcao)
                        {
                            if (p1.posicao + 1 < arr.Length)
                                p1.posicao++;
                        }
                        else
                        {
                            if (p1.posicao - 1 > 0)
                                p1.posicao--;
                        }
                    }
                    else
                    {
                        if (p1.direcao)
                        {
                            if (p1.posicao + 1 > arr.Length - 1)
                            {
                                p1.posicao--;
                                p1.direcao = false;
                            }
                            else if (arr[p1.posicao + 1] == 0)
                            {
                                p1.direcao = false;
                                p1.posicao++;
                            }
                            else
                                p1.posicao++;
                        }
                        else
                        {
                            if (p1.posicao - 1 <= 0)
                            {
                                p1.posicao++;
                                p1.direcao = true;
                            }
                            else if (arr[p1.posicao - 1] == 0)
                            {
                                p1.direcao = true;
                                p1.posicao--;
                            }
                            else
                                p1.posicao--;
                        }

                    }
                    if (p2.SentiuOCheiroDoCouro)
                    {
                        if (p2.direcao)
                        {
                            if (p2.posicao + 1 < arr.Length)
                                p2.posicao++;
                        }
                        else
                        {
                            if (p2.posicao - 1 > 0)
                                p2.posicao--;
                        }
                    }
                    else
                    {
                        if (p2.direcao)
                        {
                            if (p2.posicao + 1 > arr.Length - 1)
                            {
                                p2.posicao--;
                                p2.direcao = false;
                            }
                            else if (arr[p2.posicao + 1] == 0)
                            {
                                p2.direcao = false;
                                p2.posicao++;
                            }
                            else
                                p2.posicao++;
                        }
                        else
                        {
                            if (p2.posicao - 1 <= 0)
                            {
                                p2.posicao++;
                                p2.direcao = true;
                            }
                            else if (arr[p2.posicao - 1] == 0)
                            {
                                p2.direcao = true;
                                p2.posicao--;
                            }
                            else
                                p2.posicao--;
                        }
                    }

                    if (p1.direcao)
                        Console.WriteLine("P1 andando para a direita!");
                    else
                        Console.WriteLine("P1 andando para a esquerda!");
                    if (p2.direcao)
                        Console.WriteLine("P2 andando para a direita!");
                    else
                        Console.WriteLine("P2 andando para a esquerda!");


                    if (arr[p1.posicao] == 0)
                        arr[p1.posicao] = 1;
                    else if (arr[p1.posicao] == 2)
                        p1.SentiuOCheiroDoCouro = true;
                    if (arr[p2.posicao] == 0)
                        arr[p2.posicao] = 2;
                    else if (arr[p2.posicao] == 1)
                        p2.SentiuOCheiroDoCouro = true;
                    count++;
                }
                Console.WriteLine($"As pessoinhas se encontraram na posicao {p1.posicao}!");
                Console.WriteLine($"Foram necessárias {count} iterações!");
                Console.WriteLine("Caso deseje realizar mais uma simulação, digite 1, caso contrario, digite 0!");
                repetir = Console.ReadLine();
            } while (repetir == "1");
        }
        class pessoa
        {
            public int posicao { get; set; }
            public bool SentiuOCheiroDoCouro { get; set; } = false;
            public bool direcao { get; set; }
        }
    }
}
