using System;

class Program
{
    static void Main()
    {
        int X = int.Parse(Console.ReadLine());
        int Y = int.Parse(Console.ReadLine());
        int N1 = int.Parse(Console.ReadLine());
        int N2 = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());

        bool found = false;

        for (int i = N1; i >= 0; i--)
        {
            for (int j = 0; j <= N2; j++)
            {
                if (i * X + j * Y == M)
                {
                    Console.WriteLine("Valid");
                    Console.WriteLine(i);
                    Console.WriteLine(j);
                    found = true;
                    return;
                }
            }
        }

        if (!found)
            Console.WriteLine("Invalid");
    }
}
