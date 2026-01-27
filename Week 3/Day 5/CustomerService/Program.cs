using System;
using System.Collections.Generic;

namespace CustomerServiceWorkflow
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> ticketQueue = new Queue<string>();

            ticketQueue.Enqueue("Ticket 101 - Password Reset");
            ticketQueue.Enqueue("Ticket 102 - Software Installation");
            ticketQueue.Enqueue("Ticket 103 - Network Issue");

            Console.WriteLine("=== Incoming Tickets ===");
            DisplayQueue(ticketQueue);

            Stack<string> undoHistory = new Stack<string>();

            for (int i = 0; i < 3; i++)
            {
                if (ticketQueue.Count == 0) break;

                string ticket = ticketQueue.Dequeue(); 
                Console.WriteLine($"\nProcessing {ticket}...");

                string action1 = $"Checked details of {ticket}";
                string action2 = $"Updated status of {ticket}";

                Console.WriteLine($"Action: {action1}");
                Console.WriteLine($"Action: {action2}");

                undoHistory.Push(action1);
                undoHistory.Push(action2);
            }

            if (undoHistory.Count > 0)
            {
                string lastAction = undoHistory.Pop(); 
                Console.WriteLine($"\nUndoing last action: {lastAction}");
            }

            Console.WriteLine("\n=== Remaining Tickets in Queue ===");
            DisplayQueue(ticketQueue);

            Console.WriteLine("\n=== Remaining Undo History ===");
            foreach (var action in undoHistory)
            {
                Console.WriteLine(action);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void DisplayQueue(Queue<string> queue)
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("No tickets remaining.");
                return;
            }

            foreach (var ticket in queue)
            {
                Console.WriteLine(ticket);
            }
        }
    }
}
