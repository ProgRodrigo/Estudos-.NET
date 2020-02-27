using System;

namespace Tabuada
{
    class Program
    {
        static void Main(string[] args)
        {
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine("------------ Tabuada ------------");
                Console.WriteLine("Numero:");
                int numero = int.Parse(Console.ReadLine());
                Console.WriteLine("---------------------------------");
                for (int i = 0; i <= 10; i++)
                {
                    int resultado = numero * i;
                    Console.WriteLine($"{numero} x {i} = {resultado}");
                }
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Deseja gerar outra tabuada? \nDigite: 1-Sim    2-Não");
                op = int.Parse(Console.ReadLine());
            } while (op != 2);
            Console.WriteLine("---------- Obrigado ! ------------");

        }
    }
    
}
