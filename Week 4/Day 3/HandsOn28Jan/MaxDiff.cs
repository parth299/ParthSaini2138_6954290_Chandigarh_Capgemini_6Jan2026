using System;
using System.Collections.Generic;

class MaxDifference
{
    public static int diffInArray(int[] input1)
    {
        int n = input1.Length;

        if (n == 1 || n > 10)
            return -2;

        HashSet<int> set = new HashSet<int>();

        foreach (int num in input1)
        {
            if (num < 0)
                return -1;

            if (!set.Add(num))
                return -3;
        }

        int minValue = input1[0];
        int maxDiff = input1[1] - input1[0];

        for (int i = 1; i < n; i++)
        {
            maxDiff = Math.Max(maxDiff, input1[i] - minValue);
            minValue = Math.Min(minValue, input1[i]);
        }

        return maxDiff;
    }
}
