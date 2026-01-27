// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         int N = int.Parse(Console.ReadLine());
//         Console.WriteLine(MinOperations(N));
//     }

//     static int MinOperations(int target)
//     {
//         Queue<int> q = new Queue<int>();
//         HashSet<int> visited = new HashSet<int>();

//         q.Enqueue(10);
//         visited.Add(10);

//         int steps = 0;

//         while (q.Count > 0)
//         {
//             int size = q.Count;
//             for (int i = 0; i < size; i++)
//             {
//                 int curr = q.Dequeue();
//                 if (curr == target)
//                     return steps;

//                 int[] next = { curr + 2, curr - 1, curr * 3 };

//                 foreach (int val in next)
//                 {
//                     if (val > 0 && val <= 100000 && !visited.Contains(val))
//                     {
//                         visited.Add(val);
//                         q.Enqueue(val);
//                     }
//                 }
//             }
//             steps++;
//         }
//         return -1;
//     }
// }
