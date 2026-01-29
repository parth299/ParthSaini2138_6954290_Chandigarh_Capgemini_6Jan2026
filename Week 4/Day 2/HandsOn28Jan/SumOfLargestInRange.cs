using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        int result = UserProgramCode.largestNumber(arr);
        Console.WriteLine(result);
    }
}

class UserProgramCode
{
    public static int largestNumber(int[] input1)
    {
        bool hasNegative = false;
        bool hasInvalid = false;

        HashSet<int> unique = new HashSet<int>();

        foreach (int num in input1)
        {
            if (num < 0)
                hasNegative = true;
            else if (num == 0 || num > 100)
                hasInvalid = true;
            else
                unique.Add(num);
        }

        if (hasNegative && hasInvalid)
            return -3;
        if (hasNegative)
            return -1;
        if (hasInvalid)
            return -2;

        int sum = 0;

        for (int start = 1; start <= 91; start += 10)
        {
            int max = -1;
            int end = start + 9;

            foreach (int num in unique)
            {
                if (num >= start && num <= end)
                {
                    if (num > max)
                        max = num;
                }
            }

            if (max != -1)
                sum += max;
        }

        return sum;
    }
}
