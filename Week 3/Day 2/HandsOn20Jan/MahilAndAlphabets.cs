// using System;
// using System.Text;

// class Program
// {
//     static void Main()
//     {
//         string w1 = Console.ReadLine();
//         string w2 = Console.ReadLine();

//         string vowels = "aeiouAEIOU";
//         StringBuilder result = new StringBuilder();

//         foreach (char c in w1)
//         {
//             if (!vowels.Contains(c) &&
//                 w2.ToLower().Contains(char.ToLower(c)))
//                 continue;

//             result.Append(c);
//         }

//         StringBuilder finalResult = new StringBuilder();
//         for (int i = 0; i < result.Length; i++)
//         {
//             if (i == 0 || char.ToLower(result[i]) != char.ToLower(result[i - 1]))
//                 finalResult.Append(result[i]);
//         }

//         Console.WriteLine(finalResult.ToString());
//     }
// }
