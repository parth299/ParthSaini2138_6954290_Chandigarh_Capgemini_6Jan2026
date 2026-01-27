// using System;

// class Program
// {
//     static void Main()
//     {
//         int n = int.Parse(Console.ReadLine());
//         string s = Console.ReadLine();

//         if (n > s.Length)
//         {
//             Console.WriteLine("Invalid");
//             return;
//         }

//         for (int i = 0; i <= s.Length - n; i++)
//         {
//             string sub = s.Substring(i, n);

//             bool validChars = true;
//             foreach (char c in sub)
//             {
//                 if (c != 'P' && c != 'S' && c != 'G')
//                 {
//                     validChars = false;
//                     break;
//                 }
//             }

//             if (!validChars) continue;

//             int count = 1;
//             for (int j = 1; j < sub.Length; j++)
//             {
//                 if (sub[j] == sub[j - 1])
//                 {
//                     count++;
//                     if (count >= n / 2)
//                     {
//                         Console.WriteLine("Yes");
//                         return;
//                     }
//                 }
//                 else
//                     count = 1;
//             }
//         }
//         Console.WriteLine("No");
//     }
// }
