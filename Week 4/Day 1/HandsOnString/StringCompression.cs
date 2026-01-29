using System;
using System.Text;

class StringCompression
{
    public static string CompressString(string s)
    {
        if (string.IsNullOrEmpty(s))
            return "";

        StringBuilder compressed = new StringBuilder();
        int count = 1;

        for (int i = 1; i <= s.Length; i++)
        {
            if (i < s.Length && s[i] == s[i - 1])
            {
                count++;
            }
            else
            {
                compressed.Append(s[i - 1]);
                compressed.Append(count);
                count = 1;
            }
        }

        return compressed.ToString();
    }

    static void Main()
    {
        string input = Console.ReadLine();
        string result = CompressString(input);
        Console.WriteLine(result);
    }
}
